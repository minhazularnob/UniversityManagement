using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.DAL
{
    public class DesignationGateway:CommonGateway
    {


        internal List<Models.Designation> GetAll()
        {
            string query = "SELECT * FROM Designation";

            Connection.Open();
            Command.CommandText = query;

            SqlDataReader reader = Command.ExecuteReader();
            List<Designation> designations = new List<Designation>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Designation designation = new Designation();

                    designation.Id = (int)reader["Id"];
                    designation.DesignationName = reader["DesignationName"].ToString();
                    designations.Add(designation);
                }
            }
            reader.Close();
            Connection.Close();

            return designations;
        }
    }
}