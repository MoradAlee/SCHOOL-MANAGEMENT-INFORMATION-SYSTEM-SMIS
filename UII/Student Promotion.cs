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
    public partial class Student_Promotion : Telerik.WinControls.UI.RadForm
    {
        public School_Management_System.DB_Connectivity.DB_Connection clsobj = new School_Management_System.DB_Connectivity.DB_Connection();
        int i;
        public Student_Promotion()
        {
            InitializeComponent();
        }
        private void Student_Promotion_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'school_Management_SystemDataSet.S_classess_Details' table. You can move, or remove it, as needed.
            this.s_classess_DetailsTableAdapter.Fill(this.school_Management_SystemDataSet.S_classess_Details);
            addcolm();
        }
            private void slctstudent()
        {
            try
            {
                clsobj.constate();
                clsobj.com = new SqlCommand("Select StdID, Regno, Stdname, Fname,AdmittedinClass,Classno from Students_Details Where AdmittedinClass like '%" + radMultiColumnComboBox1.Text + "%'", clsobj.con);
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
            private void addcolm()
            {
                try
                {
                    DataGridViewCheckBoxColumn prmpt = new DataGridViewCheckBoxColumn();
                    prmpt.Name = "promote";
                    prmpt.HeaderText = "Promote";
                    dataGridView1.Columns.Add(prmpt);
                    DataGridViewCheckBoxColumn demot = new DataGridViewCheckBoxColumn();
                    demot.Name = "Dmt";
                    demot.HeaderText = "Demote";
                    dataGridView1.Columns.Add(demot);

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

        private void radButton5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void prmpt()
        {
            try
            {
                for (i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    if (Convert.ToBoolean(dataGridView1.Rows[i].Cells["promote"].Value) == true)
                    {
                        clsobj.constate();
                        clsobj.com = new SqlCommand("Update Students_Details Set AdmittedinClass='" + radMultiColumnComboBox2.Text + "' Where Regno='" + dataGridView1.Rows[i].Cells["Regno"].Value.ToString() + "'", clsobj.con);
                        clsobj.com.Connection = clsobj.con;
                        clsobj.com.ExecuteNonQuery();


                    }
                    else if (Convert.ToBoolean(dataGridView1.Rows[i].Cells["Dmt"].Value) == true)
                    {
                        clsobj.constate();
                        clsobj.com = new SqlCommand("Update Students_Details Set AdmittedinClass='" + radMultiColumnComboBox1.Text + "' Where StdID='" + dataGridView1.Rows[i].Cells["StdID"].Value.ToString() + "'and Regno='" + dataGridView1.Rows[i].Cells["Regno"].Value.ToString() + "' and Stdname='" + dataGridView1.Rows[i].Cells["Stdname"].ToString() + "'", clsobj.con);
                        clsobj.com.Connection = clsobj.con;
                        clsobj.com.ExecuteNonQuery();
                    }
                   
                }
                MessageBox.Show("Student Promoted/Demoted Successfully!!", "School Says!", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                clsobj.con.Close();
                dataGridView1.DataSource = null;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }


        private void radButton1_Click(object sender, EventArgs e)
        {
            prmpt();

        }

        private void radButton4_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;

        }

        private void radButton3_Click(object sender, EventArgs e)
        {

        }
    }
}
