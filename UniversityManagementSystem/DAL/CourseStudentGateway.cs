using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.DAL
{
    public class CourseStudentGateway:CommonGateway
    {
        public string Save(Models.CourseStudent courseStudent)
        {
            string query = "INSERT INTO CourseStudent(StudentId,CourseId,CourseStudentDate,Grade) VALUES ('" +
                           courseStudent.StudentId + "','" + courseStudent.CourseId + "','" + courseStudent.Date + "','')";
            Connection.Open();
            Command.CommandText = query;
            int rowsEffected = Command.ExecuteNonQuery();
            Connection.Close();
            return "Student has been Added to this course";
        }

        public bool IsEnrollBefore(Models.CourseStudent courseStudent)
        {
            string query = "SELECT * FROM CourseStudent WHERE StudentId='"+courseStudent.StudentId+"' AND CourseId='"+courseStudent.CourseId+"'";

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

        public List<Models.Course> GetEnrolledCourseListByStudentId(int studentId)
        {
            string query ="SELECT CourseStudent.CourseId, Course.CourseName, CourseStudent.Grade " +
                          "FROM CourseStudent " +
                          "LEFT JOIN Course " +
                          "ON CourseStudent.CourseId=Course.Id WHERE CourseStudent.StudentId='"+studentId+"'";

            Connection.Open();
            Command.CommandText = query;

            SqlDataReader reader = Command.ExecuteReader();
            List<Course> courses = new List<Course>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Course course = new Course();

                    course.Id = (int)reader["CourseId"];
                    course.CourseName = reader["CourseName"].ToString();
                    course.Description = reader["Grade"].ToString();
                    courses.Add(course);
                }
            }
            reader.Close();
            Connection.Close();
            return courses;
        }

        public string UpdateResult(CourseStudent courseStudent)
        {
            string query = "UPDATE CourseStudent SET Grade = '"+courseStudent.Grade+"' WHERE StudentId='"+courseStudent.StudentId+"' AND CourseId='"+courseStudent.CourseId+"'";
            Connection.Open();
            Command.CommandText = query;
            int rowsEffected = Command.ExecuteNonQuery();
            Connection.Close();
            return "Grade has been Updated";
        }

        public List<ViewResult> GetResultByStudentId(int studentId)
        {
            string query = "SELECT Course.Code, Course.CourseName, CourseStudent.Grade " +
                           "FROM CourseStudent " +
                           "LEFT JOIN Course " +
                           "ON CourseStudent.CourseId=Course.Id WHERE CourseStudent.StudentId='"+studentId+"'";

            Connection.Open();
            Command.CommandText = query;

            SqlDataReader reader = Command.ExecuteReader();
            List<ViewResult> viewResults = new List<ViewResult>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    ViewResult viewResult = new ViewResult();

                    //viewResult.Id = (int)reader["CourseId"];
                    viewResult.Code = reader["Code"].ToString();
                    viewResult.Name = reader["CourseName"].ToString();
                    viewResult.Grade = reader["Grade"].ToString();
                    viewResults.Add(viewResult);
                }
            }
            reader.Close();
            Connection.Close();
            return viewResults;
        }
    }
}