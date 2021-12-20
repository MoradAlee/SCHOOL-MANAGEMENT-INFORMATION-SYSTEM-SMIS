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
using System.Drawing.Imaging;

namespace School_Management_System.UI
{
    public partial class Transport_Membership_Details : Telerik.WinControls.UI.RadForm
    {
        public School_Management_System.DB_Connectivity.DB_Connection clsobj = new School_Management_System.DB_Connectivity.DB_Connection();
        int i;

        public Transport_Membership_Details()
        {
            InitializeComponent();
        }

        private void Hostel_Membership_Details_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'school_Management_SystemDataSet.s_active_Bus_Details' table. You can move, or remove it, as needed.
            this.s_active_Bus_DetailsTableAdapter.Fill(this.school_Management_SystemDataSet.s_active_Bus_Details);
            // TODO: This line of code loads data into the 'school_Management_SystemDataSet.s_active_Room_Details' table. You can move, or remove it, as needed.
            this.s_active_Room_DetailsTableAdapter.Fill(this.school_Management_SystemDataSet.s_active_Room_Details);
            // TODO: This line of code loads data into the 'school_Management_SystemDataSet.S_active_Students_Details' table. You can move, or remove it, as needed.
            this.s_active_Students_DetailsTableAdapter.Fill(this.school_Management_SystemDataSet.S_active_Students_Details);

