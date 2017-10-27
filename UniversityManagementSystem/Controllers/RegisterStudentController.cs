using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystem.BLL;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Controllers
{
    public class RegisterStudentController : Controller
    {
        DepartmentManager departmentManager = new DepartmentManager();
        StudentManager studentManager = new StudentManager();

        [HttpGet]
        public ActionResult Index()
        {
            List<Department> departments = departmentManager.GetAll();
            string dateTime = DateTime.Today.Day + "-" + DateTime.Today.Month + "-" + DateTime.Today.Year;
            ViewBag.Departments = departments;

            ViewBag.dateTime = dateTime;
            return View();
        }
        [HttpPost]
        public ActionResult Index(Student student)
        {
            List<Department> departments = departmentManager.GetAll();
            ViewBag.Departments = departments;
            string dateTime = DateTime.Today.Day + "-" + DateTime.Today.Month + "-" + DateTime.Today.Year;
            ViewBag.dateTime = dateTime;
            string message = "";
            if (!studentManager.IsEmailExists(student))
            {
                message = studentManager.Save(student);
            }
            else
            {
                message = "Student Already Exists";
            }
            ViewBag.message = message;
            ModelState.Clear();
            return View();
        }        
	}
}