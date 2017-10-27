using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using UniversityManagementSystem.BLL;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Controllers
{
    public class ViewClassScheduleController : Controller
    {
        private DepartmentManager _departmentManager = new DepartmentManager();
        private ViewClassScheduleManager _viewClassScheduleManager = new ViewClassScheduleManager();

        // GET: ViewClassSchedule
        public ActionResult Index()
        {
            PopulateDropDownList();
            return View();
        }

        public JsonResult GetScheduledRoomByDepartmentId(int departmentId)
        {
            List<ViewClassSchedule> viewClassSchedules = _viewClassScheduleManager.GetClassSchedules(departmentId);
            List<ViewClassSchedule> tempData = new List<ViewClassSchedule>();

            tempData = viewClassSchedules.DistinctBy(x => x.CourseCode).ToList();
            List<FinalData> finalData = new List<FinalData>();
            string info = "", courseName = "", courseCode = "";
            foreach (var data in tempData)
            {

                var tData = from a in viewClassSchedules
                            where a.CourseCode.Contains(data.CourseCode)
                            select a;
                int t = 1;

                foreach (var fData in tData)
                {
                    if (fData.Assign == "assigned")
                    {
                        int m = tData.Count();
                        courseCode = fData.CourseCode;
                        courseName = fData.CourseName;
                        if (t != tData.Count())
                        {
                            info = info + "R.no: " + fData.RoomNo + ", " + fData.Day + "," + fData.FromHour + ":" +
                                   fData.FromMin + fData.FromFormat + "-"
                                   + fData.ToHour + ":" + fData.ToMin + fData.ToFormat + ";" + "<br />";
                        }
                        else
                        {
                            info = info + "R.no: " + fData.RoomNo + ", " + fData.Day + "," + fData.FromHour + ":" +
                                   fData.FromMin + fData.FromFormat + "-"
                                   + fData.ToHour + ":" + fData.ToMin + fData.ToFormat;
                        }
                    }
                    else if (fData.Day == null && (fData.Assign == "unassigned" || fData.Assign == null))
                    {
                        courseCode = fData.CourseCode;
                        courseName = fData.CourseName;
                        info = null;
                    }
                    else
                    {
                        courseCode = fData.CourseCode;
                        courseName = fData.CourseName;

                    }
                    t++;
                }
                FinalData final = new FinalData()
                {
                    CourseCode = courseCode,
                    CourseName = courseName,
                    Info = info
                };
                finalData.Add(final);
                info = "";

            }


            return Json(finalData);
        }

        private void PopulateDropDownList()
        {
            List<Department> departments = _departmentManager.GetAll();

            ViewBag.Departments = departments;

        }
    }
}