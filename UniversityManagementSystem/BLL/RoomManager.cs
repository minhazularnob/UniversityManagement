using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystem.DAL;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.BLL
{
    public class RoomManager
    {
        private RoomGateway _roomGateway = new RoomGateway();
        public List<Room> GetAllRooms()
        {
            return _roomGateway.GetAllRooms();
        }

    }
}