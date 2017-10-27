using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityManagementSystem.Models
{
    public class CourseStudent
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Stident Id is Required")]
        [DisplayName("Student Reg. No.")]
        public int StudentId { get; set; }

        [Required(ErrorMessage = "Course is Required")]
        [DisplayName("Select Course")]
        public int CourseId { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
        public string Grade { get; set; } 

    }
}