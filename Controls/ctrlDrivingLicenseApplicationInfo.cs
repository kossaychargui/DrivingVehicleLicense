using Course19DVLDProject.People;
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

namespace Course19DVLDProject.Controls
{
    public partial class ctrlDrivingLicenseApplicationInfo : UserControl
    {
        public ctrlDrivingLicenseApplicationInfo()
        {
            InitializeComponent();
            

        }
        private int _DLAppID = -1;
        public int PersonID = -1;
        public string NationalNo = string.Empty;
        public void FillApplicationInfo(int DrivingLicenseApplicationID)
        {
            _DLAppID = DrivingLicenseApplicationID;
            _CurrentApplicationInfo = clsLocalDrivingLicenseApplication.GetLocalDrivingLicenseView(DrivingLicenseApplicationID);
            _LoadDrivingLicenseApplicationInfo();
        }

        //private clsLocalDrivingLicenseApplication _CurrentApplicationInfo = null;
        private clsLocalDrivingLicenseApplication.stLocalDrivingLicense _CurrentApplicationInfo;

        private void ctrlDrivingLicenseApplicationInfo_Load(object sender, EventArgs e)
        {
            
        }
        private void _LoadDrivingLicenseApplicationInfo()
        {
    
            _LoadGeneralInfo();
            _LoadApplicationBasicInfo(); ;
        }
        private void _LoadGeneralInfo()
        {
           
            lblDLAppID.Text = _CurrentApplicationInfo.LocalDrivingLicenseApplicationID.ToString();
            lblLicenseClass.Text = _CurrentApplicationInfo.ClassName;
            lblPassedTests.Text = _CurrentApplicationInfo.PassedTestCount.ToString() + "/3";
            
        }
        private void _LoadApplicationBasicInfo()
        {
            clsLocalDrivingLicenseApplication app = clsLocalDrivingLicenseApplication.FindByID(_DLAppID);
            clsApplication application = clsApplication.FindByID(app.ApplicationID);
            lblApplicationID.Text = app.ApplicationID.ToString();
            lblApplicationStatus.Text = _CurrentApplicationInfo.Status;
            lblAppilcationFees.Text = application.PaidFees.ToString();
            lblApplicationType.Text = clsApplicationTypes.GetApplicationTypeNameByID(application.ApplicationTypeID);
            lblApplicantFullName.Text = clsPerson.GetFullName(application.ApplicantPersonID);
            lblApplicationDate.Text = application.ApplicationDate.ToString();
            lblApplicationStatusDate.Text = application.LastStatusDate.ToString();
            lblCreatedBy.Text = clsUser.GetUserName(application.CreatedByUserID);
            PersonID = application.ApplicantPersonID;
            NationalNo = clsPerson.GetNationalNo(application.ApplicantPersonID);
                   
                
            
        }

        private void lbViewPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmPersonDetails frm = new frmPersonDetails(PersonID);
            frm.ShowDialog();
        }
    }
}
