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
    public partial class Stationary_Sales : Telerik.WinControls.UI.RadForm
    {
        public School_Management_System.DB_Connectivity.DB_Connection clsobj = new School_Management_System.DB_Connectivity.DB_Connection();
        int i;
     
        double iprice, iqntty, tamount, rcved, rmand;
        public Stationary_Sales()
        {
            InitializeComponent();
        }

        private void Stationary_Sales_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'school_Management_SystemDataSet.s_Stationary_New_Item_Details' table. You can move, or remove it, as needed.
            this.s_Stationary_New_Item_DetailsTableAdapter.Fill(this.school_Management_SystemDataSet.s_Stationary_New_Item_Details);
            // TODO: This line of code loads data into the 'school_Management_SystemDataSet.S_active_Students_Details' table. You can move, or remove it, as needed.
            this.s_active_Students_DetailsTableAdapter.Fill(this.school_Management_SystemDataSet.S_active_Students_Details);


            txtdate.Text = DateTime.Today.ToShortDateString();

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
        private void slctall()
        {
            try
            {
                clsobj.constate();
                clsobj.com = new SqlCommand("s_Sationary_Sale_Details", clsobj.con);
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
                clsobj.com = new SqlCommand("s_MAX_Sationary_Sale_Details", clsobj.con);
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
            txtclass.Text = "";
            txtclassno.Text = "";
            txtdate.Text = DateTime.Today.ToShortDateString();
            txtfname.Text = "";
            txtitemid.Text = "";
            txtitemprice.Text = "0";
            txtquantity.Text = "";
            txtreceived.Text = "";
            txtreminaed.Text = "";
            txtstdid.Text = "";
            txtstdname.Text = "";
            txttprice.Text = "";
            cmbomonth.SelectedIndex = -1;

            slctall();

            slctmax();
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
                clsobj.com = new SqlCommand("i_Sationary_Sale_Details", clsobj.con);
                clsobj.com.Connection = clsobj.con;
                clsobj.com.CommandType = CommandType.StoredProcedure;
                clsobj.com.Parameters.AddWithValue("@Serialno",txtserialno.Text );
                clsobj.com.Parameters.AddWithValue("@StdID",txtstdid.Text );
                clsobj.com.Parameters.AddWithValue("@Regno",radMultiColumnComboBox1.Text );
                clsobj.com.Parameters.AddWithValue("@Stdname",txtstdname.Text );
                clsobj.com.Parameters.AddWithValue("@Fname",txtfname.Text );
                clsobj.com.Parameters.AddWithValue("@Classname",txtclass.Text );
                clsobj.com.Parameters.AddWithValue("@Classno",txtclassno.Text );
                clsobj.com.Parameters.AddWithValue("@ItemID",txtitemid.Text );
                clsobj.com.Parameters.AddWithValue("@Itemname",radMultiColumnComboBox2.Text );
                clsobj.com.Parameters.AddWithValue("@Price",txtitemprice.Text );
                clsobj.com.Parameters.AddWithValue("@Quantity",txtquantity.Text );
                clsobj.com.Parameters.AddWithValue("@TPrice",txttprice.Text );
                clsobj.com.Parameters.AddWithValue("@Received",txtreceived.Text );
                clsobj.com.Parameters.AddWithValue("@Remained",txtreminaed.Text );
                clsobj.com.Parameters.AddWithValue("@Formonth",cmbomonth.Text );
                clsobj.com.Parameters.AddWithValue("@SDate",txtdate.Text );
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
            insertionss();
        }

        private void txtquantity_TextChanged(object sender, EventArgs e)
        {
            if (txtitemprice.Text == "")
            { txtitemprice.Text = "0"; }
            else if (txtquantity.Text == "")
            {
                txtquantity.Text = "0";
            }
            else
            {
                iprice = Convert.ToDouble(txtitemprice.Text);
                iqntty = Convert.ToDouble(txtquantity.Text);
                tamount = Convert.ToDouble(iprice * iqntty);
                txttprice.Text = tamount.ToString();

            }
        }

        private void txtreceived_TextChanged(object sender, EventArgs e)
        {
            if (txttprice.Text == "")
            {
                txttprice.Text = "0";
            }
            else if (txtreceived.Text == "")
            {
                txtreceived.Text = "0";
            }
            else
            {
                rcved = Convert.ToDouble(txtreceived.Text);
              //  rmand = Convert.ToDouble(txtreminaed.Text);
                tamount = Convert.ToDouble(txttprice.Text);
                if (rcved > tamount)
                {
                    MessageBox.Show("Received must be less than Total!!!", "School Says", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtreceived.Text = "0";
                }
                else
                {
                    rmand = Convert.ToDouble(tamount - rcved);

                    txtreminaed.Text = rmand.ToString();

                }
            }
        }

        private void updationss()
        {
            try
            {
                clsobj.constate();
                clsobj.com = new SqlCommand("u_Sationary_Sale_Details", clsobj.con);
                clsobj.com.Connection = clsobj.con;
                clsobj.com.CommandType = CommandType.StoredProcedure;
                clsobj.com.Parameters.AddWithValue("@Serialno", txtserialno.Text);
                clsobj.com.Parameters.AddWithValue("@StdID", txtstdid.Text);
                clsobj.com.Parameters.AddWithValue("@Regno", radMultiColumnComboBox1.Text);
                clsobj.com.Parameters.AddWithValue("@Stdname", txtstdname.Text);
                clsobj.com.Parameters.AddWithValue("@Fname", txtfname.Text);
                clsobj.com.Parameters.AddWithValue("@Classname", txtclass.Text);
                clsobj.com.Parameters.AddWithValue("@Classno", txtclassno.Text);
                clsobj.com.Parameters.AddWithValue("@ItemID", txtitemid.Text);
                clsobj.com.Parameters.AddWithValue("@Itemname", radMultiColumnComboBox2.Text);
                clsobj.com.Parameters.AddWithValue("@Price", txtitemprice.Text);
                clsobj.com.Parameters.AddWithValue("@Quantity", txtquantity.Text);
                clsobj.com.Parameters.AddWithValue("@TPrice", txttprice.Text);
                clsobj.com.Parameters.AddWithValue("@Received", txtreceived.Text);
                clsobj.com.Parameters.AddWithValue("@Remained", txtreminaed.Text);
                clsobj.com.Parameters.AddWithValue("@Formonth", cmbomonth.Text);
                clsobj.com.Parameters.AddWithValue("@SDate", txtdate.Text);
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
                clsobj.com = new SqlCommand("d_Sationary_Sale_Details", clsobj.con);
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
        private void regauto()
        {
            try
            {
                clsobj.constate();
                clsobj.com = new SqlCommand("Select Regno from Stationary_Sale_Details Where Regno like '%" + txtsearchby.Text + "%'", clsobj.con);
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
                clsobj.com = new SqlCommand("Select * from Stationary_Sale_Details Where Regno like '%" + txtsearchby.Text + "%'", clsobj.con);
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
        private void srchbystationary()
        {
            try
            {
                clsobj.constate();
                clsobj.com = new SqlCommand("Select * from Stationary_Sale_Details Where Itemname like '%" + txtsearchby.Text + "%'", clsobj.con);
                clsobj.com.Connection = clsobj.con;
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(clsobj.com);
                da.Fill(ds);
                DataTable dt = ds.Tables[0];
                dataGridView1.DataSource = dt;
                clsobj.con.Close();
                itemauto();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        private void itemauto()
        {
            try
            {
                clsobj.constate();
                clsobj.com = new SqlCommand("Select Itemname from Stationary_Sale_Details Where Itemname like '%" + txtsearchby.Text + "%'", clsobj.con);
                clsobj.com.Connection = clsobj.con;
                SqlDataReader dr = clsobj.com.ExecuteReader();
                while (dr.Read())
                {
                    txtsearchby.AutoCompleteCustomSource.Add(dr["Itemname"].ToString());
                }
                clsobj.con.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void srchbystdname()
        {
            try
            {
                clsobj.constate();
                clsobj.com = new SqlCommand("Select * from Stationary_Sale_Details Where Stdname like '%" + txtsearchby.Text + "%'", clsobj.con);
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
                clsobj.com = new SqlCommand("Select Stdname from Stationary_Sale_Details Where Stdname like '%" + txtsearchby.Text + "%'", clsobj.con);
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
            if (rdioregno.IsChecked == true)
            { srchbyregno(); }
            else if (rdiostationary.IsChecked == true)
            { srchbystationary(); }
            else if (rdiostdname.IsChecked == true)
            { srchbystdname(); }
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
                txtclass.Text = this.dataGridView1.Rows[i].Cells[5].Value.ToString();
                txtclassno.Text = this.dataGridView1.Rows[i].Cells[6].Value.ToString();
                txtitemid.Text = this.dataGridView1.Rows[i].Cells[7].Value.ToString();
                radMultiColumnComboBox2.Text = this.dataGridView1.Rows[i].Cells[8].Value.ToString();
                txtitemprice.Text = this.dataGridView1.Rows[i].Cells[9].Value.ToString();
                txtquantity.Text = this.dataGridView1.Rows[i].Cells[10].Value.ToString();
                txttprice.Text = this.dataGridView1.Rows[i].Cells[11].Value.ToString();
                txtreceived.Text = this.dataGridView1.Rows[i].Cells[12].Value.ToString();
                txtreminaed.Text = this.dataGridView1.Rows[i].Cells[13].Value.ToString();
                cmbomonth.Text = this.dataGridView1.Rows[i].Cells[14].Value.ToString();
                txtdate.Text = this.dataGridView1.Rows[i].Cells[15].Value.ToString();


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
                           

                            txtclass.Text = dr["AdmittedinClass"].ToString();
                            txtclassno.Text = dr["Classno"].ToString();

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

            slctstudent();



        }

        private void slctitem()
        {

            try
            {
                clsobj.constate();
                clsobj.com = new SqlCommand("Select * from Stationary_New_Item_Details Where Itemname like '%" + radMultiColumnComboBox2.Text + "%'", clsobj.con);
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
                            txtitemid.Text = dr["ItemID"].ToString();
                        txtitemprice.Text=dr["ItemPrice"].ToString();
                           // txtquantity.Text=dr["IRemained"].ToString();


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
            slctitem();
        }
    }
}
