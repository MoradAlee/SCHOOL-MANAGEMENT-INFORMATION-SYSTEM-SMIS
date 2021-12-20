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
    public partial class Library_Membership_Details : Telerik.WinControls.UI.RadForm
    {
        public School_Management_System.DB_Connectivity.DB_Connection clsobj = new School_Management_System.DB_Connectivity.DB_Connection();
        int i;
        int sr;


        public Library_Membership_Details()
        {
            InitializeComponent();
        }

        private void Library_Membership_Details_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'school_Management_SystemDataSet.S_active_Students_Details' table. You can move, or remove it, as needed.
            
            this.s_active_Students_DetailsTableAdapter.Fill(this.school_Management_SystemDataSet.S_active_Students_Details);

            slctall();
            slctmax();
            txtjoiningdate.Text = DateTime.Today.ToShortDateString();
            txtduedate.Text = DateTime.Today.ToShortDateString();


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
                clsobj.com = new SqlCommand("S_Library_Member_Details", clsobj.con);
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
                clsobj.com = new SqlCommand("S_max_Library_Member_Details", clsobj.con);
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

        private void clr()
        {

            slctall();

            slctmax();

            txtaddress.Text = "";
            txtage.Text = "";
            txtcellno.Text = "";
            txtclass.Text = "";
            txtclassno.Text = "";
            txtdob.Text = "";
            txtduedate.Text = DateTime.Today.ToShortDateString();
            txtfname.Text = "";
            txtgender.Text = "";
            txtjoiningdate.Text = DateTime.Today.ToShortDateString();
            txtstdid.Text = "";
            txtstdname.Text = "";
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
                clsobj.com = new SqlCommand("i_Library_Member_Details", clsobj.con);
                clsobj.com.Connection = clsobj.con;
                clsobj.com.CommandType = CommandType.StoredProcedure;
                clsobj.com.Parameters.AddWithValue("@Serialno",txtserialno.Text );
                clsobj.com.Parameters.AddWithValue("@StdID",txtstdid.Text );
                clsobj.com.Parameters.AddWithValue("@Regno",radMultiColumnComboBox1.Text );
                clsobj.com.Parameters.AddWithValue("@Stdname",txtstdname.Text );
                clsobj.com.Parameters.AddWithValue("@Fname",txtfname.Text );
                clsobj.com.Parameters.AddWithValue("@DOB",txtdob.Text );
                clsobj.com.Parameters.AddWithValue("@Age",txtage.Text );
                clsobj.com.Parameters.AddWithValue("@Gender",txtgender.Text );
                clsobj.com.Parameters.AddWithValue("@Address",txtaddress.Text );
                clsobj.com.Parameters.AddWithValue("@Classname",txtclass.Text );
                clsobj.com.Parameters.AddWithValue("@Classno",txtclassno.Text );
                clsobj.com.Parameters.AddWithValue("@Cellno",txtcellno.Text );
                clsobj.com.Parameters.AddWithValue("@JoiningDate",txtjoiningdate.Text );
                clsobj.com.Parameters.AddWithValue("@DueDate",txtduedate.Text );
                clsobj.com.Parameters.AddWithValue("@IsActive",chkisactive.CheckState );
                clsobj.com.ExecuteNonQuery();
                MsgsSaved msgs=new MsgsSaved();
                msgs.ShowDialog();
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
                clsobj.com = new SqlCommand("u_Library_Member_Details", clsobj.con);
                clsobj.com.Connection = clsobj.con;
                clsobj.com.CommandType = CommandType.StoredProcedure;
                clsobj.com.Parameters.AddWithValue("@Serialno", txtserialno.Text);
                clsobj.com.Parameters.AddWithValue("@StdID", txtstdid.Text);
                clsobj.com.Parameters.AddWithValue("@Regno", radMultiColumnComboBox1.Text);
                clsobj.com.Parameters.AddWithValue("@Stdname", txtstdname.Text);
                clsobj.com.Parameters.AddWithValue("@Fname", txtfname.Text);
                clsobj.com.Parameters.AddWithValue("@DOB", txtdob.Text);
                clsobj.com.Parameters.AddWithValue("@Age", txtage.Text);
                clsobj.com.Parameters.AddWithValue("@Gender", txtgender.Text);
                clsobj.com.Parameters.AddWithValue("@Address", txtaddress.Text);
                clsobj.com.Parameters.AddWithValue("@Classname", txtclass.Text);
                clsobj.com.Parameters.AddWithValue("@Classno", txtclassno.Text);
                clsobj.com.Parameters.AddWithValue("@Cellno", txtcellno.Text);
                clsobj.com.Parameters.AddWithValue("@JoiningDate", txtjoiningdate.Text);
                clsobj.com.Parameters.AddWithValue("@DueDate", txtduedate.Text);
                clsobj.com.Parameters.AddWithValue("@IsActive", chkisactive.CheckState);
                clsobj.com.ExecuteNonQuery();
                MsgsUpdations msgs = new MsgsUpdations();
                msgs.ShowDialog();
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
                clsobj.com = new SqlCommand("d_Library_Member_Details", clsobj.con);
                clsobj.com.Connection = clsobj.con;
                clsobj.com.CommandType = CommandType.StoredProcedure;
                clsobj.com.Parameters.AddWithValue("@Serialno", txtserialno.Text);
           
                clsobj.com.ExecuteNonQuery();
                MsgsDeletions msgs = new MsgsDeletions();
                msgs.ShowDialog();
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

        private void feeauto()
        {
            try
            {
                clsobj.constate();
                clsobj.com = new SqlCommand("Select Classname from Library_Members_Details Where Classname like '%" + txtsearchby.Text + "%'", clsobj.con);
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
                clsobj.com = new SqlCommand("Select * from Library_Members_Details Where Classname like '%" + txtsearchby.Text + "%'", clsobj.con);
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
        private void nameauto()
        {
            try
            {
                clsobj.constate();
                clsobj.com = new SqlCommand("Select Stdname from Library_Members_Details Where Stdname like '%" + txtsearchby.Text + "%'", clsobj.con);
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
                clsobj.com = new SqlCommand("Select * from Library_Members_Details Where Stdname like '%" + txtsearchby.Text + "%'", clsobj.con);
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
        private void srchbyregno()
        {

            try
            {
                clsobj.constate();
                clsobj.com = new SqlCommand("Select * from Library_Members_Details Where Regno like '%" + txtsearchby.Text + "%'", clsobj.con);
                clsobj.com.Connection = clsobj.con;
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(clsobj.com);
                da.Fill(ds);
                DataTable dt = ds.Tables[0];
                dataGridView1.DataSource = dt;
                clsobj.con.Close();
                regauto();
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
                clsobj.com = new SqlCommand("Select Regno from Library_Members_Details Where Regno like '%" + txtsearchby.Text + "%'", clsobj.con);
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
                i = this.dataGridView1.SelectedCells[i].RowIndex;
                txtserialno.Text = this.dataGridView1.Rows[i].Cells[0].Value.ToString();
                txtstdid.Text = this.dataGridView1.Rows[i].Cells[1].Value.ToString();
                radMultiColumnComboBox1.Text = this.dataGridView1.Rows[i].Cells[2].Value.ToString();
                txtstdname.Text = this.dataGridView1.Rows[i].Cells[3].Value.ToString();
                txtfname.Text = this.dataGridView1.Rows[i].Cells[4].Value.ToString();
                txtdob.Text = this.dataGridView1.Rows[i].Cells[5].Value.ToString();
                txtage.Text = this.dataGridView1.Rows[i].Cells[6].Value.ToString();
                txtgender.Text = this.dataGridView1.Rows[i].Cells[7].Value.ToString();
                txtaddress.Text = this.dataGridView1.Rows[i].Cells[8].Value.ToString();
                txtclass.Text = this.dataGridView1.Rows[i].Cells[9].Value.ToString();
                txtclassno.Text = this.dataGridView1.Rows[i].Cells[10].Value.ToString();
                txtcellno.Text = this.dataGridView1.Rows[i].Cells[11].Value.ToString();
                txtjoiningdate.Text = this.dataGridView1.Rows[i].Cells[12].Value.ToString();
                txtduedate.Text = this.dataGridView1.Rows[i].Cells[13].Value.ToString();
                chkisactive.Checked = Convert.ToBoolean(this.dataGridView1.Rows[i].Cells[14].Value.ToString());

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
                            txtstdid.Text = dr["StdID"].ToString();
                            txtstdname.Text = dr["Stdname"].ToString();
                            txtfname.Text = dr["Fname"].ToString();
                            txtdob.Text = dr["DOB"].ToString();
                            txtage.Text = dr["Age"].ToString();

                            txtgender.Text = dr["Gender"].ToString();
                            txtclass.Text = dr["AdmittedinClass"].ToString();
                            txtclassno.Text = dr["Classno"].ToString();
                       
                            txtaddress.Text = dr["PermAddress"].ToString();
                            txtcellno.Text = dr["Contactno"].ToString();
                           


                           

                            
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

        private void radMultiColumnComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            slctstudent();
        }
    }
}
