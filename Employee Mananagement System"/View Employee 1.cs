﻿using System;
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
    public partial class View_Employee_1 : Form
    {
        public View_Employee_1()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=CHAVEESHWARA\SQLEXPRESS;Initial Catalog=EMS;Integrated Security=True");

        private void button3_Click(object sender, EventArgs e)
        {
            HR_Assistant hra = new HR_Assistant();
            hra.Show();
            this.Hide();
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

        private void View_Employee_1_Load(object sender, EventArgs e)
        {
            getempdetails();
        }
    }
}
