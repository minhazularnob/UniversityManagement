using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityManagementSystem.Models
{
    public class SaveResult
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Student Id is Required")]
        public int StudentId { get; set; }
        [Required(ErrorMessage = "Course Id is Required")]
        
        public int CourseId { get; set; }
        [Required(ErrorMessage = "Please Give the Grade")]
        public string Grade { get; set; }

    }
}