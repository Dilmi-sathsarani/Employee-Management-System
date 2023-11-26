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
    public partial class Update_Designation : Form
    {
        public Update_Designation()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=CHAVEESHWARA\SQLEXPRESS;Initial Catalog=EMS;Integrated Security=True");
        private void getdesdetails()
        {
            SqlCommand cmd = new SqlCommand("Select* from Designation", conn);
            DataTable dt = new DataTable();

            conn.Open();

            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            conn.Close();

            dataGridView1.DataSource = dt;
        }
        private void Update_Designation_Load(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Select DepName from Department where status ='Active'", conn);

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            combodep.DataSource = dt;
            combodep.DisplayMember = "DepName";
            getdesdetails();
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
                SqlCommand cmd = new SqlCommand("Update Designation set DesName='" + txtdesname.Text + "', Department= '" + combodep.Text + "', Salary= '" + int.Parse(txtsalary.Text) + "', Status= '" + combostatus.Text + "' where DesCode='" + int.Parse(txtdescode.Text) + "' ", conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Designation Updated Succesfully");


                conn.Close();

                getdesdetails();
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtdesname.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
    txtdescode.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();

    // Find the index of the department name in the ComboBox items
    int depIndex = combodep.FindStringExact(dataGridView1.SelectedRows[0].Cells[2].Value.ToString());

    // Set the selected index of the ComboBox
    if (depIndex != -1)
    {
        combodep.SelectedIndex = depIndex;
    }

    txtsalary.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
    combostatus.SelectedItem = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();

            
        }
    }
}
