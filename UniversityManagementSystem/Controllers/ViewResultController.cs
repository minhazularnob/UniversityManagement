using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystem.BLL;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Controllers
{
    public class ViewResultController : Controller
    {
        StudentManager studentManager = new StudentManager();
        CourseStudentManager courseStudentManager =new CourseStudentManager();
        public ActionResult Index()
        {
            List<Student> students = studentManager.GetAll();
            ViewBag.students = students;
            return View();
        }
        public JsonResult GetStudentById(int studentId)
        {
            return Json(studentManager.GetStudentById(studentId));
        }
        public JsonResult GetResultByStudentId(int studentId)
        {
            return Json(courseStudentManager.GetResultByStudentId(studentId));
        }
	}
}