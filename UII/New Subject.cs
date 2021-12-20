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


namespace School_Management_System.UI
{
    public partial class New_Subject : Telerik.WinControls.UI.RadForm
    {
        public School_Management_System.DB_Connectivity.DB_Connection clsobj = new School_Management_System.DB_Connectivity.DB_Connection();
        int i;
        


        public New_Subject()
        {
            InitializeComponent();
        }

        private void New_Subject_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'school_Management_SystemDataSet.S_classess_Details' table. You can move, or remove it, as needed.
            this.s_classess_DetailsTableAdapter.Fill(this.school_Management_SystemDataSet.S_classess_Details);

            slctall();

            slctmax();

        }

        private void radButton5_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void insertionss()
        {
            try
            {
                clsobj.constate();
                clsobj.com = new SqlCommand("i_Subjects_Details", clsobj.con);
                clsobj.com.Connection = clsobj.con;
                clsobj.com.CommandType = CommandType.StoredProcedure;
                clsobj.com.Parameters.AddWithValue("@Subjname", txtsubjname.Text );
                clsobj.com.Parameters.AddWithValue("@SubjCode", txtsubjcode.Text );
                clsobj.com.Parameters.AddWithValue("@ClassID",txtclassid.Text  );
                clsobj.com.Parameters.AddWithValue("@Classname",radMultiColumnComboBox1.Text  );
                clsobj.com.Parameters.AddWithValue("@Descriptions", txtdescriptions.Text );
    
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
        private void slctall()
        {
            try
            {
                clsobj.constate();
                clsobj.com = new SqlCommand("s_Subjects_Details", clsobj.con);
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
                clsobj.com = new SqlCommand("s_MAX_Subjects_Details", clsobj.con);
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
                        txtsubjid.Text = dr["SubjectID"].ToString();

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
            txtclassid.Text = "";
            txtdescriptions.Text = "";
            txtsubjcode.Text = "";
            txtsubjname.Text = "";

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
                clsobj.com = new SqlCommand("u_Subjects_Details", clsobj.con);
                clsobj.com.Connection = clsobj.con;
                clsobj.com.CommandType = CommandType.StoredProcedure;
                clsobj.com.Parameters.AddWithValue("@SubjID", txtsubjid.Text);
                clsobj.com.Parameters.AddWithValue("@Subjname", txtsubjname.Text);
                clsobj.com.Parameters.AddWithValue("@SubjCode", txtsubjcode.Text);
                clsobj.com.Parameters.AddWithValue("@ClassID", txtclassid.Text);
                clsobj.com.Parameters.AddWithValue("@Classname", radMultiColumnComboBox1.Text);
                clsobj.com.Parameters.AddWithValue("@Descriptions", txtdescriptions.Text);

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
                clsobj.com = new SqlCommand("d_Subjects_Details", clsobj.con);
                clsobj.com.Connection = clsobj.con;
                clsobj.com.CommandType = CommandType.StoredProcedure;
                clsobj.com.Parameters.AddWithValue("@SubjID", txtsubjid.Text);
            

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

        private void slctclass()
        {
            try
            {
                clsobj.constate();
                clsobj.com = new SqlCommand("Select * from Classess_Details Where Classname like '%" + radMultiColumnComboBox1.Text + "%'", clsobj.con);
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
                           // txtdescriptiins.Text = dr["Descriptions"].ToString();

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

        private void radButton6_Click(object sender, EventArgs e)
        {
            slctall();

        }
        private void classauto()
        {
            try
            {
                clsobj.constate();
                clsobj.com = new SqlCommand("Select Classname from Subject_Details Where Classname like '%" + txtsearchby.Text + "%'", clsobj.con);
                clsobj.com.Connection = clsobj.con;
                SqlDataReader dr = clsobj.com.ExecuteReader();
                while (dr.Read())
                {
                    txtsearchby.AutoCompleteCustomSource.Add(dr["Classname"].ToString());
                }
                clsobj.con.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);

            }
        }
        private void srchbyclass()
        {
            try
            {
                clsobj.constate();
                clsobj.com = new SqlCommand("Select * from Subject_Details Where Classname like '%" + txtsearchby.Text + "%'", clsobj.con);
                clsobj.com.Connection = clsobj.con;
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(clsobj.com);
                da.Fill(ds);
                DataTable dt = ds.Tables[0];
                dataGridView1.DataSource = dt;
                clsobj.con.Close();
                classauto();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);

            }
        }
        private void codeauto()
        {
            try
            {
                clsobj.constate();
                clsobj.com = new SqlCommand("Select SubjCode from Subject_Details Where SubjCode like '%" + txtsearchby.Text + "%'", clsobj.con);
                clsobj.com.Connection = clsobj.con;
                SqlDataReader dr = clsobj.com.ExecuteReader();
                while (dr.Read())
                {
                    txtsearchby.AutoCompleteCustomSource.Add(dr["SubjCode"].ToString());
                }
                clsobj.con.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);

            }
        }
        private void srchbycode()
        {
            try
            {
                clsobj.constate();
                clsobj.com = new SqlCommand("Select * from Subject_Details Where SubjCode like '%" + txtsearchby.Text + "%'", clsobj.con);
                clsobj.com.Connection = clsobj.con;
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(clsobj.com);
                da.Fill(ds);
                DataTable dt = ds.Tables[0];
                dataGridView1.DataSource = dt;
                clsobj.con.Close();
                codeauto();
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
                clsobj.com = new SqlCommand("Select Subjname from Subject_Details Where Subjname like '%" + txtsearchby.Text + "%'", clsobj.con);
                clsobj.com.Connection = clsobj.con;
                SqlDataReader dr = clsobj.com.ExecuteReader();
                while (dr.Read())
                {
                    txtsearchby.AutoCompleteCustomSource.Add(dr["Subjname"].ToString());
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
                clsobj.com = new SqlCommand("Select * from Subject_Details Where Subjname like '%" + txtsearchby.Text + "%'", clsobj.con);
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
        private void txtsearchby_TextChanged(object sender, EventArgs e)
        {
            if (rdioclass.IsChecked == true)
            { srchbyclass(); }
            else if (rdiocode.IsChecked == true)
            { srchbycode(); }
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
                txtsubjid.Text = this.dataGridView1.Rows[i].Cells[0].Value.ToString();
                txtsubjname.Text = this.dataGridView1.Rows[i].Cells[1].Value.ToString();
                txtsubjcode.Text = this.dataGridView1.Rows[i].Cells[2].Value.ToString();
                txtclassid.Text = this.dataGridView1.Rows[i].Cells[3].Value.ToString();
                radMultiColumnComboBox1.Text = this.dataGridView1.Rows[i].Cells[4].Value.ToString();
                txtdescriptions.Text = this.dataGridView1.Rows[i].Cells[5].Value.ToString();

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
