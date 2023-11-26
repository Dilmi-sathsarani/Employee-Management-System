using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace Employee_Mananagement_System
{
    public partial class AddDepartment : Form
    {
        public AddDepartment()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=CHAVEESHWARA\SQLEXPRESS;Initial Catalog=EMS;Integrated Security=True");

        private void button3_Click(object sender, EventArgs e)
        {
            HR_Panel ad = new HR_Panel();
            ad.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtdepname.Clear();
            txtdepcode.Clear();
            txtloc.Clear();
            txttp.Clear();
            comboBox1.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                conn.Open();
                SqlCommand cmd = new SqlCommand("insert into Department values('" + txtdepname.Text + "','" + txtdepcode.Text + "','" + txtloc.Text + "','"+ txttp.Text + "','"+ comboBox1.Text+ "')", conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Department Added Succesfully");
                conn.Close();

                txtdepname.Clear();
                txtdepcode.Clear();
                txtloc.Clear();
                txttp.Clear();
                comboBox1.SelectedIndex = 0;





            }
            catch
            {
                MessageBox.Show("Error");
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
