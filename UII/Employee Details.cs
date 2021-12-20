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
    public partial class Employee_Details : Telerik.WinControls.UI.RadForm
    {
        public School_Management_System.DB_Connectivity.DB_Connection clsobj = new School_Management_System.DB_Connectivity.DB_Connection();
        int i;


        public Employee_Details()
        {
            InitializeComponent();
        }

        private void Employee_Details_Load(object sender, EventArgs e)
        {

            slctall();
            
            slctmax();


            txtdate.Text = DateTime.Today.ToShortDateString();

            ddob.Value =Convert.ToDateTime( DateTime.Today.ToShortDateString());

            cmbobgroup.Items.Add("--Select Blood Group--");
            cmbobgroup.Items.Add("O+ve");
            cmbobgroup.Items.Add("A+ve");
            cmbobgroup.Items.Add("B+ve");
            cmbobgroup.Items.Add("AB+ve");
            cmbobgroup.Items.Add("O-ve");
            cmbobgroup.Items.Add("B-ve");
            cmbobgroup.Items.Add("AB-ve");
            cmbobgroup.SelectedIndex = 0;

            cmbodesignation.Items.Add("--Select Designation--");
            cmbodesignation.Items.Add("Principal");
            cmbodesignation.Items.Add("Vice Principal");
            cmbodesignation.Items.Add("Senior Teacher");
            cmbodesignation.Items.Add("PET");
            cmbodesignation.Items.Add("Class Four");
            cmbodesignation.Items.Add("Watch Man");
            cmbodesignation.Items.Add("Gate Keeper");
            cmbodesignation.Items.Add("Office Boy");
            cmbodesignation.SelectedIndex = 0;

            cmboemptype.Items.Add("--Select Type--");
            cmboemptype.Items.Add("Permanent");
            cmboemptype.Items.Add("Ad-hoc");
            cmboemptype.Items.Add("Contract");
            cmboemptype.Items.Add("Visiting");
            cmboemptype.SelectedIndex = 0;

            cmbogender.Items.Add("--Select B.Group--");
            cmbogender.Items.Add("Male");
            cmbogender.Items.Add("Female");
            cmbogender.SelectedIndex = 0;

        
        }

        private void label13_Click(object sender, EventArgs e)
        {
            
        }

        private void radButton8_Click(object sender, EventArgs e)
        {
            try
            {

                openFileDialog1.InitialDirectory = "C://";
                openFileDialog1.Filter = "JPEG|*.jpg|PNG|*.png|BMP|*.bmp|ALL FILES|*.*";
                openFileDialog1.ShowDialog();
                pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void radButton5_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void txtempname_TextChanged(object sender, EventArgs e)
        {

            if (txtempname.Text == "")
            {
                txtempname.Text = "";

            }

            else
            {
                try
                {
                    string barcode = txtempname.Text;

                    Bitmap bitmap = new Bitmap(barcode.Length * 40, 120);

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

        private void clr()
        {
            txtage.Text = "";
            txtdate.Text = DateTime.Today.ToShortDateString();
            txtdegree.Text = "";
            txtdescriptions.Text = "";
            txtemail.Text = "";
            txtempname.Text = "";
            txtfname.Text = "";
            txtgrade.Text = "";
            txtpermaddress.Text = "";
            txtpostaddress.Text = "";
            txtsession.Text = "";
            txtuniv.Text = "";
            mskdcellno.Text = "";
            mskdcnic.Text = "";
            mskdphoneno.Text = "";
            cmbobgroup.SelectedIndex = 0;
            cmbodesignation.SelectedIndex = 0;
            cmboemptype.SelectedIndex = 0;
            cmbogender.SelectedIndex = 0;

            pictureBox1.Image = null;

            slctall();

            slctmax();


        }
        private void slctmax()
        {
            try
            {
                clsobj.constate();
                clsobj.com = new SqlCommand("s_max_Employee_Details", clsobj.con);
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
                        txtempid.Text = dr["EmployeeID"].ToString();

                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        private void radButton4_Click(object sender, EventArgs e)
        {
            clr();
        }

        private void txtpostaddress_TextChanged(object sender, EventArgs e)
        {
            if (txtpostaddress.Text == "as above")
            {
                txtpostaddress.Text = txtpermaddress.Text;
            }
            else if (txtpostaddress.Text == "As Above")
            {
                txtpostaddress.Text = txtpermaddress.Text;
            }
            else if (txtpostaddress.Text == "AS ABOVE")
            {
                txtpostaddress.Text = txtpermaddress.Text;
            }
          

        }

        private void slctall()
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
                dataGridView1.DataSource = dt;
                clsobj.con.Close();
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
                clsobj.com = new SqlCommand("i_Employee_Details", clsobj.con);
                clsobj.com.Connection = clsobj.con;
                clsobj.com.CommandType = CommandType.StoredProcedure;
                clsobj.com.Parameters.AddWithValue("@EmpID", txtempid.Text);
                clsobj.com.Parameters.AddWithValue("@Empname", txtempname.Text);
                clsobj.com.Parameters.AddWithValue("@Fname", txtfname.Text);
                clsobj.com.Parameters.AddWithValue("@DOB", ddob.Value.ToShortDateString());
                clsobj.com.Parameters.AddWithValue("@Age", txtage.Text );
                clsobj.com.Parameters.AddWithValue("@Gender", cmbogender.Text );
                clsobj.com.Parameters.AddWithValue("@BGroup", cmbobgroup.Text);
                clsobj.com.Parameters.AddWithValue("@EmpType", cmboemptype.Text);
                clsobj.com.Parameters.AddWithValue("@EmpDesignation", cmbodesignation.Text);
                clsobj.com.Parameters.AddWithValue("@PermAddress", txtpermaddress.Text);
                clsobj.com.Parameters.AddWithValue("@PostAddress", txtpostaddress.Text);
                clsobj.com.Parameters.AddWithValue("@CNIC", mskdcnic.Text );
                clsobj.com.Parameters.AddWithValue("@Cellno", mskdcellno.Text);
                clsobj.com.Parameters.AddWithValue("@Phoneno", mskdphoneno.Text);
                clsobj.com.Parameters.AddWithValue("@Email", txtemail.Text);
                clsobj.com.Parameters.AddWithValue("@Degree", txtdegree.Text);
                clsobj.com.Parameters.AddWithValue("@Univ", txtuniv.Text);
                clsobj.com.Parameters.AddWithValue("@Grade", txtgrade.Text);
                clsobj.com.Parameters.AddWithValue("@Session", txtsession.Text);
                clsobj.com.Parameters.AddWithValue("@JoiningDate", txtdate.Text );
                clsobj.com.Parameters.AddWithValue("@Descriptions", txtdescriptions.Text);
                clsobj.com.Parameters.AddWithValue("@Status", chkisactive.CheckState);
                if (pictureBox1.Image != null)
                {
                    clsobj.com.Parameters.Add("@Pics", SqlDbType.Image).Value = ImageFunction.imageToByteArray(pictureBox1.Image);
                }
                else
                {
                    MessageBox.Show("Please Upload an Image to Save the Record.", "GHS Says", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                }
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
            if (txtempid.Text == "")
            {
                txtempid.Text = "0";
            }
            else
            {
                i = Convert.ToInt32(txtempid.Text);
                i += 1;

                txtempid.Text = i.ToString();
            }
            insertionss();

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {


        }

        private void updationss()
        {
            try
            {
                clsobj.constate();
                clsobj.com = new SqlCommand("u_Employee_Details", clsobj.con);
                clsobj.com.Connection = clsobj.con;
                clsobj.com.CommandType = CommandType.StoredProcedure;
                clsobj.com.Parameters.AddWithValue("@EmpID", txtempid.Text);
                clsobj.com.Parameters.AddWithValue("@Empname", txtempname.Text);
                clsobj.com.Parameters.AddWithValue("@Fname", txtfname.Text);
                clsobj.com.Parameters.AddWithValue("@DOB", ddob.Value.ToShortDateString());
                clsobj.com.Parameters.AddWithValue("@Age", txtage.Text);
                clsobj.com.Parameters.AddWithValue("@Gender", cmbogender.Text);
                clsobj.com.Parameters.AddWithValue("@BGroup", cmbobgroup.Text);
                clsobj.com.Parameters.AddWithValue("@EmpType", cmboemptype.Text);
                clsobj.com.Parameters.AddWithValue("@EmpDesignation", cmbodesignation.Text);
                clsobj.com.Parameters.AddWithValue("@PermAddress", txtpermaddress.Text);
                clsobj.com.Parameters.AddWithValue("@PostAddress", txtpostaddress.Text);
                clsobj.com.Parameters.AddWithValue("@CNIC", mskdcnic.Text);
                clsobj.com.Parameters.AddWithValue("@Cellno", mskdcellno.Text);
                clsobj.com.Parameters.AddWithValue("@Phoneno", mskdphoneno.Text);
                clsobj.com.Parameters.AddWithValue("@Email", txtemail.Text);
                clsobj.com.Parameters.AddWithValue("@Degree", txtdegree.Text);
                clsobj.com.Parameters.AddWithValue("@Univ", txtuniv.Text);
                clsobj.com.Parameters.AddWithValue("@Grade", txtgrade.Text);
                clsobj.com.Parameters.AddWithValue("@Session", txtsession.Text);
                clsobj.com.Parameters.AddWithValue("@JoiningDate", txtdate.Text);
                clsobj.com.Parameters.AddWithValue("@Descriptions", txtdescriptions.Text);
                clsobj.com.Parameters.AddWithValue("@Status", chkisactive.CheckState);
                if (pictureBox1.Image != null)
                {
                    clsobj.com.Parameters.Add("@Pics", SqlDbType.Image).Value = ImageFunction.imageToByteArray(pictureBox1.Image);
                }
                else
                {
                    MessageBox.Show("Please Upload an Image to Save the Record.", "GHS Says", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                }
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
                clsobj.com = new SqlCommand("d_Employee_Details", clsobj.con);
                clsobj.com.Connection = clsobj.con;
                clsobj.com.CommandType = CommandType.StoredProcedure;
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
                txtempid.Text = this.dataGridView1.Rows[i].Cells[0].Value.ToString();
                txtempname.Text = this.dataGridView1.Rows[i].Cells[1].Value.ToString();
                txtfname.Text = this.dataGridView1.Rows[i].Cells[2].Value.ToString();
               ddob.Value  =Convert.ToDateTime(this.dataGridView1.Rows[i].Cells[3].Value.ToString());
               txtage.Text = this.dataGridView1.Rows[i].Cells[4].Value.ToString();
               cmbogender.Text = this.dataGridView1.Rows[i].Cells[5].Value.ToString();
               cmbobgroup.Text = this.dataGridView1.Rows[i].Cells[6].Value.ToString();
               cmboemptype.Text = this.dataGridView1.Rows[i].Cells[7].Value.ToString();
               cmbodesignation.Text = this.dataGridView1.Rows[i].Cells[8].Value.ToString();
               txtpermaddress.Text = this.dataGridView1.Rows[i].Cells[9].Value.ToString();
               txtpostaddress.Text = this.dataGridView1.Rows[i].Cells[10].Value.ToString();
               mskdcnic.Text = this.dataGridView1.Rows[i].Cells[11].Value.ToString();
               mskdcellno.Text = this.dataGridView1.Rows[i].Cells[12].Value.ToString();
               mskdphoneno.Text = this.dataGridView1.Rows[i].Cells[13].Value.ToString();
               txtemail.Text = this.dataGridView1.Rows[i].Cells[14].Value.ToString();
               txtdegree.Text = this.dataGridView1.Rows[i].Cells[15].Value.ToString();
               txtuniv.Text = this.dataGridView1.Rows[i].Cells[16].Value.ToString();
               txtgrade.Text = this.dataGridView1.Rows[i].Cells[17].Value.ToString();
               txtsession.Text = this.dataGridView1.Rows[i].Cells[18].Value.ToString();
               txtdate.Text = this.dataGridView1.Rows[i].Cells[19].Value.ToString();
               txtdescriptions.Text = this.dataGridView1.Rows[i].Cells[20].Value.ToString();
                chkisactive.Checked=Convert.ToBoolean(dataGridView1.Rows[i].Cells[21].Value.ToString());
                pictureBox1.Image = dataGridView1.CurrentRow.Cells["Pics"].Value == DBNull.Value ? null : ImageFunction.ByteArrayToImage((byte[])dataGridView1.CurrentRow.Cells["Pics"].Value);

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
        private void cnicauto()
        {
            try
            {
                clsobj.constate();
                clsobj.com = new SqlCommand("Select CNIC from Employee_Details Where CNIC like '%" + txtsearchby.Text + "%'", clsobj.con);
                clsobj.com.Connection = clsobj.con;
                SqlDataReader dr = clsobj.com.ExecuteReader();
                while (dr.Read())
                {
                    txtsearchby.AutoCompleteCustomSource.Add(dr["CNIC"].ToString());
                }
                clsobj.con.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        private void srchbycnic()
        {
            try
            {
                clsobj.constate();
                clsobj.com = new SqlCommand("Select * from Employee_Details Where CNIC like '%" + txtsearchby.Text + "%'", clsobj.con);
                clsobj.com.Connection = clsobj.con;
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(clsobj.com);
                da.Fill(ds);
                DataTable dt = ds.Tables[0];
                dataGridView1.DataSource = dt;
                clsobj.con.Close();
                cnicauto();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        private void desigauto()
        {
            try
            {
                clsobj.constate();
                clsobj.com = new SqlCommand("Select EmpDesignation from Employee_Details Where EmpDesignation like '%" + txtsearchby.Text + "%'", clsobj.con);
                clsobj.com.Connection = clsobj.con;
                SqlDataReader dr = clsobj.com.ExecuteReader();
                while (dr.Read())
                {
                    txtsearchby.AutoCompleteCustomSource.Add(dr["EmpDesignation"].ToString());
                }
                clsobj.con.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        private void srchbydesignation()
        {
            try
            {
                clsobj.constate();
                clsobj.com = new SqlCommand("Select * from Employee_Details Where EmpDesignation like '%" + txtsearchby.Text + "%'", clsobj.con);
                clsobj.com.Connection = clsobj.con;
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(clsobj.com);
                da.Fill(ds);
                DataTable dt = ds.Tables[0];
                dataGridView1.DataSource = dt;
                clsobj.con.Close();
                desigauto();
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
                clsobj.com = new SqlCommand("Select * from Employee_Details Where Empname like '%" + txtsearchby.Text + "%'", clsobj.con);
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
                clsobj.com = new SqlCommand("Select Empname from Employee_Details Where Empname like '%" + txtsearchby.Text + "%'", clsobj.con);
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
        private void typeauto()
        {
            try
            {
                clsobj.constate();
                clsobj.com = new SqlCommand("Select EmpType from Employee_Details Where EmpType like '%" + txtsearchby.Text + "%'", clsobj.con);
                clsobj.com.Connection = clsobj.con;
                SqlDataReader dr = clsobj.com.ExecuteReader();
                while (dr.Read())
                {
                    txtsearchby.AutoCompleteCustomSource.Add(dr["EmpType"].ToString());
                }
                clsobj.con.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        private void srchbytype()
        {
            try
            {
                clsobj.constate();
                clsobj.com = new SqlCommand("Select * from Employee_Details Where EmpType like '%" + txtsearchby.Text + "%'", clsobj.con);
                clsobj.com.Connection = clsobj.con;
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(clsobj.com);
                da.Fill(ds);
                DataTable dt = ds.Tables[0];
                dataGridView1.DataSource = dt;
                clsobj.con.Close();
                typeauto();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        private void txtsearchby_TextChanged(object sender, EventArgs e)
        {
            if (rdiocnic.IsChecked == true)
            { srchbycnic(); }
            else if (rdiodesignation.IsChecked == true)
            { srchbydesignation(); }
            else if (rdioname.IsChecked == true)
            { srchbyname(); }
            else if (rdiotype.IsChecked == true)
            { srchbytype(); }

        }

        private void ddob_ValueChanged(object sender, EventArgs e)
        {
            DateTime d1 = DateTime.Parse(ddob.Value.ToShortDateString());
            DateTime d2 = DateTime.Parse(DateTime.Today.ToShortDateString());
            // TimeSpan     days =  d2 - d1;
            // double d =Convert.ToDouble  (days);
            // double age =Convert.ToDouble  (d / 365);
            int year = (d2 - d1).Days / 365;


            txtage.Text = year.ToString();
        }
    }
}
