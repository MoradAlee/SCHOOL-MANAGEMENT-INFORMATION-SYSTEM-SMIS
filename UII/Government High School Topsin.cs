using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using School_Management_System.Reporting;

namespace School_Management_System.UI
{
    public partial class Government_High_School_Topsin : Telerik.WinControls.UI.RadForm
    {
        public Government_High_School_Topsin()
        {
            InitializeComponent();
        }

        private void controlPanelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            System.Diagnostics.Process.Start("C:/Windows/system32/ControlPanel.exe");
        }

        private void createUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("C:");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You Sure To Exit ?", "Confirmation", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning) == DialogResult.Yes)
            {

                Application.Exit();
            }
        }

        private void studentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Students_Details std = new Students_Details();
            std.MdiParent = this;
            std.Show();

        }

        private void employeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Employee_Details ed = new Employee_Details();
            ed.MdiParent = this;
            ed.Show();

        }

        private void expensesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            School_Expenses se = new School_Expenses();
            se.MdiParent = this;
            se.Show();

        }

        private void subjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            New_Subject ns = new New_Subject();
            ns.MdiParent = this;
            ns.Show();

        }

        private void sessionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Session_Details sd = new Session_Details();
            sd.MdiParent = this;
            sd.Show();

        }

        private void stationaryNewItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stationary_New_Items sni = new Stationary_New_Items();
            sni.MdiParent = this;
            sni.Show();

        }

        private void stationaryItemsSalesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stationary_Sales ss = new Stationary_Sales();
            ss.MdiParent = this;
            ss.Show();

        }

        private void examinationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Examination_Details ed = new Examination_Details();
            ed.MdiParent = this;
            ed.Show();
        }
       
        private void classesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Classess_Details cd = new Classess_Details();
            cd.MdiParent = this;
            cd.Show();

        }

        private void timeTableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Weekly_Timetable_Details wtt = new Weekly_Timetable_Details();
            wtt.MdiParent = this;
            wtt.Show();

        }

        private void classFeeStructureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Class_Fee_Structure_Details cfsd = new Class_Fee_Structure_Details();
            cfsd.MdiParent = this;
            cfsd.Show();

        }

        private void employeePayrollToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Employee_Payroll_Details epd = new Employee_Payroll_Details();
            epd.MdiParent = this;
            epd.Show();

        }

        private void admissionWithdrawalCertificateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RptAdmissionWithdrawal_Viewer rv = new RptAdmissionWithdrawal_Viewer();
            rv.MdiParent = this;
            rv.Show();

        }

        private void sLCCertificateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SLC_Certificate_Viewer scv = new SLC_Certificate_Viewer();
            scv.MdiParent = this;
            scv.Show();

        }

        private void resultbookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Resultbook_Details rd = new Resultbook_Details();
            rd.MdiParent = this;
            rd.Show();

        }

        private void accountbookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Accountbook_Details ad = new Accountbook_Details();
            ad.MdiParent = this;
            ad.Show();

        }

        private void newRoomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            New_Room nr = new New_Room();
            nr.MdiParent = this;
            nr.Show();

        }

        
        private void assignRoomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Assign_Room ar = new Assign_Room();
            ar.MdiParent = this;
            ar.Show();
        }

        private void hostelFeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hostel_Fee_Details hfd = new Hostel_Fee_Details();
            hfd.MdiParent = this;
            hfd.Show();

        }

        private void newBusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            New_Bus_Details nbd = new New_Bus_Details();
            nbd.MdiParent = this;
            nbd.Show();

        }

        private void newRouteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            New_Route nr = new New_Route();
            nr.MdiParent = this;
            nr.Show();

        }

        private void newStudentToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Transport_Membership_Details tmd = new Transport_Membership_Details();
            tmd.MdiParent = this;
            tmd.Show();

        }

        private void transportFeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Transport_Fee tf = new Transport_Fee();
            tf.MdiParent = this;
            tf.Show();

        }

        private void expensesToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Bus_Expenses be = new Bus_Expenses();
            be.MdiParent = this;
            be.Show();

        }

        private void newBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            New_Book_Details nbd = new New_Book_Details();
            nbd.MdiParent = this;
            nbd.Show();

        }

        private void newStudentToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Library_Membership_Details lmd = new Library_Membership_Details();
            lmd.MdiParent = this;
            lmd.Show();

        }

        private void studentFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RptStudentformviewer rv = new RptStudentformviewer();
            rv.MdiParent = this;
            rv.Show();

        }

        private void employeeFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RpTeMPLOYEEFORMVIEWER rve = new RpTeMPLOYEEFORMVIEWER();
            rve.MdiParent = this;
            rve.Show();

        }

        private void accountbookClasswiseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RptAccountbookClasswise1 rpt = new RptAccountbookClasswise1();
            rpt.MdiParent = this;
            rpt.Show();

        }

        private void accountbookDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RptAccountbookVierwer rv = new RptAccountbookVierwer();
            rv.MdiParent = this;
            rv.Show();

        }

        private void dMCClasswiseToolStripMenuItem_Click(object sender, EventArgs e)
        {

            RPTDMCCLASSWISE dc = new RPTDMCCLASSWISE();
            dc.MdiParent = this;
            dc.Show();


        }

        private void dMCAllSchoolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rptdmcsallviewer rdv = new rptdmcsallviewer();
            rdv.MdiParent = this;
            rdv.Show();

        }

        private void employeePayrollToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ReportViewer rv = new ReportViewer();
            rv.MdiParent = this;
            rv.Show();

        }

        private void sLCCertificateToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SLC_Certificate_Viewer scv = new SLC_Certificate_Viewer();
            scv.MdiParent = this;
            scv.Show();

        }

        private void admissionWithdrawalCertificateToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            RptAdmissionWithdrawal_Viewer rdv = new RptAdmissionWithdrawal_Viewer();
            rdv.MdiParent = this;
            rdv.Show();

        }

        private void timeTableToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            RptTimetableviewers rtv = new RptTimetableviewers();
            rtv.MdiParent = this;
            rtv.Show();

        }

        private void libraryBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RptLibraryBooksViewer rbv = new RptLibraryBooksViewer();
            rbv.MdiParent = this;
            rbv.Show();

        }

        private void employeeOvertimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RptEmployeeOVertimeviewer rov = new RptEmployeeOVertimeviewer();
            rov.MdiParent = this;
            rov.Show();

        }

        private void booksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RptLibraryBooksViewer rbv = new RptLibraryBooksViewer();
            rbv.MdiParent = this;
            rbv.Show();

        }

        private void classessToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RptClassessViewer rv = new RptClassessViewer();
            rv.MdiParent = this;
            rv.Show();

        }

        private void busesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RptBuses1 rb = new RptBuses1();
            rb.MdiParent = this;
            rb.Show();

        }

        private void borrowBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RptBoorrowBooksViewer rbv = new RptBoorrowBooksViewer();
            rbv.MdiParent = this;
            rbv.Show();

        }

        private void struckupStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Struckup_Students ss = new Struckup_Students();
            ss.MdiParent = this;
            ss.Show();

        }

        private void studentPromotionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Student_Promotion sp = new Student_Promotion();
            sp.MdiParent = this;
            sp.Show();

        }

        private void commandBarButton1_Click(object sender, EventArgs e)
        {
            Employee_Details ed = new Employee_Details();
            ed.MdiParent = this;
            ed.Show();
        }

        private void commandBarButton2_Click(object sender, EventArgs e)
        {
            New_Book_Details nb = new New_Book_Details();
            nb.MdiParent = this;
            nb.Show();

        }

        private void commandBarButton17_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("C:/Windows/system32/mspaint.exe");
        }

        private void commandBarButton18_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("C:/Windows/system32/ControlPanel.exe");
        }

        private void commandBarButton16_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("C:");
        }

        private void commandBarButton19_Click(object sender, EventArgs e)
        {
            Overtime_Details od = new Overtime_Details();
            od.MdiParent = this;
            od.Show();

        }

        private void commandBarButton20_Click(object sender, EventArgs e)
        {
            New_Route nr = new New_Route();
            nr.MdiParent = this;
            nr.Show();

        }

        private void commandBarButton21_Click(object sender, EventArgs e)
        {
            Weekly_Timetable_Details wkd = new Weekly_Timetable_Details();
            wkd.MdiParent = this;
            wkd.Show();

        }

        private void commandBarButton22_Click(object sender, EventArgs e)
        {
            User_Validation uv = new User_Validation();
            uv.MdiParent = this;
            uv.Show();

        }

        private void commandBarButton23_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You Sure To Exit ?", "Confirmation", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning) == DialogResult.Yes)
            {

                Application.Exit();
            }
        }

        private void commandBarButton24_Click(object sender, EventArgs e)
        {
            foreach (Form form in this.MdiChildren)
            {
                form.Close();
            }
        }

        private void commandBarButton25_Click(object sender, EventArgs e)
        {
            RptAdmissionWithdrawal_Viewer rvw = new RptAdmissionWithdrawal_Viewer();
            rvw.MdiParent = this;
            rvw.Show();

        }

        private void commandBarButton26_Click(object sender, EventArgs e)
        {
            Overtime_Details od = new Overtime_Details();
            od.MdiParent = this;
            od.Show();

        }

        private void commandBarButton15_Click(object sender, EventArgs e)
        {
            Accountbook_Details ad = new Accountbook_Details();
            ad.MdiParent = this;
            ad.Show();

        }

        private void commandBarButton14_Click(object sender, EventArgs e)
        {
            Resultbook_Details rd = new Resultbook_Details();
            rd.MdiParent = this;
            rd.Show();

        }

        private void commandBarButton13_Click(object sender, EventArgs e)
        {
            Employee_Payroll_Details epd = new Employee_Payroll_Details();
            epd.MdiParent = this;
            epd.Show();

        }

        private void commandBarButton12_Click(object sender, EventArgs e)
        {
            Transport_Membership_Details tmd = new Transport_Membership_Details();
            tmd.MdiParent = this;
            tmd.Show();

        }

        private void commandBarButton11_Click(object sender, EventArgs e)
        {
            RptAccountbookClasswise1 rbc = new RptAccountbookClasswise1();
            rbc.MdiParent = this;
            rbc.Show();

        }

        private void commandBarButton10_Click(object sender, EventArgs e)
        {
            New_Subject ns = new New_Subject();
            ns.MdiParent = this;
            ns.Show();

        }

        private void commandBarButton9_Click(object sender, EventArgs e)
        {
            New_Book_Details nbd = new New_Book_Details();
            nbd.MdiParent = this;
            nbd.Show();

        }

        private void commandBarButton8_Click(object sender, EventArgs e)
        {
            Employee_Details ed = new Employee_Details();
            ed.MdiParent = this;
            ed.Show();

        }

        private void commandBarButton7_Click(object sender, EventArgs e)
        {
            Stationary_New_Items sni = new Stationary_New_Items();
            sni.MdiParent = this;
            sni.Show();

        }

        private void commandBarButton6_Click(object sender, EventArgs e)
        {
            Stationary_Sales ss = new Stationary_Sales();
            ss.MdiParent = this;
            ss.Show();

        }

        private void commandBarButton5_Click(object sender, EventArgs e)
        {
            Library_Membership_Details lmd = new Library_Membership_Details();
            lmd.MdiParent = this;
            lmd.Show();

        }

        private void commandBarButton4_Click(object sender, EventArgs e)
        {
            Classess_Details cd = new Classess_Details();
            cd.MdiParent = this;
            cd.Show();

        }

        private void commandBarButton3_Click(object sender, EventArgs e)
        {
            Class_Fee_Structure_Details csd = new Class_Fee_Structure_Details();
            csd.MdiParent = this;
            csd.Show();

        }

       
    }
}
