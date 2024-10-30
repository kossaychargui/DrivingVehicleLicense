using Course19DVLDProject.Applications.Manage_Applications.International_Driving_License_Applications;
using Course19DVLDProject.Applications.Manage_Applications.Local_Driving_License_Applications;
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

namespace Course19DVLDProject.Applications.Driving_Licence_Services.Renew_Driving_License
{
    public partial class frmRenewLocalDrivingLicense : Form
    {
        public frmRenewLocalDrivingLicense()
        {
            InitializeComponent();
            ctrlFilterLicense1.DataBack += CtrlFilterLicense1_DataBack;
        }
        private clsLicense _OldLicense;

        private void frmRenewLocalDrivingLicense_Load(object sender, EventArgs e)
        {
            lblApplicationDate.Text = DateTime.Now.ToString();
            lblIssueDate.Text = DateTime.Now.ToString();
            lblCreatedBy.Text = clsGlobalSettings.LoggedInUser.UserName;
            lblApplicationFees.Text = clsApplicationTypes.GetApplicationFeesByID((int)clsApplicationTypes.enApplicationTypes.RenewDrivingLicense).ToString();
        }

        private void CtrlFilterLicense1_DataBack(object sender, int LicenseID)
        {
            _OldLicense = clsLicense.FindByID(LicenseID);
            lblOldLicenseID.Text = _OldLicense.LicenseID.ToString();
            clsLicenseClass licenseClass = clsLicenseClass.GetLicenseClassByID(_OldLicense.LicenseClass);
            lblExpirationDate.Text = DateTime.Now.AddYears(licenseClass.DefaultValidityLength).ToString();
            lblLicenseFees.Text = licenseClass.Fees.ToString();
            lblTotalFees.Text = (licenseClass.Fees + Convert.ToDecimal(lblApplicationFees.Text)).ToString();
            llShowLicenseHistory.Enabled = true;
            if(_OldLicense.ExpirationDate > DateTime.Now)
            {
                MessageBox.Show($"License is not expired yet. It will be expired on {_OldLicense.ExpirationDate}, You can only renew an EXPIRED license!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnRenew.Enabled = false;
                return;
            }
            btnRenew.Enabled = true;    
           
            
        }

        private void btnRenew_Click(object sender, EventArgs e)
        {
            int ActiveLicenseID = -1;
            if ((ActiveLicenseID = clsDriver.IsDriverHasActiveLicenseFromSameClassAndGetID(ctrlFilterLicense1._CurrentLicense.DriverID, _OldLicense.LicenseClass)) != -1)
            {
                MessageBox.Show($"Person Already Have an active license for this class with id = {ActiveLicenseID}", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnRenew.Enabled = false;
                return;
            }
            clsApplication Rapplication = new clsApplication();
            Rapplication.ApplicantPersonID = ctrlFilterLicense1.CurrentPersonID;
            Rapplication.ApplicationDate = DateTime.Now;
            Rapplication.ApplicationTypeID = (int)clsApplicationTypes.enApplicationTypes.RenewDrivingLicense;
            Rapplication.ApplicationStatus = (int)clsApplication.enApplicationStatus.Completed;
            Rapplication.LastStatusDate = DateTime.Now;
            Rapplication.PaidFees = Convert.ToDecimal(lblTotalFees.Text);
            Rapplication.CreatedByUserID = clsGlobalSettings.LoggedInUser.ID;
            if (Rapplication.Save())
            {
                lblRnewLicenseApplicationID.Text = Rapplication.ApplicationID.ToString();
                clsLicense Nlicense = new clsLicense();
                Nlicense.ApplicationID = Rapplication.ApplicationID;
                Nlicense.DriverID = _OldLicense.DriverID;
                Nlicense.LicenseClass = _OldLicense.LicenseClass;
                Nlicense.IssueDate = DateTime.Now;
                Nlicense.ExpirationDate = Convert.ToDateTime(lblExpirationDate.Text);
                Nlicense.Notes = tbNotes.Text;
                Nlicense.PaidFees = Convert.ToDecimal(lblLicenseFees.Text);
                Nlicense.IsActive = true;
                Nlicense.IssueReason = (int)clsApplicationTypes.enApplicationTypes.RenewDrivingLicense;
                Nlicense.CreatedByUserID = clsGlobalSettings.LoggedInUser.ID;


                if (Nlicense.AddNew())
                {
                    llShowNewLicenseInfo.Enabled = true;
                    lblRenewedLicenseID.Text = Nlicense.ApplicationID.ToString();
                    btnRenew.Enabled = false;
                    tbNotes.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Failed To make a new License!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (!clsApplication.DeleteApplication(Rapplication.ApplicationID))
                        MessageBox.Show("Failed even to delete the application that has been made, the system may be not connedted the the DataBase please contact the troubltshooting team!", "Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("Failed to save renew application!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
        private void llShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLicenseInfo frm = new frmLicenseInfo(Convert.ToInt32(lblRenewedLicenseID.Text));
            frm.ShowDialog();
        }

        private void llShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLicenseHistory frm = new frmLicenseHistory(ctrlFilterLicense1.CurrentPersonID);
            frm.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
