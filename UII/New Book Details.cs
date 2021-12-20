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
    public partial class New_Book_Details : Telerik.WinControls.UI.RadForm
    {
        public School_Management_System.DB_Connectivity.DB_Connection clsobj = new School_Management_System.DB_Connectivity.DB_Connection();
        int i;
        int sr;


        public New_Book_Details()
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
                clsobj.com = new SqlCommand("S_New_Book_Details", clsobj.con);
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
                clsobj.com = new SqlCommand("S_max_New_Book_Details", clsobj.con);
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
                        txtbookid.Text = dr["BookID"].ToString();

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

            txtauthorname.Text = "";
            //txtbookid.Text = "";
            txtbookname.Text = "";
            txtdescritpions.Text = "";
            txtisbbno.Text = "";
            txtnoofbooks.Text = "";
            txtpages.Text = "";
            txtprice.Text = "";
            txtpublisher.Text = "";
            txtremained.Text = "";

        }

        private void radButton4_Click(object sender, EventArgs e)
        {
            clr();
        }

        private void New_Book_Details_Load(object sender, EventArgs e)
        {
            slctall();

            slctmax();


        }

        private void insertionss()
        {
            try
            {
                clsobj.constate();
                clsobj.com = new SqlCommand("i_New_Book_Details", clsobj.con);
                clsobj.com.Connection = clsobj.con;
                clsobj.com.CommandType = CommandType.StoredProcedure;
                clsobj.com.Parameters.AddWithValue("@BookID",txtbookid.Text );
                clsobj.com.Parameters.AddWithValue("@Bookname",txtbookname.Text );
                clsobj.com.Parameters.AddWithValue("@Authorname",txtauthorname.Text );
                clsobj.com.Parameters.AddWithValue("@ISDNno",txtisbbno.Text );
                clsobj.com.Parameters.AddWithValue("@NoofBooks",txtnoofbooks.Text );
                clsobj.com.Parameters.AddWithValue("@RBooks",txtremained.Text );
                clsobj.com.Parameters.AddWithValue("@Publisher",txtpublisher.Text );
                clsobj.com.Parameters.AddWithValue("@Pages",txtpages.Text );
                clsobj.com.Parameters.AddWithValue("@Price",txtprice.Text );
                clsobj.com.Parameters.AddWithValue("@Descriptions",txtdescritpions.Text );
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
            if (txtbookid.Text == "")
            {
                txtbookid.Text = "0";
            }
            else
            {
                sr = Convert.ToInt32(txtbookid.Text);
                sr += 1;
                txtbookid.Text = sr.ToString();

            }
            insertionss();
        }

        private void updationss()
        {
            try
            {
                clsobj.constate();
                clsobj.com = new SqlCommand("u_New_Book_Details", clsobj.con);
                clsobj.com.Connection = clsobj.con;
                clsobj.com.CommandType = CommandType.StoredProcedure;
                clsobj.com.Parameters.AddWithValue("@BookID", txtbookid.Text);
                clsobj.com.Parameters.AddWithValue("@Bookname", txtbookname.Text);
                clsobj.com.Parameters.AddWithValue("@Authorname", txtauthorname.Text);
                clsobj.com.Parameters.AddWithValue("@ISDNno", txtisbbno.Text);
                clsobj.com.Parameters.AddWithValue("@NoofBooks", txtnoofbooks.Text);
                clsobj.com.Parameters.AddWithValue("@RBooks", txtremained.Text);
                clsobj.com.Parameters.AddWithValue("@Publisher", txtpublisher.Text);
                clsobj.com.Parameters.AddWithValue("@Pages", txtpages.Text);
                clsobj.com.Parameters.AddWithValue("@Price", txtprice.Text);
                clsobj.com.Parameters.AddWithValue("@Descriptions", txtdescritpions.Text);
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
                clsobj.com = new SqlCommand("d_New_Book_Details", clsobj.con);
                clsobj.com.Connection = clsobj.con;
                clsobj.com.CommandType = CommandType.StoredProcedure;
                clsobj.com.Parameters.AddWithValue("@BookID", txtbookid.Text);
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
        private void authorauto()
        {
            try
            {
                clsobj.constate();
                clsobj.com = new SqlCommand("Select Authorname from New_Book_Details Where Authorname like '%" + txtsearchby.Text + "%'", clsobj.con);
                clsobj.com.Connection = clsobj.con;
                SqlDataReader dr = clsobj.com.ExecuteReader();
                while (dr.Read())
                {
                    txtsearchby.AutoCompleteCustomSource.Add(dr["Authorname"].ToString());
                }
                clsobj.con.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);

            }
        }
        private void srchbyauthor()
        {
            try
            {
                clsobj.constate();
                clsobj.com = new SqlCommand("Select * from New_Book_Details Where Authorname like '%" + txtsearchby.Text + "%'", clsobj.con);
                clsobj.com.Connection = clsobj.con;
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(clsobj.com);
                da.Fill(ds);
                DataTable dt = ds.Tables[0];
                dataGridView1.DataSource = dt;
                clsobj.con.Close();
                authorauto();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);

            }
        }

        private void srchbyisbnno()
        {
            try
            {
                clsobj.constate();
                clsobj.com = new SqlCommand("Select * from New_Book_Details Where ISDNno like '%" + txtsearchby.Text + "%'", clsobj.con);
                clsobj.com.Connection = clsobj.con;
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(clsobj.com);
                da.Fill(ds);
                DataTable dt = ds.Tables[0];
                dataGridView1.DataSource = dt;
                clsobj.con.Close();
              isdnauto();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);

            }
        }
        private void isdnauto()
        {

            try
            {
                clsobj.constate();
                clsobj.com = new SqlCommand("Select ISDNno from New_Book_Details Where ISDNno like '%" + txtsearchby.Text + "%'", clsobj.con);
                clsobj.com.Connection = clsobj.con;
                SqlDataReader dr = clsobj.com.ExecuteReader();
                while (dr.Read())
                {
                    txtsearchby.AutoCompleteCustomSource.Add(dr["ISDNno"].ToString());
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
                clsobj.com = new SqlCommand("Select * from New_Book_Details Where Bookname like '%" + txtsearchby.Text + "%'", clsobj.con);
                clsobj.com.Connection = clsobj.con;
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(clsobj.com);
                da.Fill(ds);
                DataTable dt = ds.Tables[0];
                dataGridView1.DataSource = dt;
                clsobj.con.Close();
               bookauto();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);

            }
        }
        private void bookauto()
        {
            try
            {
                clsobj.constate();
                clsobj.com = new SqlCommand("Select Bookname from New_Book_Details Where Bookname like '%" + txtsearchby.Text + "%'", clsobj.con);
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

        private void srchbypublisher()
        {
            try
            {
                clsobj.constate();
                clsobj.com = new SqlCommand("Select * from New_Book_Details Where Publisher like '%" + txtsearchby.Text + "%'", clsobj.con);
                clsobj.com.Connection = clsobj.con;
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(clsobj.com);
                da.Fill(ds);
                DataTable dt = ds.Tables[0];
                dataGridView1.DataSource = dt;
                clsobj.con.Close();
                publisherauto();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);

            }
        }
        private void publisherauto()
        {
            try
            {
                clsobj.constate();
                clsobj.com = new SqlCommand("Select Publisher from New_Book_Details Where Publisher like '%" + txtsearchby.Text + "%'", clsobj.con);
                clsobj.com.Connection = clsobj.con;
                SqlDataReader dr = clsobj.com.ExecuteReader();
                while (dr.Read())
                {
                    txtsearchby.AutoCompleteCustomSource.Add(dr["Publisher"].ToString());
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
            if (rdioauthor.IsChecked == true)
            { srchbyauthor(); }
            else if (rdioisbnno.IsChecked == true)
            { srchbyisbnno(); }
            else if (rdioname.IsChecked == true)
            { srchbyname(); }
            else if (rdiopublisher.IsChecked == true)
            { srchbypublisher(); }
        }

        private void senddata()
        {
            try
            {
                i = this.dataGridView1.SelectedCells[i].RowIndex;
                txtbookid.Text = this.dataGridView1.Rows[i].Cells[0].Value.ToString();
                txtbookname.Text = this.dataGridView1.Rows[i].Cells[1].Value.ToString();
                txtauthorname.Text = this.dataGridView1.Rows[i].Cells[2].Value.ToString();
                txtisbbno.Text = this.dataGridView1.Rows[i].Cells[3].Value.ToString();
                txtnoofbooks.Text = this.dataGridView1.Rows[i].Cells[4].Value.ToString();
                txtremained.Text = this.dataGridView1.Rows[i].Cells[5].Value.ToString();
                txtpublisher.Text = this.dataGridView1.Rows[i].Cells[6].Value.ToString();
                txtpages.Text = this.dataGridView1.Rows[i].Cells[7].Value.ToString();
                txtprice.Text = this.dataGridView1.Rows[i].Cells[8].Value.ToString();
                txtdescritpions.Text = this.dataGridView1.Rows[i].Cells[9].Value.ToString();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            senddata();
            radPageViewPage1.Show();
            radPageViewPage2.Hide();
        }

        private void radButton7_Click(object sender, EventArgs e)
        {
            senddata();
            radPageViewPage1.Show();
            radPageViewPage2.Hide();
        }
    }
}
