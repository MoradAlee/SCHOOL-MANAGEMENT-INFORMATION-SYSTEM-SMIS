using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
//using System.Windows.Forms;
using Telerik.WinControls;
using System.Data.Sql;
using System.Data.SqlClient;
using System.IO;
using System.Configuration;
using School_Management_System.DB_Connectivity;


namespace School_Management_System.UI
{
    public partial class Weekly_Timetable_Details : Telerik.WinControls.UI.RadForm
    {

        public School_Management_System.DB_Connectivity.DB_Connection clsobj = new School_Management_System.DB_Connectivity.DB_Connection();
        int i;
        int sr;
        public Weekly_Timetable_Details()
        {
            InitializeComponent();
        }


        private void slctempl()
        {
            try
            {
                clsobj.constate();
                clsobj.com = new SqlCommand("s_active_Employee_Details", clsobj.con);
                clsobj.com.Connection = clsobj.con;
                clsobj.com.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(clsobj.com);
                da.Fill(ds);
                DataTable dt = ds.Tables[0];
               // dataGridView1.DataSource = dt;

                radMultiColumnComboBox80.DataSource = dt;
                radMultiColumnComboBox80.DisplayMember = "Empname";
                radMultiColumnComboBox80.DblClickRotate = true;


                radMultiColumnComboBox78.DataSource = dt;
                radMultiColumnComboBox78.DisplayMember = "Empname";
                radMultiColumnComboBox78.DblClickRotate = true;


                radMultiColumnComboBox76.DataSource = dt;
                radMultiColumnComboBox76.DisplayMember = "Empname";
                radMultiColumnComboBox76.DblClickRotate = true;


                radMultiColumnComboBox77.DataSource = dt;
                radMultiColumnComboBox77.DisplayMember = "Empname";
                radMultiColumnComboBox77.DblClickRotate = true;


                radMultiColumnComboBox75.DataSource = dt;
                radMultiColumnComboBox75.DisplayMember = "Empname";
                radMultiColumnComboBox75.DblClickRotate = true;


                radMultiColumnComboBox74.DataSource = dt;
                radMultiColumnComboBox74.DisplayMember = "Empname";
                radMultiColumnComboBox74.DblClickRotate = true;


                radMultiColumnComboBox63.DataSource = dt;
                radMultiColumnComboBox63.DisplayMember = "Empname";
                radMultiColumnComboBox63.DblClickRotate = true;




                radMultiColumnComboBox64.DataSource = dt;
                radMultiColumnComboBox64.DisplayMember = "Empname";
                radMultiColumnComboBox64.DblClickRotate = true;

                radMultiColumnComboBox62.DataSource = dt;
                radMultiColumnComboBox62.DisplayMember = "Empname";
                radMultiColumnComboBox62.DblClickRotate = true;

                radMultiColumnComboBox65.DataSource = dt;
                radMultiColumnComboBox65.DisplayMember = "Empname";
                radMultiColumnComboBox65.DblClickRotate = true;

                radMultiColumnComboBox66.DataSource = dt;
                radMultiColumnComboBox66.DisplayMember = "Empname";
                radMultiColumnComboBox66.DblClickRotate = true;

                radMultiColumnComboBox68.DataSource = dt;
                radMultiColumnComboBox68.DisplayMember = "Empname";
                radMultiColumnComboBox68.DblClickRotate = true;

                radMultiColumnComboBox50.DataSource = dt;
                radMultiColumnComboBox50.DisplayMember = "Empname";
                radMultiColumnComboBox50.DblClickRotate = true;

                radMultiColumnComboBox51.DataSource = dt;
                radMultiColumnComboBox51.DisplayMember = "Empname";
                radMultiColumnComboBox51.DblClickRotate = true;

                radMultiColumnComboBox52.DataSource = dt;
                radMultiColumnComboBox52.DisplayMember = "Empname";
                radMultiColumnComboBox52.DblClickRotate = true;

                radMultiColumnComboBox53.DataSource = dt;
                radMultiColumnComboBox53.DisplayMember = "Empname";
                radMultiColumnComboBox53.DblClickRotate = true;

                radMultiColumnComboBox54.DataSource = dt;
                radMultiColumnComboBox54.DisplayMember = "Empname";
                radMultiColumnComboBox54.DblClickRotate = true;

                radMultiColumnComboBox56.DataSource = dt;
                radMultiColumnComboBox56.DisplayMember = "Empname";
                radMultiColumnComboBox56.DblClickRotate = true;

                radMultiColumnComboBox38.DataSource = dt;
                radMultiColumnComboBox38.DisplayMember = "Empname";
                radMultiColumnComboBox38.DblClickRotate = true;

                radMultiColumnComboBox39.DataSource = dt;
                radMultiColumnComboBox39.DisplayMember = "Empname";
                radMultiColumnComboBox39.DblClickRotate = true;

                radMultiColumnComboBox40.DataSource = dt;
                radMultiColumnComboBox40.DisplayMember = "Empname";
                radMultiColumnComboBox40.DblClickRotate = true;

                radMultiColumnComboBox41.DataSource = dt;
                radMultiColumnComboBox41.DisplayMember = "Empname";
                radMultiColumnComboBox41.DblClickRotate = true;

                radMultiColumnComboBox42.DataSource = dt;
                radMultiColumnComboBox42.DisplayMember = "Empname";
                radMultiColumnComboBox42.DblClickRotate = true;

                radMultiColumnComboBox44.DataSource = dt;
                radMultiColumnComboBox44.DisplayMember = "Empname";
                radMultiColumnComboBox44.DblClickRotate = true;

                radMultiColumnComboBox32.DataSource = dt;
                radMultiColumnComboBox32.DisplayMember = "Empname";
                radMultiColumnComboBox32.DblClickRotate = true;

                radMultiColumnComboBox30.DataSource = dt;
                radMultiColumnComboBox30.DisplayMember = "Empname";
                radMultiColumnComboBox30.DblClickRotate = true;

                radMultiColumnComboBox28.DataSource = dt;
                radMultiColumnComboBox28.DisplayMember = "Empname";
                radMultiColumnComboBox28.DblClickRotate = true;

                radMultiColumnComboBox29.DataSource = dt;
                radMultiColumnComboBox29.DisplayMember = "Empname";
                radMultiColumnComboBox29.DblClickRotate = true;

                radMultiColumnComboBox27.DataSource = dt;
                radMultiColumnComboBox27.DisplayMember = "Empname";
                radMultiColumnComboBox27.DblClickRotate = true;

                radMultiColumnComboBox26.DataSource = dt;
                radMultiColumnComboBox26.DisplayMember = "Empname";
                radMultiColumnComboBox26.DblClickRotate = true;

                radMultiColumnComboBox14.DataSource = dt;
                radMultiColumnComboBox14.DisplayMember = "Empname";
                radMultiColumnComboBox14.DblClickRotate = true;

                radMultiColumnComboBox15.DataSource = dt;
                radMultiColumnComboBox15.DisplayMember = "Empname";
                radMultiColumnComboBox15.DblClickRotate = true;

                radMultiColumnComboBox16.DataSource = dt;
                radMultiColumnComboBox16.DisplayMember = "Empname";
                radMultiColumnComboBox16.DblClickRotate = true;

                radMultiColumnComboBox17.DataSource = dt;
                radMultiColumnComboBox17.DisplayMember = "Empname";
                radMultiColumnComboBox17.DblClickRotate = true;

                radMultiColumnComboBox18.DataSource = dt;
                radMultiColumnComboBox18.DisplayMember = "Empname";
                radMultiColumnComboBox18.DblClickRotate = true;

                radMultiColumnComboBox20.DataSource = dt;
                radMultiColumnComboBox20.DisplayMember = "Empname";
                radMultiColumnComboBox20.DblClickRotate = true;

                radMultiColumnComboBox10.DataSource = dt;
                radMultiColumnComboBox10.DisplayMember = "Empname";
                radMultiColumnComboBox10.DblClickRotate = true;
                radMultiColumnComboBox12.DataSource = dt;
                radMultiColumnComboBox12.DisplayMember = "Empname";
                radMultiColumnComboBox12.DblClickRotate = true;

                radMultiColumnComboBox6.DataSource = dt;
                radMultiColumnComboBox6.DisplayMember = "Empname";
                radMultiColumnComboBox6.DblClickRotate = true;

                radMultiColumnComboBox8.DataSource = dt;
                radMultiColumnComboBox8.DisplayMember = "Empname";
                radMultiColumnComboBox8.DblClickRotate = true;

                radMultiColumnComboBox4.DataSource = dt;
                radMultiColumnComboBox4.DisplayMember = "Empname";
                radMultiColumnComboBox4.DblClickRotate = true;


                radMultiColumnComboBox2.DataSource = dt;
                radMultiColumnComboBox2.DisplayMember = "Empname";
                radMultiColumnComboBox2.DblClickRotate = true;


                clsobj.con.Close();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        
        }


        private void slctsubj()
        {
            try
            {
                clsobj.constate();
                clsobj.com = new SqlCommand("select * from Subject_Details Where Classname like '%" + radMultiColumnComboBox1.Text + "%'", clsobj.con);
                clsobj.com.Connection = clsobj.con;
                //clsobj.com.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(clsobj.com);
                da.Fill(ds);
                DataTable dt = ds.Tables[0];
                // dataGridView1.DataSource = dt;

                
                radMultiColumnComboBox3.DataSource = dt;
                radMultiColumnComboBox3.DisplayMember = "Subjname";
                radMultiColumnComboBox3.DblClickRotate = true;

                radMultiColumnComboBox5.DataSource = dt;
                radMultiColumnComboBox5.DisplayMember = "Subjname";
                radMultiColumnComboBox5.DblClickRotate = true;

                radMultiColumnComboBox7.DataSource = dt;
                radMultiColumnComboBox7.DisplayMember = "Subjname";
                radMultiColumnComboBox7.DblClickRotate = true;

                radMultiColumnComboBox9.DataSource = dt;
                radMultiColumnComboBox9.DisplayMember = "Subjname";
                radMultiColumnComboBox9.DblClickRotate = true;

                radMultiColumnComboBox11.DataSource = dt;
                radMultiColumnComboBox11.DisplayMember = "Subjname";
                radMultiColumnComboBox11.DblClickRotate = true;

                radMultiColumnComboBox13.DataSource = dt;
                radMultiColumnComboBox13.DisplayMember = "Subjname";
                radMultiColumnComboBox13.DblClickRotate = true;

                radMultiColumnComboBox19.DataSource = dt;
                radMultiColumnComboBox19.DisplayMember = "Subjname";
                radMultiColumnComboBox19.DblClickRotate = true;

                radMultiColumnComboBox21.DataSource = dt;
                radMultiColumnComboBox21.DisplayMember = "Subjname";
                radMultiColumnComboBox21.DblClickRotate = true;

                radMultiColumnComboBox25.DataSource = dt;
                radMultiColumnComboBox25.DisplayMember = "Subjname";
                radMultiColumnComboBox25.DblClickRotate = true;

                radMultiColumnComboBox22.DataSource = dt;
                radMultiColumnComboBox22.DisplayMember = "Subjname";
                radMultiColumnComboBox22.DblClickRotate = true;

                radMultiColumnComboBox23.DataSource = dt;
                radMultiColumnComboBox23.DisplayMember = "Subjname";
                radMultiColumnComboBox23.DblClickRotate = true;

                radMultiColumnComboBox24.DataSource = dt;
                radMultiColumnComboBox24.DisplayMember = "Subjname";
                radMultiColumnComboBox24.DblClickRotate = true;

                radMultiColumnComboBox31.DataSource = dt;
                radMultiColumnComboBox31.DisplayMember = "Subjname";
                radMultiColumnComboBox31.DblClickRotate = true;

                radMultiColumnComboBox33.DataSource = dt;
                radMultiColumnComboBox33.DisplayMember = "Subjname";
                radMultiColumnComboBox33.DblClickRotate = true;

                radMultiColumnComboBox37.DataSource = dt;
                radMultiColumnComboBox37.DisplayMember = "Subjname";
                radMultiColumnComboBox37.DblClickRotate = true;

                radMultiColumnComboBox34.DataSource = dt;
                radMultiColumnComboBox34.DisplayMember = "Subjname";
                radMultiColumnComboBox34.DblClickRotate = true;

                radMultiColumnComboBox35.DataSource = dt;
                radMultiColumnComboBox35.DisplayMember = "Subjname";
                radMultiColumnComboBox35.DblClickRotate = true;

                radMultiColumnComboBox36.DataSource = dt;
                radMultiColumnComboBox36.DisplayMember = "Subjname";
                radMultiColumnComboBox36.DblClickRotate = true;

                radMultiColumnComboBox43.DataSource = dt;
                radMultiColumnComboBox43.DisplayMember = "Subjname";
                radMultiColumnComboBox43.DblClickRotate = true;

                radMultiColumnComboBox45.DataSource = dt;
                radMultiColumnComboBox45.DisplayMember = "Subjname";
                radMultiColumnComboBox45.DblClickRotate = true;

                radMultiColumnComboBox49.DataSource = dt;
                radMultiColumnComboBox49.DisplayMember = "Subjname";
                radMultiColumnComboBox49.DblClickRotate = true;

                radMultiColumnComboBox46.DataSource = dt;
                radMultiColumnComboBox46.DisplayMember = "Subjname";
                radMultiColumnComboBox46.DblClickRotate = true;

                radMultiColumnComboBox47.DataSource = dt;
                radMultiColumnComboBox47.DisplayMember = "Subjname";
                radMultiColumnComboBox47.DblClickRotate = true;

                radMultiColumnComboBox48.DataSource = dt;
                radMultiColumnComboBox48.DisplayMember = "Subjname";
                radMultiColumnComboBox48.DblClickRotate = true;

                radMultiColumnComboBox60.DataSource = dt;
                radMultiColumnComboBox60.DisplayMember = "Subjname";
                radMultiColumnComboBox60.DblClickRotate = true;

                radMultiColumnComboBox61.DataSource = dt;
                radMultiColumnComboBox61.DisplayMember = "Subjname";
                radMultiColumnComboBox61.DblClickRotate = true;

                radMultiColumnComboBox59.DataSource = dt;
                radMultiColumnComboBox59.DisplayMember = "Subjname";
                radMultiColumnComboBox59.DblClickRotate = true;

                radMultiColumnComboBox58.DataSource = dt;
                radMultiColumnComboBox58.DisplayMember = "Subjname";
                radMultiColumnComboBox58.DblClickRotate = true;

                radMultiColumnComboBox57.DataSource = dt;
                radMultiColumnComboBox57.DisplayMember = "Subjname";
                radMultiColumnComboBox57.DblClickRotate = true;

                radMultiColumnComboBox55.DataSource = dt;
                radMultiColumnComboBox55.DisplayMember = "Subjname";
                radMultiColumnComboBox55.DblClickRotate = true;

                radMultiColumnComboBox67.DataSource = dt;
                radMultiColumnComboBox67.DisplayMember = "Subjname";
                radMultiColumnComboBox67.DblClickRotate = true;

                radMultiColumnComboBox69.DataSource = dt;
                radMultiColumnComboBox69.DisplayMember = "Subjname";
                radMultiColumnComboBox69.DblClickRotate = true;

                radMultiColumnComboBox71.DataSource = dt;
                radMultiColumnComboBox71.DisplayMember = "Subjname";
                radMultiColumnComboBox71.DblClickRotate = true;

                radMultiColumnComboBox70.DataSource = dt;
                radMultiColumnComboBox70.DisplayMember = "Subjname";
                radMultiColumnComboBox70.DblClickRotate = true;

                radMultiColumnComboBox72.DataSource = dt;
                radMultiColumnComboBox72.DisplayMember = "Subjname";
                radMultiColumnComboBox72.DblClickRotate = true;

                radMultiColumnComboBox73.DataSource = dt;
                radMultiColumnComboBox73.DisplayMember = "Subjname";
                radMultiColumnComboBox73.DblClickRotate = true;

                radMultiColumnComboBox79.DataSource = dt;
                radMultiColumnComboBox79.DisplayMember = "Subjname";
                radMultiColumnComboBox79.DblClickRotate = true;

                radMultiColumnComboBox81.DataSource = dt;
                radMultiColumnComboBox81.DisplayMember = "Subjname";
                radMultiColumnComboBox81.DblClickRotate = true;

                radMultiColumnComboBox82.DataSource = dt;
                radMultiColumnComboBox82.DisplayMember = "Subjname";
                radMultiColumnComboBox82.DblClickRotate = true;

                radMultiColumnComboBox83.DataSource = dt;
                radMultiColumnComboBox83.DisplayMember = "Subjname";
                radMultiColumnComboBox83.DblClickRotate = true;

                radMultiColumnComboBox84.DataSource = dt;
                radMultiColumnComboBox84.DisplayMember = "Subjname";
                radMultiColumnComboBox84.DblClickRotate = true;

                radMultiColumnComboBox85.DataSource = dt;
                radMultiColumnComboBox85.DisplayMember = "Subjname";
                radMultiColumnComboBox85.DblClickRotate = true;


                clsobj.con.Close();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        
        }


        private void Weekly_Timetable_Details_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'school_Management_SystemDataSet1.S_classess_Details' table. You can move, or remove it, as needed.
            this.s_classess_DetailsTableAdapter.Fill(this.school_Management_SystemDataSet1.S_classess_Details);

            cmbofrommonth.Items.Add("-Select Month-");
            cmbofrommonth.Items.Add("January");
            cmbofrommonth.Items.Add("February");
            cmbofrommonth.Items.Add("March");
            cmbofrommonth.Items.Add("April");
            cmbofrommonth.Items.Add("May");
            cmbofrommonth.Items.Add("June");
            cmbofrommonth.Items.Add("July");
            cmbofrommonth.Items.Add("August");
            cmbofrommonth.Items.Add("September");
            cmbofrommonth.Items.Add("October");
            cmbofrommonth.Items.Add("November");
            cmbofrommonth.Items.Add("December");
            cmbofrommonth.SelectedIndex = 0;
            cmbotomonth.Items.Add("-Select Month-");
            cmbotomonth.Items.Add("January");
            cmbotomonth.Items.Add("February");
            cmbotomonth.Items.Add("March");
            cmbotomonth.Items.Add("April");
            cmbotomonth.Items.Add("May");
            cmbotomonth.Items.Add("June");
            cmbotomonth.Items.Add("July");
            cmbotomonth.Items.Add("August");
            cmbotomonth.Items.Add("September");
            cmbotomonth.Items.Add("October");
            cmbotomonth.Items.Add("November");
            cmbotomonth.Items.Add("December");
            cmbotomonth.SelectedIndex = 0;

            slctempl();
            slctmax();
            slctsession();
            slctsubj();
        }

        private void slctsession()
        {

            try
            {
                clsobj.constate();
                clsobj.com = new SqlCommand("Select * from Session_Details", clsobj.con);
                clsobj.com.Connection = clsobj.con;
                //clsobj.com.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(clsobj.com);
                da.Fill(ds);
                DataTable dt = ds.Tables[0];
                cmbosession.DataSource = dt;
                cmbosession.DisplayMember = "SessionHead";
                cmbosession.ValueMember = "SessionID";

                clsobj.con.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void radMultiColumnComboBox56_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void slctclass()
        {
            try
            {
                clsobj.constate();
                clsobj.com = new SqlCommand("Select * from Classess_Details Where Classname like '%" + radMultiColumnComboBox1.Text + "%'", clsobj.con);
                clsobj.com.Connection = clsobj.con;
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
                            txtclassid.Text = dr["ClassID"].ToString();

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
            slctclass();
        }

        private void radMultiColumnComboBox57_SelectedIndexChanged(object sender, EventArgs e)
        {
            txttue5.Text = radMultiColumnComboBox51.Text + radMultiColumnComboBox57.Text;
        }

        private void radMultiColumnComboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtmon1.Text = radMultiColumnComboBox2.Text + radMultiColumnComboBox3.Text;

        }

        private void radMultiColumnComboBox19_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtmon2.Text = radMultiColumnComboBox14.Text + radMultiColumnComboBox19.Text;

        }

        private void radMultiColumnComboBox31_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtmon3.Text = radMultiColumnComboBox26.Text + radMultiColumnComboBox31.Text;
        }

        private void radMultiColumnComboBox43_SelectedIndexChanged(object sender, EventArgs e)
        {

            txtmon4.Text = radMultiColumnComboBox38.Text + radMultiColumnComboBox43.Text;


        }

        private void radMultiColumnComboBox55_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtmon5.Text = radMultiColumnComboBox50.Text + radMultiColumnComboBox55.Text;

        }

