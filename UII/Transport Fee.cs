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
    public partial class Transport_Fee : Telerik.WinControls.UI.RadForm
    {
        public School_Management_System.DB_Connectivity.DB_Connection clsobj = new School_Management_System.DB_Connectivity.DB_Connection();
        int i;
        int sr;
        public Transport_Fee()
        {
            InitializeComponent();
        }

        private void Transport_Fee_Load(object sender, EventArgs e)
        {
            
            // TODO: This line of code loads data into the 'school_Management_SystemDataSet.s_active_Bus_Admission_Details' table. You can move, or remove it, as needed.
            
            this.s_active_Bus_Admission_DetailsTableAdapter.Fill(this.school_Management_SystemDataSet.s_active_Bus_Admission_Details);
            
            slctall();

            slctmax();

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
                clsobj.com = new SqlCommand("s_Transport_Fee_Details", clsobj.con);
                clsobj.com.Connection = clsobj.con;
                clsobj.com.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(clsobj.com);
                da.Fill(ds);
                DataTable dt = ds.Tables[0];
               dataGridView2.DataSource = dt;
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
                clsobj.com = new SqlCommand("s_max_Transport_Fee_Details", clsobj.con);
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
                        txtserialno.Text = dr["Serialno"].ToString();

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

            txtarrears.Text = "";
            txtbalance.Text = "";
            txtdate.Text = DateTime.Today.ToShortDateString();
            txdescritpions.Text = "";
            txtfname.Text = "";
            txtreceived.Text = "";
            txtremained.Text = "";
            txtstdid.Text = "";
            txtstdname.Text = "";
            chkisrecieved.Checked = false;
            cmbomonth.SelectedIndex = 0;
            cmboyeear.SelectedIndex = 0;


        }

        private void radButton4_Click(object sender, EventArgs e)
        {
            clr();
        }

        private void deletionss()
        {
            try
            {

                clsobj.constate();
                clsobj.com = new SqlCommand("d_Transport_Fee_Details", clsobj.con);
                clsobj.com.Connection = clsobj.con;
                clsobj.com.CommandType = CommandType.StoredProcedure;
                clsobj.com.Parameters.AddWithValue("@Serialno", txtserialno.Text);
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

        private void insertionss()
        {
            try
            {
            
                clsobj.constate();
                clsobj.com = new SqlCommand("i_Transport_Fee_Details", clsobj.con);
                clsobj.com.Connection = clsobj.con;
                clsobj.com.CommandType = CommandType.StoredProcedure;
                clsobj.com.Parameters.AddWithValue("@Serialno",txtserialno.Text );
                clsobj.com.Parameters.AddWithValue("@StdID",txtstdid.Text );
                    clsobj.com.Parameters.AddWithValue("@Stdname",txtstdname.Text );
                clsobj.com.Parameters.AddWithValue("@Fname",txtfname.Text );
                    clsobj.com.Parameters.AddWithValue("@Arrears",txtarrears .Text );
                clsobj.com.Parameters.AddWithValue("@CBalance",txtbalance.Text );
                    clsobj.com.Parameters.AddWithValue("@Received",txtreceived.Text );
                clsobj.com.Parameters.AddWithValue("@Remained",txtremained.Text );
                clsobj.com.Parameters.AddWithValue("@Formonthof",cmbomonth.Text );
                clsobj.com.Parameters.AddWithValue("@Foryear",cmboyeear .Text );
                clsobj.com.Parameters.AddWithValue("@FDate",txtdate.Text );
                clsobj.com.Parameters.AddWithValue("@Descriptions",txdescritpions.Text );
                clsobj.com.Parameters.AddWithValue("@TReceived",chkisrecieved.CheckState );
                
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
            if (txtserialno.Text == "")
            {
                txtserialno.Text = "0";
            }
            else
            {
                sr = Convert.ToInt32(txtserialno.Text);
                sr += 1;
                txtserialno.Text = sr.ToString();

            }
            insertionss();
        }

        private void updationss()
        {
            try
            {

                clsobj.constate();
                clsobj.com = new SqlCommand("u_Transport_Fee_Details", clsobj.con);
                clsobj.com.Connection = clsobj.con;
                clsobj.com.CommandType = CommandType.StoredProcedure;
                clsobj.com.Parameters.AddWithValue("@Serialno", txtserialno.Text);
                clsobj.com.Parameters.AddWithValue("@StdID", txtstdid.Text);
                clsobj.com.Parameters.AddWithValue("@Stdname", txtstdname.Text);
                clsobj.com.Parameters.AddWithValue("@Fname", txtfname.Text);
                clsobj.com.Parameters.AddWithValue("@Arrears", txtarrears.Text);
                clsobj.com.Parameters.AddWithValue("@CBalance", txtbalance.Text);
                clsobj.com.Parameters.AddWithValue("@Received", txtreceived.Text);
                clsobj.com.Parameters.AddWithValue("@Remained", txtremained.Text);
                clsobj.com.Parameters.AddWithValue("@Formonthof", cmbomonth.Text);
                clsobj.com.Parameters.AddWithValue("@Foryear", cmboyeear.Text);
                clsobj.com.Parameters.AddWithValue("@FDate", txtdate.Text);
                clsobj.com.Parameters.AddWithValue("@Descriptions", txdescritpions.Text);
                clsobj.com.Parameters.AddWithValue("@TReceived", chkisrecieved.CheckState);

                clsobj.com.ExecuteNonQuery();
                MsgsUpdations  msgs = new MsgsUpdations ();
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

        private void radButton8_Click(object sender, EventArgs e)
        {
            slctall();

        }

        private void srchbymonth()
        {
            try
            {
                clsobj.constate();
                clsobj.com = new SqlCommand("Select * from Transport_Fee_Details Where Formonthof like '%" + txtsearchby.Text + "%'", clsobj.con);
                clsobj.com.Connection = clsobj.con;
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(clsobj.com);
                da.Fill(ds);
                DataTable dt = ds.Tables[0];
                dataGridView2.DataSource = dt;
                clsobj.con.Close();
               monthauto();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        private void monthauto()
        {
            try
            {
                clsobj.constate();
                clsobj.com = new SqlCommand("Select Formonthof from Transport_Fee_Details Where Formonthof like '%" + txtsearchby.Text + "%'", clsobj.con);
                clsobj.com.Connection = clsobj.con;
                SqlDataReader dr = clsobj.com.ExecuteReader();
                while (dr.Read())
                {
                    txtsearchby.AutoCompleteCustomSource.Add(dr["Formonthof"].ToString());
                }
                clsobj.con.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void nameauto()
        {
            try
            {
                clsobj.constate();
                clsobj.com = new SqlCommand("Select Stdname from Transport_Fee_Details Where Stdname like '%" + txtsearchby.Text + "%'", clsobj.con);
                clsobj.com.Connection = clsobj.con;
                SqlDataReader dr = clsobj.com.ExecuteReader();
                while (dr.Read())
                {
                    txtsearchby.AutoCompleteCustomSource.Add(dr["Stdname"].ToString());
                }
                clsobj.con.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        private void srchbyname()
        {
            try
            {
                clsobj.constate();
                clsobj.com = new SqlCommand("Select * from Transport_Fee_Details Where Stdname like '%" + txtsearchby.Text + "%'", clsobj.con);
                clsobj.com.Connection = clsobj.con;
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(clsobj.com);
                da.Fill(ds);
                DataTable dt = ds.Tables[0];
                dataGridView2.DataSource = dt;
                clsobj.con.Close();
                nameauto();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        private void txtsearchby_TextChanged(object sender, EventArgs e)
        {
            if (rdiomonth.IsChecked == true)
            { srchbymonth(); }
            else if (rdioname.IsChecked == true)
            { srchbyname(); }

        }

        private void senddata()
        {
            try
            {
                i = this.dataGridView2.SelectedCells[i].RowIndex;
                txtserialno.Text = this.dataGridView2.Rows[i].Cells[0].Value.ToString();
                txtstdid.Text = this.dataGridView2.Rows[i].Cells[1].Value.ToString();
                txtstdname.Text = this.dataGridView2.Rows[i].Cells[2].Value.ToString();
                txtfname.Text = this.dataGridView2.Rows[i].Cells[3].Value.ToString();
                txtarrears.Text = this.dataGridView2.Rows[i].Cells[4].Value.ToString();
                txtbalance.Text = this.dataGridView2.Rows[i].Cells[5].Value.ToString();
                txtreceived.Text = this.dataGridView2.Rows[i].Cells[6].Value.ToString();
                txtremained.Text = this.dataGridView2.Rows[i].Cells[7].Value.ToString();
                cmbomonth.Text = this.dataGridView2.Rows[i].Cells[8].Value.ToString();
                cmboyeear.Text = this.dataGridView2.Rows[i].Cells[9].Value.ToString();
                txtdate.Text = this.dataGridView2.Rows[i].Cells[10].Value.ToString();
                txdescritpions.Text = this.dataGridView2.Rows[i].Cells[11].Value.ToString();
                chkisrecieved.Checked = Convert.ToBoolean(this.dataGridView2.Rows[i].Cells[12].Value.ToString());

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void radButton9_Click(object sender, EventArgs e)
        {
            senddata();
            radPageViewPage1.Show();
            radPageViewPage2.Hide();
        }

        private void dataGridView2_DoubleClick(object sender, EventArgs e)
        {
            senddata();
            radPageViewPage1.Show();
            radPageViewPage2.Hide();
        }

        private void radMultiColumnComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
