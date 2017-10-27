using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityManagementSystem.Models
{
    public class Course
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please Enter Course Code")]
        [StringLength(20,MinimumLength = 5,ErrorMessage = "Course Code must have 5 to 20 Characters")]
        public string Code { get; set; }

        [Required(ErrorMessage = "Please Enter Course Name")]
        [DisplayName("Name")]
        public string CourseName { get; set; }

        [Required(ErrorMessage = "Enter Credit")]
        [RegularExpression(@"^(?:5(?:\.0)?|[1-4](?:\.[0-9])?|0?\.[5-9])$",ErrorMessage = "Credit must be a Number and Range is 0.5 to 5.0")]
        public double Credit { get; set; }


        public string Description { get; set; }

        [Required(ErrorMessage = "Department is Required")]
        [DisplayName("Department")]
        public int DepartmentId { get; set; }

        [Required(ErrorMessage = "Semester is Required")]
        [DisplayName("Semester")]
        public int SemesterId { get; set; }

        
        public int TeacherId { get; set; }
    }
}