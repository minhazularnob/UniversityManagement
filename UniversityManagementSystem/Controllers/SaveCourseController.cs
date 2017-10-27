using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystem.BLL;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Controllers
{
    public class SaveCourseController : Controller
    {
        DepartmentManager departmentManager = new DepartmentManager();
        SemesterManager semesterManager = new SemesterManager();
        [HttpGet]
        public ActionResult Index()
        {
            List<Department> departments = departmentManager.GetAll();
            List<Semester> semesters = semesterManager.GetAll();

            ViewBag.departments = departments;
            ViewBag.semesters = semesters;
            return View();
        }
        [HttpPost]
        public ActionResult Index(Course course)
        {
            List<Department> departments = departmentManager.GetAll();
            ViewBag.departments = departments;
            List<Semester> semesters = semesterManager.GetAll();
            ViewBag.semesters = semesters;

            CourseManager courseManager = new CourseManager();
            string message = courseManager.Save(course);
            ViewBag.message = message;

            ModelState.Clear();
            return View();
        }
	}
}