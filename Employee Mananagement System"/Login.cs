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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection(@"Data Source=CHAVEESHWARA\SQLEXPRESS;Initial Catalog=EMS;Integrated Security=True");
        private void gunaTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            String username, password;
            username = nametxt.Text;
            password = pwtxt.Text;
            string usertype = comboBox1.Text;

            try
            {
                String querry = "SELECT * FROM Users WHERE username='"+nametxt.Text+"' AND password='"+pwtxt.Text+"' AND usertype ='"+comboBox1.Text+ "' ";
                SqlDataAdapter sda = new SqlDataAdapter(querry, conn);

                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count>0)
                {
                    username = nametxt.Text;
                    password = pwtxt.Text;
                    if (usertype=="Admin") {
                        AdminPanel mf = new AdminPanel();
                        mf.Show();
                        this.Hide();
                    }
                    else if (usertype == "HR Manager")
                    {
                        HR_Panel hr = new HR_Panel();
                        hr.Show();
                        this.Hide();
                    }
                    else if (usertype == "HR Assistant")
                    {
                        HR_Assistant hr = new HR_Assistant();
                        hr.Show();
                        this.Hide();
                    }
                }
                
                else
                {
                    MessageBox.Show("Wrong Username or Password");
                }

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

        private void btnclear_Click(object sender, EventArgs e)
        {
            nametxt.Clear();
            pwtxt.Clear();
            comboBox1.SelectedIndex = 0;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
