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
    public partial class ViewDepartment : Form
    {
        public ViewDepartment()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=CHAVEESHWARA\SQLEXPRESS;Initial Catalog=EMS;Integrated Security=True");

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ViewDepartment_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'eMSDataSet1.Department' table. You can move, or remove it, as needed.
            this.departmentTableAdapter.Fill(this.eMSDataSet1.Department);
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
        private void button3_Click(object sender, EventArgs e)
        {
            HR_Panel ad = new HR_Panel();
            ad.Show();
            this.Hide();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
