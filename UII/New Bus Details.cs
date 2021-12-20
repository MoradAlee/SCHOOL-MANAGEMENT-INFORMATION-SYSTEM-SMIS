using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using System.Data.Sql;
using System.Data.SqlClient;
using System.IO;
using System.Configuration;
using School_Management_System.DB_Connectivity;

namespace School_Management_System.UI
{
    public partial class New_Bus_Details : Telerik.WinControls.UI.RadForm
    {

        public School_Management_System.DB_Connectivity.DB_Connection clsobj = new School_Management_System.DB_Connectivity.DB_Connection();
        int i;
        int sr;

        public New_Bus_Details()
        {
            InitializeComponent();
        }

        private void New_Bus_Details_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'school_Management_SystemDataSet.s_active_Route_Details' table. You can move, or remove it, as needed.
            this.s_active_Route_DetailsTableAdapter.Fill(this.school_Management_SystemDataSet.s_active_Route_Details);

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
                clsobj.com = new SqlCommand("s_active_Bus_Details", clsobj.con);
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
                clsobj.com = new SqlCommand("s_max_Bus_Details", clsobj.con);
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
                        txtbusid.Text = dr["BusID"].ToString();

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
            slctall();

            slctmax();

            txtbusno.Text = "";
            txtdescriptiins.Text = "";
            txtrouteid.Text = "";
            txtseats.Text = "";
            txtseatsremained.Text = "";
            chkisactive.Checked = false;

        }


        private void radButton4_Click(object sender, EventArgs e)
        {
            clr();
        }

        private void insertionss()
        {
            try
            {
                clsobj.constate();
                clsobj.com = new SqlCommand("i_Bus_Details", clsobj.con);
                clsobj.com.Connection = clsobj.con;
                clsobj.com.CommandType = CommandType.StoredProcedure;
                clsobj.com.Parameters.AddWithValue("@BusID",txtbusid.Text );
                clsobj.com.Parameters.AddWithValue("@Busno",txtbusno.Text );
                clsobj.com.Parameters.AddWithValue("@NoofSeats",txtseats.Text );
                clsobj.com.Parameters.AddWithValue("@SeatsRemained",txtseatsremained.Text );
                clsobj.com.Parameters.AddWithValue("@RouteID",txtrouteid.Text );
                clsobj.com.Parameters.AddWithValue("@BRoute",radMultiColumnComboBox1.Text );
                clsobj.com.Parameters.AddWithValue("@Descriptions",txtdescriptiins.Text );
                clsobj.com.Parameters.AddWithValue("@IsActive",chkisactive.CheckState );
     
                clsobj.com.ExecuteNonQuery();
               MsgsSaved msgs=new MsgsSaved();
                msgs.ShowDialog();
                clr();
                clsobj.con.Close();


            }
         
          catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            if (txtbusid.Text == "")
            {
                txtbusid.Text = "0";
            }
            else
            {
                sr = Convert.ToInt32(txtbusid.Text);
                sr += 1;
                txtbusid.Text = sr.ToString();

            }
            insertionss();
        }

