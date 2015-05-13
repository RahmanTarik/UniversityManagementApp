using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityManagementApp.Model;

namespace UniversityManagementApp.DAL
{
   public class DepartmentGateway
   {

       private string connectionString =
           ConfigurationManager.ConnectionStrings["UniversityConectionString"].ConnectionString;
        internal int Save(Model.Department department)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "INSERT INTO Departments Values ('" + department.Name + "')";
            SqlCommand command = new SqlCommand(query,connection);
            connection.Open();
            int affectedRow = command.ExecuteNonQuery();
            connection.Close();
            return affectedRow;
        }

       List<Department> departments = new List<Department>(); 
        internal List<Model.Department> GetAllDepartments()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM Departments";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Department aDepartment = new Department();
                aDepartment.Id = int.Parse(reader[0].ToString());
                aDepartment.Name = reader[1].ToString();
                departments.Add(aDepartment);
            }
            reader.Close();
            connection.Close();
            return departments;
        }
   }
}
