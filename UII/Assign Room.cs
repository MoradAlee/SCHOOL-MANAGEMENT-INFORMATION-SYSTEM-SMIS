using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using System.IO;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing.Imaging;

namespace School_Management_System.UI
{
    public partial class Assign_Room : Telerik.WinControls.UI.RadForm
    {
        public School_Management_System.DB_Connectivity.DB_Connection clsobj = new School_Management_System.DB_Connectivity.DB_Connection();
        int i,sr;
        int rms, noos,rxlt;


        public Assign_Room()
        {
            InitializeComponent();
        }

        private void radButton5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void radButton4_Click(object sender, EventArgs e)
        {
            clr();
        }
        private void clr()
        {
            slctmax();
            
            scltall();


            txtaddress.Text = "";
            txtcontactno.Text = "";
            txtdescritpions.Text = "";
            txtfname.Text = "";
            txtnoofseats.Text = "";
            txtremainedseats.Text = "";
            txtroomid.Text = "";
            txtstudentid.Text = "";
            chkisactive.Checked = false;
            txtstdname.Text = "";


        }
        private void slctmax()
        {
            try
            {
 clsobj.constate();
                clsobj.com = new SqlCommand("s_MAX_Room_Assign_Details", clsobj.con);
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


        private void Assign_Room_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'school_Management_SystemDataSet.S_active_Students_Details' table. You can move, or remove it, as needed.
            this.s_active_Students_DetailsTableAdapter.Fill(this.school_Management_SystemDataSet.S_active_Students_Details);
            // TODO: This line of code loads data into the 'school_Management_SystemDataSet.s_active_Room_Details' table. You can move, or remove it, as needed.
            this.s_active_Room_DetailsTableAdapter.Fill(this.school_Management_SystemDataSet.s_active_Room_Details);

            slctmax();

            scltall();


        }

        private void scltall()
        {
            try
            {
                  clsobj.constate();
                clsobj.com = new SqlCommand("s_Room_Assign_Details", clsobj.con);
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

        private void slctroomno()
        {

            try
            {
                clsobj.constate();
                clsobj.com = new SqlCommand("Select * from Room_Details Where Roomno like '%" + radMultiColumnComboBox1.Text + "%'", clsobj.con);
                clsobj.com.Connection = clsobj.con;
                SqlDataReader dr = clsobj.com.ExecuteReader();

                while (dr.Read())
                {

                    txtroomid.Text = dr["RoomID"].ToString();
                    txtremainedseats.Text = dr["RemainedSeats"].ToString();

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
            slctroomno();
        }

        private void slctstudet()
        {
            try
            {
                 clsobj.constate();
                 clsobj.com = new SqlCommand("Select * from Students_Details Where Regno like '%" + radMultiColumnComboBox2.Text + "%'", clsobj.con);
                clsobj.com.Connection = clsobj.con;
                SqlDataReader dr = clsobj.com.ExecuteReader();
               
                    while (dr.Read())
                    {

                        txtstudentid.Text = dr["StdID"].ToString();
                        txtstdname.Text = dr["Stdname"].ToString();
                        txtfname.Text = dr["Fname"].ToString();
                        txtaddress.Text = dr["PermAddress"].ToString();
                        txtcontactno.Text = dr["Contactno"].ToString();


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
            slctstudet();
        }

        private void radButton6_Click(object sender, EventArgs e)
        {
            scltall();

        }

        private void insertionss()
        {
            try
            {
                clsobj.constate();
                clsobj.com = new SqlCommand("i_Room_Assign_Details", clsobj.con);
                clsobj.com.Connection = clsobj.con;
                clsobj.com.CommandType = CommandType.StoredProcedure;
                clsobj.com.Parameters.AddWithValue("@Serialno",txtserialno.Text );
                clsobj.com.Parameters.AddWithValue("@RoomID",txtroomid.Text );
                clsobj.com.Parameters.AddWithValue("@StdID",txtstudentid.Text );
                clsobj.com.Parameters.AddWithValue("@Regno",radMultiColumnComboBox2.Text );
                clsobj.com.Parameters.AddWithValue("@Roomno",radMultiColumnComboBox1.Text );
                clsobj.com.Parameters.AddWithValue("@NoofSeats",txtnoofseats.Text );
                clsobj.com.Parameters.AddWithValue("@RemainedSeats",txtremainedseats.Text );
                clsobj.com.Parameters.AddWithValue("@Stdname",txtstdname.Text );
                clsobj.com.Parameters.AddWithValue("@Fname",txtfname.Text );
                clsobj.com.Parameters.AddWithValue("@Address",txtaddress.Text );
                clsobj.com.Parameters.AddWithValue("@Cellno",txtcontactno.Text );
                clsobj.com.Parameters.AddWithValue("@Descriptions",txtdescritpions.Text );
                clsobj.com.Parameters.AddWithValue("@Status",chkisactive.CheckState );
                clsobj.com.ExecuteNonQuery();
                MsgsSaved msgs = new MsgsSaved();
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
            updd();
        }
        private void updd()
        {
            try
            {
                clsobj.constate();
                clsobj.com = new SqlCommand("Update Room_Details Set RemainedSeats=" + txtremainedseats.Text + " Where RoomID=" + txtroomid.Text + " and Roomno='" + radMultiColumnComboBox1.Text + "'", clsobj.con);
                clsobj.com.Connection = clsobj.con;
                clsobj.com.Parameters.AddWithValue("@RoomID", txtroomid.Text);
                clsobj.com.Parameters.AddWithValue("@Roomno", radMultiColumnComboBox1.Text);
                clsobj.com.ExecuteNonQuery();
                clsobj.con.Close();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);

            }
        }
        private void updationss()
        { 
        try
            {
                clsobj.constate();
                clsobj.com = new SqlCommand("u_Room_Assign_Details", clsobj.con);
                clsobj.com.Connection = clsobj.con;
                clsobj.com.CommandType = CommandType.StoredProcedure;
                clsobj.com.Parameters.AddWithValue("@Serialno",txtserialno.Text );
                clsobj.com.Parameters.AddWithValue("@RoomID",txtroomid.Text );
                clsobj.com.Parameters.AddWithValue("@StdID",txtstudentid.Text );
                clsobj.com.Parameters.AddWithValue("@Regno",radMultiColumnComboBox2.Text );
                clsobj.com.Parameters.AddWithValue("@Roomno",radMultiColumnComboBox1.Text );
                clsobj.com.Parameters.AddWithValue("@NoofSeats",txtnoofseats.Text );
                clsobj.com.Parameters.AddWithValue("@RemainedSeats",txtremainedseats.Text );
                clsobj.com.Parameters.AddWithValue("@Stdname",txtstdname.Text );
                clsobj.com.Parameters.AddWithValue("@Fname",txtfname.Text );
                clsobj.com.Parameters.AddWithValue("@Address",txtaddress.Text );
                clsobj.com.Parameters.AddWithValue("@Cellno",txtcontactno.Text );
                clsobj.com.Parameters.AddWithValue("@Descriptions",txtdescritpions.Text );
                clsobj.com.Parameters.AddWithValue("@Status",chkisactive.CheckState );
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
            updd();
        }

        private void deletionss()
        {
            try
            {
                clsobj.constate();
                clsobj.com = new SqlCommand("d_Room_Assign_Details", clsobj.con);
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
            updd();
        }

        private void senddata()
        {
            try
            {
                i = this.dataGridView1.SelectedCells[i].RowIndex;
                txtserialno.Text = this.dataGridView1.Rows[i].Cells[0].Value.ToString();
                txtroomid.Text = this.dataGridView1.Rows[i].Cells[1].Value.ToString();
                txtstudentid.Text = this.dataGridView1.Rows[i].Cells[2].Value.ToString();
                radMultiColumnComboBox2.Text = this.dataGridView1.Rows[i].Cells[3].Value.ToString();
                radMultiColumnComboBox1.Text = this.dataGridView1.Rows[i].Cells[4].Value.ToString();
                txtnoofseats.Text = this.dataGridView1.Rows[i].Cells[5].Value.ToString();
                txtremainedseats.Text = this.dataGridView1.Rows[i].Cells[6].Value.ToString();
                txtstdname.Text = this.dataGridView1.Rows[i].Cells[7].Value.ToString();
                txtfname.Text = this.dataGridView1.Rows[i].Cells[8].Value.ToString();
                txtaddress.Text = this.dataGridView1.Rows[i].Cells[9].Value.ToString();
                txtcontactno.Text = this.dataGridView1.Rows[i].Cells[10].Value.ToString();
                txtdescritpions.Text = this.dataGridView1.Rows[i].Cells[11].Value.ToString();
                chkisactive.Checked = Convert.ToBoolean(dataGridView1.Rows[i].Cells[12].Value.ToString());
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

        private void txtnoofseats_TextChanged(object sender, EventArgs e)
        {

           

        }

        private void chkisactive_CheckedChanged(object sender, EventArgs e)
        {

            try

            {


                if (chkisactive.Checked == true)
                {
                    if (txtnoofseats.Text == "")
                    {

                        txtnoofseats.Text = "0";

                    }

                    else if (txtremainedseats.Text == "")
                    {
                        txtremainedseats.Text = "0";
                    }
                    else if (Convert.ToInt32(txtremainedseats.Text) <= 2)
                    {
                        MessageBox.Show("Remained Seats must be checked!!!", "School Says", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    }
                    else
                    {
                        rms = Convert.ToInt32(txtremainedseats.Text);
                        noos = Convert.ToInt32(txtnoofseats.Text);
                        rxlt = Convert.ToInt32(rms - noos);
                        txtremainedseats.Text = rxlt.ToString();

                    }
                }
                else
                {
                    if (txtnoofseats.Text == "")
                    {

                        txtnoofseats.Text = "0";

                    }

                    else if (txtremainedseats.Text == "")
                    {
                        txtremainedseats.Text = "0";
                    }
                    else if (Convert.ToInt32(txtremainedseats.Text) <= 2)
                    {
                        MessageBox.Show("Remained Seats must be checked!!!", "School Says", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    }
                    else
                    {
                        rms = Convert.ToInt32(txtremainedseats.Text);
                        noos = Convert.ToInt32(txtnoofseats.Text);
                        rxlt = Convert.ToInt32(rms + noos);
                        txtremainedseats.Text = rxlt.ToString();

                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void mobileauto()
        {
            try
            {
                clsobj.constate();
                clsobj.com = new SqlCommand("Select Cellno from Room_Assign_Details Where Cellno like '%" + txtsearchby.Text + "%'", clsobj.con);
                clsobj.com.Connection = clsobj.con;
                SqlDataReader dr = clsobj.com.ExecuteReader();
                while (dr.Read())
                {
                    txtsearchby.AutoCompleteCustomSource.Add(dr["Cellno"].ToString());
                }
                clsobj.con.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void srchbymobileno()
        {
            try
            {
                clsobj.constate();
                clsobj.com = new SqlCommand("Select * from Room_Assign_Details Where Cellno like '%" + txtsearchby.Text + "%'", clsobj.con);
                clsobj.com.Connection = clsobj.con;
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(clsobj.com);
                da.Fill(ds);
                DataTable dt = ds.Tables[0];
                dataGridView1.DataSource = dt;
                clsobj.con.Close();
                mobileauto();
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
                clsobj.com = new SqlCommand("Select Stdname from Room_Assign_Details Where Stdname like '%" + txtsearchby.Text + "%'", clsobj.con);
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
                clsobj.com = new SqlCommand("Select * from Room_Assign_Details Where Stdname like '%" + txtsearchby.Text + "%'", clsobj.con);
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
        private void srchbyroomno()
        {
            try
            {
                clsobj.constate();
                clsobj.com = new SqlCommand("Select * from Room_Assign_Details Where Roomno like '%" + txtsearchby.Text + "%'", clsobj.con);
                clsobj.com.Connection = clsobj.con;
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(clsobj.com);
                da.Fill(ds);
                DataTable dt = ds.Tables[0];
                dataGridView1.DataSource = dt;
                clsobj.con.Close();
              roomauto();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        private void roomauto()
        {
            try
            {
                clsobj.constate();
                clsobj.com = new SqlCommand("Select Roomno from Room_Assign_Details Where Roomno like '%" + txtsearchby.Text + "%'", clsobj.con);
                clsobj.com.Connection = clsobj.con;
                SqlDataReader dr = clsobj.com.ExecuteReader();
                while (dr.Read())
                {
                    txtsearchby.AutoCompleteCustomSource.Add(dr["Roomno"].ToString());
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
            if (rdiomobileno.IsChecked == true)
            { srchbymobileno(); }
            else if (rdioname.IsChecked == true)
            { srchbyname(); }
            else if (rdioroomno.IsChecked == true)
            { srchbyroomno(); }
        }

    }
}
