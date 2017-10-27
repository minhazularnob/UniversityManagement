using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystem.DAL;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.BLL
{
    public class CourseStudentManager
    {
        CourseStudentGateway courseStudentGateway = new CourseStudentGateway();
         public string Save(Models.CourseStudent courseStudent)
         {
             return courseStudentGateway.Save(courseStudent);
         }

        public bool IsEnrollBefore(Models.CourseStudent courseStudent)
        {
            return courseStudentGateway.IsEnrollBefore(courseStudent);
        }

        public List<Course> GetEnrolledCourseListByStudentId(int studentId)
        {
            return courseStudentGateway.GetEnrolledCourseListByStudentId(studentId);
        }

        public string UpdateResult(CourseStudent courseStudent)
        {
            return courseStudentGateway.UpdateResult(courseStudent);
        }

        public List<ViewResult> GetResultByStudentId(int studentId)
        {
            return courseStudentGateway.GetResultByStudentId(studentId);
        }
    }
}