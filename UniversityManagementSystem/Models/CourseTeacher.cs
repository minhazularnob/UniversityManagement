using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityManagementSystem.Models
{
    public class CourseTeacher
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please Select the Department")]
        [DisplayName("Department")]
        public int DepartmentId { get; set; }
        [DisplayName("Teacher")]

        [Required(ErrorMessage = "Please Select the Teacher")]
        public int TeacherId { get; set; }

        [Required(ErrorMessage = "Please Select the Course")]
        [DisplayName("Course")]

        public int CourseId { get; set; }

    }
}