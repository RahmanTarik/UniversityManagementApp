using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityManagementApp.DAL;
using UniversityManagementApp.Model;

namespace UniversityManagementApp.BLL
{
    public class StudentManager
    {
        //private string connectionString =
        //    @"SERVER = RAHMAN-PC\MSSQLSERVER2012; DATABASE = UniversityDB; Integrated Security = true";
        StudentGateway gateway = new StudentGateway();
        public bool IsRegNoexists(string regNo)
        {

            Student student = gateway.GetStudentByRegNo(regNo);
            if (student != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool Insert(Student student)
        {
            bool isRegNoExists = IsRegNoexists(student.RegNo);
            if (isRegNoExists)
            {
                return false;
            }
          return  gateway.Insert(student)>0;
        }

        public Student GetStudentById(int studentId)
        {
           Student student = gateway.GetStudentById(studentId);
            return student;
        }

        public bool Update(Student student)
        {

            return gateway.Update(student) > 0;
        }

        public List<Student> GetAllStudents()
        {
           return gateway.GetAllStudents();
        }
        public List<StudentDepartmentVIew> GetAllStudentDepartment()
        {
            return gateway.GetAllStudentDepartment();
        }


        public bool Delete(Student student)
        {
            if (student==null)
            {
                return false;
            }
            Student aStudent = new Student();
            aStudent = GetStudentById(student.Id);
            if (aStudent==null)
            {
                return false;
            }
            int rowAffected = gateway.Delere(student);
            return rowAffected > 0;
        }

        internal Student GetStudentsByRegNo(string regNo)
        {
            return gateway.GetStudentByRegNo(regNo);
        }

        internal List<StudentDepartmentVIew> GetStudentBySearchOption(string regNo, string name, string department)
        {
            return gateway.GetStudentBySearchOption(regNo,name,department);
        }
    }
}

