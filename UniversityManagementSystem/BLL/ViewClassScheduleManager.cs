using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystem.DAL;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.BLL
{
    public class ViewClassScheduleManager
    {
        private ViewClassScheduleGateway _viewClassScheduleGateway = new ViewClassScheduleGateway();
        public List<ViewClassSchedule> GetClassSchedules(int deptId)
        {
            return _viewClassScheduleGateway.GetClassSchedules(deptId);
        }
    }
}