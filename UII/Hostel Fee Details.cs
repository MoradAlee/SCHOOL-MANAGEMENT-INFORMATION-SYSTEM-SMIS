using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace School_Management_System.UI
{
    public partial class Hostel_Fee_Details : Telerik.WinControls.UI.RadForm
    {
        public Hostel_Fee_Details()
        {
            InitializeComponent();
        }

        private void Hostel_Fee_Details_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'school_Management_SystemDataSet.S_active_Students_Details' table. You can move, or remove it, as needed.
         //   this.s_active_Students_DetailsTableAdapter.Fill(this.school_Management_SystemDataSet.S_active_Students_Details);

        }

        private void radMultiColumnComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
