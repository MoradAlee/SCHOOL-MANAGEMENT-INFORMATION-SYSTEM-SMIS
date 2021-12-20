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
    public partial class Overtime_Details : Telerik.WinControls.UI.RadForm
    {
        public School_Management_System.DB_Connectivity.DB_Connection clsobj = new School_Management_System.DB_Connectivity.DB_Connection();
        int i;
        int sr;


        public Overtime_Details()
        {
            InitializeComponent();
        }
        private void slctall()
        {
            try
            {
                clsobj.constate();
                clsobj.com = new SqlCommand("s_Overtime_Details", clsobj.con);
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
                clsobj.com = new SqlCommand("s_MAX_Overtime_Details", clsobj.con);
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

        private void Overtime_Details_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'school_Management_SystemDataSet.s_active_Employee_Details' table. You can move, or remove it, as needed.
            this.s_active_Employee_DetailsTableAdapter.Fill(this.school_Management_SystemDataSet.s_active_Employee_Details);

            txtdate.Text = DateTime.Today.ToShortDateString();

            slctall();
            slctmax();

            cmbomonth.Items.Add("--Select Month--");
            cmbomonth.Items.Add("January");
            cmbomonth.Items.Add("February");
            cmbomonth.Items.Add("March");
            cmbomonth.Items.Add("April");
            cmbomonth.Items.Add("May");
            cmbomonth.Items.Add("June");
            cmbomonth.Items.Add("July");
            cmbomonth.Items.Add("August");
            cmbomonth.Items.Add("September");
            cmbomonth.Items.Add("October");
            cmbomonth.Items.Add("November");
            cmbomonth.Items.Add("December");

            cmbomonth.SelectedIndex = 0;

        }

        private void radButton5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void clr()
        {
            slctall();

            slctmax();

            txtdate.Text = DateTime.Today.ToShortDateString();
            txtdescritpions.Text = "";
            txtempid.Text = "";
            txttotime.Text = "";
            txtfromtime.Text = "";
            txtnettime.Text = "";
            pictureBox2.Image = null;

            cmbomonth.SelectedIndex = 0;



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
                clsobj.com = new SqlCommand("i_Overtime_Details", clsobj.con);
                clsobj.com.Connection = clsobj.con;
                clsobj.com.CommandType = CommandType.StoredProcedure;
                clsobj.com.Parameters.AddWithValue("@Serialno",txtserialno.Text );
                clsobj.com.Parameters.AddWithValue("@EmpID",txtempid.Text );
                clsobj.com.Parameters.AddWithValue("@Empname",radMultiColumnComboBox1.Text );
                clsobj.com.Parameters.AddWithValue("@FromTime",txtfromtime.Text );
                clsobj.com.Parameters.AddWithValue("@ToTime",txttotime.Text );
                clsobj.com.Parameters.AddWithValue("@NetTime",txtnettime.Text );
                clsobj.com.Parameters.AddWithValue("@Descriptions",txtdescritpions.Text );
                clsobj.com.Parameters.AddWithValue("@ODate",txtdate.Text );
                clsobj.com.Parameters.AddWithValue("@Formonth",cmbomonth.Text );
         
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
                clsobj.com = new SqlCommand("u_Overtime_Details", clsobj.con);
                clsobj.com.Connection = clsobj.con;
                clsobj.com.CommandType = CommandType.StoredProcedure;
                clsobj.com.Parameters.AddWithValue("@Serialno", txtserialno.Text);
                clsobj.com.Parameters.AddWithValue("@EmpID", txtempid.Text);
                clsobj.com.Parameters.AddWithValue("@Empname", radMultiColumnComboBox1.Text);
                clsobj.com.Parameters.AddWithValue("@FromTime", txtfromtime.Text);
                clsobj.com.Parameters.AddWithValue("@ToTime", txttotime.Text);
                clsobj.com.Parameters.AddWithValue("@NetTime", txtnettime.Text);
                clsobj.com.Parameters.AddWithValue("@Descriptions", txtdescritpions.Text);
                clsobj.com.Parameters.AddWithValue("@ODate", txtdate.Text);
                clsobj.com.Parameters.AddWithValue("@Formonth", cmbomonth.Text);

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
                clsobj.com = new SqlCommand("d_Overtime_Details", clsobj.con);
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

        private void txttotime_TextChanged(object sender, EventArgs e)
        {
            try
            {
                
            if (txtfromtime.Text == "")
            {
                txtfromtime.Text = "0";
            }
            else if (txttotime.Text == "")
            { txttotime.Text = "0"; }
            double ft;
            double tt;
            ft = Convert.ToDouble(txtfromtime.Text);
            tt = Convert.ToDouble(txttotime.Text);
            double rxlt;
           
            if (ft > tt)
            {

                switch (txtfromtime.Text)
                {
                    case "8.00":
                        rxlt = 4.00 + Convert.ToDouble(txttotime.Text);
                        txtnettime.Text = rxlt.ToString();
                        break;
                    case "9.00":
                        rxlt = 3.00 + Convert.ToDouble(txttotime.Text);
                        txtnettime.Text = rxlt.ToString();
                        break;

                    case "10.00":
                        rxlt = 2.00 + Convert.ToDouble(txttotime.Text);
                        txtnettime.Text = rxlt.ToString();
                        break;
                    case "11.00":
                        rxlt = 1.00 + Convert.ToDouble(txttotime.Text);
                        txtnettime.Text = rxlt.ToString();
                        break;
                    case "12.00":
                        rxlt = 0.00 + Convert.ToDouble(txttotime.Text);
                        txtnettime.Text = rxlt.ToString();
                        break;

                }
            }
            else if (ft <= tt)
            {
               
                  
                        rxlt = Convert.ToDouble(txttotime.Text) - Convert.ToDouble(txtfromtime.Text);
                        txtnettime.Text = rxlt.ToString();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void slctemployee()
        { 
        try
            {
                clsobj.constate();
                clsobj.com = new SqlCommand("Select * from Employee_Details Where Empname like '%" + radMultiColumnComboBox1.Text + "%'", clsobj.con);
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
                            txtempid.Text = dr["EmpID"].ToString();
                         //   txtdescriptiins.Text = dr["Descriptions"].ToString();

                       }
                        Byte[] data = new Byte[0];
                        data = (Byte[])(ds.Tables[0].Rows[0]["Pics"]);
                        MemoryStream mem = new MemoryStream(data);
                        pictureBox2.Image = Image.FromStream(mem);
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
            slctemployee();
        }

        private void radButton6_Click(object sender, EventArgs e)
        {
            slctall();
        }
        private void monthauto()
        {
            try
            {
                clsobj.constate();
                clsobj.com = new SqlCommand("Select Formonth from Overtime_Details Where Formonth like '%" + txtsearchby.Text + "%'", clsobj.con);
                clsobj.com.Connection = clsobj.con;
                SqlDataReader dr = clsobj.com.ExecuteReader();
                while (dr.Read())
                {
                    txtsearchby.AutoCompleteCustomSource.Add(dr["Formonth"].ToString());
                }
                clsobj.con.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);

            }
        }
        private void srchbymonth()
        {
            try
            {
                clsobj.constate();
                clsobj.com = new SqlCommand("Select * from Overtime_Details Where Formonth like '%" + txtsearchby.Text + "%'", clsobj.con);
                clsobj.com.Connection = clsobj.con;
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(clsobj.com);
                da.Fill(ds);
                DataTable dt = ds.Tables[0];
                dataGridView1.DataSource = dt;
                clsobj.con.Close();
                monthauto();
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
                clsobj.com = new SqlCommand("Select * from Overtime_Details Where Empname like '%" + txtsearchby.Text + "%'", clsobj.con);
                clsobj.com.Connection = clsobj.con;
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(clsobj.com);
                da.Fill(ds);
                DataTable dt = ds.Tables[0];
                dataGridView1.DataSource = dt;
                clsobj.con.Close();
                empauto();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);

            }
        }
        private void empauto()
        {
            try
            {
                clsobj.constate();
                clsobj.com = new SqlCommand("Select Empname from Overtime_Details Where Empname like '%" + txtsearchby.Text + "%'", clsobj.con);
                clsobj.com.Connection = clsobj.con;
                SqlDataReader dr = clsobj.com.ExecuteReader();
                while (dr.Read())
                {
                    txtsearchby.AutoCompleteCustomSource.Add(dr["Empname"].ToString());
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
            if (rdiomonth.IsChecked == true)
            {
                srchbymonth();
            }
            else if (rdioname.IsChecked == true)
            {
    srchbyname();
            }
        }

        private void senddata()
        {
            try
            {
                i = this.dataGridView1.SelectedCells[i].RowIndex;
                txtserialno.Text = this.dataGridView1.Rows[i].Cells[0].Value.ToString();
                txtempid.Text = this.dataGridView1.Rows[i].Cells[1].Value.ToString();
                radMultiColumnComboBox1.Text = this.dataGridView1.Rows[i].Cells[2].Value.ToString();
                txtfromtime.Text = this.dataGridView1.Rows[i].Cells[3].Value.ToString();
                txttotime.Text = this.dataGridView1.Rows[i].Cells[4].Value.ToString();
                txtnettime.Text = this.dataGridView1.Rows[i].Cells[5].Value.ToString();
                txtdescritpions.Text = this.dataGridView1.Rows[i].Cells[6].Value.ToString();
                txtdate.Text = this.dataGridView1.Rows[i].Cells[7].Value.ToString();
                cmbomonth.Text = this.dataGridView1.Rows[i].Cells[8].Value.ToString();

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
