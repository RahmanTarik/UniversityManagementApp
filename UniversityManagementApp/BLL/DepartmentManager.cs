using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityManagementApp.DAL;
using UniversityManagementApp.Model;

namespace UniversityManagementApp.BLL
{
   public class DepartmentManager
    {

       DepartmentGateway gateway = new DepartmentGateway();
        internal string Save(Model.Department department)
        {
            int result = gateway.Save(department);
            if (result > 0)
            {
                return "Department Saved Successfully!!";
            }
            else
            {
                return "Failed to Save Department";
            }
        }

       internal List<Department> GetAllDepartments()
       {
           return gateway.GetAllDepartments();
       }
    }
}
