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
using System.Data.Sql;
using School_Management_System.DB_Connectivity;

namespace School_Management_System.UI
{
    public partial class Students_Details : Telerik.WinControls.UI.RadForm
    {
        public School_Management_System.DB_Connectivity.DB_Connection clsobj = new School_Management_System.DB_Connectivity.DB_Connection();

        int i,j;


        public Students_Details()
        {
            InitializeComponent();
        }

        private void radPageViewPage3_Paint(object sender, PaintEventArgs e)
        {
        
        }

        private void radPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void insertionss()
        {
            try
            {
                clsobj.constate();
                clsobj.com = new SqlCommand("i_Students_Details", clsobj.con);
                clsobj.com.Connection = clsobj.con;
                clsobj.com.CommandType = CommandType.StoredProcedure;
                clsobj.com.Parameters.AddWithValue("@StdID",txtstudentid.Text );
                clsobj.com.Parameters.AddWithValue("@Regno",txtregno.Text );
                clsobj.com.Parameters.AddWithValue("@Stdname",txtstdname.Text );
                clsobj.com.Parameters.AddWithValue("@Fname",txtfname.Text );
                clsobj.com.Parameters.AddWithValue("@DOB",ddob.Value.ToShortDateString());
                clsobj.com.Parameters.AddWithValue("@Age",txtage.Text );
                clsobj.com.Parameters.AddWithValue("@Inwords",txtinwords.Text );
                clsobj.com.Parameters.AddWithValue("@Gender",cmbogender.Text );
                clsobj.com.Parameters.AddWithValue("@GuardianOccupation",txtguardianoccupation.Text );
                clsobj.com.Parameters.AddWithValue("@CNIC",mskdcnic.Text );
                clsobj.com.Parameters.AddWithValue("@PreviousClass",radMultiColumnComboBox1.Text );
                clsobj.com.Parameters.AddWithValue("@ClassID",txtclassid.Text );
                clsobj.com.Parameters.AddWithValue("@AdmittedinClass",radMultiColumnComboBox2.Text );
                clsobj.com.Parameters.AddWithValue("@Classno",txtclassno.Text );
                clsobj.com.Parameters.AddWithValue("@Rollno",txtrollno.Text );
                clsobj.com.Parameters.AddWithValue("@AdmissionDate",txtadmdate.Text );
                clsobj.com.Parameters.AddWithValue("@Domicile",cmbodomicile.Text );
                clsobj.com.Parameters.AddWithValue("@PermAddress",txtpermaddr.Text );
                  clsobj.com.Parameters.AddWithValue("@PostAddress",txtpostaddr.Text );
                    clsobj.com.Parameters.AddWithValue("@Contactno",mskdcontactno.Text );
                    clsobj.com.Parameters.AddWithValue("@Descriptions",txtdescriptions.Text );
                    clsobj.com.Parameters.AddWithValue("@Status",chkisactive.CheckState );
                    if (pictureBox1.Image != null)
                    {
                        clsobj.com.Parameters.Add("@Pics", SqlDbType.Image).Value = ImageFunction.imageToByteArray(pictureBox1.Image);
                    }
                    else
                    {
                        MessageBox.Show("Please Upload an Image to Save the Record.", "GHS Says", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                    }
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
            if (txtstudentid.Text == "")
            { txtstudentid.Text = "0"; }
            else
            {
                i = Convert.ToInt32(txtstudentid.Text);
                i += 1;
                txtstudentid.Text = i.ToString();
              


                txtregno.Text = txtregno.Text + txtstudentid.Text;
                txtrollno.Text = txtstudentid.Text;
                if (txtclassno.Text == "")
                {
                    txtclassno.Text = "1";
                    insertionss();
                }
                else
                {
                    j = Convert.ToInt32(txtclassno.Text);
                    j  += 1;
                    txtclassno.Text = j.ToString();
 insertionss(); 
                }
                   
            }

            
        }

        private void radButton5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void clr()
        {
            txtadmdate.Text = DateTime.Today.ToShortDateString();
            txtage.Text = "";
            txtclassid.Text = "";
            txtclassno.Text = "";
            txtdescriptions.Text = "";
            txtfname.Text = "";
            txtguardianoccupation.Text = "";
            txtinwords.Text = "";
            pictureBox1.Image = null;

            txtpermaddr.Text = "";
            txtpostaddr.Text = "";
          //  txtregno.Text = "";
            txtrollno.Text = "";
            txtstdname.Text = "";
            mskdcnic.Text = "";
            mskdcontactno.Text = "";
            cmbodomicile.SelectedIndex = 0;
            cmbogender.SelectedIndex = 0;
            chkisactive.Checked = false;

            slctall();

            slctmax();

        }

        private void slctmax()
        {
            try
            {
                clsobj.constate();
                clsobj.com = new SqlCommand("S_max_Students_Details", clsobj.con);
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
                        txtstudentid.Text  = dr["ID"].ToString();

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
                  clsobj.com = new SqlCommand("S_active_Students_Details", clsobj.con);
                clsobj.com.Connection = clsobj.con;
                clsobj.com.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(clsobj.com );
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


        private void radButton4_Click(object sender, EventArgs e)
        {
            clr();
        }

        private void Students_Details_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'school_Management_SystemDataSet.S_classess_Details' table. You can move, or remove it, as needed.
            this.s_classess_DetailsTableAdapter.Fill(this.school_Management_SystemDataSet.S_classess_Details);
            txtadmdate.Text = DateTime.Today.ToShortDateString();
            cmbogender.Items.Add("--Select Gender--");
            cmbogender.Items.Add("Male");
            cmbogender.Items.Add("Female");

            cmbogender.SelectedIndex = 0;


            cmbodomicile.Items.Add("--Select Domicile");
            cmbodomicile.Items.Add("Swat");
            cmbodomicile.Items.Add("Buner");
            cmbodomicile.Items.Add("Dir");
            cmbodomicile.Items.Add("Malakand");
            cmbodomicile.Items.Add("Shangle");
            cmbodomicile.Items.Add("Peshawar");
            cmbodomicile.Items.Add("Chitral");
            cmbodomicile.Items.Add("Mardan");
            cmbodomicile.Items.Add("DI Khan");
            cmbodomicile.Items.Add("DG Khan");
            
            cmbodomicile.SelectedIndex = 0;

          //  slctclass();
            slctall();


            slctmax();



        }

        private void slctclass()
        {
            try
            {
                clsobj.constate();
                clsobj.com = new SqlCommand("S_active_Students_Details", clsobj.con);
                clsobj.com.Connection = clsobj.con;
                clsobj.com.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(clsobj.com);
                da.Fill(ds);
                DataTable dt = ds.Tables[0];
                radMultiColumnComboBox1.DataSource = dt;
                radMultiColumnComboBox2.DataSource = dt;
                clsobj.con.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);

            }
        }

        private void txtstdname_TextChanged(object sender, EventArgs e)
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

        private void updationss()
        {
            try
            {
                clsobj.constate();
                clsobj.com = new SqlCommand("u_Students_Details", clsobj.con);
                clsobj.com.Connection = clsobj.con;
                clsobj.com.CommandType = CommandType.StoredProcedure;
                clsobj.com.Parameters.AddWithValue("@StdID", txtstudentid.Text);
                clsobj.com.Parameters.AddWithValue("@Regno", txtregno.Text);
                clsobj.com.Parameters.AddWithValue("@Stdname", txtstdname.Text);
                clsobj.com.Parameters.AddWithValue("@Fname", txtfname.Text);
                clsobj.com.Parameters.AddWithValue("@DOB", ddob.Value.ToShortDateString());
                clsobj.com.Parameters.AddWithValue("@Age", txtage.Text);
                clsobj.com.Parameters.AddWithValue("@Inwords", txtinwords.Text);
                clsobj.com.Parameters.AddWithValue("@Gender", cmbogender.Text);
                clsobj.com.Parameters.AddWithValue("@GuardianOccupation", txtguardianoccupation.Text);
                clsobj.com.Parameters.AddWithValue("@CNIC", mskdcnic.Text);
                clsobj.com.Parameters.AddWithValue("@PreviousClass", radMultiColumnComboBox1.Text);
                clsobj.com.Parameters.AddWithValue("@ClassID", txtclassid.Text);
                clsobj.com.Parameters.AddWithValue("@AdmittedinClass", radMultiColumnComboBox2.Text);
                clsobj.com.Parameters.AddWithValue("@Classno", txtclassno.Text);
                clsobj.com.Parameters.AddWithValue("@Rollno", txtrollno.Text);
                clsobj.com.Parameters.AddWithValue("@AdmissionDate", txtadmdate.Text);
                clsobj.com.Parameters.AddWithValue("@Domicile", cmbodomicile.Text);
                clsobj.com.Parameters.AddWithValue("@PermAddress", txtpermaddr.Text);
                clsobj.com.Parameters.AddWithValue("@PostAddress", txtpostaddr.Text);
                clsobj.com.Parameters.AddWithValue("@Contactno", mskdcontactno.Text);
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
            txtregno.Text = txtregno.Text + txtstudentid.Text;
            updationss();
        }
        private void DELETIONSS()
        {
            try
            {
                 clsobj.constate();
                clsobj.com = new SqlCommand("d_Students_Details", clsobj.con);
                clsobj.com.Connection = clsobj.con;
                clsobj.com.CommandType = CommandType.StoredProcedure;
                clsobj.com.Parameters.AddWithValue("@StdID", txtstudentid.Text);
             
                clsobj.com.ExecuteNonQuery();
                MsgsDeletions  msgs = new MsgsDeletions();
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
            DELETIONSS();
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
                txtstudentid.Text = this.dataGridView1.Rows[i].Cells[0].Value.ToString();
                txtregno.Text = this.dataGridView1.Rows[i].Cells[1].Value.ToString();
                txtstdname.Text = this.dataGridView1.Rows[i].Cells[2].Value.ToString();
                txtfname.Text = this.dataGridView1.Rows[i].Cells[3].Value.ToString();
                ddob.Value =Convert.ToDateTime(this.dataGridView1.Rows[i].Cells[4].Value.ToString());
                txtage.Text = this.dataGridView1.Rows[i].Cells[5].Value.ToString();
                txtinwords.Text = this.dataGridView1.Rows[i].Cells[6].Value.ToString();
                cmbogender.Text = this.dataGridView1.Rows[i].Cells[7].Value.ToString();
                txtguardianoccupation.Text = this.dataGridView1.Rows[i].Cells[8].Value.ToString();
                mskdcnic.Text = this.dataGridView1.Rows[i].Cells[9].Value.ToString();
               radMultiColumnComboBox1.Text = this.dataGridView1.Rows[i].Cells[10].Value.ToString();
               txtclassid.Text = this.dataGridView1.Rows[i].Cells[11].Value.ToString();
                radMultiColumnComboBox2.Text = this.dataGridView1.Rows[i].Cells[12].Value.ToString();
                txtclassno.Text = this.dataGridView1.Rows[i].Cells[13].Value.ToString();
                txtrollno.Text = this.dataGridView1.Rows[i].Cells[14].Value.ToString();
                txtadmdate.Text = this.dataGridView1.Rows[i].Cells[15].Value.ToString();
                cmbodomicile.Text = this.dataGridView1.Rows[i].Cells[16].Value.ToString();
                txtpermaddr.Text = this.dataGridView1.Rows[i].Cells[17].Value.ToString();
                txtpostaddr.Text = this.dataGridView1.Rows[i].Cells[18].Value.ToString();
                mskdcontactno.Text = this.dataGridView1.Rows[i].Cells[19].Value.ToString();
                txtdescriptions.Text = this.dataGridView1.Rows[i].Cells[20].Value.ToString();
                chkisactive.Checked =Convert.ToBoolean( this.dataGridView1.Rows[i].Cells[21].Value.ToString());
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
                clsobj.com = new SqlCommand("Select CNIC from Students_Details Where CNIC like '%" + txtsearchby.Text + "%'", clsobj.con);
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
                clsobj.com = new SqlCommand("Select * from Students_Details Where CNIC like '%" + txtsearchby.Text + "%'", clsobj.con);
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

        private void domauto()
        {
            try
            {
                clsobj.constate();
                clsobj.com = new SqlCommand("Select Domicile from Students_Details Where Domicile like '%" + txtsearchby.Text + "%'", clsobj.con);
                clsobj.com.Connection = clsobj.con;
                SqlDataReader dr = clsobj.com.ExecuteReader();
                while (dr.Read())
                {
                    txtsearchby.AutoCompleteCustomSource.Add(dr["Domicile"].ToString());
                }
                clsobj.con.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        private void srchbydomicile()
        {
            try
            {
                clsobj.constate();
                clsobj.com = new SqlCommand("Select * from Students_Details Where Domicile like '%" + txtsearchby.Text + "%'", clsobj.con);
                clsobj.com.Connection = clsobj.con;
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(clsobj.com);
                da.Fill(ds);
                DataTable dt = ds.Tables[0];
                dataGridView1.DataSource = dt;
                clsobj.con.Close();
                domauto();
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
                clsobj.com = new SqlCommand("Select * from Students_Details Where Stdname like '%" + txtsearchby.Text + "%'", clsobj.con);
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
                clsobj.com = new SqlCommand("Select Stdname from Students_Details Where Stdname like '%" + txtsearchby.Text + "%'", clsobj.con);
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

        private void srchbyregno()
        {
            try
            {
clsobj.constate();
                clsobj.com = new SqlCommand("Select * from Students_Details Where Regno like '%" + txtsearchby.Text + "%'", clsobj.con);
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
                clsobj.com = new SqlCommand("Select Regno from Students_Details Where Regno like '%" + txtsearchby.Text + "%'", clsobj.con);
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
            if (rdiocnic.IsChecked == true)
            { srchbycnic(); }
            else if (rdiodomicile.IsChecked == true)
            { srchbydomicile(); }
            else if (rdioname.IsChecked == true)
            { srchbyname(); }
            else if (rdioregno.IsChecked == true)
            { srchbyregno(); }
        }

        private void slctclassid()
        {
            try
            {
                clsobj.constate();
                clsobj.com = new SqlCommand("Select * from Classess_Details Where Classname like '%" + radMultiColumnComboBox2.Text  + "%'", clsobj.con);
                clsobj.com.Connection = clsobj.con;
                SqlDataReader dr = clsobj.com.ExecuteReader();
                while (dr.Read())
                {
                    txtclassid.Text = dr["ClassID"].ToString();
                }
                clsobj.con.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void slctmaxcno()
        {
            try
            {
                 clsobj.constate();
                 clsobj.com = new SqlCommand("Select Max(Classno) as CNO from Students_Details Where AdmittedinClass like '%" + radMultiColumnComboBox2.Text + "%'", clsobj.con);
                clsobj.com.Connection = clsobj.con;
                SqlDataReader dr = clsobj.com.ExecuteReader();
               
                    while (dr.Read())
                    {

                        txtclassno.Text = dr["CNO"].ToString();
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
            slctclassid();
            slctmaxcno();
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

        private void txtpostaddr_TextChanged(object sender, EventArgs e)
        {
            if (txtpostaddr.Text  == "as above")
            {
                txtpostaddr.Text = txtpermaddr.Text;
            }
            else if (txtpostaddr.Text == "As Above")
            {
                txtpostaddr.Text = txtpermaddr.Text;
            }
            else if (txtpostaddr.Text == "AS ABOVE")
            {
                txtpostaddr.Text = txtpermaddr.Text;
            }
        }

        private void txtclassid_TextChanged(object sender, EventArgs e)
        {
      
        }

        private void radMultiColumnComboBox2_Leave(object sender, EventArgs e)
        {
          
        }
    }
}
