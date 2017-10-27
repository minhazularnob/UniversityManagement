using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityManagementSystem.DAL
{
    public class CourseTeacherGateway:CommonGateway
    {
        public bool Save(Models.CourseTeacher courseTeacher)
        {
            string query = "INSERT INTO CourseTeacher(DepartmentId,TeacherId,CourseId) VALUES ('"+courseTeacher.DepartmentId+"','"+courseTeacher.TeacherId+"','"+courseTeacher.CourseId+"')";

            Connection.Open();
            Command.CommandText = query;

            int rowsEffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowsEffected > 0;
        }
    }
}