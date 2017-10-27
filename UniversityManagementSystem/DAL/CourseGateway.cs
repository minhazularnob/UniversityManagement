using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.DAL
{
    public class CourseGateway:CommonGateway
    {
        public string Save(Course course)
        {
            string query = "INSERT INTO Course(CourseName, Credit,CourseDescription,DepartmentId,SemesterId,Code,TeacherId) VALUES ('" + course.CourseName + "','" + course.Credit + "','" + course.Description + "','" + course.DepartmentId + "','" + course.SemesterId + "','" + course.Code + "','0')";

            Connection.Open();
            Command.CommandText = query;

            int rowsEffected = Command.ExecuteNonQuery();
            Connection.Close();
            return "Course Saved Successfully";
        }

        public List<Course> GetAll()
        {
            string query = "SELECT * FROM Course ORDER BY CourseName";

            Connection.Open();
            Command.CommandText = query;

            SqlDataReader reader = Command.ExecuteReader();
            List<Course> courses = new List<Course>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Course course = new Course();

                    course.Id = (int)reader["Id"];
                    course.CourseName = reader["CourseName"].ToString();
                    course.Credit = (double) reader["Credit"];
                    course.Description = reader["CourseDescription"].ToString();
                    course.DepartmentId = (int) reader["DepartmentId"];
                    course.SemesterId = (int) reader["SemesterId"];
                    course.Code = reader["Code"].ToString();
                    course.TeacherId = (int)reader["TeacherId"];                  
                    courses.Add(course);
                }
            }
            reader.Close();
            Connection.Close();
            return courses;
        }
       
        public bool IsCodeExists(Course course)
        {

            string query = "SELECT * FROM Course WHERE Code='"+course.Code+"'";

            Connection.Open();
            Command.CommandText = query;

            SqlDataReader reader = Command.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Close();
                Connection.Close();
                return true;
            }
            reader.Close();
            Connection.Close();
            return false;

        }
        public bool IsNameExists(Course course)
        {
            string query = "SELECT * FROM Course WHERE CourseName='"+course.CourseName+"'";

            Connection.Open();
            Command.CommandText = query;

            SqlDataReader reader = Command.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Close();
                Connection.Close();
                return true;
            }
            reader.Close();
            Connection.Close();
            return false;
        }

        public List<Course> GetCourseListByDepartmentId(int departmentId)
        {
            string query = "SELECT * FROM Course WHERE DepartmentId = '"+departmentId+"' ORDER BY CourseName";

            Connection.Open();
            Command.CommandText = query;

            SqlDataReader reader = Command.ExecuteReader();
            List<Course> courses = new List<Course>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Course course = new Course();
                    course.Id = (int)reader["Id"];
                    course.CourseName = reader["CourseName"].ToString();
                    course.Credit = (double)reader["Credit"];
                    course.Description = reader["CourseDescription"].ToString();
                    course.DepartmentId = (int)reader["DepartmentId"];
                    course.SemesterId = (int)reader["SemesterId"];
                    course.Code = reader["Code"].ToString();
                    course.TeacherId = (int)reader["TeacherId"];                  
                    courses.Add(course);
                }
            }
            reader.Close();
            Connection.Close();
            return courses;
        }

        public Course GetCourseById(int courseId)
        {
            string query = "SELECT * FROM Course WHERE Id = '"+courseId+"'";

            Connection.Open();
            Command.CommandText = query;

            SqlDataReader reader = Command.ExecuteReader();
            Course course = new Course();
            if (reader.HasRows)
            {
                reader.Read();
                course.Id = (int)reader["Id"];
                course.CourseName = reader["CourseName"].ToString();
                course.Credit = (double)reader["Credit"];
                course.Description = reader["CourseDescription"].ToString();
                course.DepartmentId = (int)reader["DepartmentId"];
                course.SemesterId = (int)reader["SemesterId"];
                course.Code = reader["Code"].ToString();
                course.TeacherId = (int)reader["TeacherId"];                  
            }
            reader.Close();
            Connection.Close();
            return course;
        }

        public int GetTeacherIdByCourseId(int p)
        {
            string query = "SELECT TeacherId FROM Course WHERE Id='"+p+"'";

            Connection.Open();
            Command.CommandText = query;

            SqlDataReader reader = Command.ExecuteReader();
            int teacherId = 100;
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    teacherId = (int)reader["TeacherId"];
                }
                
                
            }
            reader.Close();
            Connection.Close();
            return teacherId;
        }

        public List<Course> GetAllWithTeacherName()
        {
            string query = "SELECT Course.Id, Course.TeacherId, Course.Code, Course.CourseName, Course.SemesterId, Course.Credit, Teacher.Name " +
                           "FROM Course " +
                           "LEFT JOIN Teacher " +
                           "ON Course.TeacherId=Teacher.Id";

            Connection.Open();
            Command.CommandText = query;

            SqlDataReader reader = Command.ExecuteReader();
            List<Course> courses = new List<Course>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Course course = new Course();

                    course.Id = (int)reader["Id"];
                    course.CourseName = reader["CourseName"].ToString();
                    course.Credit = (double)reader["Credit"];                    
                    course.SemesterId = (int)reader["SemesterId"];
                    course.Code = reader["Code"].ToString();
                    course.Description = reader["Name"].ToString();
                    if ((int) reader["TeacherId"] == 0)
                    {
                        course.Description = "Not Assinged Yet";
                    }
                    courses.Add(course);
                }
            }
            reader.Close();
            Connection.Close();
            return courses;
        }

        public List<Course> GetAllCourseListByDepartmentIdWithTeacherName(int department)
        {
            string query =
                "Select c.Id, c.CourseName, c.Credit,c.DepartmentId,c.SemesterId,c.Code,t.Id ,ISNULL(t.Name, '(Not Assinged Yet)')as TeacherName " +
                "from Course c " +
                "left join Teacher t on c.TeacherId=t.Id where c.DepartmentId='"+department+"'";

            Connection.Open();
            Command.CommandText = query;

            SqlDataReader reader = Command.ExecuteReader();
            List<Course> courses = new List<Course>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Course course = new Course();

                    course.Id = (int)reader["Id"];
                    course.CourseName = reader["CourseName"].ToString();
                    course.Credit = (double)reader["Credit"];
                    course.SemesterId = (int)reader["SemesterId"];
                    course.Code = reader["Code"].ToString();
                    course.Description = reader["TeacherName"].ToString();
                    courses.Add(course);
                }
            }
            reader.Close();
            Connection.Close();
            return courses;
        }

        public bool MakeCourseAssinged(CourseTeacher courseTeacher)
        {
            string query = "Update Course SET TeacherId = '" + courseTeacher.TeacherId + "' WHERE Id='" +
                           courseTeacher.CourseId + "'";

            Connection.Open();
            Command.CommandText = query;

            int rowsEffected = Command.ExecuteNonQuery();
            Connection.Close();
            return true;
        }

        public string UnassignedAllCourses()
        {
            string query = "Update Course SET TeacherId = '0'";                           

            Connection.Open();
            Command.CommandText = query;

            int rowsEffected = Command.ExecuteNonQuery();
            Connection.Close();
            return "All Course Already Unassinged";
        }
    }
}