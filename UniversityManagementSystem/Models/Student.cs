using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityManagementSystem.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        [Required(ErrorMessage = "Please enter your Name")]
        [StringLength(30, MinimumLength = 2,ErrorMessage = "Name must be 2 to 30 characters long")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter your Contact Number")]
        [StringLength(12, MinimumLength = 7, ErrorMessage = "Name must be 9 to 12 characters long")]
        [RegularExpression(@"^(?:\+88|01)?(?:\d{9}|\d{7})$",ErrorMessage = "Invalid Contact Number")]
        [DisplayName("Contact No.")]
        public string Contact { get; set; }
        [Required(ErrorMessage = "Please enter your Email Address")]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "anyone@mail.com")]
        public string Email { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        [Required]
        public string Address { get; set; }
        [Required]
        [DisplayName("Department Name")]
        public int DepartmentId { get; set; }
        public string RegistrationNumber { get; set; }


    }
}