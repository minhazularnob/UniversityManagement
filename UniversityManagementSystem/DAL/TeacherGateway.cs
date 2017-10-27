using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.DAL
{
    public class TeacherGateway : CommonGateway
    {
        public string Save(Models.Teacher teacher)
        {
            string query =
                "INSERT INTO Teacher(Name,TeacherAddress,Email,ContactNo,DesignationId,DepartmentId,CreditToBeTaken,TakenCredit) VALUES ('" +
                teacher.Name + "','" + teacher.Address + "','" + teacher.Email + "','" + teacher.ContactNo + "','" +
                teacher.DesignationId + "','" + teacher.DepartmentId + "','" + teacher.CreditToBeTaken + "','0.00')";
            Connection.Open();
            Command.CommandText = query;
            int rowsEffected = Command.ExecuteNonQuery();
            Connection.Close();
            return "Teacher Saved Successfully";
        }

        public List<Models.Teacher> GetAll()
        {
            string query = "SELECT * FROM Teacher ORDER BY Name";

            Connection.Open();
            Command.CommandText = query;

            SqlDataReader reader = Command.ExecuteReader();
            List<Teacher> teachers = new List<Teacher>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Teacher teacher = new Teacher();

                    teacher.Id = (int) reader["Id"];
                    teacher.Name = reader["Name"].ToString();
                    teacher.Address = reader["TeacherAddress"].ToString();
                    teacher.Email = reader["Email"].ToString();
                    teacher.ContactNo = reader["ContactNo"].ToString();
                    teacher.DesignationId = (int) reader["DesignationId"];
                    teacher.DepartmentId = (int) reader["DepartmentId"];
                    teacher.CreditToBeTaken = (double) reader["CreditToBeTaken"];
                    teacher.TakenCredit = (double) reader["TakenCredit"];

                    teachers.Add(teacher);
                }
            }
            reader.Close();
            Connection.Close();

            return teachers;
        }

        public List<Teacher> GetTeacherListByDepartmentId(int departmentId)
        {
            string query = "  SELECT * FROM Teacher WHERE DepartmentId='" + departmentId + "' ORDER BY Name";

            Connection.Open();
            Command.CommandText = query;

            SqlDataReader reader = Command.ExecuteReader();
            List<Teacher> teachers = new List<Teacher>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Teacher teacher = new Teacher();

                    teacher.Id = (int) reader["Id"];
                    teacher.Name = reader["Name"].ToString();
                    teacher.Address = reader["TeacherAddress"].ToString();
                    teacher.Email = reader["Email"].ToString();
                    teacher.ContactNo = reader["ContactNo"].ToString();
                    teacher.DesignationId = (int) reader["DesignationId"];
                    teacher.DepartmentId = (int) reader["DepartmentId"];
                    teacher.CreditToBeTaken = (double) reader["CreditToBeTaken"];
                    teacher.TakenCredit = (double) reader["TakenCredit"];

                    teachers.Add(teacher);
                }
            }
            reader.Close();
            Connection.Close();

            return teachers;
        }

        public bool IsEmailExists(Teacher teacher)
        {
            string query = "SELECT * FROM Teacher WHERE Email='"+teacher.Email+"'";

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

        public Teacher GetTeacherById(int teacherId)
        {
            string query = "SELECT * FROM Teacher WHERE Id='"+teacherId+"'";

            Connection.Open();
            Command.CommandText = query;

            SqlDataReader reader = Command.ExecuteReader();
            Teacher teacher = new Teacher();
            if (reader.HasRows)
            {
                reader.Read();
                teacher.Id = (int)reader["Id"];
                teacher.Name = reader["Name"].ToString();
                teacher.Address = reader["TeacherAddress"].ToString();
                teacher.Email = reader["Email"].ToString();
                teacher.ContactNo = reader["ContactNo"].ToString();
                teacher.DesignationId = (int)reader["DesignationId"];
                teacher.DepartmentId = (int)reader["DepartmentId"];
                teacher.CreditToBeTaken = (double)reader["CreditToBeTaken"];
                teacher.TakenCredit = (double)reader["TakenCredit"];                                    
            }
            reader.Close();
            Connection.Close();
            return teacher;
        }

        public bool AddCreditToTeacherById(int t, int c)
        {
            string query = "UPDATE Teacher SET TakenCredit = TakenCredit + '" + c + "' WHERE Id = '" + t + "'";
                
            Connection.Open();
            Command.CommandText = query;
            int rowsEffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowsEffected > 0;
        }
    }
}
