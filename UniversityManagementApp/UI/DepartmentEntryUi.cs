using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UniversityManagementApp.BLL;
using UniversityManagementApp.Model;

namespace UniversityManagementApp.UI
{
    public partial class DepartmentEntryUi : Form
    {
        public DepartmentEntryUi()
        {
            InitializeComponent();
        }

        DepartmentManager manager = new DepartmentManager();
        private void saveButton_Click(object sender, EventArgs e)
        {
            Department department = new Department();
            department.Name = departmentTextBox.Text;
            MessageBox.Show(manager.Save(department));
            departmentTextBox.Clear();
        }
    }
}
