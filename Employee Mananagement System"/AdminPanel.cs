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
using System.Data;


namespace Employee_Mananagement_System
{
    public partial class AdminPanel : Form
    {
        public AdminPanel()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=CHAVEESHWARA\SQLEXPRESS;Initial Catalog=EMS;Integrated Security=True");

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lblusername_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
        }

        private void button4_Click(object sender, EventArgs e)
        {
           
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            Login F1 = new Login();
            F1.Show();
            this.Close();
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            getuserdetails();
            tabControl1.SelectedIndex = 0;
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void AdminPanel_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'eMSDataSet.Users' table. You can move, or remove it, as needed.
            this.usersTableAdapter.Fill(this.eMSDataSet.Users);
            getuserdetails();
            getuserdetails1();
        }

        private void getuserdetails()
        {
            SqlCommand cmd = new SqlCommand("Select* from Users",conn);
            DataTable dt = new DataTable();

            conn.Open();

            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            conn.Close();

            dataGridView2.DataSource = dt;
        }
        private void getuserdetails1()
        {
            SqlCommand cmd = new SqlCommand("Select* from Users", conn);
            DataTable dt = new DataTable();

            conn.Open();

            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            conn.Close();

            dataGridView1.DataSource = dt;
        }
        private void btncreate_Click(object sender, EventArgs e)
        {
            try
            {

                conn.Open();
                SqlCommand cmd = new SqlCommand("insert into Users values('" + txtusername.Text + "','" + txtpw.Text + "','" + comboBox1.Text + "')", conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("User Added Succesfully");
                conn.Close();

                txtusername.Clear();
                txtpw.Clear();
                comboBox1.SelectedIndex = 0;

                getuserdetails();
                getuserdetails1();

               

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

        private void button3_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 2;
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            comboBox2.SelectedItem = dataGridView2.SelectedRows[0].Cells[2].Value.ToString();
            txtuname.Text= dataGridView2.SelectedRows[0].Cells[0].Value.ToString();
            txtpassword.Text = dataGridView2.SelectedRows[0].Cells[1].Value.ToString();
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Update Users set Password='" + txtpassword.Text + "', UserType= '" + comboBox2.Text + "' where UserName='" + txtuname.Text + "' ", conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("User Updated Succesfully");


                conn.Close();

                getuserdetails();
                getuserdetails1();
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

        private void btndelete_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("Delete Users Where UserName='" + txtuname.Text + "' ", conn);
            cmd.ExecuteNonQuery();
            MessageBox.Show("User Deleted Succesfully");


            conn.Close();

            getuserdetails();
            getuserdetails1();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