        private void updationss()
        {
            try
            {
                clsobj.constate();
                clsobj.com = new SqlCommand("u_Bus_Details", clsobj.con);
                clsobj.com.Connection = clsobj.con;
                clsobj.com.CommandType = CommandType.StoredProcedure;
                clsobj.com.Parameters.AddWithValue("@BusID", txtbusid.Text);
                clsobj.com.Parameters.AddWithValue("@Busno", txtbusno.Text);
                clsobj.com.Parameters.AddWithValue("@NoofSeats", txtseats.Text);
                clsobj.com.Parameters.AddWithValue("@SeatsRemained", txtseatsremained.Text);
                clsobj.com.Parameters.AddWithValue("@RouteID", txtrouteid.Text);
                clsobj.com.Parameters.AddWithValue("@BRoute", radMultiColumnComboBox1.Text);
                clsobj.com.Parameters.AddWithValue("@Descriptions", txtdescriptiins.Text);
                clsobj.com.Parameters.AddWithValue("@IsActive", chkisactive.CheckState);

                clsobj.com.ExecuteNonQuery();
                MsgsUpdations msgs = new MsgsUpdations();
                msgs.ShowDialog();
                clr();
                clsobj.con.Close();


            }

            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
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
                clsobj.com = new SqlCommand("d_Bus_Details", clsobj.con);
                clsobj.com.Connection = clsobj.con;
                clsobj.com.CommandType = CommandType.StoredProcedure;
                clsobj.com.Parameters.AddWithValue("@BusID", txtbusid.Text);
              

                clsobj.com.ExecuteNonQuery();
                MsgsDeletions msgs = new MsgsDeletions();
                msgs.ShowDialog();
                clr();
                clsobj.con.Close();


            }

            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
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
        private void routeauto()
        {
            try
            {
                clsobj.constate();
                clsobj.com = new SqlCommand("Select BRoute from Bus_Details Where BRoute like '%" + txtsearchby.Text + "%'", clsobj.con);
                clsobj.com.Connection = clsobj.con;
                SqlDataReader dr = clsobj.com.ExecuteReader();
                while (dr.Read())
                {
                    txtsearchby.AutoCompleteCustomSource.Add(dr["BRoute"].ToString());
                }
                clsobj.con.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);

            }
        }
        private void srchbyroute()
        {
            try
            {
                clsobj.constate();
                clsobj.com = new SqlCommand("Select * from Bus_Details Where BRoute like '%" + txtsearchby.Text + "%'", clsobj.con);
                clsobj.com.Connection = clsobj.con;
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(clsobj.com);
                da.Fill(ds);
                DataTable dt = ds.Tables[0];
                dataGridView1.DataSource = dt;
                clsobj.con.Close();
                routeauto();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);

            }
        }
        private void srchbyvehicle()
        {
            try
            {
                clsobj.constate();
                clsobj.com = new SqlCommand("Select * from Bus_Details Where Busno like '%" + txtsearchby.Text + "%'", clsobj.con);
                clsobj.com.Connection = clsobj.con;
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(clsobj.com);
                da.Fill(ds);
                DataTable dt = ds.Tables[0];
                dataGridView1.DataSource = dt;
                clsobj.con.Close();
                busauto();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);

            }
        }
        private void busauto()
        {
            try
            {
                clsobj.constate();
                clsobj.com = new SqlCommand("Select Busno from Bus_Details Where Busno like '%" + txtsearchby.Text + "%'", clsobj.con);
                clsobj.com.Connection = clsobj.con;
                SqlDataReader dr = clsobj.com.ExecuteReader();
                while (dr.Read())
                {
                    txtsearchby.AutoCompleteCustomSource.Add(dr["Busno"].ToString());
                }
                clsobj.con.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);

            }
        }
        private void txtsearchby_TextChanged(object sender, EventArgs e)
        {
            if (rdioroute.IsChecked == true)
            { srchbyroute(); }
            else if (rdiovehicle.IsChecked == true)
            { srchbyvehicle(); }
        }

        private void senddata()
        {
            try
            {
                i = this.dataGridView1.SelectedCells[i].RowIndex;
                txtbusid.Text = this.dataGridView1.Rows[i].Cells[0].Value.ToString();
                txtbusno.Text = this.dataGridView1.Rows[i].Cells[1].Value.ToString();
                txtseats.Text = this.dataGridView1.Rows[i].Cells[2].Value.ToString();
                txtseatsremained.Text = this.dataGridView1.Rows[i].Cells[3].Value.ToString();
                txtrouteid.Text = this.dataGridView1.Rows[i].Cells[4].Value.ToString();
                radMultiColumnComboBox1.Text = this.dataGridView1.Rows[i].Cells[5].Value.ToString();
                txtdescriptiins.Text = this.dataGridView1.Rows[i].Cells[6].Value.ToString();
                chkisactive.Checked = Convert.ToBoolean(this.dataGridView1.Rows[i].Cells[7].Value.ToString());
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
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

        private void slctroute()
        {
            try
            {
                clsobj.constate();
                clsobj.com = new SqlCommand("Select * from Route_Details Where Routename like '%" + radMultiColumnComboBox1.Text + "%'", clsobj.con);
                clsobj.com.Connection = clsobj.con;
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(clsobj.com);
                da.Fill(ds, "DDD");
                DataTable dt = ds.Tables[0];
                if (ds.Tables["DDD"].Rows.Count > 0)
                {
                    using (SqlDataReader dr = clsobj.com.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            txtrouteid.Text = dr["RouteID"].ToString();
                            txtdescriptiins.Text = dr["Descriptions"].ToString();

                       }
                    }
                 
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        
        }

        private void radMultiColumnComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            slctroute();
        }
    }
}
