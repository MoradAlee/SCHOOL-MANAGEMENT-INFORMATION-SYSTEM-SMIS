using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using System.IO;
using System.Drawing.Imaging;

using System.Data.SqlClient;
using School_Management_System.DB_Connectivity;

namespace School_Management_System.UI
{
    public partial class Employee_Payroll_Details : Telerik.WinControls.UI.RadForm
    {
        public School_Management_System.DB_Connectivity.DB_Connection clsobj = new School_Management_System.DB_Connectivity.DB_Connection();
        int i;

        double aamount, lamount, ovamount, adays, ldays, ovdays, tab, tleav, tov, bsalary, allow, arrrs, tearn, tded, netsal, rcved, rmnd;



        public Employee_Payroll_Details()
        {
            InitializeComponent();
        }

        private void Employee_Payroll_Details_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'school_Management_SystemDataSet.s_active_Employee_Details' table. You can move, or remove it, as needed.
            this.s_active_Employee_DetailsTableAdapter.Fill(this.school_Management_SystemDataSet.s_active_Employee_Details);
            // TODO: This line of code loads data into the 'school_Management_SystemDataSet1.s_Session_Details' table. You can move, or remove it, as needed.
            this.s_Session_DetailsTableAdapter.Fill(this.school_Management_SystemDataSet1.s_Session_Details);
         
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
        private void slctmax()
        {
            try
            {
                clsobj.constate();
                clsobj.com = new SqlCommand("s_max_Employee_Payroll_Details", clsobj.con);
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
                clsobj.com = new SqlCommand("s_Employee_Payroll_Details", clsobj.con);
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
        private void txtserialno_TextChanged(object sender, EventArgs e)
        {

        }

        private void slctemp()
        {
            try
            {
                clsobj.constate();
                clsobj.com = new SqlCommand("Select * from Employee_Details Where Empname like '%" + radMultiColumnComboBox3.Text + "%'", clsobj.con);
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

                            txtempid.Text = dr["EmpID"].ToString();
                          //  txtstdname.Text = dr["Stdname"].ToString();
                            txtfname.Text = dr["Fname"].ToString();
                            txtaddress.Text = dr["PermAddress"].ToString();
                            //  txtcontactno.Text = dr["Contactno"].ToString();


                        }
                    }
                    Byte[] data = new Byte[0];
                    data = (Byte[])(ds.Tables[0].Rows[0]["Pics"]);
                    MemoryStream mem = new MemoryStream(data);
                    pictureBox4.Image = Image.FromStream(mem);
                    clsobj.con.Close();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void slctarrrs()
        {
            try
            {
                clsobj.constate();
                clsobj.com = new SqlCommand("Select * from Employee_Payroll_Details Where Empname like '%" + radMultiColumnComboBox3.Text + "%'", clsobj.con);
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
                txtarrears.Text = dr["Remained"].ToString();
                          }
                    }
                                   }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void radMultiColumnComboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            slctemp();

            slctarrrs();
        }

