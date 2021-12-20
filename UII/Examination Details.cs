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
    public partial class Examination_Details : Telerik.WinControls.UI.RadForm
    {
        public School_Management_System.DB_Connectivity.DB_Connection clsobj = new School_Management_System.DB_Connectivity.DB_Connection();
        int i;
        int sr;



        public Examination_Details()
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
                clsobj.com = new SqlCommand("s_active_Examination_Details", clsobj.con);
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
                clsobj.com = new SqlCommand("s_max_Examination_Details", clsobj.con);
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
                        txtexamid.Text = dr["ExaminationID"].ToString();

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
            txtexmaniation.Text = "";
            txtnoofsubjects.Text = "";
            txttmarks.Text = "";
            chkisactive.Checked = false;

            slctall();
            slctmax();
        }

        private void radButton4_Click(object sender, EventArgs e)
        {
            clr();
        }

        private void Examination_Details_Load(object sender, EventArgs e)
        {
            slctall();
            slctmax();

        }

        private void insertionss()
        {
            try
            {
                clsobj.constate();
                clsobj.com = new SqlCommand("i_Examination_Details", clsobj.con);
                clsobj.com.Connection = clsobj.con;
                clsobj.com.CommandType = CommandType.StoredProcedure;
                clsobj.com.Parameters.AddWithValue("@ExamID",txtexamid.Text );
                clsobj.com.Parameters.AddWithValue("@Examname",txtexmaniation.Text );
                clsobj.com.Parameters.AddWithValue("@NoofSubjects",txtnoofsubjects.Text );
                clsobj.com.Parameters.AddWithValue("@TMarks",txttmarks.Text );
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
            if (txtexamid.Text == "")
            {
                txtexamid.Text = "0";
            }
            else
            {
                sr = Convert.ToInt32(txtexamid.Text);
                sr += 1;
                txtexamid.Text = sr.ToString();

            }
            insertionss();
        }
        private void updationss()
        {
            try
            {
                clsobj.constate();
                clsobj.com = new SqlCommand("u_Examination_Details", clsobj.con);
                clsobj.com.Connection = clsobj.con;
                clsobj.com.CommandType = CommandType.StoredProcedure;
                clsobj.com.Parameters.AddWithValue("@ExamID", txtexamid.Text);
                clsobj.com.Parameters.AddWithValue("@Examname", txtexmaniation.Text);
                clsobj.com.Parameters.AddWithValue("@NoofSubjects", txtnoofsubjects.Text);
                clsobj.com.Parameters.AddWithValue("@TMarks", txttmarks.Text);
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
                clsobj.com = new SqlCommand("d_Examination_Details", clsobj.con);
                clsobj.com.Connection = clsobj.con;
                clsobj.com.CommandType = CommandType.StoredProcedure;
                clsobj.com.Parameters.AddWithValue("@ExamID", txtexamid.Text);
          

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
                txtexamid.Text = this.dataGridView1.Rows[i].Cells[0].Value.ToString();
                txtexmaniation.Text = this.dataGridView1.Rows[i].Cells[1].Value.ToString();
                txtnoofsubjects.Text = this.dataGridView1.Rows[i].Cells[2].Value.ToString();
                txttmarks.Text = this.dataGridView1.Rows[i].Cells[3].Value.ToString();
                chkisactive.Checked = Convert.ToBoolean(this.dataGridView1.Rows[i].Cells[4].Value.ToString());
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
    }
}
