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

namespace Course19DVLDProject.Applications.Manage_Applications.Local_Driving_License_Applications
{
    public partial class frmIssueDriverLicenseForTheFirstTime : Form
    {
        public frmIssueDriverLicenseForTheFirstTime(int LocalDrivingApplicationID)
        {
            InitializeComponent();
            _LocalLocalDrivingApplicationID = LocalDrivingApplicationID;
        }
        private int _LocalLocalDrivingApplicationID = -1;
        private clsLocalDrivingLicenseApplication _CurrentLocalDrivingLicenseApplication = null;
        private clsApplication _CurrentApplication = null;

        private void frmIssueDriverLicenseForTheFirstTime_Load(object sender, EventArgs e)
        {
            ctrlDrivingLicenseApplicationInfo1.FillApplicationInfo(_LocalLocalDrivingApplicationID);
            _CurrentLocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.FindByID(_LocalLocalDrivingApplicationID);
            _CurrentApplication = clsApplication.FindByID(_CurrentLocalDrivingLicenseApplication.ApplicationID);
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            int DriverID = -1;
           
            if((DriverID = AddDriverAndGetID()) == -1)
            {
                MessageBox.Show("Cannot Add Driver!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            clsLicenseClass LicenseClass = clsLicenseClass.GetLicenseClassByID(_CurrentLocalDrivingLicenseApplication.LicenseClassID); ;
            clsLicense LicenseToAdd = new clsLicense();
            LicenseToAdd.ApplicationID = _CurrentLocalDrivingLicenseApplication.ApplicationID;
            LicenseToAdd.DriverID = DriverID;
            LicenseToAdd.LicenseClass = _CurrentLocalDrivingLicenseApplication.LicenseClassID;
            LicenseToAdd.IssueDate = DateTime.Now;
            int YearstoAdd = LicenseClass.DefaultValidityLength;
            LicenseToAdd.ExpirationDate = DateTime.Now.AddYears(YearstoAdd);
 
            LicenseToAdd.Notes =tbNotes.Text;
            LicenseToAdd.PaidFees = LicenseClass.Fees;
            LicenseToAdd.IsActive = true;
            LicenseToAdd.IssueReason = _CurrentApplication.ApplicationTypeID;
            LicenseToAdd.CreatedByUserID = clsGlobalSettings.LoggedInUser.ID;
            if(LicenseToAdd.AddNew()){
                MessageBox.Show($"License Issued Successfully with ID{LicenseToAdd.LicenseID}", "Successfull", MessageBoxButtons.OK);
                clsApplication.CompleteApplication(_CurrentLocalDrivingLicenseApplication.ApplicationID);
                this.Close();
            }
            else
            {
                MessageBox.Show("Failed To Add License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error );
            }


        }
        private int AddDriverAndGetID()
        {
            if (clsDriver.IsPersonAlreadyADriver(_CurrentApplication.ApplicantPersonID))
            {
                return 1;
            }
            clsDriver driver = new clsDriver();
            driver.PersonID = _CurrentApplication.ApplicantPersonID;
            driver.CreatedByUserID = clsGlobalSettings.LoggedInUser.ID;
            driver.CreatedDate = DateTime.Now;
            return driver.AddDriver() ? driver.ID : -1;
        }


    }
}
