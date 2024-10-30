using Course19DVLDProject.Properties;
using DVLDBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DVLDBusinessLayer.clsTestAppointment;

namespace Course19DVLDProject.Applications.Manage_Applications.Local_Driving_License_Applications.Schedule_Tests
{
    public partial class frmTestAppointment : Form
    {
        public frmTestAppointment(int LocalDrivingLicenseApplicationID, int AppointmentType)
        {
            InitializeComponent();
            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            _AppointmentType = AppointmentType;
            switch (AppointmentType) {
                case 1:
                    this.Text = "Vision Test Appointment";
                    
                    pbTestAppointmentImage.Image = Resources.Vision_Test;
                    break;
                case 2:
                    Text = "Written Test Appointment";
                    pbTestAppointmentImage.Image = Resources.written_Test;
                    break;
                case 3:
                    Text = "Street Test Appointment";
                    pbTestAppointmentImage.Image = Resources.practical_Test;
                    break;
            }
            lblTestAppointmentName.Text = Text;

        }
        private int _AppointmentType = -1;
        private int _LocalDrivingLicenseApplicationID = -1;
        private DataView dv = null;

        private void frmVisionTestAppointment_Load(object sender, EventArgs e)
        {
            ctrlDrivingLicenseApplicationInfo1.FillApplicationInfo(_LocalDrivingLicenseApplicationID);
            _LoadAppointments();
        }
        private void _LoadAppointments()
        {
            string NationalNo = ctrlDrivingLicenseApplicationInfo1.NationalNo;
            switch (_AppointmentType)
            {
                case 1:
                    dv = new DataView(clsTestAppointment.GetVisionTestAppointments(NationalNo));
                    break;
                case 2:
                    dv = new DataView(clsTestAppointment.GetWrittenTestAppointments(NationalNo));
                    break;
                case 3:
                    dv = new DataView(clsTestAppointment.GetPracticalTestAppointments(NationalNo));
                    break;
            }
            
            dataGridView1.DataSource = dv;
            lblNumberOfRecords.Text = dv.Count.ToString();
        }

        private void btnScheduleTest_Click(object sender, EventArgs e)
        {
            if(clsTestAppointment.IsLocalDrivingLicenseHaveUnlockedTestAppointment(_LocalDrivingLicenseApplicationID, _AppointmentType))
            {
                MessageBox.Show("Person Already have an Appointment!", "Not Allowed", MessageBoxButtons.OK ,MessageBoxIcon.Error);
                return;
            }

            if (clsTestAppointment.CheckLocalDrivingLicenseTestResult(_LocalDrivingLicenseApplicationID, _AppointmentType, true))
            {
                MessageBox.Show("Person Already have already Take this test, You can only retake failed Tests!", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Issue second time
            if (clsTestAppointment.CheckLocalDrivingLicenseTestResult(_LocalDrivingLicenseApplicationID, _AppointmentType, false))
            {
                frmScheduleTest frm = new frmScheduleTest(_LocalDrivingLicenseApplicationID, _AppointmentType, true);
                frm.ShowDialog();
            }
            // for the frirst time
            else {
                frmScheduleTest frm = new frmScheduleTest(_LocalDrivingLicenseApplicationID, _AppointmentType);
                frm.ShowDialog();
            }
            _LoadAppointments();
        }

        private void toolStripMenuItemEdit_Click(object sender, EventArgs e)
        {
            int AppointmentID = (int)dataGridView1.CurrentRow.Cells[0].Value;
            bool IsRetake = clsTestAppointment.CheckLocalDrivingLicenseTestResult(_LocalDrivingLicenseApplicationID, _AppointmentType, false);
            frmScheduleTest frm = new frmScheduleTest(_LocalDrivingLicenseApplicationID, _AppointmentType, IsRetake, AppointmentID);
            frm.ShowDialog();
            
        }

        private void toolStripMenuItemTake_Click(object sender, EventArgs e)
        {
            int TestAppointmentID = (int)dataGridView1.CurrentRow.Cells[0].Value;
            frmTakeTest frm = new frmTakeTest(TestAppointmentID, _AppointmentType);
            frm.ShowDialog();
            _LoadAppointments();
        }


    }
}
