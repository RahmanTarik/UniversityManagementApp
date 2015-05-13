using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;
using UniversityManagementApp.BLL;
using UniversityManagementApp.Model;

namespace UniversityManagementApp.UI
{
    public partial class StudentEntryUi : Form
    {
        StudentManager manager = new StudentManager();
        DepartmentManager departmentManager = new DepartmentManager();
        public StudentEntryUi()
        {
            InitializeComponent();
        }

        List<Student> _studentsList = new List<Student>();
        private int _studentId = 0;
        private bool _isUpdateMode = false;

        //string connectionString =
        //        @"SERVER = RAHMAN-PC\MSSQLSERVER2012; DATABASE = UniversityDB; Integrated Security = true";
        private void saveButton_Click(object sender, EventArgs e)
        {
            string name = nameTextBox.Text.Trim();
            string regNo = regNoTextBox.Text.Trim();
            string address = addressTextBox.Text.Trim();
            int departmentId = int.Parse(depatmentComboBox.SelectedValue.ToString());
            Student student = new Student();

            student.Name = name;
            student.RegNo = regNo;
            student.Address = address;
            student.Id = _studentId;
            student.DepartmentId = departmentId;

            bool isSuccess = false;
            if(_isUpdateMode)
            {
                isSuccess = manager.Update(student);
            }
            else
            {
                isSuccess = manager.Insert(student);
            }


            if (isSuccess)
            {
                if (_isUpdateMode)
                {
                    MessageBox.Show("Updated Successfully!");
                    saveButton.Text = "Save";
                    _isUpdateMode = false;
                }
                else
                {
                    MessageBox.Show("Inserted Successfully!");
                }
                ClearText();
                //ShowAllStudent();
                ShowAllStudentDepartment();
                regNoTextBox.ReadOnly = false;
            }
            else
            {
                if (_isUpdateMode)
                {
                    MessageBox.Show("Update failed!");
                }
                else
                {
                    MessageBox.Show("Already Exists!");
                }
            }

        }
        
        private void StudentEntryUi_Load(object sender, EventArgs e)
        {
            //ShowAllStudent();
            ShowAllStudentDepartment();
            LoadDepartemntComboBox();

        }

        private void LoadDepartemntComboBox()
        {
            List<Department> departments = departmentManager.GetAllDepartments();
            depatmentComboBox.DisplayMember = "Name";
            depatmentComboBox.ValueMember = "Id";
            depatmentComboBox.DataSource = null;
            depatmentComboBox.DataSource = departments;
            
        }

        private void ShowAllStudent()
        {
            _studentsList.Clear();
            _studentsList = manager.GetAllStudents();
            LoadListVIew(_studentsList);
        }
        List<StudentDepartmentVIew> studentDepartmentVIews = new List<StudentDepartmentVIew>();
        private void ShowAllStudentDepartment()
        {
            studentDepartmentVIews.Clear();
            studentDepartmentVIews = manager.GetAllStudentDepartment();

            LoadListVIewByStudentDepartment(studentDepartmentVIews);
        }

        private void LoadListVIew(List<Student> students )
        {
            studentsListView.Items.Clear();
            foreach (Student student in students)
            {
                ListViewItem item = new ListViewItem(student.Id.ToString());
                item.SubItems.Add(student.Name);
                item.SubItems.Add(student.RegNo);
                item.SubItems.Add(student.Address);
                item.Tag = student;
                studentsListView.Items.Add(item);
            }
        }
        private void LoadListVIewByStudentDepartment(List<StudentDepartmentVIew> studentDepartmentVIews)
        {
            studentsListView.Items.Clear();
            foreach (StudentDepartmentVIew studentDepartment in studentDepartmentVIews)
            {
                ListViewItem item = new ListViewItem(studentDepartment.Id.ToString());
                item.SubItems.Add(studentDepartment.Name);
                item.SubItems.Add(studentDepartment.RegNo);
                item.SubItems.Add(studentDepartment.Address);
                item.SubItems.Add(studentDepartment.DepartmentName);
                item.Tag = studentDepartment;
                studentsListView.Items.Add(item);
            }
        }

        private void studentsListView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (studentsListView.SelectedItems.Count > 0)
            {
                ListViewItem firstSelectedListViewItem = studentsListView.SelectedItems[0];
                StudentDepartmentVIew taggedStudent = (StudentDepartmentVIew)firstSelectedListViewItem.Tag;
                int studentId = taggedStudent.Id;

                Student student = manager.GetStudentById(studentId);
                nameTextBox.Text = student.Name;
                regNoTextBox.Text = student.RegNo;
                addressTextBox.Text = student.Address;
                
                _isUpdateMode = true;
                this._studentId = student.Id;
                saveButton.Text = "Update";
                regNoTextBox.ReadOnly = true;
            }
        }

       
        public void ClearText()
        {
            _studentId = 0;
            nameTextBox.Clear();
            regNoTextBox.Clear();
            addressTextBox.Clear();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            Student student = new Student();
            student.Id = _studentId;
            student.Name = nameTextBox.Text;
            student.RegNo = regNoTextBox.Text;
            student.Address = addressTextBox.Text;

            bool isSuccess = manager.Delete(student);
            if (isSuccess)
            {
                MessageBox.Show("Deleted Successfully");
                //ShowAllStudent();
                ShowAllStudentDepartment();
                ClearText();
            }
            else
            {
                MessageBox.Show("Failed to Delete");
                
            }
            saveButton.Text = "Save";
            _isUpdateMode = false;
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            string regNo = searchRegNoTextBox.Text;
            string name = searchNameTextBox.Text;
            string department = searchDepartmentTextBox.Text;
            List<StudentDepartmentVIew> students = manager.GetStudentBySearchOption(regNo,name,department);
            LoadListVIewByStudentDepartment(students);
            //LoadListVIew(students);

        }
    }
}
