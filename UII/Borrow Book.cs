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
    public partial class Borrow_Book : Telerik.WinControls.UI.RadForm
    {
        public School_Management_System.DB_Connectivity.DB_Connection clsobj = new School_Management_System.DB_Connectivity.DB_Connection();
        int i, sr;
        public Borrow_Book()
        {
            InitializeComponent();
        }

        private void Borrow_Book_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'school_Management_SystemDataSet1.S_New_Book_Details' table. You can move, or remove it, as needed.
            this.s_New_Book_DetailsTableAdapter.Fill(this.school_Management_SystemDataSet1.S_New_Book_Details);
            // TODO: This line of code loads data into the 'school_Management_SystemDataSet1.S_Library_Member_Details' table. You can move, or remove it, as needed.
            this.s_Library_Member_DetailsTableAdapter.Fill(this.school_Management_SystemDataSet1.S_Library_Member_Details);

            slctall();
            slctmax();

            txtduedate.Text = DateTime.Today.ToShortDateString();
            
            txtissuedate.Text = DateTime.Today.ToShortDateString();


        }

        private void radButton5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void clr()
        {
            slctall();
            slctmax();
            txtauthor.Text = "";
            txtavaialbe.Text = "";
            txtbookid.Text = "";
            txtdescriptions.Text = "";
            txtduedate.Text = DateTime.Today.ToShortDateString();
            txtfname.Text = "";
            txtisbnno.Text = "";
            txtissuedate.Text = DateTime.Today.ToShortDateString();
            txtstdid.Text = "";
            txtstdname.Text = "";
            chkisactive.Checked = false;
                              }
        private void slctall()
        {
            try
            {
                clsobj.constate();
                clsobj.com = new SqlCommand("s_Borrow_Book_Details", clsobj.con);
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
                clsobj.com = new SqlCommand("s_max_Borrow_Book_Details", clsobj.con);
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
                        txtserialno.Text = dr["Serial"].ToString();

                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
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
                clsobj.com = new SqlCommand("i_Borrow_Book_Details", clsobj.con);
                clsobj.com.Connection = clsobj.con;
                clsobj.com.CommandType = CommandType.StoredProcedure;
                clsobj.com.Parameters.AddWithValue("@Serialno",txtserialno.Text );
                clsobj.com.Parameters.AddWithValue("@StdID",txtstdid.Text );
                clsobj.com.Parameters.AddWithValue("@Regno",radMultiColumnComboBox1.Text );
                clsobj.com.Parameters.AddWithValue("@Stdname",txtstdname.Text );
                clsobj.com.Parameters.AddWithValue("@Fname",txtfname.Text );
                clsobj.com.Parameters.AddWithValue("@BookID",txtbookid.Text );
                clsobj.com.Parameters.AddWithValue("@Bookname",radMultiColumnComboBox2.Text );
                clsobj.com.Parameters.AddWithValue("@Authorname",txtauthor.Text );
                clsobj.com.Parameters.AddWithValue("@ISDNno",txtisbnno.Text );
                clsobj.com.Parameters.AddWithValue("@AvailableBooks",txtavaialbe.Text );
                clsobj.com.Parameters.AddWithValue("@IssueDate",txtissuedate.Text );
                clsobj.com.Parameters.AddWithValue("@DueDate",txtduedate.Text );
                clsobj.com.Parameters.AddWithValue("@Descriptions",txtdescriptions.Text );
                clsobj.com.Parameters.AddWithValue("@IsRecieved",chkisactive.CheckState );
    
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
                clsobj.com = new SqlCommand("u_Borrow_Book_Details", clsobj.con);
                clsobj.com.Connection = clsobj.con;
                clsobj.com.CommandType = CommandType.StoredProcedure;
                clsobj.com.Parameters.AddWithValue("@Serialno", txtserialno.Text);
                clsobj.com.Parameters.AddWithValue("@StdID", txtstdid.Text);
                clsobj.com.Parameters.AddWithValue("@Regno", radMultiColumnComboBox1.Text);
                clsobj.com.Parameters.AddWithValue("@Stdname", txtstdname.Text);
                clsobj.com.Parameters.AddWithValue("@Fname", txtfname.Text);
                clsobj.com.Parameters.AddWithValue("@BookID", txtbookid.Text);
                clsobj.com.Parameters.AddWithValue("@Bookname", radMultiColumnComboBox2.Text);
                clsobj.com.Parameters.AddWithValue("@Authorname", txtauthor.Text);
                clsobj.com.Parameters.AddWithValue("@ISDNno", txtisbnno.Text);
                clsobj.com.Parameters.AddWithValue("@AvailableBooks", txtavaialbe.Text);
                clsobj.com.Parameters.AddWithValue("@IssueDate", txtissuedate.Text);
                clsobj.com.Parameters.AddWithValue("@DueDate", txtduedate.Text);
                clsobj.com.Parameters.AddWithValue("@Descriptions", txtdescriptions.Text);
                clsobj.com.Parameters.AddWithValue("@IsRecieved", chkisactive.CheckState);

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
                clsobj.com = new SqlCommand("d_Borrow_Book_Details", clsobj.con);
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

        private void slctstudet()
        {
            try
            {
                clsobj.constate();
                clsobj.com = new SqlCommand("Select * from Library_Members_Details Where Regno like '%" + radMultiColumnComboBox1.Text + "%'", clsobj.con);
                clsobj.com.Connection = clsobj.con;
                //     SqlDataReader dr = clsobj.com.ExecuteReader();
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

                            txtstdid.Text = dr["StdID"].ToString();
                            txtstdname.Text = dr["Stdname"].ToString();
                            txtfname.Text = dr["Fname"].ToString();
                          //  txtaddress.Text = dr["PermAddress"].ToString();
                            //  txtcontactno.Text = dr["Contactno"].ToString();


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
            slctstudet();
        }

        private void slctbook()
        {
            try
            {
                clsobj.constate();
                clsobj.com = new SqlCommand("Select * from New_Book_Details Where Bookname like '%" + radMultiColumnComboBox2.Text + "%'", clsobj.con);
                clsobj.com.Connection = clsobj.con;
                //     SqlDataReader dr = clsobj.com.ExecuteReader();
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

                           txtbookid.Text = dr["BookID"].ToString();
                            txtauthor.Text = dr["Authorname"].ToString();
                            txtisbnno.Text = dr["ISDNno"].ToString();
                            txtavaialbe.Text = dr["RBooks"].ToString();


                        }
                    }
                 
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void radMultiColumnComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            slctbook();
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
                txtstdid.Text = this.dataGridView1.Rows[i].Cells[1].Value.ToString();
                radMultiColumnComboBox1.Text = this.dataGridView1.Rows[i].Cells[2].Value.ToString();
                txtstdname.Text = this.dataGridView1.Rows[i].Cells[3].Value.ToString();
                txtfname.Text = this.dataGridView1.Rows[i].Cells[4].Value.ToString();
                txtbookid.Text = this.dataGridView1.Rows[i].Cells[5].Value.ToString();
                radMultiColumnComboBox2.Text = this.dataGridView1.Rows[i].Cells[6].Value.ToString();
                txtauthor.Text = this.dataGridView1.Rows[i].Cells[7].Value.ToString();
                txtisbnno.Text = this.dataGridView1.Rows[i].Cells[8].Value.ToString();
                txtavaialbe.Text = this.dataGridView1.Rows[i].Cells[9].Value.ToString();
                txtissuedate.Text = this.dataGridView1.Rows[i].Cells[10].Value.ToString();
                txtduedate.Text = this.dataGridView1.Rows[i].Cells[11].Value.ToString();
                txtdescriptions.Text = this.dataGridView1.Rows[i].Cells[12].Value.ToString();
                chkisactive.Checked = Convert.ToBoolean(this.dataGridView1.Rows[i].Cells[13].Value.ToString());
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
        private void bnameauto()
        {
            try
            {
                clsobj.constate();
                clsobj.com = new SqlCommand("Select Bookname from Borrow_Book Where Bookname like '%" + txtsearchby.Text + "%'", clsobj.con);
                clsobj.com.Connection = clsobj.con;
                SqlDataReader dr = clsobj.com.ExecuteReader();
                while (dr.Read())
                {
                    txtsearchby.AutoCompleteCustomSource.Add(dr["Bookname"].ToString());
                }
                clsobj.con.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);

            }
        }
        private void srchbybook()
        {
            try
            {
                clsobj.constate();
                clsobj.com = new SqlCommand("Select * from Borrow_Book Where Bookname like '%" + txtsearchby.Text + "%'", clsobj.con);
                clsobj.com.Connection = clsobj.con;
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(clsobj.com);
                da.Fill(ds);
                DataTable dt = ds.Tables[0];
                dataGridView1.DataSource = dt;
                clsobj.con.Close();
                bnameauto();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);

            }
        }
        private void srchbystd()
        {

            try
            {
                clsobj.constate();
                clsobj.com = new SqlCommand("Select * from Borrow_Book Where Stdname like '%" + txtsearchby.Text + "%'", clsobj.con);
                clsobj.com.Connection = clsobj.con;
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(clsobj.com);
                da.Fill(ds);
                DataTable dt = ds.Tables[0];
                dataGridView1.DataSource = dt;
                clsobj.con.Close();
                nameauto();
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
                clsobj.com = new SqlCommand("Select Stdname from Borrow_Book Where Stdname like '%" + txtsearchby.Text + "%'", clsobj.con);
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
        private void txtsearchby_TextChanged(object sender, EventArgs e)
        {
            if (rdiobookname.IsChecked == true)
            {
                srchbybook();
            }
            else if (rdiostdname.IsChecked == true)
            {
                srchbystd();
            }
        }
    }
}
