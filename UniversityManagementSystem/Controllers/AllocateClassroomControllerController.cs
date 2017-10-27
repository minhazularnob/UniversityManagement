using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystem.BLL;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Controllers
{
    public class AllocateClassroomController : Controller
    {
        private DepartmentManager _departmentManager = new DepartmentManager();
        private RoomManager _roomManager = new RoomManager();
        private CourseManager _courseManager = new CourseManager();

        private AllocateClassroomManager _allocateClassroomManager = new AllocateClassroomManager();
        // GET: AllocateClassroom
        [HttpGet]
        public ActionResult Index()
        {
            PopulateDepartmentList();
            PopulateDefaultCourseList();
            PopulateRoom();
            ViewBag.Days = Day();

            return View();
        }

        [HttpPost]

        public ActionResult Index(AllocateRoom allocateRoom)
        {
            PopulateDepartmentList();
            PopulateDefaultCourseList();
            PopulateRoom();
            ViewBag.Days = Day();

            if (ModelState.IsValid)
            {
                bool check = false;
                if (allocateRoom.FromFormat == allocateRoom.ToFormat)
                {
                    if (allocateRoom.FromHour > allocateRoom.ToHour)
                    {
                        check = true;
                    }
                }
                if (!check)
                {

                    AllocateRoom room = _allocateClassroomManager.Save(allocateRoom);

                    if (room == null)
                    {
                        ViewBag.Message = "Scheduled Successfully";
                        ModelState.Clear();
                    }
                    else
                    {

                        ViewBag.Message = "classroom overlapes by " + _courseManager.GetCourseById(room.CourseId).Code;
                    }
                }
                else
                {
                    ViewBag.Message = "Please enter valid class time";

                }
            }

            return View();
        }

        public JsonResult GetCourseByDepartmentId(int departmentId)
        {
            var courseList = _courseManager.GetCourseListByDepartmentId(departmentId);

            return Json(courseList);
        }

        private void PopulateRoom()
        {
            List<Room> getRooms = _roomManager.GetAllRooms();
            List<SelectListItem> roomList = new List<SelectListItem>();
            roomList.Add(new SelectListItem()
            {
                Value = "",
                Text = "Select..."
            });
            foreach (Room room in getRooms)
            {
                SelectListItem item = new SelectListItem
                {
                    Value = room.Id.ToString(),
                    Text = room.RoomNo
                };
                roomList.Add(item);

            }
            ViewBag.Rooms = roomList;
        }

        private void PopulateDepartmentList()
        {
            List<Department> getDepartments = _departmentManager.GetAll();

            List<SelectListItem> departmentList = new List<SelectListItem>();
            departmentList.Add(new SelectListItem()
            {
                Value = "",
                Text = "Select..."
            });

            foreach (Department department in getDepartments)
            {
                SelectListItem item = new SelectListItem
                {
                    Value = department.Id.ToString(),
                    Text = department.Name
                };
                departmentList.Add(item);
            }

            ViewBag.Departments = departmentList;
        }

        private void PopulateDefaultCourseList()
        {

            List<SelectListItem> courseList = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Value = "",
                    Text = "Select.."
                }
            };

            ViewBag.Courses = courseList;

        }



        private List<SelectListItem> Day()
        {
            List<SelectListItem> days = new List<SelectListItem>
            {
                 new SelectListItem{Value = "",Text = "Selct.."},
                new SelectListItem {Value = "Sat",Text = "Saturday"},
                new SelectListItem {Value = "Sun",Text = "Sunday"},
                new SelectListItem {Value = "Mon",Text = "Monday"},
                new SelectListItem {Value = "Tue",Text = "Tuesday"},
                new SelectListItem {Value = "Wed",Text = "Wednesday"},
                new SelectListItem {Value = "Thu",Text = "Thursday"},
                new SelectListItem {Value = "Fri",Text = "Friday"},

            };

            return days;
        }
    }
}