            txtdate.Text = DateTime.Today.ToShortDateString();
            slctall();
            slctmax();

        }
        private void slctmax()
        {
            try
            {
                clsobj.constate();
                clsobj.com = new SqlCommand("s_MAX_Transport_Membership_Details", clsobj.con);
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
        private void slctall()
        {
            try
            {
                clsobj.constate();
                clsobj.com = new SqlCommand("s_Transport_Membership_Details", clsobj.con);
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
        private void slctstudet()
        {
            try
            {
                clsobj.constate();
                clsobj.com = new SqlCommand("Select * from Students_Details Where Regno like '%" + radMultiColumnComboBox1.Text + "%'", clsobj.con);
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

                            txtstudentid.Text = dr["StdID"].ToString();
                            txtstdname.Text = dr["Stdname"].ToString();
                            txtfname.Text = dr["Fname"].ToString();
                            txtaddress.Text = dr["PermAddress"].ToString();
                            //  txtcontactno.Text = dr["Contactno"].ToString();


                        }
                    }
                    Byte[] data = new Byte[0];
                    data = (Byte[])(ds.Tables[0].Rows[0]["Pics"]);
                    MemoryStream mem = new MemoryStream(data);
                    pictureBox1.Image = Image.FromStream(mem);
                    clsobj.con.Close();
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

        private void slctbus()
        {
            try
            {
                clsobj.constate();
                clsobj.com = new SqlCommand("Select * from Bus_Details Where Busno like '%" + radMultiColumnComboBox2.Text + "%'", clsobj.con);
                clsobj.com.Connection = clsobj.con;
                SqlDataReader dr = clsobj.com.ExecuteReader();

                while (dr.Read())
                {

                    txtbusid.Text = dr["BusID"].ToString();
                    txtnoofseats.Text = dr["SeatsRemained"].ToString();
               //   txtrmndseats.Text  = dr[""].ToString();
                    txtroute.Text = dr["BRoute"].ToString();
                    //  txtcontactno.Text = dr["Contactno"].ToString();


                }

                clsobj.con.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void radMultiColumnComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            slctbus();
        }


        private void radButton6_Click(object sender, EventArgs e)
        {
            slctall();
        }
     
          private void nameauto()
        {
            try
            {
                clsobj.constate();
                clsobj.com = new SqlCommand("Select Stdname from Transport_Membership_Details Where Stdname like '%" + txtsearchby.Text + "%'", clsobj.con);
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
                clsobj.com = new SqlCommand("Select * from Transport_Membership_Details Where Stdname like '%" + txtsearchby.Text + "%'", clsobj.con);
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

        private void busauto()
        {
            try
            {
                clsobj.constate();
                clsobj.com = new SqlCommand("Select Busno from Transport_Membership_Details Where Busno like '%" + txtsearchby.Text + "%'", clsobj.con);
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

        private void srchbybusno()
        {
            try
            {
                clsobj.constate();
                clsobj.com = new SqlCommand("Select * from Transport_Membership_Details Where Busno like '%" + txtsearchby.Text + "%'", clsobj.con);
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
        private void txtsearchby_TextChanged(object sender, EventArgs e)
        {
            if (rdiobusno.IsChecked == true)
            { srchbybusno(); }
            else if (rdioname.IsChecked == true)
            { srchbyname(); }
        }

        private void senddata()
        {
            try
            {
                i = this.dataGridView1.SelectedCells[i].RowIndex;
                txtserialno.Text = this.dataGridView1.Rows[i].Cells[0].Value.ToString();
                txtstudentid.Text = this.dataGridView1.Rows[i].Cells[1].Value.ToString();
                radMultiColumnComboBox1.Text = this.dataGridView1.Rows[i].Cells[2].Value.ToString();
                txtstdname.Text = this.dataGridView1.Rows[i].Cells[3].Value.ToString();
                txtfname.Text = this.dataGridView1.Rows[i].Cells[4].Value.ToString();
                txtaddress.Text = this.dataGridView1.Rows[i].Cells[5].Value.ToString();
                txtbusid.Text = this.dataGridView1.Rows[i].Cells[6].Value.ToString();
                radMultiColumnComboBox2.Text = this.dataGridView1.Rows[i].Cells[7].Value.ToString();
                txtnoofseats.Text = this.dataGridView1.Rows[i].Cells[8].Value.ToString();
                txtrmndseats.Text = this.dataGridView1.Rows[i].Cells[9].Value.ToString();
                txtroute.Text = this.dataGridView1.Rows[i].Cells[10].Value.ToString();
                txtdescriptions.Text = this.dataGridView1.Rows[i].Cells[11].Value.ToString();
                txtdate.Text = this.dataGridView1.Rows[i].Cells[12].Value.ToString();

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

        private void insertionss()
        {
            try
            {
                clsobj.constate();
                clsobj.com = new SqlCommand("i_Transport_Membership_Details", clsobj.con);
                clsobj.com.Connection = clsobj.con;
                clsobj.com.CommandType = CommandType.StoredProcedure;
                clsobj.com.Parameters.AddWithValue("@StdID",txtstudentid.Text );
                clsobj.com.Parameters.AddWithValue("@Regno",radMultiColumnComboBox1.Text );
                clsobj.com.Parameters.AddWithValue("@Stdname",txtstdname.Text );
                clsobj.com.Parameters.AddWithValue("@Fname",txtfname.Text );
                clsobj.com.Parameters.AddWithValue("@Address",txtaddress.Text );
                clsobj.com.Parameters.AddWithValue("@BusID",txtbusid.Text );
                clsobj.com.Parameters.AddWithValue("@Busno",radMultiColumnComboBox2.Text );
                clsobj.com.Parameters.AddWithValue("@NoofSeats",txtrmndseats.Text );
                clsobj.com.Parameters.AddWithValue("@SeatsRemained",txtnoofseats.Text );
                clsobj.com.Parameters.AddWithValue("@Route",txtroute.Text );
                clsobj.com.Parameters.AddWithValue("@Descriptions",txtdescriptions.Text );
                clsobj.com.Parameters.AddWithValue("@JDate",txtdate.Text );
            
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

        private void clr()
        {
            slctall();

            slctmax();

            txtstudentid.Text = "";
            txtstdname.Text = "";
            txtroute.Text = "";
            txtrmndseats.Text = "";
            txtnoofseats.Text = "";
            txtfname.Text = "";
            txtdescriptions.Text = "";
            txtdate.Text = DateTime.Today.ToShortDateString();
            txtbusid.Text = "";
            txtaddress.Text = "";
        
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            insertionss();
        }

        private void radButton2_Click(object sender, EventArgs e)
        {
            updationss();
        }
        private void updationss()
        {
            try
            {
                clsobj.constate();
                clsobj.com = new SqlCommand("u_Transport_Membership_Details", clsobj.con);
                clsobj.com.Connection = clsobj.con;
                clsobj.com.CommandType = CommandType.StoredProcedure;
                clsobj.com.Parameters.AddWithValue("@Serialno", txtserialno.Text);
                clsobj.com.Parameters.AddWithValue("@StdID", txtstudentid.Text);
                clsobj.com.Parameters.AddWithValue("@Regno", radMultiColumnComboBox1.Text);
                clsobj.com.Parameters.AddWithValue("@Stdname", txtstdname.Text);
                clsobj.com.Parameters.AddWithValue("@Fname", txtfname.Text);
                clsobj.com.Parameters.AddWithValue("@Address", txtaddress.Text);
                clsobj.com.Parameters.AddWithValue("@BusID", txtbusid.Text);
                clsobj.com.Parameters.AddWithValue("@Busno", radMultiColumnComboBox2.Text);
                clsobj.com.Parameters.AddWithValue("@NoofSeats", txtrmndseats.Text);
                clsobj.com.Parameters.AddWithValue("@SeatsRemained", txtnoofseats.Text);
                clsobj.com.Parameters.AddWithValue("@Route", txtroute.Text);
                clsobj.com.Parameters.AddWithValue("@Descriptions", txtdescriptions.Text);
                clsobj.com.Parameters.AddWithValue("@JDate", txtdate.Text);

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

        private void deletionss()
        {
            try
            {
                clsobj.constate();
                clsobj.com = new SqlCommand("u_Transport_Membership_Details", clsobj.con);
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

        private void radButton4_Click(object sender, EventArgs e)
        {
            clr();
        }

        private void txtstdname_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtstdname.Text == "")
                {
                    txtstdname.Text = "";

                }

                else
                {
                    try
                    {
                        string barcode = txtstdname.Text;

                        Bitmap bitmap = new Bitmap(barcode.Length * 40, 150);

                        using (Graphics grpahics = Graphics.FromImage(bitmap))
                        {

                            Font ofont = new System.Drawing.Font("IDAutomationHC39M", 20);


                            PointF point = new PointF(2f, 2f);

                            SolidBrush black = new SolidBrush(Color.Black);

                            SolidBrush White = new SolidBrush(Color.White);

                            grpahics.FillRectangle(White, 0, 0, bitmap.Width, bitmap.Height);

                            grpahics.DrawString("*" + barcode + "*", ofont, black, point);
                        }
                        using (MemoryStream ms = new MemoryStream())
                        {
                            bitmap.Save(ms, ImageFormat.Png);

                            pictureBox2.Image = bitmap;

                            pictureBox2.Height = bitmap.Height;

                            pictureBox2.Width = bitmap.Width;


                        }
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}