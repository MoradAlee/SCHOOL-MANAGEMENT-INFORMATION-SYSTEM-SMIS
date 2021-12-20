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
    public partial class Accountbook_Details : Telerik.WinControls.UI.RadForm
    {
        public School_Management_System.DB_Connectivity.DB_Connection clsobj = new School_Management_System.DB_Connectivity.DB_Connection();
        int i;
        int sr;

        double arr, oam, cb, tb;
        double rcb, rcv, rcm;


        public Accountbook_Details()
        {
            InitializeComponent();
        }

        private void Accountbook_Details_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'school_Management_SystemDataSet1.s_Session_Details' table. You can move, or remove it, as needed.
            this.s_Session_DetailsTableAdapter.Fill(this.school_Management_SystemDataSet1.s_Session_Details);
            
            
            // TODO: This line of code loads data into the 'school_Management_SystemDataSet.s_Accountbook_Details' table. You can move, or remove it, as needed.
            this.s_Accountbook_DetailsTableAdapter.Fill(this.school_Management_SystemDataSet.s_Accountbook_Details);
           // TODO: This line of code loads data into the 'school_Management_SystemDataSet.S_classess_Details' table. You can move, or remove it, as needed.
            this.s_classess_DetailsTableAdapter.Fill(this.school_Management_SystemDataSet.S_classess_Details);

            slctmax();

            txtdate.Text = DateTime.Today.ToShortDateString();

            cmbormonth.Items.Add("--Select Month--");
            cmbormonth.Items.Add("January");
            cmbormonth.Items.Add("February");
            cmbormonth.Items.Add("March");
            cmbormonth.Items.Add("April");
            cmbormonth.Items.Add("May");
            cmbormonth.Items.Add("June");
            cmbormonth.Items.Add("July");
            cmbormonth.Items.Add("August");
            cmbormonth.Items.Add("September");
            cmbormonth.Items.Add("October");
            cmbormonth.Items.Add("November");
            cmbormonth.Items.Add("December");

            cmbormonth.SelectedIndex = 0;


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

          
            addcolm();
        }

        private void addcolm()
        {
            try
            {
                DataGridViewTextBoxColumn arrs = new DataGridViewTextBoxColumn();
                arrs.Name = "Arrears";
                arrs.HeaderText = "Arrears";
                dataGridView1.Columns.Add(arrs);
                DataGridViewTextBoxColumn ohead = new DataGridViewTextBoxColumn();
                ohead.Name = "OHead";
                ohead.HeaderText = "Others Head";
                dataGridView1.Columns.Add(ohead);
                DataGridViewTextBoxColumn oamount = new DataGridViewTextBoxColumn();
                oamount.Name = "OAmount";
                oamount.HeaderText = "Others Amount";
                dataGridView1.Columns.Add(oamount);
                DataGridViewTextBoxColumn cbalance = new DataGridViewTextBoxColumn();
                cbalance.Name = "CBalance";
                cbalance.HeaderText = "Current Balance";
                dataGridView1.Columns.Add(cbalance);
                DataGridViewTextBoxColumn tbalance = new DataGridViewTextBoxColumn();
                tbalance.Name = "TBalance";
                tbalance.HeaderText = "Total Balance";
                dataGridView1.Columns.Add(tbalance);
                DataGridViewTextBoxColumn rcved = new DataGridViewTextBoxColumn();
                rcved.Name = "Rcvd";
                rcved.HeaderText = "Received";
                dataGridView1. Columns.Add(rcved);
                DataGridViewTextBoxColumn rmnd = new DataGridViewTextBoxColumn();
                rmnd.Name = "Rmnd";
                rmnd.HeaderText = "Remained";
                dataGridView1.Columns.Add(rmnd);

            


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void slctstudent()
        {
            try
            {
                clsobj.constate();
                clsobj.com = new SqlCommand("Select StdID, Regno, Stdname, Fname,PermAddress,AdmittedinClass,Classno from Students_Details Where AdmittedinClass like '%" + radMultiColumnComboBox1.Text + "%'", clsobj.con);
                clsobj.com.Connection = clsobj.con;
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(clsobj.com);
                da.Fill(ds, "DDD");
                DataTable dt = ds.Tables[0];
               
            
                dataGridView1.DataSource = dt;
                clsobj.con.Close();
              //  InitializeDataGridView();
                
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        private void slctfee()
        {
            try
            {
                clsobj.constate();
                clsobj.com = new SqlCommand("Select * from Fee_Class_Details Where Classname like '%" + radMultiColumnComboBox1.Text + "%'", clsobj.con);
                clsobj.com.Connection = clsobj.con;
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(clsobj.com);
                 SqlDataReader dr = clsobj.com.ExecuteReader();
                while (dr.Read())
                {
                    for (i = 0; i < dataGridView1.Rows.Count - 1; i++)
                    {
                        dataGridView1.Rows[i].Cells["CBalance"].Value = dr["AmountofFee"].ToString();



                    }
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
            slctstudent();
            slctfee();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                for (i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    dataGridView1.Rows[i].Cells["Arrears"].Value = radTextBox8.Text;


                }
            }
            else
            {
                for (i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    dataGridView1.Rows[i].Cells["Arrears"].Value = "0";


                }
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked == true)
            {
                for (i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    dataGridView1.Rows[i].Cells["OAmount"].Value = radTextBox8.Text;


                }
            }
            else
            {
                for (i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    dataGridView1.Rows[i].Cells["OAmount"].Value = "0";


                }
            } 
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBox3.Checked == true)
            {
                for (i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    dataGridView1.Rows[i].Cells["OHead"].Value = radTextBox8.Text;


                }
            }
            else
            {
                for (i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    dataGridView1.Rows[i].Cells["OHead"].Value = "";


                }
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBox3.Checked == true)
            {
                for (i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    dataGridView1.Rows[i].Cells["CBalance"].Value = radTextBox8.Text;


                }
            }
            else
            {
                for (i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    dataGridView1.Rows[i].Cells["CBalance"].Value = "";


                }
            }
        }

        private void radButton6_Click(object sender, EventArgs e)
        {
            for (i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                if (dataGridView1.Rows[i].Cells["Arrears"].Value.ToString() == "")
                {
                    dataGridView1.Rows[i].Cells["Arrears"].Value = "0".ToString();
                }
                else if (dataGridView1.Rows[i].Cells["OAmount"].Value.ToString() == "")
                {
                    dataGridView1.Rows[i].Cells["OAmount"].Value = "0".ToString() ;
                }
                else if (dataGridView1.Rows[i].Cells["CBalance"].Value.ToString() == "")
                { dataGridView1.Rows[i].Cells["CBalance"].Value = "".ToString(); }
                else
                {
                    arr = Convert.ToDouble(dataGridView1.Rows[i].Cells["Arrears"].Value.ToString());
                    oam = Convert.ToDouble(dataGridView1.Rows[i].Cells["OAmount"].Value.ToString());
                    cb = Convert.ToDouble(dataGridView1.Rows[i].Cells["CBalance"].Value.ToString());
                   tb=Convert.ToDouble  (arr+oam+cb);
                   
                    
                    
                    dataGridView1.Rows[i].Cells["TBalance"].Value = tb.ToString();
                    dataGridView1.Rows[i].Cells["Rcvd"].Value = "0";
                    dataGridView1.Rows[i].Cells["Rmnd"].Value = dataGridView1.Rows[i].Cells["TBalance"].Value.ToString();
                }

            }
        }

        private void radButton5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void slctmax()
        {
            try
            {
                clsobj.constate();
                clsobj.com = new SqlCommand("s_max_Accountbook_Details", clsobj.con);
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
                        txtserialno.Text = dr["SERIAL"].ToString();

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
                clsobj.com = new SqlCommand("s_Accountbook_Details", clsobj.con);
                clsobj.com.Connection = clsobj.con;
                clsobj.com.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(clsobj.com);
                da.Fill(ds);
                DataTable dt = ds.Tables[0];
              //  dataGridView1.DataSource = dt;
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
            txtdate.Text = DateTime.Today.ToShortDateString();
            cmbomonth.SelectedIndex = -1;
         //   cmboyear.SelectedIndex = -1;

        }

        private void radButton4_Click(object sender, EventArgs e)
        {
            clr();
        }

        private void insertionss()
        {
            for (i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                try
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
                    clsobj.constate();
                    clsobj.com = new SqlCommand("i_Accountbook_Details", clsobj.con);
                    clsobj.com.Connection = clsobj.con;
                    clsobj.com.CommandType = CommandType.StoredProcedure;
                    clsobj.com.Parameters.AddWithValue("@Serialno", txtserialno.Text);
                    clsobj.com.Parameters.AddWithValue("@StdID", dataGridView1.Rows[i].Cells["StdID"].Value.ToString());
                    clsobj.com.Parameters.AddWithValue("@Regno", dataGridView1.Rows[i].Cells["Regno"].Value.ToString());
                    clsobj.com.Parameters.AddWithValue("@Stdname", dataGridView1.Rows[i].Cells["Stdname"].Value.ToString());
                    clsobj.com.Parameters.AddWithValue("@Fname", dataGridView1.Rows[i].Cells["Fname"].Value.ToString());
                    clsobj.com.Parameters.AddWithValue("@Address", dataGridView1.Rows[i].Cells["PermAddress"].Value.ToString());
                    clsobj.com.Parameters.AddWithValue("@Classname", radMultiColumnComboBox1.Text );
                    clsobj.com.Parameters.AddWithValue("@Classno", dataGridView1.Rows[i].Cells["Classno"].Value.ToString());
                    clsobj.com.Parameters.AddWithValue("@Formonthof", cmbomonth.Text);
                    clsobj.com.Parameters.AddWithValue("@ForYear", radMultiColumnComboBox3.Text );
                    clsobj.com.Parameters.AddWithValue("@FeeDate", txtdate.Text);
                    clsobj.com.Parameters.AddWithValue("@Arrears", dataGridView1.Rows[i].Cells["Arrears"].Value.ToString());
                    clsobj.com.Parameters.AddWithValue("@OthersHead", dataGridView1.Rows[i].Cells["OHead"].Value.ToString());
                    clsobj.com.Parameters.AddWithValue("@OAmount", dataGridView1.Rows[i].Cells["OAmount"].Value.ToString());
                    clsobj.com.Parameters.AddWithValue("@CBalance", dataGridView1.Rows[i].Cells["CBalance"].Value.ToString());
                    clsobj.com.Parameters.AddWithValue("@TBalance", dataGridView1.Rows[i].Cells["TBalance"].Value.ToString());
                    clsobj.com.Parameters.AddWithValue("@Received", dataGridView1.Rows[i].Cells["Rcvd"].Value.ToString());
                    clsobj.com.Parameters.AddWithValue("@Remained", dataGridView1.Rows[i].Cells["Rmnd"].Value.ToString());
                    clsobj.com.Parameters.AddWithValue("@IsReceived", chkisreceived.CheckState);
                    clsobj.com.ExecuteNonQuery();
                  

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
            MsgsSaved msgs = new MsgsSaved();
            msgs.ShowDialog();
            clr();
            clsobj.con.Close();

        }



        private void insertionss1()
        {
            for (i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                try
                {
                    clsobj.constate();
                    clsobj.com = new SqlCommand("i_Accountbook_History_Details", clsobj.con);
                    clsobj.com.Connection = clsobj.con;
                    clsobj.com.CommandType = CommandType.StoredProcedure;
                    clsobj.com.Parameters.AddWithValue("@Serialno", txtserialno.Text);
                    clsobj.com.Parameters.AddWithValue("@StdID", dataGridView1.Rows[i].Cells["StdID"].Value.ToString());
                    clsobj.com.Parameters.AddWithValue("@Regno", dataGridView1.Rows[i].Cells["Regno"].Value.ToString());
                    clsobj.com.Parameters.AddWithValue("@Stdname", dataGridView1.Rows[i].Cells["Stdname"].Value.ToString());
                    clsobj.com.Parameters.AddWithValue("@Fname", dataGridView1.Rows[i].Cells["Fname"].Value.ToString());
                    clsobj.com.Parameters.AddWithValue("@Address", dataGridView1.Rows[i].Cells["PermAddress"].Value.ToString());
                    clsobj.com.Parameters.AddWithValue("@Classname", radMultiColumnComboBox1.Text);
                    clsobj.com.Parameters.AddWithValue("@Classno", dataGridView1.Rows[i].Cells["Classno"].Value.ToString());
                    clsobj.com.Parameters.AddWithValue("@Formonthof", cmbomonth.Text);
                    clsobj.com.Parameters.AddWithValue("@ForYear", radMultiColumnComboBox3.Text);
                    clsobj.com.Parameters.AddWithValue("@FeeDate", txtdate.Text);
                    clsobj.com.Parameters.AddWithValue("@Arrears", dataGridView1.Rows[i].Cells["Arrears"].Value.ToString());
                    clsobj.com.Parameters.AddWithValue("@OthersHead", dataGridView1.Rows[i].Cells["OHead"].Value.ToString());
                    clsobj.com.Parameters.AddWithValue("@OAmount", dataGridView1.Rows[i].Cells["OAmount"].Value.ToString());
                    clsobj.com.Parameters.AddWithValue("@CBalance", dataGridView1.Rows[i].Cells["CBalance"].Value.ToString());
                    clsobj.com.Parameters.AddWithValue("@TBalance", dataGridView1.Rows[i].Cells["TBalance"].Value.ToString());
                    clsobj.com.Parameters.AddWithValue("@Received", dataGridView1.Rows[i].Cells["Rcvd"].Value.ToString());
                    clsobj.com.Parameters.AddWithValue("@Remained", dataGridView1.Rows[i].Cells["Rmnd"].Value.ToString());
                    clsobj.com.Parameters.AddWithValue("@IsReceived", chkisreceived.CheckState);
                    clsobj.com.ExecuteNonQuery();
                   // insertionss1();

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
          
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
         
            
         insertionss();
         insertionss1();
        }

        private void radButton2_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(dataGridView1.Rows[i].Cells["Classno"].Value.ToString());
        }

        private void slctaccntbook()
        {
            try
            {
                clsobj.constate();
                clsobj.com = new SqlCommand("Select * from Accountbook_Details Where  Regno like '%" + radMultiColumnComboBox2.Text + "%' and Formonthof Like '%" + cmbormonth.Text + "%'", clsobj.con);
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
                            txtempid.Text = dr["Serialno"].ToString();
                            txtrname.Text = dr["Stdname"].ToString();
                            txtrfname.Text = dr["Fname"].ToString();
                            txtrcbalance.Text = dr["Remained"].ToString();
                                                    }
                    }

                }
                clsobj.com.ExecuteNonQuery();
                clsobj.con.Close();
            }
             

            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void radMultiColumnComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            slctaccntbook();
        }

        private void txtrrreceived_TextChanged(object sender, EventArgs e)
        {
            if (txtrcbalance.Text == "")
            {
                txtrcbalance.Text = "0";
            }
            else if (txtrrreceived.Text == "")
            {
                txtrrreceived.Text = "0";
            }
            else
            {
                rcb = Convert.ToDouble(txtrcbalance.Text);
                rcv = Convert.ToDouble(txtrrreceived.Text);
                if (rcv > rcb)
                {
                    MessageBox.Show("Received must not be greater than Current Balance!!", "School Says", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtrrreceived.Text = "0";
                }
                else
                {
                    rcm = Convert.ToDouble(rcb - rcv);
                    txtrnetbalance.Text = rcm.ToString();
                    if (txtrnetbalance.Text == "0")
                    {
                        chkrrisreceived.Checked = true;

                    }
                    else
                    {
                        chkrrisreceived.Checked = false;

                    }
                }
            }
        }
        private void clrr()
        {
            txtempid.Text = "";
            txtrname.Text = "";
            txtrfname.Text = "";
            txtrcbalance.Text ="0";
            txtrnetbalance.Text = "0";
            txtrrreceived.Text = "0";
            cmbormonth.SelectedIndex = -1;

        }

        private void Upd()
        {
            try
            {
                clsobj.constate();
                clsobj.com = new SqlCommand("Update Accountbook_Details Set Received='" + txtrrreceived.Text + "',Remained='" + txtrnetbalance.Text + "' Where Serialno=" + txtempid.Text + " and Formonthof ='" + cmbormonth.Text + "' and Regno='" + radMultiColumnComboBox2.Text + "'", clsobj.con);
                clsobj.com.Connection = clsobj.con;
                clsobj.com.ExecuteNonQuery();
                if (txtrnetbalance.Text == "0")
                {
                    MessageBox.Show("Fee Received Successfully", "School Says", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    clrr();
                }
                else
                {
                    MessageBox.Show("Fee Partially Received Successfully", "School Says", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clrr();
                }
                clsobj.con.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void radButton7_Click(object sender, EventArgs e)
        {
            Upd();
        }

       
    }
}
