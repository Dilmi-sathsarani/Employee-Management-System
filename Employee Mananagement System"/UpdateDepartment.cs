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
    public partial class UpdateDepartment : Form
    {
        public UpdateDepartment()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=CHAVEESHWARA\SQLEXPRESS;Initial Catalog=EMS;Integrated Security=True");

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            HR_Panel ad = new HR_Panel();
            ad.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Update Department set DepName='" + txtdepname.Text + "', Location= '" + txtloc.Text + "', Telephone= '" + int.Parse(txttp.Text) + "', Status= '" + combostatus.Text + "' where DepCode='" + int.Parse(txtdepcode.Text) + "' ", conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Department Updated Succesfully");


                conn.Close();

                getdepdetails();
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

        private void UpdateDepartment_Load(object sender, EventArgs e)
        {
            getdepdetails();
        }
        private void getdepdetails()
        {
            SqlCommand cmd = new SqlCommand("Select* from Department", conn);
            DataTable dt = new DataTable();

            conn.Open();

            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            conn.Close();

            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtdepname.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            txtdepcode.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            txtloc.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            txttp.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            combostatus.SelectedItem = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();      
        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("Delete Department  where DepCode='" + int.Parse(txtdepcode.Text) + "'   ", conn);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Department Deleted Succesfully");


            conn.Close();

            getdepdetails();
        }
    }
}