        private void radMultiColumnComboBox67_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtmon6.Text = radMultiColumnComboBox62.Text + radMultiColumnComboBox67.Text;
        }

        private void radMultiColumnComboBox79_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtmon7.Text = radMultiColumnComboBox74.Text + radMultiColumnComboBox79.Text;
        }

        private void radMultiColumnComboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            txttue1.Text = radMultiColumnComboBox4.Text + radMultiColumnComboBox5.Text;
        }

        private void radMultiColumnComboBox21_SelectedIndexChanged(object sender, EventArgs e)
        {
            txttue2.Text = radMultiColumnComboBox15.Text + radMultiColumnComboBox21.Text;
        }

        private void radMultiColumnComboBox33_SelectedIndexChanged(object sender, EventArgs e)
        {
            txttue3.Text = radMultiColumnComboBox27.Text + radMultiColumnComboBox33.Text;
        }

        private void radMultiColumnComboBox45_SelectedIndexChanged(object sender, EventArgs e)
        {
            txttue4.Text = radMultiColumnComboBox39.Text + radMultiColumnComboBox45.Text;
        }

        private void radMultiColumnComboBox69_SelectedIndexChanged(object sender, EventArgs e)
        {
            txttue6.Text = radMultiColumnComboBox63.Text + radMultiColumnComboBox69.Text;
        }

        private void radMultiColumnComboBox81_SelectedIndexChanged(object sender, EventArgs e)
        {
            txttue7.Text = radMultiColumnComboBox75.Text + radMultiColumnComboBox81.Text;
        }

        private void radMultiColumnComboBox9_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtwed1.Text = radMultiColumnComboBox8.Text + radMultiColumnComboBox9.Text;
  
        }

        private void radMultiColumnComboBox25_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtwed2.Text = radMultiColumnComboBox17.Text + radMultiColumnComboBox25.Text;
        }

        private void radMultiColumnComboBox37_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtwed3.Text = radMultiColumnComboBox28.Text + radMultiColumnComboBox37.Text;
        }

        private void radMultiColumnComboBox49_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtwed4.Text = radMultiColumnComboBox41.Text + radMultiColumnComboBox49.Text;
        }

        private void radMultiColumnComboBox61_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtwed5.Text = radMultiColumnComboBox53.Text + radMultiColumnComboBox61.Text;
        }

        private void radMultiColumnComboBox73_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtwed6.Text = radMultiColumnComboBox65.Text + radMultiColumnComboBox73.Text;
        }

        private void radMultiColumnComboBox85_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtwed7.Text = radMultiColumnComboBox77.Text + radMultiColumnComboBox85.Text;
        }

        private void radMultiColumnComboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtthur1.Text = radMultiColumnComboBox6.Text + radMultiColumnComboBox7.Text;
        }

        private void radMultiColumnComboBox22_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtthur2.Text = radMultiColumnComboBox16.Text + radMultiColumnComboBox22.Text;
        }

        private void radMultiColumnComboBox34_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtthur3.Text = radMultiColumnComboBox28.Text + radMultiColumnComboBox34.Text;
        }

        private void radMultiColumnComboBox46_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtthur4.Text = radMultiColumnComboBox40.Text + radMultiColumnComboBox46.Text;
        }

        private void radMultiColumnComboBox58_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtthur5.Text = radMultiColumnComboBox52.Text + radMultiColumnComboBox58.Text;
        }

        private void radMultiColumnComboBox70_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtthur6.Text = radMultiColumnComboBox64.Text + radMultiColumnComboBox70.Text;
        }

        private void radMultiColumnComboBox82_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtthur7.Text = radMultiColumnComboBox76.Text + radMultiColumnComboBox82.Text;
        }

        private void radMultiColumnComboBox11_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtfri1.Text = radMultiColumnComboBox10.Text + radMultiColumnComboBox11.Text;
        }

        private void radMultiColumnComboBox23_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtfri2.Text = radMultiColumnComboBox23.Text + radMultiColumnComboBox18.Text;
        }

        private void radMultiColumnComboBox35_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtfri3.Text = radMultiColumnComboBox30.Text + radMultiColumnComboBox35.Text;
        }

        private void radMultiColumnComboBox47_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtfri4.Text = radMultiColumnComboBox42.Text + radMultiColumnComboBox47.Text;
        }

        private void radMultiColumnComboBox59_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtfri5.Text = radMultiColumnComboBox54.Text + radMultiColumnComboBox59.Text;
        }

        private void radMultiColumnComboBox71_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtfri6.Text = radMultiColumnComboBox66.Text + radMultiColumnComboBox71.Text;
        }

        private void radMultiColumnComboBox83_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtfri7.Text = radMultiColumnComboBox83.Text + radMultiColumnComboBox78.Text;
        }

        private void radMultiColumnComboBox84_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtsat7.Text = radMultiColumnComboBox80.Text + radMultiColumnComboBox84.Text;

        }

        private void radMultiColumnComboBox72_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtsat6.Text = radMultiColumnComboBox68.Text + radMultiColumnComboBox72.Text;

        }

        private void radMultiColumnComboBox60_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtsat5.Text = radMultiColumnComboBox56.Text + radMultiColumnComboBox60.Text;

        }

        private void radMultiColumnComboBox48_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtsat4.Text = radMultiColumnComboBox44.Text + radMultiColumnComboBox48.Text;

        }

        private void radMultiColumnComboBox36_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtsat3.Text = radMultiColumnComboBox32.Text + radMultiColumnComboBox36.Text;

        }

        private void radMultiColumnComboBox24_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtsat2.Text = radMultiColumnComboBox20.Text + radMultiColumnComboBox24.Text;

        }

        private void radMultiColumnComboBox13_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtsat1.Text = radMultiColumnComboBox12.Text + radMultiColumnComboBox13.Text;

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
                clsobj.com = new SqlCommand("s_MAX_School_TimeTable_Details", clsobj.con);
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
            slctmax();

            cmbofrommonth.SelectedIndex = -1;
            cmbosession.SelectedIndex = -1;
            cmbotomonth.SelectedIndex = -1;
            txtclassid.Text = "";
            txtdescriptions.Text = "";
            txtfri1.Text = "";
            txtfri2.Text = "";
            txtfri3.Text = "";
            txtfri4.Text = "";
            txtfri5.Text = "";
            txtfri6.Text = "";
            txtfri7.Text = "";
            txtmon1.Text = "";
            txtmon2.Text = "";
            txtmon3.Text = "";
            txtmon4.Text = "";
            txtmon5.Text = "";
            txtmon6.Text = "";
            txtmon7.Text = "";
            txtsat1.Text = "";
            txtsat2.Text = "";
            txtsat3.Text = "";
            txtsat4.Text = "";
            txtsat5.Text = "";
            txtsat6.Text = "";
            txtsat7.Text = "";
            txtt1.Text = "";
            txtt2.Text = "";
            txtt3.Text = "";
            txtt4.Text = "";
            txtt5.Text = "";
            txtt6.Text = "";
            txtt7.Text = "";
            txtthur1.Text = "";
            txtthur2.Text = "";
            txtthur3.Text = "";
            txtthur4.Text = "";
            txtthur5.Text = "";
            txtthur6.Text = "";
            txtthur7.Text = "";
            txttue1.Text = "";
            txttue2.Text = "";
            txttue3.Text = "";
            txttue4.Text = "";
            txttue5.Text = "";
            txttue6.Text = "";
            txttue7.Text = "";
            txtwed1.Text = "";
            txtwed2.Text = "";
            txtwed3.Text = "";
            txtwed4.Text = "";
            txtwed5.Text = "";
            txtwed6.Text = "";
            txtwed7.Text = "";
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
                clsobj.com = new SqlCommand("i_School_TimeTable_Details", clsobj.con);
                clsobj.com.Connection = clsobj.con;
                clsobj.com.CommandType = CommandType.StoredProcedure;
                clsobj.com.Parameters.AddWithValue("@ClassID",txtclassid.Text );
                clsobj.com.Parameters.AddWithValue("@Classname",radMultiColumnComboBox1.Text );
                clsobj.com.Parameters.AddWithValue("@Time1",txtt1.Text );
                clsobj.com.Parameters.AddWithValue("@Time2",txtt2.Text );
                clsobj.com.Parameters.AddWithValue("@Time3",txtt3.Text );
                clsobj.com.Parameters.AddWithValue("@Time4",txtt4.Text );
                clsobj.com.Parameters.AddWithValue("@Time5",txtt5.Text );
                clsobj.com.Parameters.AddWithValue("@Time6",txtt6.Text );
                clsobj.com.Parameters.AddWithValue("@Time7",txtt7.Text );
                clsobj.com.Parameters.AddWithValue("@Mon1",txtmon1.Text );
                clsobj.com.Parameters.AddWithValue("@Mon2",txtmon2.Text );
                clsobj.com.Parameters.AddWithValue("@Mon3",txtmon3.Text );
                clsobj.com.Parameters.AddWithValue("@Mon4",txtmon4.Text );
                clsobj.com.Parameters.AddWithValue("@Mon5",txtmon5.Text );
                clsobj.com.Parameters.AddWithValue("@Mon6",txtmon6.Text );
                clsobj.com.Parameters.AddWithValue("@Mon7",txtmon7.Text );
                clsobj.com.Parameters.AddWithValue("@Tue1",txttue1.Text );
                clsobj.com.Parameters.AddWithValue("@Tue2",txttue2.Text );
                clsobj.com.Parameters.AddWithValue("@Tue3",txttue3.Text );
                clsobj.com.Parameters.AddWithValue("@Tue4",txttue4.Text );
                clsobj.com.Parameters.AddWithValue("@Tue5",txttue5.Text );
                clsobj.com.Parameters.AddWithValue("@Tue6",txttue6.Text );
                clsobj.com.Parameters.AddWithValue("@Tue7",txttue7.Text );
                clsobj.com.Parameters.AddWithValue("@Wed1",txtwed1.Text );
                clsobj.com.Parameters.AddWithValue("@Wed2",txtwed2.Text );
                clsobj.com.Parameters.AddWithValue("@Wed3",txtwed3.Text );
                clsobj.com.Parameters.AddWithValue("@Wed4",txtwed4.Text );
                clsobj.com.Parameters.AddWithValue("@Wed5",txtwed5.Text );
                clsobj.com.Parameters.AddWithValue("@Wed6",txtwed6.Text );
                clsobj.com.Parameters.AddWithValue("@Wed7",txtwed7.Text );
                clsobj.com.Parameters.AddWithValue("@Thur1",txtthur1.Text );
                clsobj.com.Parameters.AddWithValue("@Thur2",txtthur2.Text );
                clsobj.com.Parameters.AddWithValue("@Thur3",txtthur3.Text );
                clsobj.com.Parameters.AddWithValue("@Thur4",txtthur4.Text );
                clsobj.com.Parameters.AddWithValue("@Thur5",txtthur5.Text );
                clsobj.com.Parameters.AddWithValue("@Thur6",txtthur6.Text );
                clsobj.com.Parameters.AddWithValue("@Thur7",txtthur7.Text );
                clsobj.com.Parameters.AddWithValue("@Fri1",txtfri1.Text );
                clsobj.com.Parameters.AddWithValue("@Fri2",txtfri2.Text );
                clsobj.com.Parameters.AddWithValue("@Fri3",txtfri3.Text );
                clsobj.com.Parameters.AddWithValue("@Fri4",txtfri4.Text );
                clsobj.com.Parameters.AddWithValue("@Fri5",txtfri5.Text );
                clsobj.com.Parameters.AddWithValue("@Fri6",txtfri6.Text );
                clsobj.com.Parameters.AddWithValue("@Fri7",txtfri7.Text );
                clsobj.com.Parameters.AddWithValue("@Sat1",txtsat1.Text );
                clsobj.com.Parameters.AddWithValue("@Sat2",txtsat2.Text );
                clsobj.com.Parameters.AddWithValue("@Sat3",txtsat3.Text );
                clsobj.com.Parameters.AddWithValue("@Sat4",txtsat4.Text );
                clsobj.com.Parameters.AddWithValue("@Sat5",txtsat5.Text );
                clsobj.com.Parameters.AddWithValue("@Sat6",txtsat6.Text );
                clsobj.com.Parameters.AddWithValue("@Sat7",txtsat7.Text );
                clsobj.com.Parameters.AddWithValue("@Frommonth",cmbofrommonth.Text );
                clsobj.com.Parameters.AddWithValue("@Tomonth",cmbotomonth.Text );
                clsobj.com.Parameters.AddWithValue("@Year",cmbosession.Text );
                clsobj.com.Parameters.AddWithValue("@Descriptions",txtdescriptions.Text );
                clsobj.com.Parameters.AddWithValue("@IsActive",chkisactive.CheckState  );
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
            insertionss();
        }
        private void updationss()
        {
            try
            {
                clsobj.constate();
                clsobj.com = new SqlCommand("u_School_TimeTable_Details", clsobj.con);
                clsobj.com.Connection = clsobj.con;
                clsobj.com.CommandType = CommandType.StoredProcedure;
                clsobj.com.Parameters.AddWithValue("@Serialno", txtserialno.Text);

                clsobj.com.Parameters.AddWithValue("@ClassID",txtclassid.Text );
                clsobj.com.Parameters.AddWithValue("@Classname",radMultiColumnComboBox1.Text );
                clsobj.com.Parameters.AddWithValue("@Time1",txtt1.Text );
                clsobj.com.Parameters.AddWithValue("@Time2",txtt2.Text );
                clsobj.com.Parameters.AddWithValue("@Time3",txtt3.Text );
                clsobj.com.Parameters.AddWithValue("@Time4",txtt4.Text );
                clsobj.com.Parameters.AddWithValue("@Time5",txtt5.Text );
                clsobj.com.Parameters.AddWithValue("@Time6",txtt6.Text );
                clsobj.com.Parameters.AddWithValue("@Time7",txtt7.Text );
                clsobj.com.Parameters.AddWithValue("@Mon1",txtmon1.Text );
                clsobj.com.Parameters.AddWithValue("@Mon2",txtmon2.Text );
                clsobj.com.Parameters.AddWithValue("@Mon3",txtmon3.Text );
                clsobj.com.Parameters.AddWithValue("@Mon4",txtmon4.Text );
                clsobj.com.Parameters.AddWithValue("@Mon5",txtmon5.Text );
                clsobj.com.Parameters.AddWithValue("@Mon6",txtmon6.Text );
                clsobj.com.Parameters.AddWithValue("@Mon7",txtmon7.Text );
                clsobj.com.Parameters.AddWithValue("@Tue1",txttue1.Text );
                clsobj.com.Parameters.AddWithValue("@Tue2",txttue2.Text );
                clsobj.com.Parameters.AddWithValue("@Tue3",txttue3.Text );
                clsobj.com.Parameters.AddWithValue("@Tue4",txttue4.Text );
                clsobj.com.Parameters.AddWithValue("@Tue5",txttue5.Text );
                clsobj.com.Parameters.AddWithValue("@Tue6",txttue6.Text );
                clsobj.com.Parameters.AddWithValue("@Tue7",txttue7.Text );
                clsobj.com.Parameters.AddWithValue("@Wed1",txtwed1.Text );
                clsobj.com.Parameters.AddWithValue("@Wed2",txtwed2.Text );
                clsobj.com.Parameters.AddWithValue("@Wed3",txtwed3.Text );
                clsobj.com.Parameters.AddWithValue("@Wed4",txtwed4.Text );
                clsobj.com.Parameters.AddWithValue("@Wed5",txtwed5.Text );
                clsobj.com.Parameters.AddWithValue("@Wed6",txtwed6.Text );
                clsobj.com.Parameters.AddWithValue("@Wed7",txtwed7.Text );
                clsobj.com.Parameters.AddWithValue("@Thur1",txtthur1.Text );
                clsobj.com.Parameters.AddWithValue("@Thur2",txtthur2.Text );
                clsobj.com.Parameters.AddWithValue("@Thur3",txtthur3.Text );
                clsobj.com.Parameters.AddWithValue("@Thur4",txtthur4.Text );
                clsobj.com.Parameters.AddWithValue("@Thur5",txtthur5.Text );
                clsobj.com.Parameters.AddWithValue("@Thur6",txtthur6.Text );
                clsobj.com.Parameters.AddWithValue("@Thur7",txtthur7.Text );
                clsobj.com.Parameters.AddWithValue("@Fri1",txtfri1.Text );
                clsobj.com.Parameters.AddWithValue("@Fri2",txtfri2.Text );
                clsobj.com.Parameters.AddWithValue("@Fri3",txtfri3.Text );
                clsobj.com.Parameters.AddWithValue("@Fri4",txtfri4.Text );
                clsobj.com.Parameters.AddWithValue("@Fri5",txtfri5.Text );
                clsobj.com.Parameters.AddWithValue("@Fri6",txtfri6.Text );
                clsobj.com.Parameters.AddWithValue("@Fri7",txtfri7.Text );
                clsobj.com.Parameters.AddWithValue("@Sat1",txtsat1.Text );
                clsobj.com.Parameters.AddWithValue("@Sat2",txtsat2.Text );
                clsobj.com.Parameters.AddWithValue("@Sat3",txtsat3.Text );
                clsobj.com.Parameters.AddWithValue("@Sat4",txtsat4.Text );
                clsobj.com.Parameters.AddWithValue("@Sat5",txtsat5.Text );
                clsobj.com.Parameters.AddWithValue("@Sat6",txtsat6.Text );
                clsobj.com.Parameters.AddWithValue("@Sat7",txtsat7.Text );
                clsobj.com.Parameters.AddWithValue("@Frommonth",cmbofrommonth.Text );
                clsobj.com.Parameters.AddWithValue("@Tomonth",cmbotomonth.Text );
                clsobj.com.Parameters.AddWithValue("@Year",cmbosession.Text );
                clsobj.com.Parameters.AddWithValue("@Descriptions",txtdescriptions.Text );
                clsobj.com.Parameters.AddWithValue("@IsActive",chkisactive.Text );
                clsobj.com.ExecuteNonQuery();
                MsgsUpdations  msgs = new MsgsUpdations();
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
                clsobj.com = new SqlCommand("D_School_TimeTable_Details", clsobj.con);
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
    }
}

