using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystem.DAL;

namespace UniversityManagementSystem.BLL
{
    public class SemesterManager
    {
        SemesterGateway semesterGateway = new SemesterGateway();
        public List<Models.Semester> GetAll()
        {
            return semesterGateway.GetAll();
        }
    }
}