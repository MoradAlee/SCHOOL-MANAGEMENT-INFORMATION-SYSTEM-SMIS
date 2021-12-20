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
    public partial class Bus_Expenses : Telerik.WinControls.UI.RadForm
    {
        public School_Management_System.DB_Connectivity.DB_Connection clsobj = new School_Management_System.DB_Connectivity.DB_Connection();
        int i,sr;


        public Bus_Expenses()
        {
            InitializeComponent();
        }

        private void Bus_Expenses_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'school_Management_SystemDataSet.s_active_Bus_Details' table. You can move, or remove it, as needed.
            this.s_active_Bus_DetailsTableAdapter.Fill(this.school_Management_SystemDataSet.s_active_Bus_Details);

            txtdate.Text = DateTime.Today.ToShortDateString();



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
                clsobj.com = new SqlCommand("S_Bus_Expenses_Details", clsobj.con);
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
                clsobj.com = new SqlCommand("S_max_Bus_Expenses_Details", clsobj.con);
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
                        txtexpid.Text = dr["Expense"].ToString();

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
            txtdate.Text = DateTime.Today.ToShortDateString();
            txtdescriptions.Text = "";
            txtexpensesamount.Text = "";
           // txtexpid.Text = "";
            txtvehicleid.Text = "";


            slctall();
            slctmax();
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
                clsobj.com = new SqlCommand("i_Bus_Expenses_Details", clsobj.con);
                clsobj.com.Connection = clsobj.con;
                clsobj.com.CommandType = CommandType.StoredProcedure;
                clsobj.com.Parameters.AddWithValue("@ExpenseID",txtexpid.Text );
                clsobj.com.Parameters.AddWithValue("@EDate",txtdate.Text );
                clsobj.com.Parameters.AddWithValue("@Descriptions",txtdescriptions.Text );
                clsobj.com.Parameters.AddWithValue("@BusID",txtvehicleid.Text );
                clsobj.com.Parameters.AddWithValue("@Busno",radMultiColumnComboBox1.Text );
                clsobj.com.Parameters.AddWithValue("@Amount",txtexpensesamount.Text );
         
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
            if (txtexpid.Text == "")
            {
                txtexpid.Text = "0";
            }
            else
            {
                sr = Convert.ToInt32(txtexpid.Text);
                sr += 1;
                txtexpid.Text = sr.ToString();

            }
            insertionss();
        }

        private void updationss()
        {
            try
            {
                clsobj.constate();
                clsobj.com = new SqlCommand("u_Bus_Expenses_Details", clsobj.con);
                clsobj.com.Connection = clsobj.con;
                clsobj.com.CommandType = CommandType.StoredProcedure;
                clsobj.com.Parameters.AddWithValue("@ExpenseID", txtexpid.Text);
                clsobj.com.Parameters.AddWithValue("@EDate", txtdate.Text);
                clsobj.com.Parameters.AddWithValue("@Descriptions", txtdescriptions.Text);
                clsobj.com.Parameters.AddWithValue("@BusID", txtvehicleid.Text);
                clsobj.com.Parameters.AddWithValue("@Busno", radMultiColumnComboBox1.Text);
                clsobj.com.Parameters.AddWithValue("@Amount", txtexpensesamount.Text);

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
                clsobj.com = new SqlCommand("d_Bus_Expenses_Details", clsobj.con);
                clsobj.com.Connection = clsobj.con;
                clsobj.com.CommandType = CommandType.StoredProcedure;
                clsobj.com.Parameters.AddWithValue("@ExpenseID", txtexpid.Text);
            

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

        private void senddata()
        {
            try
            {
                i = this.dataGridView1.SelectedCells[i].RowIndex;
                txtexpid.Text = this.dataGridView1.Rows[i].Cells[0].Value.ToString();
                txtdate.Text = this.dataGridView1.Rows[i].Cells[1].Value.ToString();
                txtdescriptions.Text = this.dataGridView1.Rows[i].Cells[2].Value.ToString();
                txtvehicleid.Text = this.dataGridView1.Rows[i].Cells[3].Value.ToString();
                radMultiColumnComboBox1.Text = this.dataGridView1.Rows[i].Cells[4].Value.ToString();
                txtexpensesamount.Text = this.dataGridView1.Rows[i].Cells[5].Value.ToString();
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
        private void dateauto()
        {
            try
            {
                clsobj.constate();
                clsobj.com = new SqlCommand("Select EDate from Bus_Expenses_Details Where EDate like '%" + txtsearchby.Text + "%'", clsobj.con);
                clsobj.com.Connection = clsobj.con;
                SqlDataReader dr = clsobj.com.ExecuteReader();
                while (dr.Read())
                {
                    txtsearchby.AutoCompleteCustomSource.Add(dr["EDate"].ToString());
                }
                clsobj.con.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);

            }
        }
        private void srchbydate()
        {
            try
            {
                clsobj.constate();
                clsobj.com = new SqlCommand("Select * from Bus_Expenses_Details Where EDate like '%" + txtsearchby.Text + "%'", clsobj.con);
                clsobj.com.Connection = clsobj.con;
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(clsobj.com);
                da.Fill(ds);
                DataTable dt = ds.Tables[0];
                dataGridView1.DataSource = dt;
                clsobj.con.Close();
                dateauto();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);

            }
        }
        private void srchbyvehno()
        {
            try
            {
                clsobj.constate();
                clsobj.com = new SqlCommand("Select * from Bus_Expenses_Details Where Busno like '%" + txtsearchby.Text + "%'", clsobj.con);
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
                clsobj.com = new SqlCommand("Select Busno from Bus_Expenses_Details Where Busno like '%" + txtsearchby.Text + "%'", clsobj.con);
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
            if (rdiodate.IsChecked == true)
            { srchbydate(); }
            else if (rdiovehicleno.IsChecked == true)
            { srchbyvehno(); }
        }

        private void slctbus()
        {
            try
            {
                clsobj.constate();
                clsobj.com = new SqlCommand("Select * from Bus_Details Where Busno like '%" + radMultiColumnComboBox1.Text + "%'", clsobj.con);
                clsobj.com.Connection = clsobj.con;
                SqlDataReader dr = clsobj.com.ExecuteReader();

                while (dr.Read())
                {

                    txtvehicleid.Text = dr["BusID"].ToString();


                }

                clsobj.con.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void radMultiColumnComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            slctbus();
        }
    }
}
