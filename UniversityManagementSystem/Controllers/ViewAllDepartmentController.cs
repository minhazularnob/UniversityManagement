using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystem.BLL;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Controllers
{
    public class ViewAllDepartmentController : Controller
    {
        public ActionResult Index()
        {
            DepartmentManager departmentManager = new DepartmentManager();
            List<Department> departments = departmentManager.GetAll();
            ViewBag.departments = departments;
            return View();
        }
	}
}