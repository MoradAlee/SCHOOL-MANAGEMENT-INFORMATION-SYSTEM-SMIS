using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using System.Data.SqlClient;
using System.Data.Sql;
using System.IO;
using System.Configuration;
using School_Management_System.DB_Connectivity;

namespace School_Management_System.UI
{
    public partial class Class_Fee_Structure_Details : Telerik.WinControls.UI.RadForm
    {
        public School_Management_System.DB_Connectivity.DB_Connection clsobj = new School_Management_System.DB_Connectivity.DB_Connection();
        int i,sr;


        public Class_Fee_Structure_Details()
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
                clsobj.com = new SqlCommand("s_active_Fee_Class_Details", clsobj.con);
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
                clsobj.com = new SqlCommand("s_max_Fee_Class_Details", clsobj.con);
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
            txtclassid.Text = "";
            txtdescriptions.Text = "";
            txtfeeamount.Text = "";
            chkisactive.Checked = false;

            slctall();
            slctmax();

        }

        private void radButton4_Click(object sender, EventArgs e)
        {
            clr();
        }

        private void slctcls()
        {
            try
            {
                clsobj.constate();
                clsobj.com = new SqlCommand("Select * from Classess_Details Where Classname like '%" + radMultiColumnComboBox1.Text + "%'", clsobj.con);
                clsobj.com.Connection = clsobj.con;
                SqlDataReader dr = clsobj.com.ExecuteReader();

                while (dr.Read())
                {

                    txtclassid.Text = dr["ClassID"].ToString();


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
            slctcls();
        }

        private void Class_Fee_Structure_Details_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'school_Management_SystemDataSet.S_classess_Details' table. You can move, or remove it, as needed.
            this.s_classess_DetailsTableAdapter.Fill(this.school_Management_SystemDataSet.S_classess_Details);
            slctall();
            slctmax();

        }

        private void insertionss()
        {
            try
            {
                clsobj.constate();
                clsobj.com = new SqlCommand("i_Fee_Class_Details", clsobj.con);
                clsobj.com.Connection = clsobj.con;
                clsobj.com.CommandType = CommandType.StoredProcedure;
                clsobj.com.Parameters.AddWithValue("@Serialno",txtserialno.Text );
                clsobj.com.Parameters.AddWithValue("@ClassID",txtclassid.Text );
                clsobj.com.Parameters.AddWithValue("@Classname",radMultiColumnComboBox1.Text );
                clsobj.com.Parameters.AddWithValue("@AmountofFee",txtfeeamount.Text );
                clsobj.com.Parameters.AddWithValue("@Descriptions",txtdescriptions.Text );
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
                clsobj.com = new SqlCommand("u_Fee_Class_Details", clsobj.con);
                clsobj.com.Connection = clsobj.con;
                clsobj.com.CommandType = CommandType.StoredProcedure;
                clsobj.com.Parameters.AddWithValue("@Serialno", txtserialno.Text);
                clsobj.com.Parameters.AddWithValue("@ClassID", txtclassid.Text);
                clsobj.com.Parameters.AddWithValue("@Classname", radMultiColumnComboBox1.Text);
                clsobj.com.Parameters.AddWithValue("@AmountofFee", txtfeeamount.Text);
                clsobj.com.Parameters.AddWithValue("@Descriptions", txtdescriptions.Text);
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
                clsobj.com = new SqlCommand("d_Fee_Class_Details", clsobj.con);
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

        private void radButton6_Click(object sender, EventArgs e)
        {
            slctall();
        }

        private void senddata()
        {
            try
            {
                i = this.dataGridView1.SelectedCells[i].RowIndex;
                txtserialno.Text = this.dataGridView1.Rows[i].Cells[0].Value.ToString();
                txtclassid.Text = this.dataGridView1.Rows[i].Cells[1].Value.ToString();
                radMultiColumnComboBox1.Text = this.dataGridView1.Rows[i].Cells[2].Value.ToString();
                txtfeeamount.Text = this.dataGridView1.Rows[i].Cells[3].Value.ToString();
                txtdescriptions.Text = this.dataGridView1.Rows[i].Cells[4].Value.ToString();
                chkisactive.Checked=Convert.ToBoolean(dataGridView1.Rows[i].Cells[5].Value.ToString());
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
        private void feeauto()
        {
            try
            {
                clsobj.constate();
                clsobj.com = new SqlCommand("Select AmountofFee from Fee_Class_Details Where AmountofFee like '%" + txtsearchby.Text + "%'", clsobj.con);
                clsobj.com.Connection = clsobj.con;
                SqlDataReader dr = clsobj.com.ExecuteReader();
                while (dr.Read())
                {
                    txtsearchby.AutoCompleteCustomSource.Add(dr["AmountofFee"].ToString());
                }
                clsobj.con.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);

            }
        }
        private void srchbyamount()
        {
            try
            {
                clsobj.constate();
                clsobj.com = new SqlCommand("Select * from Fee_Class_Details Where AmountofFee like '%" + txtsearchby.Text + "%'", clsobj.con);
                clsobj.com.Connection = clsobj.con;
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(clsobj.com);
                da.Fill(ds);
                DataTable dt = ds.Tables[0];
                dataGridView1.DataSource = dt;
                clsobj.con.Close();
               feeauto();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);

            }
        }

        private void classauto()
        {
            try
            {
                clsobj.constate();
                clsobj.com = new SqlCommand("Select Classname from Fee_Class_Details Where Classname like '%" + txtsearchby.Text + "%'", clsobj.con);
                clsobj.com.Connection = clsobj.con;
                SqlDataReader dr = clsobj.com.ExecuteReader();
                while (dr.Read())
                {
                    txtsearchby.AutoCompleteCustomSource.Add(dr["Classname"].ToString());
                }
                clsobj.con.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);

            }
        }
        private void srchbyclass()
        {
            try
            {
                clsobj.constate();
                clsobj.com = new SqlCommand("Select * from Fee_Class_Details Where Classname like '%" + txtsearchby.Text + "%'", clsobj.con);
                clsobj.com.Connection = clsobj.con;
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(clsobj.com);
                da.Fill(ds);
                DataTable dt = ds.Tables[0];
                dataGridView1.DataSource = dt;
                clsobj.con.Close();
                classauto();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);

            }
        }

        private void txtsearchby_TextChanged(object sender, EventArgs e)
        {
            if (rdioamount.IsChecked == true)
            { srchbyamount(); }
            else if (rdioclass.IsChecked == true)
            { srchbyclass(); }
        }
    }
}
