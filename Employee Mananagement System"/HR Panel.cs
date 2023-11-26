using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Employee_Mananagement_System
{
    public partial class HR_Panel : Form
    {
        public HR_Panel()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            AddDepartment ad = new AddDepartment();
            ad.Show();
            this.Hide();
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            Login F1 = new Login();
            F1.Show();
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ViewDepartment vd = new ViewDepartment();
            vd.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            UpdateDepartment ud = new UpdateDepartment();
            ud.Show();
            this.Hide();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Add_Designation des = new Add_Designation();
            des.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            View_Designation des = new View_Designation();
            des.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Update_Designation ds = new Update_Designation();
            ds.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Add_Employee emp = new Add_Employee();
            emp.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            View_Employee emp = new View_Employee();
            emp.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Update_Employee emp = new Update_Employee();
            emp.Show();
            this.Hide();
        }
    }
}
