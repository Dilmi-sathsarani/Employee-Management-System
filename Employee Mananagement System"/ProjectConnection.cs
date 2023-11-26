using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Employee_Mananagement_System
{
    class ProjectConnection
    {
        public static SqlConnection conn = null;

        public void Connection1()
        {
            conn = new SqlConnection(@"Data Source=CHAVEESHWARA\SQLEXPRESS;Initial Catalog=EMS;Integrated Security=True");
            conn.Open();
        }
    }
}
