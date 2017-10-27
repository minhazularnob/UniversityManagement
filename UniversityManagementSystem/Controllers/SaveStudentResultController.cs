using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystem.BLL;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Controllers
{
    public class SaveStudentResultController : Controller
    {
        StudentManager studentManager = new StudentManager();
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
            ViewBag.courses = courses;
            ViewBag.grades = GetGradeList();
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

            string message = courseStudentManager.UpdateResult(courseStudent);

            ViewBag.courses = courses;
            ViewBag.grades = GetGradeList();
            return View();
        }

        public List<SelectListItem> GetGradeList()
        {
            List<SelectListItem> grades = new List<SelectListItem>()
            {
                new SelectListItem {Value = "", Text = "--Select--"},
                new SelectListItem {Value = "A+", Text = "A+"},
                new SelectListItem {Value = "A", Text = "A"},
                new SelectListItem {Value = "A-", Text = "A-"},
                new SelectListItem {Value = "B+", Text = "B+"},
                new SelectListItem {Value = "B", Text = "B"},
                new SelectListItem {Value = "B-", Text = "B-"},
                new SelectListItem {Value = "C+", Text = "C+"},
                new SelectListItem {Value = "C", Text = "C"},
                new SelectListItem {Value = "C-", Text = "C-"},
                new SelectListItem {Value = "D+", Text = "D+"},
                new SelectListItem {Value = "D", Text = "D"},
                new SelectListItem {Value = "D-", Text = "D-"},
                new SelectListItem {Value = "F", Text = "F"}
            };
            return grades;
        }
        public JsonResult GetStudentById(int studentId)
        {
            return Json(studentManager.GetStudentById(studentId));
        }
        public JsonResult GetEnrolledCourseListByStudentId(int studentId)
        {
            return Json(courseStudentManager.GetEnrolledCourseListByStudentId(studentId));
        }
    }
}