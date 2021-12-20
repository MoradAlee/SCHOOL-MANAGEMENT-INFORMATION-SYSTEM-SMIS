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
    public partial class Gov__High_School_Topsin : Telerik.WinControls.UI.RadForm
    {
        public Gov__High_School_Topsin()
        {
            InitializeComponent();
        }

        private void Gov__High_School_Topsin_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            if (radProgressBar1.Value1 == 100)
            {
                timer1.Stop();
                User_Validation uv = new User_Validation();
                uv.Show();
                this.Hide();


            }
            else
            {
                radProgressBar1.Value1 += 1;
                radProgressBar1.Text = radProgressBar1.Value1 + "%";

            }
        }
    }
}
