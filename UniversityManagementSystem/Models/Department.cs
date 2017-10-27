using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityManagementSystem.Models
{
    public class Department
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Department Name is Required")]
        [StringLength(50, MinimumLength = 2,ErrorMessage = "Name atleast 2 Characters long")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Department Code is Required")]
        [StringLength(7,MinimumLength = 2,ErrorMessage = "Code must be 2 to 7 Characters long")]
        public string Code { get; set; }

    }
}
