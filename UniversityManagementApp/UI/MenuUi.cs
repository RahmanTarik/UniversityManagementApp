using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UniversityManagementApp.UI
{
    public partial class MenuUi : Form
    {
        public MenuUi()
        {
            InitializeComponent();
        }

        private void studentButton_Click(object sender, EventArgs e)
        {
            StudentEntryUi studentEntryUi = new StudentEntryUi();
            studentEntryUi.Show();
        }

        private void departmentButton_Click(object sender, EventArgs e)
        {
            DepartmentEntryUi departmentEntryUi = new DepartmentEntryUi();
            departmentEntryUi.Show();
        }
    }
}
