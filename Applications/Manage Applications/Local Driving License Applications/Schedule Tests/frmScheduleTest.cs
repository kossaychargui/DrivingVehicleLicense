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
using static DVLDBusinessLayer.clsLocalDrivingLicenseApplication;

namespace Course19DVLDProject.Applications.Manage_Applications.Local_Driving_License_Applications.Schedule_Tests
{
    public partial class frmScheduleTest : Form
    {
        public frmScheduleTest(int LocalDrivingApplicationID, int TestType, bool IsRetake = false, int AppointmentID = -1)
        {
            InitializeComponent();
            _TestType = TestType;
            _LocalDrivingApplicationID = LocalDrivingApplicationID;
            switch (TestType)
            {
                case 1:
                    gbTestType.Text = "Vision Test";
                    break;
                case 2:
                    gbTestType.Text = "Written Test";
                    break;
                case 3:
                    gbTestType.Text = "Practical Test";
                    break;
            }
            _AppointmentID = AppointmentID;
            if (AppointmentID == -1)
                _Mode = enMode.AddNewAppointment;
            else
            {
                if (clsTestAppointment.IsTestAppointmentLocked(AppointmentID))
                {
                    _Mode = enMode.Locked;
                    btnSave.Enabled = false;
                    dtpTestDate.Enabled = false;
                    lblAppointemenLockedNote.Visible = true;
                }
                else
                    _Mode = enMode.EditDate;
            }
            if (IsRetake)
                gbRetakeTestInfo.Enabled = true;
   
        }
      
        private int _TestType = -1;
        private int _LocalDrivingApplicationID = -1;
        private enum enMode { AddNewAppointment, EditDate, Locked};
        private enMode _Mode;
        private int _AppointmentID = -1;
        private string _PersonNationalNo = string.Empty;
        private void frmScheduleTest_Load(object sender, EventArgs e)
        {
            dtpTestDate.MinDate = DateTime.Now;
            _LoadLocalDrivingLicenseApplicationInfo();
        }

        private void _LoadLocalDrivingLicenseApplicationInfo()
        {

            stLocalDrivingLicense LocalDrivingLicense = clsLocalDrivingLicenseApplication.GetLocalDrivingLicenseView(_LocalDrivingApplicationID);
            _PersonNationalNo = LocalDrivingLicense.NationalNo;
            lblDrivingLicenseApplicationID.Text = LocalDrivingLicense.LocalDrivingLicenseApplicationID.ToString();
            lblClassName.Text = LocalDrivingLicense.ClassName;
            lblApplicantName.Text = LocalDrivingLicense.FullName;
            lblTrialCount.Text = clsLocalDrivingLicenseApplication.NumberOfTrialsOnTestType(_LocalDrivingApplicationID, _TestType).ToString();
            if (_Mode == enMode.AddNewAppointment)
                dtpTestDate.Value = DateTime.Now;
            else
                dtpTestDate.Value = clsTestAppointment.GetTestAppointmentDate(_AppointmentID);
            clsTestType TestType = clsTestType.GetTestTypeByID(_TestType);
            lblFees.Text = TestType.Fees.ToString();
            decimal RetakeTestFees = 0;
            if (clsTestAppointment.CheckLocalDrivingLicenseTestResult(_LocalDrivingApplicationID, _TestType, false)) {
                gbRetakeTestInfo.Enabled = true;
                RetakeTestFees = clsApplicationTypes.GetApplicationFeesByID((int)clsApplicationTypes.enApplicationTypes.RenewDrivingLicense);
            }
            lblRetakeApplicationFees.Text = RetakeTestFees.ToString();
            lblTotalFees.Text = (TestType.Fees + RetakeTestFees).ToString();
        }
  

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_Mode == enMode.AddNewAppointment)
            {
                // in case of retake we should create an application for retake addtionally to the test appointment;
                if (gbRetakeTestInfo.Enabled)
                {
                    clsApplication application = new clsApplication();
                    clsPerson person = clsPerson.Find(_PersonNationalNo);
                    application.ApplicantPersonID = person.ID;
                    application.ApplicationDate = DateTime.Now;
                    application.ApplicationTypeID = (int)clsApplicationTypes.enApplicationTypes.RenewDrivingLicense;
                    application.ApplicationStatus = (int)clsApplication.enApplicationStatus.Completed;
                    application.LastStatusDate = DateTime.Now;
                    application.PaidFees = Convert.ToDecimal(lblRetakeApplicationFees.Text);
                    application.CreatedByUserID = clsGlobalSettings.LoggedInUser.ID;
                    if (!application.Save())
                    {
                        MessageBox.Show("Failed To save retake test application!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    lblRetakeTestApplicationID.Text = application.ApplicationID.ToString();
                }
                
                clsTestAppointment testAppointment = new clsTestAppointment();
                testAppointment.TestTypeID = _TestType;
                testAppointment.LocalDrivingLicenseApplicationID = _LocalDrivingApplicationID;
                testAppointment.AppointmentDate = dtpTestDate.Value;
                testAppointment.PaidFees = Convert.ToDecimal(lblTotalFees.Text);
                testAppointment.CreatedByUserID = clsGlobalSettings.LoggedInUser.ID;
                testAppointment.IsLocked = false;
                if (testAppointment.AddNew())
                {
                    MessageBox.Show("Appointment Saved Successfully!");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Failed to Schedule an Appointment!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else// for the edit
            {
                if(clsTestAppointment.UpdateAppointment(_AppointmentID, dtpTestDate.Value, false))
                {
                    MessageBox.Show("Test Appointment Date Scheduled Successfully!", "Success", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("Failed To change the test Appointment Date!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
