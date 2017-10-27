using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Ajax.Utilities;
using UniversityManagementSystem.DAL;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.BLL
{
    public class DepartmentManager
    {
        DepartmentGateway departmentGateway= new DepartmentGateway();
        public string Save(Department department)
        {
            if (IsCodeExists(department))
            {
                return "Code already exists";
            }
            if (IsNameExists(department))
            {
                return "Name already exists";
            }
            return departmentGateway.Save(department);
        }
        public bool IsCodeExists(Department department)
        {
            return departmentGateway.IsCodeExists(department);
        }
        public bool IsNameExists(Department department)
        {
            return departmentGateway.IsNameExists(department);
        }

        public List<Models.Department> GetAll()
        {
            return departmentGateway.GetAll();
        }

        public string GetDepartmentNameById(int S_Id)
        {
            return departmentGateway.GetDepartmentNameById(S_Id);
        }

        public int GetDepartmentIdByStudentId(int studentId)
        {
            return departmentGateway.GetDepartmentIdByStudentId(studentId);
        }
    }
}