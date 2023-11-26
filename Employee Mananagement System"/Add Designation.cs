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
    public partial class Add_Designation : Form
    {
        public Add_Designation()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=CHAVEESHWARA\SQLEXPRESS;Initial Catalog=EMS;Integrated Security=True");

        private void Add_Designation_Load(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Select DepName from Department where status ='Active'", conn);
            
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            combodep.DataSource = dt;
            combodep.DisplayMember = "DepName";


        }

        private void button3_Click(object sender, EventArgs e)
        {
            HR_Panel ad = new HR_Panel();
            ad.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtdesname.Clear();
            txtdescode.Clear();
            combodep.SelectedIndex = 0;
            txtsalary.Clear();
            combostatus.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                conn.Open();
                SqlCommand cmd = new SqlCommand("insert into Designation values('" + txtdesname.Text + "','" + txtdescode.Text + "','" + combodep.Text + "','" + txtsalary.Text + "','" + combostatus.Text + "')", conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Designation Added Succesfully");
                conn.Close();

                txtdesname.Clear();
                txtdescode.Clear();
                combodep.SelectedIndex = 0;
                txtsalary.Clear();
                combostatus.SelectedIndex = 0;





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
