using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.DAL
{
    public class DepartmentGateway:CommonGateway
    {
        public string Save(Department department)
        {
            string query = "INSERT INTO Department(Name,Code) VALUES('"+department.Name+"','"+department.Code+"')";
            Connection.Open();
            Command.CommandText = query;
            int rowsEffected = Command.ExecuteNonQuery();
            Connection.Close();
            return "Save Successfully";
        }

        public List<Models.Department> GetAll()
        {
            string query = "  SELECT * FROM Department ORDER BY Name";

            Connection.Open();
            Command.CommandText = query;

            SqlDataReader reader = Command.ExecuteReader();
            List<Department> departments = new List<Department>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Department department = new Department();

                    department.Id = (int)reader["Id"];
                    department.Name = reader["Name"].ToString();
                    department.Code = reader["Code"].ToString();
                    departments.Add(department);
                }
            }
            reader.Close();
            Connection.Close();

            return departments;
        }

        public string GetDepartmentNameById(int S_Id)
        {
            string query = "SELECT Name FROM Department WHERE Id = '" + S_Id + "'";
            Connection.Open();
            Command.CommandText = query;
            string dept_Name = "";
            SqlDataReader reader = Command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    dept_Name = reader["Name"].ToString();
                }
            }
            reader.Close();
            Connection.Close();

            return dept_Name;

        }

        public bool IsCodeExists(Department department)
        {
            string query = "SELECT * FROM Department WHERE Code='"+department.Code+"'";

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

        public bool IsNameExists(Department department)
        {
            string query = "SELECT * FROM Department WHERE Name='" + department.Name + "'";

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

        public int GetDepartmentIdByStudentId(int studentId)
        {
            string query = "SELECT DepartmentId FROM Student WHERE StudentId='" + studentId + "'";

            Connection.Open();
            Command.CommandText = query;

            SqlDataReader reader = Command.ExecuteReader();
            int departmentId = 0;
            if (reader.HasRows)
            {
                reader.Read();
                departmentId = (int) reader["DepartmentId"];
                reader.Close();
                Connection.Close();
                return departmentId;
            }
            reader.Close();
            Connection.Close();
            return departmentId;
        }
    }
}