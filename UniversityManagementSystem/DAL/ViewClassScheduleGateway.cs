using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.DAL
{
    public class ViewClassScheduleGateway : CommonGateway
    {
        public List<ViewClassSchedule> GetClassSchedules(int deptId)
        {

            string query = " select sc.Code, sc.CourseName, r.RoomNo,ar.Day,ar.FromHour,ar.FromMin,ar.FromFormat,ar.ToHour,ar.ToMin,ar.ToFormat,ar.Assign from Course sc left join AllocateRoom ar ON ar.CourseId = sc.Id left join Room r On ar.RoomId = r.id where sc.Id IN(select ID from Course Where DepartmentId = '" + deptId + "' ) ";
            Connection.Open();
            Command.CommandText = query;

            SqlDataReader reader = Command.ExecuteReader();
            List<ViewClassSchedule> classSchedules = new List<ViewClassSchedule>();

            while (reader.Read())
            {
                ViewClassSchedule classSchedule = new ViewClassSchedule()
                {
                    CourseCode = reader["Code"] as string,
                    CourseName = reader["CourseName"] as string,
                    RoomNo = reader["RoomNo"] as string,
                    Day = reader["Day"] as string,
                    FromHour = (reader["FromHour"] as int?) ?? 0,
                    FromMin = (reader["FromMin"] as int?) ?? 0,
                    FromFormat = reader["FromFormat"] as string,
                    ToHour = (reader["ToHour"] as int?) ?? 0,
                    ToMin = (reader["ToMin"] as int?) ?? 0,
                    ToFormat = reader["ToFormat"] as string,
                    Assign = reader["Assign"] as string
                };

                classSchedules.Add(classSchedule);
            }

            Connection.Close();
            reader.Close();

            return classSchedules;
        }

    }
}