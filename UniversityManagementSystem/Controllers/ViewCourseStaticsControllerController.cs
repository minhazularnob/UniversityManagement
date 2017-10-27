using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystem.BLL;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Controllers
{
    public class ViewCourseStaticsControllerController : Controller
    {
        DepartmentManager departmentManager = new DepartmentManager();
        CourseManager courseManager = new CourseManager();

        [HttpGet]
        public ActionResult Index()
        {
            List<Department> departments = departmentManager.GetAll();
            ViewBag.departments = departments;
            List<Course> courses = courseManager.GetAllWithTeacherName();
            ViewBag.courses = courses;
            return View();
        }

        [HttpPost]
        public ActionResult Index(int Department)
        {
            List<Department> departments = departmentManager.GetAll();
            ViewBag.departments = departments;
            List<Course> courses = courseManager.GetAllCourseListByDepartmentIdWithTeacherName(Department);
            ViewBag.courses = courses;

            return View();
        }

	}
}