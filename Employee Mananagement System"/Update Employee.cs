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
    public partial class Update_Employee : Form
    {
        public Update_Employee()
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

        private void Update_Employee_Load(object sender, EventArgs e)
        {
            // Load departments into combodep ComboBox
            SqlCommand cmd = new SqlCommand("Select DepName from Department where status ='Active'", conn);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            combodep.DataSource = dt;
            combodep.DisplayMember = "DepName";
            getempdetails();
            LoadDesignations();
        }
        private void LoadDesignations()
        {
            // Assuming you have a variable to store the selected department, for example:
            string selectedDepartment = combodep.Text;

            // Create a new SqlCommand to fetch designation names for the selected department
            SqlCommand designationCmd = new SqlCommand("SELECT DesName FROM Designation WHERE Department = @Department AND Status = 'Active'", conn);
            designationCmd.Parameters.AddWithValue("@Department", selectedDepartment);

            // Use SqlDataAdapter to fill data into a DataTable
            SqlDataAdapter designationDa = new SqlDataAdapter();
            designationDa.SelectCommand = designationCmd;
            DataTable designationDt = new DataTable();
            designationDa.Fill(designationDt);

            // Set the DataTable as the DataSource for the designation ComboBox
            combodes.DataSource = designationDt;
            combodes.DisplayMember = "DesName";

        }
        private void getempdetails()
        {
            SqlCommand cmd = new SqlCommand("Select* from Employee", conn);
            DataTable dt = new DataTable();

            conn.Open();

            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            conn.Close();

            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtname.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            txtepf.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            txtaddress.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            txtdob.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            txttp.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            txtemail.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            combodep.SelectedItem = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
            

        }

        private void combodep_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDesignations();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Update Employee set Name='" + txtname.Text + "', Address= '" + txtaddress.Text + "', Dob= '" + txtdob.Text + "', TP= '" + txttp.Text + "', Email= '" + txtemail.Text + "', Department= '" + combodep.Text + "', Designation= '" + combodes.Text + "' where EPF_No='" + int.Parse(txtepf.Text) + "' ", conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Employee Updated Succesfully");


                conn.Close();

                getempdetails();
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

        private void button2_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("Delete Employee  where EPF_No='" + int.Parse(txtepf.Text) + "'   ", conn);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Employee Deleted Succesfully");


            conn.Close();

            getempdetails();

            txtname.Clear();
            txtepf.Clear();
            txtaddress.Clear();
            txtdob.Clear();
            txttp.Clear();
            txtemail.Clear();
            combodep.SelectedIndex = 0;
        }
    }
}
