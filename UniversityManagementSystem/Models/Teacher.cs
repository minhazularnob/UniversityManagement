using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityManagementSystem.Models
{
    public class Teacher
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is Required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Address is Required")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Email is Required")]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$",ErrorMessage = "example@mail.com")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Contact Number is Required")]
        [DisplayName("Contact No.")]
        [RegularExpression(@"^(?:\+88|01)?(?:\d{11}|\d{13})$", ErrorMessage = "Invalid format of Mobile Number")]
        public string ContactNo { get; set; }

        [Required(ErrorMessage = "Designation is Required")]
        [DisplayName("Designation")]
        public int DesignationId { get; set; }

        [Required(ErrorMessage = "Department is Required")]
        [DisplayName("Department")]
        public int DepartmentId { get; set; }

        [Required]
        [DisplayName("Credit to be Taken")]
        [RegularExpression(@"\+?(\d+(\.(\d+)?)?|\.\d+)", ErrorMessage = "Please Enter a Possitive Value")]
        public double CreditToBeTaken { get; set; }

        public double TakenCredit { get; set; }

    }
}