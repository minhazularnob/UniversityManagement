using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.DAL
{
    public class RoomGateway : CommonGateway
    {
        public List<Room> GetAllRooms()
        {

            string query = "SELECT * FROM Room";
            Connection.Open();
            Command.CommandText = query;

            SqlDataReader reader = Command.ExecuteReader();
            List<Room> rooms = new List<Room>();

            while (reader.Read())
            {
                Room room = new Room()
                {
                    Id = (int)reader["Id"],
                    RoomNo = reader["RoomNo"].ToString()
                };

                rooms.Add(room);
            }

            Connection.Close();
            reader.Close();

            return rooms;
        }
    }
}