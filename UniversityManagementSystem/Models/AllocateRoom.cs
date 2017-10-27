using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityManagementSystem.Models
{
    public class AllocateRoom
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("Department")]
        public int DepartmentId { get; set; }

        [Required]
        [DisplayName("Course")]
        public int CourseId { get; set; }

        [Required]
        [DisplayName("Room")]
        public int RoomId { get; set; }

        [Required]
        [DisplayName("Day")]
        public string Day { get; set; }


        [Required(ErrorMessage = "Please enter valid Hour")]
        [RegularExpression("[0-9]*", ErrorMessage = "Please enter valid Hour")]
        [Range(1, 12)]
        [DisplayName("From")]

        public int FromHour { get; set; }


        [Required(ErrorMessage = "Please enter valid minitue")]
        [RegularExpression("[0-9]*", ErrorMessage = "Please enter valid minitue")]
        [Range(0, 60)]
        [DisplayName("Minitue")]
        public int FromMin { get; set; }


        [Required]
        public string FromFormat { get; set; }


        [Required(ErrorMessage = "Please enter valid Hour")]
        [Range(1, 12)]
        [DisplayName("To")]
        [RegularExpression("[0-9]*", ErrorMessage = "Please enter valid Hour")]
        public int ToHour { get; set; }


        [Required(ErrorMessage = "Please enter valid minitue")]
        [RegularExpression("[0-9]*", ErrorMessage = "Please enter valid minitue")]
        [Range(0, 60)]
        [DisplayName("Minitue")]
        public int ToMin { get; set; }


        [Required]
        public string ToFormat { get; set; }
        public string Assign { get; set; }

    }
}