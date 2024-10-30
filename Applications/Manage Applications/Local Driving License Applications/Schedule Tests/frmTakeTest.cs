using Course19DVLDProject.Properties;
using DVLDBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Course19DVLDProject.Applications.Manage_Applications.Local_Driving_License_Applications.Schedule_Tests
{
    public partial class frmTakeTest : Form
    {
        public frmTakeTest(int TestAppointmentID, int TestType)
        {
            InitializeComponent();
            _TestAppointmentID = TestAppointmentID;
            _TestType = TestType;
            if (clsTestAppointment.IsTestAppointmentLocked(TestAppointmentID))
            {
                _Mode = enMode.ViewTestResult;
                lblTestLockedNote.Visible = true;
               
                rbFail.Enabled = false;
                rbPass.Enabled = false;
                tbNotes.Enabled = false;
                btnSave.Enabled = false;
                _CurrentTest = clsTest.FindTestByTestAppointmentID(TestAppointmentID);
           
            }
            else
                _Mode = enMode.TakeTest;
            switch (TestType)
            {
                case 1:
                    Text = "Vision Test";
                    pbTestImage.Image = Resources.Vision_Test;
                    break;
                case 2:
                    Text = "Written Test";
                    pbTestImage.Image = Resources.written_Test;
                    break;
                case 3:
                    Text = "Practical Test";
                    pbTestImage.Image = Resources.practical_Test;
                    break;
            }
        }
        private int _TestAppointmentID = -1;
        private int _TestType = -1;
        private enum enMode { TakeTest, ViewTestResult }
        private enMode _Mode = enMode.TakeTest;
        private clsTest _CurrentTest = null;

        private void frmTakeTest_Load(object sender, EventArgs e)
        {
            _LoadTestAppointmentInfo();
        }
        private void _LoadTestAppointmentInfo()
        {
            clsTestAppointment.stTestAppointmentView? TestAppointment = clsTestAppointment.FindAppointmentViewByID(_TestAppointmentID);

            if(TestAppointment.HasValue)
            {
                lblDrivingLicenseApplicationID.Text = TestAppointment.Value.TestAppointmentID.ToString();
                lblClassName.Text = TestAppointment.Value.ClassName;
                lblApplicantName.Text = TestAppointment.Value.FullName;
                lblTrialCount.Text = clsLocalDrivingLicenseApplication.NumberOfTrialsOnTestType(TestAppointment.Value.LocalDrivingLicenseApplicationID, _TestType).ToString();
                lblTestDate.Text = TestAppointment.Value.AppointmentDate.ToString();
                lblFees.Text = TestAppointment.Value.PaidFees.ToString();
                if (_Mode == enMode.TakeTest) {
                    lblTestID.Text = "Not Taken Yet";
                }
                else
                {
                    
                    lblTestID.Text = _CurrentTest.TestID.ToString();
                    tbNotes.Text = _CurrentTest.Notes.ToString();
                    if (_CurrentTest.TestResult)
                    {
                        rbPass.Checked = true; rbFail.Checked = false;
                    }else
                    {
                        rbPass.Checked = false; rbFail.Checked = true;
                    }
                }

            }
            else
                MessageBox.Show("Cannot Load TestAppointment Details!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_Mode == enMode.TakeTest && MessageBox.Show("Are you sure you want to save this test result, test result cannot be changed", "Info", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                
                _CurrentTest = new clsTest();
                _CurrentTest.TestAppointmentID = _TestAppointmentID;
                _CurrentTest.TestResult = rbPass.Checked;
                _CurrentTest.Notes = tbNotes.Text;
                _CurrentTest.CreatedByUserID = clsGlobalSettings.LoggedInUser.ID;
                if (_CurrentTest.AddNew())
                {
                    MessageBox.Show("Test Saved Successfully", "Successfull", MessageBoxButtons.OK);
                    lblTestID.Text = _CurrentTest.TestID.ToString();
                    clsTestAppointment.LockTestAppointment(_TestAppointmentID, true);                  
                    _Mode = enMode.ViewTestResult;
                }
                else
                {
                    MessageBox.Show("Failed To save test result", "Error", MessageBoxButtons.OK);
                }
                
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
