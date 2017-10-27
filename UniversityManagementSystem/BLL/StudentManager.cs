using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystem.DAL;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.BLL
{
    public class StudentManager
    {
        StudentGateway studentGateway = new StudentGateway();
        DepartmentManager departmentManager = new DepartmentManager();
        public string Save(Models.Student student)
        {
            student.RegistrationNumber = GetStudentRegNumber(student);
            return studentGateway.Save(student);
        }

        private string GetStudentRegNumber(Models.Student student)
        {
            string studentDepartment = departmentManager.GetDepartmentNameById(student.DepartmentId);
            string studentYear = student.Date.Year.ToString();
            Random rnd = new Random();
            int mainSerial = rnd.Next(1, 999);

            return studentDepartment +"-"+ studentYear + "-" + mainSerial;
        }

        public bool IsEmailExists(Models.Student student)
        {
            return studentGateway.IsEmailExists(student);
        }

        public List<Models.Student> GetAll()
        {
            return studentGateway.GetAll();
        }

        public Student GetStudentById(int studentId)
        {
            return studentGateway.GetStudentById(studentId);
        }
    }
}