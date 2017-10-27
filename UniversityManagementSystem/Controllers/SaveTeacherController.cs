using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystem.BLL;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Controllers
{
    public class SaveTeacherController : Controller
    {
        DepartmentManager departmentManager = new DepartmentManager();
        DesignationManager designationManager = new DesignationManager();
        TeacherManager teacherManager = new TeacherManager();

        [HttpGet]
        public ActionResult Index()
        {
            List<Department> departments = departmentManager.GetAll();
            ViewBag.departments = departments;
            List<Designation> designations = designationManager.GetAll();
            ViewBag.designations = designations;
            return View();
        }
        [HttpPost]
        public ActionResult Index(Teacher teacher)
        {
            List<Department> departments = departmentManager.GetAll();
            ViewBag.departments = departments;
            List<Designation> designations = designationManager.GetAll();
            ViewBag.designations = designations;

            string message = teacherManager.Save(teacher);
            ViewBag.message = message;

            ModelState.Clear();
            return View();
        }
	}
}