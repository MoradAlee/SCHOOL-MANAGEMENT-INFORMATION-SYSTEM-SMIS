using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using System.Data.SqlClient;
using System.IO;
using System.Configuration;
using System.Data.Sql;
using School_Management_System.DB_Connectivity;
namespace School_Management_System.UI
{
    public partial class Classess_Details : Telerik.WinControls.UI.RadForm
    {
        public School_Management_System.DB_Connectivity.DB_Connection clsobj=new School_Management_System.DB_Connectivity.DB_Connection();
        int i;
        int sr;


        public Classess_Details()
        {
            InitializeComponent();
        }

        private void radButton5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
         private void slctall()
        {
            try
            {
                clsobj.constate();
                clsobj.com = new SqlCommand("S_classess_Details", clsobj.con);
                clsobj.com.Connection = clsobj.con;
                clsobj.com.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(clsobj.com);
                da.Fill(ds);
                DataTable dt = ds.Tables[0];
                dataGridView1.DataSource = dt;
                clsobj.con.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        private void slctmax()
        {
            try
            {
                clsobj.constate();
                clsobj.com = new SqlCommand("S_max_classess_Details", clsobj.con);
                clsobj.com.Connection = clsobj.con;
                clsobj.com.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(clsobj.com);
                da.Fill(ds);
                DataTable dt = ds.Tables[0];
                using (SqlDataReader dr = clsobj.com.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        txtclassid.Text = dr["Class"].ToString();

                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        private void clr()
        {
        txtclassname.Text="";
            txtdescriptions.Text="";
            slctmax();
            slctall();

        }

        private void radButton4_Click(object sender, EventArgs e)
        {
            clr();
        }

        private void Classess_Details_Load(object sender, EventArgs e)
        {
            slctmax();
            slctall();

        }

        private void insertionss()
        {
        try 
	{	        
		clsobj.constate();
            clsobj.com=new SqlCommand("i_classess_Details",clsobj.con);
            clsobj.com.Connection=clsobj.con;
            clsobj.com.CommandType=CommandType.StoredProcedure;
            clsobj.com.Parameters.AddWithValue("@ClassID",txtclassid.Text );
            clsobj.com.Parameters.AddWithValue("@Classname",txtclassname.Text );
            clsobj.com.Parameters.AddWithValue("@Descriptions",txtdescriptions.Text );
            clsobj.com.ExecuteNonQuery();
        MsgsSaved msgs=new MsgsSaved();
            msgs.ShowDialog();
            clr();
            clsobj.con.Close();
	}
	catch (Exception ex)
	{
		
		MessageBox.Show(ex.Message );
	}
        }

        private void radButton1_Click(object sender, EventArgs e)
        {   if (txtclassid.Text == "")
            {
                txtclassid.Text = "0";
            }
            else
            {
                sr = Convert.ToInt32(txtclassid.Text);
                sr += 1;
                txtclassid.Text = sr.ToString();

            }
            insertionss();
        }

        private void updationss()
        {
          try 
	{	        
		clsobj.constate();
            clsobj.com=new SqlCommand("u_classess_Details",clsobj.con);
            clsobj.com.Connection=clsobj.con;
            clsobj.com.CommandType=CommandType.StoredProcedure;
            clsobj.com.Parameters.AddWithValue("@ClassID",txtclassid.Text );
            clsobj.com.Parameters.AddWithValue("@Classname",txtclassname.Text );
            clsobj.com.Parameters.AddWithValue("@Descriptions",txtdescriptions.Text );
            clsobj.com.ExecuteNonQuery();
        MsgsUpdations  msgs=new MsgsUpdations();
            msgs.ShowDialog();
            clr();
            clsobj.con.Close();
	}
	catch (Exception ex)
	{
		
		MessageBox.Show(ex.Message );
	}
        }

        private void radButton2_Click(object sender, EventArgs e)
        {
            updationss();
        }

        private void deletionss()
        {
          try 
	{	        
		clsobj.constate();
            clsobj.com=new SqlCommand("d_classess_Details",clsobj.con);
            clsobj.com.Connection=clsobj.con;
            clsobj.com.CommandType=CommandType.StoredProcedure;
            clsobj.com.Parameters.AddWithValue("@ClassID",txtclassid.Text );
         
            clsobj.com.ExecuteNonQuery();
        MsgsDeletions   msgs=new MsgsDeletions();
            msgs.ShowDialog();
            clr();
            clsobj.con.Close();
	}
	catch (Exception ex)
	{
		
		MessageBox.Show(ex.Message );
	}
        }

        private void radButton3_Click(object sender, EventArgs e)
        {
            deletionss();
        }

        private void radButton6_Click(object sender, EventArgs e)
        {
            slctall();

        }

        private void senddata()
        {
        try 
	{	        
		i=this.dataGridView1.SelectedCells[i].RowIndex;
            txtclassid.Text=this.dataGridView1.Rows[i].Cells[0].Value.ToString();
            txtclassname.Text=this.dataGridView1.Rows[i].Cells[1].Value.ToString();
            txtdescriptions.Text=this.dataGridView1.Rows[i].Cells[2].Value.ToString();

	}
	catch (Exception ex)
	{
		
		MessageBox.Show(ex.Message );
	}
        }

        private void radButton7_Click(object sender, EventArgs e)
        {
        senddata();
            radPageViewPage1.Show();
            radPageViewPage2.Hide();

        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
                senddata();
            radPageViewPage1.Show();
            radPageViewPage2.Hide();
        }
    }
}
