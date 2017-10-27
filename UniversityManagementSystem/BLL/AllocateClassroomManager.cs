using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystem.DAL;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.BLL
{
    public class AllocateClassroomManager
    {
        private AllocateClassroomGateway _allocateClassroomGateway = new AllocateClassroomGateway();

        public AllocateRoom Save(AllocateRoom allocateRoom)
        {
            AllocateRoom room = IsRoomAvailable(allocateRoom);

            if (room == null)
            {
                _allocateClassroomGateway.Save(allocateRoom);
                return null;
            }

            return room;
        }

        private List<AllocateRoom> GetByDay(string day, int roomId)
        {
            return _allocateClassroomGateway.GetByDay(day, roomId);
        }

        private AllocateRoom IsRoomAvailable(AllocateRoom allocateRoom)
        {
            DateTime fromTime, toTime, fromTime1, toTime1;

            List<AllocateRoom> rooms = GetByDay(allocateRoom.Day, allocateRoom.RoomId);

            if (rooms != null)
            {
                foreach (AllocateRoom room in rooms)
                {
                    string fromHour = room.FromHour.ToString();
                    string fromMin = room.FromMin.ToString();
                    string fromFormat = room.FromFormat;
                    string toHour = room.ToHour.ToString();
                    string toMin = room.ToMin.ToString();
                    string toFormat = room.ToFormat;

                    fromTime = DateTime.Parse(fromHour + ":" + fromMin + " " + fromFormat);
                    toTime = DateTime.Parse(toHour + ":" + toMin + " " + toFormat);

                    fromTime1 = DateTime.Parse(allocateRoom.FromHour + ":" + allocateRoom.FromMin + " " +
                                               allocateRoom.FromFormat);
                    toTime1 = DateTime.Parse(allocateRoom.ToHour + ":" + allocateRoom.ToMin + " " +
                                             allocateRoom.ToFormat);

                    if (fromTime1 > fromTime && toTime > toTime1 && fromTime1 < toTime)
                    {
                        return room;
                    }
                    else if (fromTime1 > fromTime && toTime > fromTime1 && toTime1 > toTime)
                    {
                        return room;
                    }

                    else if (fromTime >= fromTime1 && toTime1 > fromTime && toTime > toTime1)
                    {
                        return room;
                    }
                    else if (fromTime >= fromTime1 && toTime1 >= toTime)
                    {
                        return room;
                    }

                }
            }
            return null;
        }

        public string UnallocateAllClassRoom()
        {
            return _allocateClassroomGateway.UnallocateAllClassRoom();

        }
    }
}