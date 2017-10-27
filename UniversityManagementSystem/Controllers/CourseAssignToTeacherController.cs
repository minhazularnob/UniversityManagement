using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystem.BLL;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Controllers
{
    public class CourseAssignToTeacherController : Controller
    {
        DepartmentManager departmentManager = new DepartmentManager();
        TeacherManager teacherManager = new TeacherManager();
        CourseManager courseManager = new CourseManager();
        CourseTeacherManager courseTeacherManager = new CourseTeacherManager();


        [HttpGet]
        public ActionResult Index()
        {
            List<Department> departments = departmentManager.GetAll();
            ViewBag.Departments = departments;

            List<Teacher> teachers = new List<Teacher>
            {
                new Teacher{Id = ' ' ,Name = "--Select--"}
            };
            ViewBag.Teachers = teachers;

            List<Course> courses = new List<Course>
            {
                new Course{Id = ' ' ,Code = "--Select--",CourseName = "",Credit = ' '}
            };
            ViewBag.Courses = courses;



            return View();
        }
        [HttpPost]
        public ActionResult Index(CourseTeacher courseTeacher, int CourseCredit)
        {
            
            List<Department> departments = departmentManager.GetAll();
            ViewBag.Departments = departments;

            List<Teacher> teachers = new List<Teacher>
            {
                new Teacher{Id = ' ' ,Name = "--Select--"}
            };
            ViewBag.Teachers = teachers;

            List<Course> courses = new List<Course>
            {
                new Course{Id = ' ' ,Code = "--Select--"}
            };
            ViewBag.Courses = courses;
            

            string message = "";
            int teacherId = courseManager.GetTeacherIdByCourseId(courseTeacher.CourseId);
            if (teacherId == 0)
            {
                bool isSave = courseTeacherManager.Save(courseTeacher);
                bool addCreditToTeacher = teacherManager.AddCreditToTeacherById(courseTeacher.TeacherId, CourseCredit);
                bool makeCourseAssinged = courseManager.MakeCourseAssinged(courseTeacher);
                Teacher tempTeacher = new Teacher();
                tempTeacher = teacherManager.GetTeacherById(courseTeacher.TeacherId);
                message = " Save Successful. Course has been assigned to " + tempTeacher.Name;
            }
            else
            {
                Teacher tempTeacher = new Teacher();
                tempTeacher = teacherManager.GetTeacherById(teacherId);
                message = "Sorry, this Course is already Assinged to Mr." + tempTeacher.Name + " and you can contact with him by Email: " + tempTeacher.Email;
            }


            ViewBag.message = message;
            ModelState.Clear();
            return View();
        }

        public JsonResult GetTeacherListByDepartmentId(int departmentId)
        {
            return Json(teacherManager.GetTeacherListByDepartmentId(departmentId));
        }
        public JsonResult GetTeacherById(int teacherId)
        {
            return Json(teacherManager.GetTeacherById(teacherId));
        }
        public JsonResult GetCourseListByDepartmentId(int departmentId)
        {
            return Json(courseManager.GetCourseListByDepartmentId(departmentId));
        }
        public JsonResult GetCourseById(int courseId)
        {
            return Json(courseManager.GetCourseById(courseId));
        }
        

	}
}