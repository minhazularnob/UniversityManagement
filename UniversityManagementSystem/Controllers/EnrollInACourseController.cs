using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystem.BLL;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Controllers
{
    public class EnrollInACourseController : Controller
    {
        StudentManager studentManager = new StudentManager();
        CourseManager courseManager = new CourseManager();
        DepartmentManager departmentManager = new DepartmentManager();
        CourseStudentManager courseStudentManager = new CourseStudentManager();

        [HttpGet]
        public ActionResult Index()
        {
            List<Student> students = studentManager.GetAll();
            ViewBag.students = students;
            List<Course> courses = new List<Course>
            {
                new Course{Id = ' ' ,Code = "--Select--",CourseName = "",Credit = ' '}
            };
            ViewBag.Courses = courses;
            return View();
        }

        [HttpPost]
        public ActionResult Index(CourseStudent courseStudent)
        {
            List<Student> students = studentManager.GetAll();
            ViewBag.students = students;
            List<Course> courses = new List<Course>
            {
                new Course{Id = ' ' ,Code = "--Select--",CourseName = "",Credit = ' '}
            };
            string message = "";
            if (!courseStudentManager.IsEnrollBefore(courseStudent))
            {
                message = courseStudentManager.Save(courseStudent);
            }
            else
            {
                message = "Sorry, This Student Already Enrolled This Course";
            }


            ViewBag.message = message;
            ViewBag.Courses = courses;
            ModelState.Clear();
            return View();
        }
        public JsonResult GetStudentById(int studentId)
        {
            return Json(studentManager.GetStudentById(studentId));
        }
        public JsonResult GetCourseListByDepartmentId(int studentId)
        {
            int departmentId = departmentManager.GetDepartmentIdByStudentId(studentId);
            return Json(courseManager.GetCourseListByDepartmentId(departmentId));
        }
	}
}