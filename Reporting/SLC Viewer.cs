using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace School_Management_System.Reporting
{
    public partial class SLC_Viewer : Form
    {
        public SLC_Viewer()
        {
            InitializeComponent();
        }

        private void SLC_Viewer_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'school_Management_SystemDataSet1.s_SLC_Details' table. You can move, or remove it, as needed.
            this.s_SLC_DetailsTableAdapter.Fill(this.school_Management_SystemDataSet1.s_SLC_Details);

            this.reportViewer1.RefreshReport();
        }
    }
}
