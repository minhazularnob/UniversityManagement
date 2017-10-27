using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystem.BLL;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Controllers
{
    public class SaveDepartmentController : Controller
    {
        DepartmentManager departmentManager = new DepartmentManager();
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Department department)
        {
            string message = departmentManager.Save(department);
            ViewBag.message = message;
            ModelState.Clear();
            return View();
        }
	}
}