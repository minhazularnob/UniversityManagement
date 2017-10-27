using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityManagementSystem.Models
{
    public class ViewClassSchedule
    {
        public string CourseCode { get; set; }
        public string CourseName { get; set; }

        public string RoomNo { get; set; }
        public string Day { get; set; }
        public int FromHour { get; set; }
        public int FromMin { get; set; }
        public string FromFormat { get; set; }

        public int ToHour { get; set; }
        public int ToMin { get; set; }
        public string ToFormat { get; set; }

        public string Assign { get; set; }
    }
}