        private void txtabsentamount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtabsentdays.Text == "")
                {
                    txtabsentdays.Text = "0";
                }
                else if (txtabsentamount.Text == "")
                {
                    txtabsentamount.Text = "0";
                }
                else
                {
                    adays = Convert.ToDouble(txtabsentdays.Text);
                    aamount = Convert.ToDouble(txtabsentamount.Text);
                    tab = Convert.ToDouble (adays * aamount);
                    txttotalabsent.Text = tab.ToString();

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void txtleavesamount_TextChanged(object sender, EventArgs e)
        {

            try
            {
                if (txtleavedays.Text == "")
                {
                    txtleavedays.Text = "0";
                }
                else if (txtleavesamount.Text == "")
                {
                    txtleavesamount.Text = "0";
                }
                else
                {
                    ldays = Convert.ToDouble(txtleavedays.Text);
                    lamount = Convert.ToDouble(txtleavesamount.Text);
                    tleav = Convert.ToDouble(ldays * lamount);
                    txttotalleaves.Text = tleav.ToString();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            
         
        }

        private void txtovertimeamount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtovertimehrs.Text == "")
                {
                    txtovertimehrs.Text = "0";
                }
                else if (txtovertimeamount.Text == "")
                {
                    txtovertimeamount.Text = "0";
                }
                else
                {
                    ovdays = Convert.ToDouble(txtovertimehrs.Text);
                    ovamount = Convert.ToDouble(txtovertimeamount.Text);
                    tov = Convert.ToDouble(ovdays * ovamount);

                    txttotalovertime.Text = tov.ToString();

                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void txttotalovertime_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtallowance_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtarrears.Text == "")
                {
                    txtarrears.Text = "0";
                }
                else if (txtbasicsalary.Text == "")
                {
                    txtbasicsalary.Text = "0";
                }
                else if (txtallowance.Text == "")
                {
                    txtallowance.Text = "0";
                }
                else if (txttotalearnings.Text == "")
                {
                    txttotalearnings.Text = "0";
                }
                else if (txttotaldeductions.Text == "")
                {
                    txttotaldeductions.Text = "";
                }

                else
                {
                    arrrs = Convert.ToDouble(txtarrears.Text);
                    bsalary = Convert.ToDouble(txtbasicsalary.Text);
                    allow = Convert.ToDouble(txtallowance.Text);

                    tearn  = Convert.ToDouble(arrrs + bsalary + allow + tov);

                    txttotalearnings.Text = tearn.ToString();

                    tearn = Convert.ToDouble(txttotalearnings.Text);
                    tded = Convert.ToDouble(txttotaldeductions.Text);
                    netsal = Convert.ToDouble(tearn - tded);

                    txtnetsalary.Text = netsal.ToString();

                                    }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

           
        }

        private void txttotalleaves_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txttotalleaves.Text == "")
                {
                    txttotalleaves.Text = "0";
                }
                else if (txttotalabsent.Text == "")
                {
                    txttotalabsent.Text = "0";
                }
                else
                {
                    tleav = Convert.ToDouble(txttotalleaves.Text);
                    tab = Convert.ToDouble(txttotalabsent.Text);
                    tded = Convert.ToDouble(tleav + tab);

                    txttotaldeductions.Text = tded.ToString();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void txtsalaryreceived_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtnetsalary.Text == "")
                {
                    txtnetsalary.Text = "0";
                }
                else if (txtsalaryreceived.Text == "")
                {
                    txtsalaryreceived.Text = "0";
                }
                else
                {
                  
                    netsal = Convert.ToDouble(txtnetsalary.Text);
                    rcved = Convert.ToDouble(txtsalaryreceived.Text);
                    rmnd = Convert.ToDouble(netsal - rcved);
                    
                    txtsalaryremained.Text = rmnd.ToString();


                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void insertionss()
        {
            try
            {
                clsobj.constate();
                clsobj.com = new SqlCommand("i_Employee_Payroll_Details", clsobj.con);
                clsobj.com.Connection = clsobj.con;
                clsobj.com.CommandType = CommandType.StoredProcedure;
                clsobj.com.Parameters.AddWithValue("@Serialno",txtserialno.Text );
                clsobj.com.Parameters.AddWithValue("@EmpID",txtempid.Text );
                clsobj.com.Parameters.AddWithValue("@Empname",radMultiColumnComboBox3.Text );
                clsobj.com.Parameters.AddWithValue("@Fname",txtfname.Text );
                clsobj.com.Parameters.AddWithValue("@Address",txtaddress.Text );
                clsobj.com.Parameters.AddWithValue("@TDays",txttdays.Text );
                clsobj.com.Parameters.AddWithValue("@DPresent",txtpresent.Text );
                clsobj.com.Parameters.AddWithValue("@DAbsent",txtabsentdays.Text );
                clsobj.com.Parameters.AddWithValue("@AAmount",txttotalabsent.Text );
                clsobj.com.Parameters.AddWithValue("@DLeaves",txtleavedays.Text );
                clsobj.com.Parameters.AddWithValue("@ALeaves",txttotalleaves.Text );
                clsobj.com.Parameters.AddWithValue("@OvertimeHrs",txtovertimehrs.Text );
                clsobj.com.Parameters.AddWithValue("@OAmount",txttotalovertime.Text );
                clsobj.com.Parameters.AddWithValue("@Arrears",txtarrears.Text );
                clsobj.com.Parameters.AddWithValue("@BasicSalary",txtbasicsalary.Text );
                clsobj.com.Parameters.AddWithValue("@OAllowance",txtallowance.Text );
                clsobj.com.Parameters.AddWithValue("@TEarnings",txttotalearnings.Text );
                clsobj.com.Parameters.AddWithValue("@TDeductions",txttotaldeductions.Text );
                clsobj.com.Parameters.AddWithValue("@NetSalary",txtnetsalary.Text );
                clsobj.com.Parameters.AddWithValue("@Received",txtsalaryreceived.Text );
                clsobj.com.Parameters.AddWithValue("@Remained",txtsalaryremained.Text );
                clsobj.com.Parameters.AddWithValue("@Formonth",cmbomonth.Text );
                clsobj.com.Parameters.AddWithValue("@ForYear",radMultiColumnComboBox2.Text );
                clsobj.com.Parameters.AddWithValue("@SDate",txtdate.Text );
                clsobj.com.Parameters.AddWithValue("@Descriptions",txtdescriptions.Text );
                clsobj.com.Parameters.AddWithValue("@IsPaid",chkispaid.CheckState );
          
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
                i = Convert.ToInt32(txtserialno.Text);
                i += 1;

                txtserialno.Text = i.ToString();
            }
            insertionss();
        }

        private void clr()
        {

            txtabsentamount.Text = "0";
            txtabsentdays.Text = "0";
            txtaddress.Text = "";
            txtallowance.Text = "0";
            txtarrears.Text = "0";
            txtbasicsalary.Text = "0";
            txtdate.Text = DateTime.Today.ToShortDateString();
            txtdescriptions.Text = "";
            txtempid.Text = "";
            txtfname.Text = "";
            txtleavedays.Text = "";
            txtleavesamount.Text = "";
            txtnetsalary.Text = "0";
            txtovertimeamount.Text = "";
            txtovertimehrs.Text = "";
            txtpresent.Text = "";
            txtsalaryreceived.Text = "";
            txtsalaryremained.Text = "";
            txttdays.Text = "";
            txttotalabsent.Text = "";
            txttotaldeductions.Text = "";
            txttotalearnings.Text = "";
            txttotalleaves.Text = "";
            txttotalovertime.Text = "";
            cmbomonth.SelectedIndex = -1;

            pictureBox4.Image = null;


            slctall();

            slctmax();

        }

        private void radButton4_Click(object sender, EventArgs e)
        {
            clr();
        }

        private void updationss()
        {
            try
            {
                clsobj.constate();
                clsobj.com = new SqlCommand("u_Employee_Payroll_Details", clsobj.con);
                clsobj.com.Connection = clsobj.con;
                clsobj.com.CommandType = CommandType.StoredProcedure;
                clsobj.com.Parameters.AddWithValue("@Serialno", txtserialno.Text);
                clsobj.com.Parameters.AddWithValue("@EmpID", txtempid.Text);
                clsobj.com.Parameters.AddWithValue("@Empname", radMultiColumnComboBox3.Text);
                clsobj.com.Parameters.AddWithValue("@Fname", txtfname.Text);
                clsobj.com.Parameters.AddWithValue("@Address", txtaddress.Text);
                clsobj.com.Parameters.AddWithValue("@TDays", txttdays.Text);
                clsobj.com.Parameters.AddWithValue("@DPresent", txtpresent.Text);
                clsobj.com.Parameters.AddWithValue("@DAbsent", txtabsentdays.Text);
                clsobj.com.Parameters.AddWithValue("@AAmount", txttotalabsent.Text);
                clsobj.com.Parameters.AddWithValue("@DLeaves", txtleavedays.Text);
                clsobj.com.Parameters.AddWithValue("@ALeaves", txttotalleaves.Text);
                clsobj.com.Parameters.AddWithValue("@OvertimeHrs", txtovertimehrs.Text);
                clsobj.com.Parameters.AddWithValue("@OAmount", txttotalovertime.Text);
                clsobj.com.Parameters.AddWithValue("@Arrears", txtarrears.Text);
                clsobj.com.Parameters.AddWithValue("@BasicSalary", txtbasicsalary.Text);
                clsobj.com.Parameters.AddWithValue("@OAllowance", txtallowance.Text);
                clsobj.com.Parameters.AddWithValue("@TEarnings", txttotalearnings.Text);
                clsobj.com.Parameters.AddWithValue("@TDeductions", txttotaldeductions.Text);
                clsobj.com.Parameters.AddWithValue("@NetSalary", txtnetsalary.Text);
                clsobj.com.Parameters.AddWithValue("@Received", txtsalaryreceived.Text);
                clsobj.com.Parameters.AddWithValue("@Remained", txtsalaryremained.Text);
                clsobj.com.Parameters.AddWithValue("@Formonth", cmbomonth.Text);
                clsobj.com.Parameters.AddWithValue("@ForYear", radMultiColumnComboBox2.Text);
                clsobj.com.Parameters.AddWithValue("@SDate", txtdate.Text);
                clsobj.com.Parameters.AddWithValue("@Descriptions", txtdescriptions.Text);
                clsobj.com.Parameters.AddWithValue("@IsPaid", chkispaid.CheckState);

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
                clsobj.com = new SqlCommand("d_Employee_Payroll_Details", clsobj.con);
                clsobj.com.Connection = clsobj.con;
                clsobj.com.CommandType = CommandType.StoredProcedure;
                clsobj.com.Parameters.AddWithValue("@Serialno", txtserialno.Text);
                clsobj.com.Parameters.AddWithValue("@EmpID", txtempid.Text);
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
                txtempid.Text = this.dataGridView1.Rows[i].Cells[1].Value.ToString();
                radMultiColumnComboBox3.Text = this.dataGridView1.Rows[i].Cells[2].Value.ToString();
                txtfname.Text = this.dataGridView1.Rows[i].Cells[3].Value.ToString();
                txtaddress.Text = this.dataGridView1.Rows[i].Cells[4].Value.ToString();
                txttdays.Text = this.dataGridView1.Rows[i].Cells[5].Value.ToString();
                txtpresent.Text = this.dataGridView1.Rows[i].Cells[6].Value.ToString();
                txtabsentdays.Text = this.dataGridView1.Rows[i].Cells[7].Value.ToString();
                txttotalabsent.Text = this.dataGridView1.Rows[i].Cells[8].Value.ToString();
                txtleavedays.Text = this.dataGridView1.Rows[i].Cells[9].Value.ToString();
                txttotalleaves.Text = this.dataGridView1.Rows[i].Cells[10].Value.ToString();
                txtovertimehrs.Text = this.dataGridView1.Rows[i].Cells[11].Value.ToString();
                txttotalovertime.Text = this.dataGridView1.Rows[i].Cells[12].Value.ToString();
                txtarrears.Text = this.dataGridView1.Rows[i].Cells[13].Value.ToString();
                txtbasicsalary.Text = this.dataGridView1.Rows[i].Cells[14].Value.ToString();
                txtallowance.Text = this.dataGridView1.Rows[i].Cells[15].Value.ToString();
                txttotalearnings.Text = this.dataGridView1.Rows[i].Cells[16].Value.ToString();
                txttotaldeductions.Text = this.dataGridView1.Rows[i].Cells[17].Value.ToString();
                txtnetsalary.Text = this.dataGridView1.Rows[i].Cells[18].Value.ToString();
                txtsalaryreceived.Text = this.dataGridView1.Rows[i].Cells[19].Value.ToString();
                txtsalaryremained.Text = this.dataGridView1.Rows[i].Cells[20].Value.ToString();
                cmbomonth.Text = this.dataGridView1.Rows[i].Cells[21].Value.ToString();
                radMultiColumnComboBox2.Text = this.dataGridView1.Rows[i].Cells[22].Value.ToString();
                txtdate.Text = this.dataGridView1.Rows[i].Cells[23].Value.ToString();
                txtdescriptions.Text = this.dataGridView1.Rows[i].Cells[24].Value.ToString();
                chkispaid.Checked = Convert.ToBoolean(this.dataGridView1.Rows[i].Cells[25].Value.ToString());
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
        private void empauto()
        {
            try
            {
                clsobj.constate();
                clsobj.com = new SqlCommand("Select Empname from Employee_Payroll_Details Where Empname like '%" + txtsearchby.Text + "%'", clsobj.con);
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

        private void srchbyemp()
        {
            try
            {
                clsobj.constate();
                clsobj.com = new SqlCommand("Select * from Employee_Payroll_Details Where Empname like '%" + txtsearchby.Text + "%'", clsobj.con);
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
        private void dateauto()
        {
            try
            {
                clsobj.constate();
                clsobj.com = new SqlCommand("Select SDate from Employee_Payroll_Details Where SDate like '%" + txtsearchby.Text + "%'", clsobj.con);
                clsobj.com.Connection = clsobj.con;
                SqlDataReader dr = clsobj.com.ExecuteReader();
                while (dr.Read())
                {
                    txtsearchby.AutoCompleteCustomSource.Add(dr["SDate"].ToString());
                }
                clsobj.con.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        private void srchbydate()
        {
            try
            {
                clsobj.constate();
                clsobj.com = new SqlCommand("Select * from Employee_Payroll_Details Where SDate like '%" + txtsearchby.Text + "%'", clsobj.con);
                clsobj.com.Connection = clsobj.con;
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(clsobj.com);
                da.Fill(ds);
                DataTable dt = ds.Tables[0];
                dataGridView1.DataSource = dt;
                clsobj.con.Close();
                dateauto();
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
                clsobj.com = new SqlCommand("Select * from Employee_Payroll_Details Where Formonth like '%" + txtsearchby.Text + "%'", clsobj.con);
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
        private void monthauto()
        {
            try
            {
                clsobj.constate();
                clsobj.com = new SqlCommand("Select Formonth from Employee_Payroll_Details Where Formonth like '%" + txtsearchby.Text + "%'", clsobj.con);
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
        private void txtsearchby_TextChanged(object sender, EventArgs e)
        {
            if (rdioemployee.IsChecked == true)
            { srchbyemp(); }
            else if (rdiodate.IsChecked == true)
            { srchbydate(); }
            else if (rdiomonth.IsChecked == true)
            { srchbymonth(); }
            else
            { MessageBox.Show("Toggle any state and then search!!", "School Says", MessageBoxButtons.OKCancel, MessageBoxIcon.Information); }
        }

        private void txtsalaryremained_TextChanged(object sender, EventArgs e)
        {
            if (txtsalaryremained.Text == "0")
            { chkispaid.Checked = true; }
        }
    }
}
