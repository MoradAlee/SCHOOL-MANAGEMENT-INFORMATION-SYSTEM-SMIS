using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.IO;
using System.Configuration;
using System.Data;

namespace School_Management_System.DB_Connectivity
{
 public    class DB_Connection
    {
        public SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=School Management System;Integrated Security=True;");
     
        public SqlCommand com = new SqlCommand();
    
        public SqlDataAdapter da = new SqlDataAdapter();
    
        public DataSet ds = new DataSet();

        public void constate()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
        }

    }
}
