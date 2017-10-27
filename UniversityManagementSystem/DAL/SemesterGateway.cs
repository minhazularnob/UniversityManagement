using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.DAL
{
    public class SemesterGateway:CommonGateway
    {
        public List<Models.Semester> GetAll()
        {
            string query = "  SELECT * FROM Semester";

            Connection.Open();
            Command.CommandText = query;

            SqlDataReader reader = Command.ExecuteReader();
            List<Semester> semesters = new List<Semester>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Semester semester = new Semester();

                    semester.Id = (int)reader["Id"];
                    semester.Name = reader["SemesterName"].ToString();
                    semesters.Add(semester);
                }
            }
            reader.Close();
            Connection.Close();

            return semesters;
        }
    }
}