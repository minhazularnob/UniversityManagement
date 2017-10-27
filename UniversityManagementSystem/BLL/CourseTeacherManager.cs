using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystem.DAL;

namespace UniversityManagementSystem.BLL
{
    public class CourseTeacherManager
    {
        CourseTeacherGateway courseTeacherGateway = new CourseTeacherGateway();
        public bool Save(Models.CourseTeacher courseTeacher)
        {
            return courseTeacherGateway.Save(courseTeacher);
        }
    }
}