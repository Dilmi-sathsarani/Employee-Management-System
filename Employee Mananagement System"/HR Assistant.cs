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
    public partial class HR_Assistant : Form
    {
        public HR_Assistant()
        {
            InitializeComponent();
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            Login F1 = new Login();
            F1.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            View_Employee_1 ve = new View_Employee_1();
            ve.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            View_Department1 vd = new View_Department1();
            vd.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            View_Designation1 vd = new View_Designation1();
            vd.Show();
            this.Hide();
        }
    }
}
