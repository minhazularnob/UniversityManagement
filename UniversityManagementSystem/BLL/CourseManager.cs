using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystem.DAL;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.BLL
{
    public class CourseManager
    {
        CourseGateway courseGateway = new CourseGateway();
        public string Save(Course course)
        {
            if (IsCodeExists(course))
            {
                return "Course Code Already Exists";
            }
            if (IsNameExists(course))
            {
                return "Course Name Already Exists";
            }
            return courseGateway.Save(course);
        }

        private bool IsCodeExists(Course course)
        {
            return courseGateway.IsCodeExists(course);
        }
        private bool IsNameExists(Course course)
        {
            return courseGateway.IsNameExists(course);
        }        
        public List<Course> GetAll()
        {
            return courseGateway.GetAll();
        }

        public List<Course> GetCourseListByDepartmentId(int departmentId)
        {
            return courseGateway.GetCourseListByDepartmentId(departmentId);
        }

        public Course GetCourseById(int courseId)
        {
            return courseGateway.GetCourseById(courseId);
        }

        public int GetTeacherIdByCourseId(int p)
        {
            return courseGateway.GetTeacherIdByCourseId(p);
        }

        public List<Course> GetAllWithTeacherName()
        {
            return courseGateway.GetAllWithTeacherName();
        }

        public List<Course> GetAllCourseListByDepartmentIdWithTeacherName(int department)
        {
            return courseGateway.GetAllCourseListByDepartmentIdWithTeacherName(department);
        }



        public bool MakeCourseAssinged(CourseTeacher courseTeacher)
        {
            return courseGateway.MakeCourseAssinged(courseTeacher);
        }

        public string UnassignedAllCourses()
        {
            return courseGateway.UnassignedAllCourses();
        }
    }
}