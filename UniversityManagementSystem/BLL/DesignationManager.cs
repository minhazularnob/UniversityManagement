using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystem.DAL;

namespace UniversityManagementSystem.BLL
{
    public class DesignationManager
    {
        DesignationGateway designation = new DesignationGateway();
        public List<Models.Designation> GetAll()
        {
            return designation.GetAll();
        }
    }
}