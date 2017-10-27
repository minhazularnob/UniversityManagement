using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystem.BLL;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Controllers
{
    public class UnassignAllClassRoomsController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UnassignAllClassRooms()
        {
            AllocateClassroomManager allocateClassroomManager = new AllocateClassroomManager();
            string message = allocateClassroomManager.UnallocateAllClassRoom();
            ViewBag.message = message;
            return View();

        }
	}
}