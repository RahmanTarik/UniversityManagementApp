using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityManagementApp.Model;

namespace UniversityManagementApp.DAL
{
  public class StudentGateway
    {
        string connectionString =
                ConfigurationManager.ConnectionStrings["UniversityConectionString"].ConnectionString;
        public Student GetStudentByRegNo(string regNo )
        {
            
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM Students WHERE RegNo = '" + regNo + "'";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            Student aStudent = null;
            while (reader.Read())
            {
                if (aStudent == null)
                {
                    aStudent = new Student();
                }

                aStudent.Id = int.Parse(reader[0].ToString());
                aStudent.Name = reader["Name"].ToString();
                aStudent.RegNo = reader["RegNo"].ToString();
                aStudent.Address = reader["Address"].ToString();
            }
            reader.Close();
            connection.Close();
            return aStudent;
        }
        public Student GetStudentById(int studentId)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM Students WHERE ID = '" + studentId + "'";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            Student aStudent = null;
            while (reader.Read())
            {
                if (aStudent == null)
                {
                    aStudent = new Student();
                }
                aStudent.Id = int.Parse(reader[0].ToString());
                aStudent.Name = reader["Name"].ToString();
                aStudent.RegNo = reader["RegNo"].ToString();
                aStudent.Address = reader["Address"].ToString();
                
            }
            reader.Close();
            connection.Close();
            return aStudent;
        }

        public int Insert(Student student)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            //string query = string.Format("INSERT INTO Students VALUES ('{0}','{1}','{2}','{3}')", student.Name, student.RegNo, student.Address,student.DepartmentId);
            string query = "student_insert";
            SqlCommand command = new SqlCommand(query, connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Clear();
            command.Parameters.Add("@Name", SqlDbType.VarChar);
            command.Parameters.Add("@regNo", SqlDbType.VarChar);
            command.Parameters.Add("@address", SqlDbType.VarChar);
            command.Parameters.Add("@departemntId", SqlDbType.Int);

            command.Parameters["@Name"].Value = student.Name;
            command.Parameters["@regNo"].Value = student.RegNo;
            command.Parameters["@address"].Value = student.Address;
            command.Parameters["@departemntId"].Value = student.DepartmentId;

            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;
        }

        public int Update(Student student)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            //string query = "UPDATE Students SET Name = '" + student.Name + "', Address = '" + student.Address + "',DepartmentId = '" + student.DepartmentId + "' WHERE ID =" + student.Id;
            string query = "studentS_update";
            SqlCommand command = new SqlCommand(query, connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Clear();
            
            command.Parameters.AddWithValue("@name", student.Name);
            command.Parameters.AddWithValue("@address", student.Address);
            command.Parameters.AddWithValue("@departmentId", student.DepartmentId);
            command.Parameters.AddWithValue("@id", student.Id);
            
            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;
            
        }
        List<Student> studentList = new List<Student>(); 
        public List<Student> GetAllStudents()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM Students";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Student aStudent = new Student();

                aStudent.Id = int.Parse(reader[0].ToString());
                aStudent.Name = reader["Name"].ToString();
                aStudent.RegNo = reader["RegNo"].ToString();
                aStudent.Address = reader["Address"].ToString();
                aStudent.DepartmentId = int.Parse(reader["DepartmentId"].ToString());
                studentList.Add(aStudent);

            }
            reader.Close();
            connection.Close();
            return studentList;
        }

      List<StudentDepartmentVIew> studentDepartmentVIews = new List<StudentDepartmentVIew>();
      public List<StudentDepartmentVIew> GetAllStudentDepartment()
      {
          SqlConnection connection = new SqlConnection(connectionString);
          string query = "SELECT * FROM StudentDepartment";
          SqlCommand command = new SqlCommand(query, connection);
          connection.Open();
          SqlDataReader reader = command.ExecuteReader();

          while (reader.Read())
          {
              StudentDepartmentVIew aStudentDepartmentVIew = new StudentDepartmentVIew();

              aStudentDepartmentVIew.Id = int.Parse(reader[0].ToString());
              aStudentDepartmentVIew.Name = reader["Name"].ToString();
              aStudentDepartmentVIew.RegNo = reader["RegNo"].ToString();
              aStudentDepartmentVIew.Address = reader["Address"].ToString();
              aStudentDepartmentVIew.DepartmentName = reader["Department Name"].ToString();
              studentDepartmentVIews.Add(aStudentDepartmentVIew);

          }
          reader.Close();
          connection.Close();
          return studentDepartmentVIews;
      }


      public int Delere(Student student)
        {
          SqlConnection connection = new SqlConnection(connectionString);
          //string query = "DELETE FROM Students WHERE ID =" + student.Id;
          string query = "students_delete";
          SqlCommand command = new SqlCommand(query, connection);
          command.CommandType = CommandType.StoredProcedure;
          command.Parameters.Clear();
          command.Parameters.AddWithValue("@id", student.Id);

            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;
        }

        internal List<StudentDepartmentVIew> GetStudentBySearchOption(string regNo, string name, string department)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM StudentDepartment";
            if (regNo !="" && name !="" && department !="")
            {
                query = "SELECT * FROM StudentDepartment WHERE RegNo = '" + regNo + "' AND Name = '" + name + "' AND [Department Name] = '" + department + "' ";
            }
            else if (regNo !="")
            {
                query = "SELECT * FROM StudentDepartment WHERE RegNo = '" + regNo + "'";
            }
            else if (name !="")
            {
                query = "SELECT * FROM StudentDepartment WHERE Name = '" + name + "'";
            }
            else if (department != "")
            {
                query = "SELECT * FROM StudentDepartment WHERE [Department Name] = '" + department + "'";
            }
           
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<StudentDepartmentVIew> students = new List<StudentDepartmentVIew>();
            while (reader.Read())
            {
               
                StudentDepartmentVIew aStudent = new StudentDepartmentVIew();
                aStudent.Id = int.Parse(reader[0].ToString());
                aStudent.Name = reader["Name"].ToString();
                aStudent.RegNo = reader["RegNo"].ToString();
                aStudent.Address = reader["Address"].ToString();
                aStudent.DepartmentName = reader["Department Name"].ToString();
                students.Add(aStudent);
            }
            reader.Close();
            connection.Close();
            return students;
        }
    }
}
