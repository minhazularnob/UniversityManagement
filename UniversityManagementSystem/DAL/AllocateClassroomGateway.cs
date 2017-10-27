using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.DAL
{
    public class AllocateClassroomGateway : CommonGateway
    {

        public bool Save(AllocateRoom allocateRoom)
        {

            string query = "INSERT INTO AllocateRoom (DepartmentId,CourseId,RoomId,Day,FromHour,FromMin,FromFormat,ToHour,ToMin,ToFormat,Assign) VALUES ('" + allocateRoom.DepartmentId + "','" + allocateRoom.CourseId + "','" + allocateRoom.RoomId + "','" + allocateRoom.Day + "','" + allocateRoom.FromHour + "','" + allocateRoom.FromMin + "'," +
                           "'" + allocateRoom.FromFormat + "','" + allocateRoom.ToHour + "','" + allocateRoom.ToMin + "','" + allocateRoom.ToFormat + "','assigned')";

            Connection.Open();
            Command.CommandText = query;

            int rowsEffected = Command.ExecuteNonQuery();
            Connection.Close();

            return rowsEffected > 0;

        }


        public List<AllocateRoom> GetByDay(string day, int roomId)
        {
            string query = " SELECT * FROM AllocateRoom WHERE Day = '" + day + "' AND RoomId = '" + roomId + "' AND Assign = 'assigned' ";
            Connection.Open();
            Command.CommandText = query;

            SqlDataReader reader = Command.ExecuteReader();
            List<AllocateRoom> getAllRooms = new List<AllocateRoom>();

            while (reader.Read())
            {
                AllocateRoom getRoom = new AllocateRoom()
                {
                    Id = (int)reader["Id"],
                    DepartmentId = (int)reader["DepartmentId"],
                    CourseId = (int)reader["CourseId"],
                    RoomId = (int)reader["RoomId"],
                    Day = reader["Day"].ToString(),
                    FromHour = (int)reader["FromHour"],
                    FromMin = (int)reader["FromMin"],
                    FromFormat = reader["FromFormat"].ToString(),
                    ToHour = (int)reader["ToHour"],
                    ToMin = (int)reader["ToMin"],
                    ToFormat = reader["ToFormat"].ToString()
                };

                getAllRooms.Add(getRoom);
            }

            Connection.Close();
            reader.Close();

            return getAllRooms;

        }


        public  string UnallocateAllClassRoom()
        {
            string query = "Update AllocateRoom SET Assign = 'unassigned'";

            Connection.Open();
            Command.CommandText = query;

            int rowsEffected = Command.ExecuteNonQuery();
            Connection.Close();
            return "All Class Room Already Unassinged";
        }
    }
}