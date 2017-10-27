using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.DAL
{
    public class StudentGateway:CommonGateway
    {
        public string Save(Models.Student student)
        {
            string query = "INSERT INTO Student(StudentName,Email,Contact,RegistrationDate,StudentAddress,DepartmentId,RegistrationNumber) " +
                           "VALUES('"+student.Name+"','"+student.Email+"','"+student.Contact+"','"+student.Date+"','"+student.Address+"','"+student.DepartmentId+"','"+student.RegistrationNumber+"')";

            Connection.Open();
            Command.CommandText = query;

            int rowsEffected = Command.ExecuteNonQuery();
            Connection.Close();

            return "Student Added Successfully";
        }

        public bool IsEmailExists(Models.Student student)
        {
            string query = "SELECT * FROM Student WHERE Email='" + student.Email + "'";

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

        public List<Models.Student> GetAll()
        {
            string query = "SELECT * FROM Student ORDER BY RegistrationNumber";

            Connection.Open();
            Command.CommandText = query;

            SqlDataReader reader = Command.ExecuteReader();
            List<Student> students = new List<Student>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Student student = new Student();

                    student.StudentId = (int)reader["StudentId"];
                    student.Name = reader["StudentName"].ToString();
                    student.Email = reader["Email"].ToString();
                    student.Contact = reader["Contact"].ToString();
                    student.Date = (DateTime)reader["RegistrationDate"];
                    student.Address = reader["StudentAddress"].ToString();
                    student.DepartmentId = (int)reader["DepartmentId"];
                    student.RegistrationNumber = reader["RegistrationNumber"].ToString();

                    students.Add(student);
                } 
            }
            reader.Close();
            Connection.Close();

            return students;
        }

        public Student GetStudentById(int studentId)
        {
            string query = "SELECT * , Department.Name as DepartmentName " +
                           "FROM Student " +
                           "LEFT JOIN Department " +
                           "ON Student.DepartmentId=Department.Id WHERE Student.StudentId='"+studentId+"'";

            Connection.Open();
            Command.CommandText = query;

            SqlDataReader reader = Command.ExecuteReader();
            Student student = null;
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    student = new Student();

                    student.StudentId = (int)reader["StudentId"];
                    student.Name = reader["StudentName"].ToString();
                    student.Email = reader["Email"].ToString();
                    student.Contact = reader["Contact"].ToString();
                    student.Date = (DateTime)reader["RegistrationDate"];
                    student.Address = reader["DepartmentName"].ToString();
                    student.DepartmentId = (int)reader["DepartmentId"];
                    student.RegistrationNumber = reader["RegistrationNumber"].ToString();

                }
            }
            reader.Close();
            Connection.Close();

            return student;
        }
    }
}