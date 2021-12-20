namespace School_Management_System.Reporting
{
    partial class SLC_Viewer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.school_Management_SystemDataSet1 = new School_Management_System.School_Management_SystemDataSet1();
            this.sSLCDetailsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.s_SLC_DetailsTableAdapter = new School_Management_System.School_Management_SystemDataSet1TableAdapters.s_SLC_DetailsTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.school_Management_SystemDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sSLCDetailsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.sSLCDetailsBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "School_Management_System.Reporting.Rpt Student.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(1160, 676);
            this.reportViewer1.TabIndex = 0;
            // 
            // school_Management_SystemDataSet1
            // 
            this.school_Management_SystemDataSet1.DataSetName = "School_Management_SystemDataSet1";
            this.school_Management_SystemDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // sSLCDetailsBindingSource
            // 
            this.sSLCDetailsBindingSource.DataMember = "s_SLC_Details";
            this.sSLCDetailsBindingSource.DataSource = this.school_Management_SystemDataSet1;
            // 
            // s_SLC_DetailsTableAdapter
            // 
            this.s_SLC_DetailsTableAdapter.ClearBeforeFill = true;
            // 
            // SLC_Viewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1160, 676);
            this.Controls.Add(this.reportViewer1);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "SLC_Viewer";
            this.Text = "SLC Viewer";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.SLC_Viewer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.school_Management_SystemDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sSLCDetailsBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private School_Management_SystemDataSet1 school_Management_SystemDataSet1;
        private System.Windows.Forms.BindingSource sSLCDetailsBindingSource;
        private School_Management_SystemDataSet1TableAdapters.s_SLC_DetailsTableAdapter s_SLC_DetailsTableAdapter;
    }
}