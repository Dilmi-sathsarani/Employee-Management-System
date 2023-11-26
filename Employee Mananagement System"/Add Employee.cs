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
    public partial class Add_Employee : Form
    {
        public Add_Employee()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=CHAVEESHWARA\SQLEXPRESS;Initial Catalog=EMS;Integrated Security=True");

        private void Add_Employee_Load(object sender, EventArgs e)
        {
            // Load departments into combodep ComboBox
            SqlCommand cmd = new SqlCommand("Select DepName from Department where status ='Active'", conn);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            combodep.DataSource = dt;
            combodep.DisplayMember = "DepName";

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




        private void button3_Click(object sender, EventArgs e)
        {
            HR_Panel ad = new HR_Panel();
            ad.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtname.Clear();
            txtepf.Clear();
            txtaddress.Clear();
            txtdob.Clear();
            txttp.Clear();
            txtemail.Clear();
            combodep.SelectedIndex = 0;
           
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
                SqlCommand cmd = new SqlCommand("insert into Employee values('" + txtname.Text + "','" + txtepf.Text + "','" + txtaddress.Text + "','" + txtdob.Text + "','" + txttp.Text + "','" + txtemail.Text + "','" + combodep.Text + "','" + combodes.Text + "')", conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Employee Added Succesfully");
                conn.Close();

                txtname.Clear();
                txtepf.Clear();
                txtaddress.Clear();
                txtdob.Clear();
                txttp.Clear();
                txtemail.Clear();
                combodep.SelectedIndex = 0;



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
