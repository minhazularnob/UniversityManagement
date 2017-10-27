using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystem.BLL;

namespace UniversityManagementSystem.Controllers
{
    public class UnassignAllCoursesController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UnassignCourses()
        {
            CourseManager courseManager = new CourseManager();
            string message = courseManager.UnassignedAllCourses();
            ViewBag.message = message;
            return View();
        }
	}
}