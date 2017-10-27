using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystem.DAL;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.BLL
{
    public class TeacherManager
    {
        TeacherGateway teacherGateway = new TeacherGateway();
        public string Save(Models.Teacher teacher)
        {
            if (IsEmailExists(teacher))
            {
                return "Email Already Exixts";
            }
            return teacherGateway.Save(teacher);
        }

        public bool IsEmailExists(Models.Teacher teacher)
        {
            return teacherGateway.IsEmailExists(teacher);
        }

        public List<Models.Teacher> GetAll()
        {
            return teacherGateway.GetAll();
        }

        public List<Models.Teacher> GetTeacherListByDepartmentId(int departmentId)
        {
            return teacherGateway.GetTeacherListByDepartmentId(departmentId);
        }

        public Teacher GetTeacherById(int teacherId)
        {
            return teacherGateway.GetTeacherById(teacherId);
        }


        public bool AddCreditToTeacherById(int t,int c)
        {
            return teacherGateway.AddCreditToTeacherById(t,c);
        }
    }
}