using Course19DVLDProject.Applications.Manage_Applications.International_Driving_License_Applications;
using Course19DVLDProject.Applications.Manage_Applications.Local_Driving_License_Applications;
using Course19DVLDProject.Controls;
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

namespace Course19DVLDProject.Applications.Driving_Licence_Services.New_Driving_Licence.Local_Driving_Licence
{
    public partial class frmNewInternationalLicenseApplication : Form
    {

        public frmNewInternationalLicenseApplication()
        {
            InitializeComponent();
            ctrlFilterLicense1.DataBack += CtrlFilterLicense1_DataBack;
        }
        private int _InternationalLicenseID = -1;
        private void CtrlFilterLicense1_DataBack(object sender, int LicenseID)
        {
            llShowLicenseHistory.Enabled = true;
            lblLocalLicenseID.Text = LicenseID.ToString();
            int InterNationalDrvingLicenseID = -1;
            if ((InterNationalDrvingLicenseID = clsInternationalLicense.GetDriverInternationalLicenseID(ctrlFilterLicense1._CurrentLicense.DriverID)) != -1)
            {
                MessageBox.Show($"Person Already Have International License with ID = {InterNationalDrvingLicenseID}", "Error", MessageBoxButtons.OK);
                btnIssue.Enabled = false;
                return;
            }
            _FillInternationalLicenseApplicationInfo();
            btnIssue.Enabled = true;
            


        }

        private clsApplication _CurrentApplication = new clsApplication();

        private clsApplicationTypes applicationType = clsApplicationTypes.GetApplicationByID((int)clsApplicationTypes.enApplicationTypes.NewInternationalDrivingLicense);

        private void frmNewInternationalLicenseApplication_Load(object sender, EventArgs e)
        {
            lblApplicationDate.Text = DateTime.Now.ToString();
            lblIssueDate.Text = DateTime.Now.ToString();
            lblExpirationDate.Text = DateTime.Now.AddYears(1).ToString();
            lblApplicationFees.Text = applicationType.Fees.ToString();
           lblCreatedBy.Text = clsGlobalSettings.LoggedInUser.UserName;

        }
        private void _FillInternationalLicenseApplicationInfo()
        {
            if (ctrlFilterLicense1.CurrentPersonID != -1)
            {
                _CurrentApplication.ApplicantPersonID = ctrlFilterLicense1.CurrentPersonID;
                _CurrentApplication.ApplicationDate = DateTime.Now;
                _CurrentApplication.ApplicationTypeID = applicationType.ID;
                _CurrentApplication.ApplicationStatus = (int)clsApplication.enApplicationStatus.Completed;
                _CurrentApplication.LastStatusDate = DateTime.Now;
                _CurrentApplication.PaidFees = applicationType.Fees;
                _CurrentApplication.CreatedByUserID = clsGlobalSettings.LoggedInUser.ID;
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();

        }
        

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if(ctrlFilterLicense1.CurrentLicenseID == -1)
            {
                MessageBox.Show("Choose A license First", "Attention", MessageBoxButtons.OK);
                return;
            }
            frmLicenseHistory frm = new frmLicenseHistory(ctrlFilterLicense1.CurrentPersonID);
            frm.ShowDialog();
        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            if (ctrlFilterLicense1._CurrentLicense.LicenseID == -1)
            {
                MessageBox.Show("Please Choose A Local Driving License First!", "Attention", MessageBoxButtons.OK);
                return;
            }
            if(ctrlFilterLicense1._CurrentLicense.LicenseClass != 3)
            {
                MessageBox.Show("License Should Be class 3!", "Attention", MessageBoxButtons.OK);
                return;
            }
            if (ctrlFilterLicense1._CurrentLicense.ExpirationDate < DateTime.Now || !ctrlFilterLicense1._CurrentLicense.IsActive)
            {
                MessageBox.Show("License Expired/License is Inactive, Renew it first!", "Attention", MessageBoxButtons.OK);
                return;
            }
            if (_CurrentApplication.Save())
            {
                clsInternationalLicense ILicense = new clsInternationalLicense();
                ILicense.ApplicationID = _CurrentApplication.ApplicationID;
                ILicense.DriverID = ctrlFilterLicense1._CurrentLicense.DriverID;
                ILicense.IssuedUsingLocalDrivingLicenseID = ctrlFilterLicense1._CurrentLicense.LicenseID;
                ILicense.IssueDate = DateTime.Now;
                ILicense.ExpirationDate = DateTime.Now.AddYears(1);
                ILicense.IsActive = true;
                ILicense.CreatedByUserID = clsGlobalSettings.LoggedInUser.ID;
                if (ILicense.AddNew())
                {
                    MessageBox.Show($"International License Issued Successfully with ID = {ILicense.InternationalLicenseID}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    llShowLicenseInfo.Enabled = true;
                    lblInternationalLicenseID.Text = ILicense.InternationalLicenseID.ToString();
                    lblInternationalLicenseApplicationID.Text = _CurrentApplication.ApplicationID.ToString();
                    _InternationalLicenseID = ILicense.InternationalLicenseID;
                }
                else
                    MessageBox.Show("Failed To add International License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
                MessageBox.Show("Failed to save application", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void llShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmInternationalLicenseInfo frm = new frmInternationalLicenseInfo(_InternationalLicenseID);
            frm.ShowDialog();
        }
    }
}
