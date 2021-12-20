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
using System.Speech.Synthesis;
using System.Data.SqlClient;
using School_Management_System.DB_Connectivity;
namespace School_Management_System.UI
{
    public partial class User_Validation : Telerik.WinControls.UI.RadForm
    {
        public School_Management_System.DB_Connectivity.DB_Connection clsobj = new School_Management_System.DB_Connectivity.DB_Connection();

        SpeechSynthesizer reader;
        public User_Validation()
        {
            InitializeComponent();
        }

        private void User_Validation_Load(object sender, EventArgs e)
        {

        }

        private void radButton4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tmr()
        {
            try
            {

                if (radProgressBar1.Value1 == 100)
                {
                    // this.Hide();
                    timer1.Stop();
                    lgin();
                    //FY_College_Management_System_CMS fycms = new FY_College_Management_System_CMS();
                    //Login lgin = new Login();
                    //lgin.Show();
                    //  fycms.Show();

                }
                else
                {
                    radProgressBar1.Value1 += 10;
                    radProgressBar1.Text = radProgressBar1.Value1.ToString() + "%";

                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        private void clr()
        {

            txtpassword.Text = "";
            txtusername.Text = "";

        }

        private void lgin()
        {
            try
            {
                if (txtusername.Text == "")
                {
                    reader = new SpeechSynthesizer();
                    reader.SpeakAsync("User Not Validated Successfully. Try Again");
                    radProgressBar1.Value1 = 0;
                    radProgressBar1.Text = "0" + "%";
                    errorProvider1.SetError(txtusername, "Invalid Username/Password!!");
                    errorProvider1.SetError(txtpassword, "Invalid Username/Password!!");
                }
                else if (txtpassword.Text == "")
                {
                    reader = new SpeechSynthesizer();
                    reader.SpeakAsync("User Not Validated Successfully. Try Again");
                    radProgressBar1.Value1 = 0;
                    radProgressBar1.Text = "0" + "%";
                    errorProvider1.SetError(txtusername, "Invalid Username/Password!!");
                    errorProvider1.SetError(txtpassword, "Invalid Username/Password!!");
                }
                else
                {

                    clsobj.constate();
                    clsobj.com = new SqlCommand("Select * from User_Details Where Username = '" + txtusername.Text + "' and Password = '" + txtpassword.Text + "'", clsobj.con);
                    clsobj.com.Connection = clsobj.con;
                    clsobj.com.Parameters.AddWithValue("@Username", txtusername.Text);
                    clsobj.com.Parameters.AddWithValue("@Password", txtpassword.Text);

                    SqlDataAdapter da = new SqlDataAdapter(clsobj.com);
                    DataSet ds = new DataSet();

                    ds = new DataSet();


                    da.Fill(ds, "Lgining");
                    DataTable dt = ds.Tables[0];
                    if (ds.Tables["Lgining"].Rows.Count > 0)
                    {
                        SqlDataReader dr = clsobj.com.ExecuteReader();
                        while (dr.Read())
                        {



                            reader = new SpeechSynthesizer();
                            reader.SpeakAsync("User Validated. Welcome");



                            Government_High_School_Topsin ghs = new Government_High_School_Topsin();
                            ghs.Show();

                            this.Hide();

                        }


                    }
                    else
                    {
                        clr();
                        radProgressBar1.Value1 = 0;
                        radProgressBar1.Text = "0" + "%";
                        reader = new SpeechSynthesizer();
                        reader.SpeakAsync("User Not Validated Successfully. Try Again");
                        errorProvider1.SetError(txtusername, "Invalid Username/Password!!");
                        errorProvider1.SetError(txtpassword, "Invalid Username/Password!!");
                    }
                    clsobj.con.Close();


                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);

            }
        }

        private void radButton3_Click(object sender, EventArgs e)
        {
            timer1.Start();
            tmr();
        }

        private void txtpassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                timer1.Start();
                tmr();
            }
        }

        private void txtusername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtpassword.Focus();

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            tmr();
        }
    }
}
