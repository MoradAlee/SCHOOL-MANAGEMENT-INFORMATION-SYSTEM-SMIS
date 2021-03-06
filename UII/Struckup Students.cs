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
    public partial class Struckup_Students : Telerik.WinControls.UI.RadForm
    {
        public School_Management_System.DB_Connectivity.DB_Connection clsobj = new School_Management_System.DB_Connectivity.DB_Connection();
        int i;
        int sr;
        public Struckup_Students()
        {
            InitializeComponent();
        }

        private void Struckup_Students_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'school_Management_SystemDataSet.S_active_Students_Details' table. You can move, or remove it, as needed.
            this.s_active_Students_DetailsTableAdapter.Fill(this.school_Management_SystemDataSet.S_active_Students_Details);

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
                clsobj.com = new SqlCommand("S_Struckup_Details", clsobj.con);
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
                clsobj.com = new SqlCommand("S_max_Struckup_Details", clsobj.con);
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

            txtage.Text = "";
            txtclass.Text = "";
            txtdate.Text = DateTime.Today.ToShortDateString();
            txtdob.Text = "";
            txtfname.Text = "";
            txtinwords.Text = "";
            txtreasonofleaving.Text = "";
            txtstdname.Text = "";
            txtstudentid.Text = "";

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
                clsobj.com = new SqlCommand("i_Struckup_Details", clsobj.con);
                clsobj.com.Connection = clsobj.con;
                clsobj.com.CommandType = CommandType.StoredProcedure;
                clsobj.com.Parameters.AddWithValue("@Serialno",txtserialno.Text );
                clsobj.com.Parameters.AddWithValue("@Regno",radMultiColumnComboBox1.Text );
                clsobj.com.Parameters.AddWithValue("@StdID",txtstudentid.Text );
                clsobj.com.Parameters.AddWithValue("@Stdname",txtstdname.Text );
                clsobj.com.Parameters.AddWithValue("@Fname",txtfname.Text );
                clsobj.com.Parameters.AddWithValue("@DOB",txtdob.Text );
                clsobj.com.Parameters.AddWithValue("@Age",txtage.Text );
                clsobj.com.Parameters.AddWithValue("@Inwords",txtinwords.Text );
                clsobj.com.Parameters.AddWithValue("@CClass",txtclass.Text );
                clsobj.com.Parameters.AddWithValue("@SDate",txtdate.Text );
                clsobj.com.Parameters.AddWithValue("@Descriptions",txtreasonofleaving.Text );
             
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
                clsobj.com = new SqlCommand("u_Struckup_Details", clsobj.con);
                clsobj.com.Connection = clsobj.con;
                clsobj.com.CommandType = CommandType.StoredProcedure;
                clsobj.com.Parameters.AddWithValue("@Serialno", txtserialno.Text);
                clsobj.com.Parameters.AddWithValue("@Regno", radMultiColumnComboBox1.Text);
                clsobj.com.Parameters.AddWithValue("@StdID", txtstudentid.Text);
                clsobj.com.Parameters.AddWithValue("@Stdname", txtstdname.Text);
                clsobj.com.Parameters.AddWithValue("@Fname", txtfname.Text);
                clsobj.com.Parameters.AddWithValue("@DOB", txtdob.Text);
                clsobj.com.Parameters.AddWithValue("@Age", txtage.Text);
                clsobj.com.Parameters.AddWithValue("@Inwords", txtinwords.Text);
                clsobj.com.Parameters.AddWithValue("@CClass", txtclass.Text);
                clsobj.com.Parameters.AddWithValue("@SDate", txtdate.Text);
                clsobj.com.Parameters.AddWithValue("@Descriptions", txtreasonofleaving.Text);

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

        private void deletionss()
        {

            try
            {
                clsobj.constate();
                clsobj.com = new SqlCommand("d_Struckup_Details", clsobj.con);
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

        private void radButton8_Click(object sender, EventArgs e)
        {
            slctall();
        }
        private void classauto()
        {
            try
            {
                clsobj.constate();
                clsobj.com = new SqlCommand("Select CClass from Struckup_Details Where CClass like '%" + txtsearchby.Text + "%'", clsobj.con);
                clsobj.com.Connection = clsobj.con;
                SqlDataReader dr = clsobj.com.ExecuteReader();
                while (dr.Read())
                {
                    txtsearchby.AutoCompleteCustomSource.Add(dr["CClass"].ToString());
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
                clsobj.com = new SqlCommand("Select * from Struckup_Details Where CClass like '%" + txtsearchby.Text + "%'", clsobj.con);
                clsobj.com.Connection = clsobj.con;
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(clsobj.com);
                da.Fill(ds);
                DataTable dt = ds.Tables[0];
                dataGridView2.DataSource = dt;
                clsobj.con.Close();
                classauto();
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
                clsobj.com = new SqlCommand("Select Stdname from Struckup_Details Where Stdname like '%" + txtsearchby.Text + "%'", clsobj.con);
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
                clsobj.com = new SqlCommand("Select * from Struckup_Details Where Stdname like '%" + txtsearchby.Text + "%'", clsobj.con);
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
        private void regauto()
        {
            try
            {
                clsobj.constate();
                clsobj.com = new SqlCommand("Select Regno from Struckup_Details Where Regno like '%" + txtsearchby.Text + "%'", clsobj.con);
                clsobj.com.Connection = clsobj.con;
                SqlDataReader dr = clsobj.com.ExecuteReader();
                while (dr.Read())
                {
                    txtsearchby.AutoCompleteCustomSource.Add(dr["Regno"].ToString());
                }
                clsobj.con.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        private void srchbyregno()
        {
            try
            {
                clsobj.constate();
                clsobj.com = new SqlCommand("Select * from Struckup_Details Where Regno like '%" + txtsearchby.Text + "%'", clsobj.con);
                clsobj.com.Connection = clsobj.con;
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(clsobj.com);
                da.Fill(ds);
                DataTable dt = ds.Tables[0];
                dataGridView2.DataSource = dt;
                clsobj.con.Close();
              regauto();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void txtsearchby_TextChanged(object sender, EventArgs e)
        {
            if (rdioclass.IsChecked == true)
            { srchbyclass(); }
            else if (rdioname.IsChecked == true)
            { srchbyname(); }
            else if (rdioregno.IsChecked == true)
            { srchbyregno(); }

        }

        private void senddata()
        {
            try
            {
                i = this.dataGridView2.SelectedCells[i].RowIndex;
                txtserialno.Text = this.dataGridView2.Rows[i].Cells[0].Value.ToString();
                radMultiColumnComboBox1.Text = this.dataGridView2.Rows[i].Cells[1].Value.ToString();
                txtstudentid.Text = this.dataGridView2.Rows[i].Cells[2].Value.ToString();
                txtstdname.Text = this.dataGridView2.Rows[i].Cells[3].Value.ToString();
                txtfname.Text = this.dataGridView2.Rows[i].Cells[4].Value.ToString();
                txtdob.Text = this.dataGridView2.Rows[i].Cells[5].Value.ToString();
                txtage.Text = this.dataGridView2.Rows[i].Cells[6].Value.ToString();
                txtinwords.Text = this.dataGridView2.Rows[i].Cells[7].Value.ToString();
                txtclass.Text = this.dataGridView2.Rows[i].Cells[8].Value.ToString();
                txtdate.Text = this.dataGridView2.Rows[i].Cells[9].Value.ToString();
                txtreasonofleaving.Text = this.dataGridView2.Rows[i].Cells[10].Value.ToString();

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
            radPageViewPage3.Hide();
        }

        private void dataGridView2_DoubleClick(object sender, EventArgs e)
        {
            senddata();
            radPageViewPage1.Show();
            radPageViewPage3.Hide();
        }

        private void radMultiColumnComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            slctstudent();
        }


        private void slctstudent()
        {
            try
            {
                clsobj.constate();
                clsobj.com = new SqlCommand("Select * from Students_Details Where Regno like '%" + radMultiColumnComboBox1.Text + "%'", clsobj.con);
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
                            txtstudentid.Text = dr["StdID"].ToString();
                            txtstdname.Text = dr["Stdname"].ToString();
                            txtfname.Text = dr["Fname"].ToString();
                            txtdob.Text = dr["DOB"].ToString();
                            txtage.Text = dr["Age"].ToString();
                            txtinwords.Text = dr["Inwords"].ToString();

                            txtclass.Text = dr["AdmittedinClass"].ToString();

                        }
                    }
                    Byte[] data = new Byte[0];
                    data = (Byte[])(ds.Tables[0].Rows[0]["Pics"]);
                    MemoryStream mem = new MemoryStream(data);
                    pictureBox1.Image = Image.FromStream(mem);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void radPageViewPage1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
