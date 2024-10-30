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

namespace Course19DVLDProject.Applications.Driving_Licence_Services.Replacement_For_Lost_Or_Damaged_License
{
    public partial class frmReplaceLicenseForDamagedOrLost : Form
    {
        public frmReplaceLicenseForDamagedOrLost()
        {
            InitializeComponent();
        }
        private decimal _ApplicationFees = 0;
        private void frmReplaceLicenseForDamagedOrLost_Load(object sender, EventArgs e)
        {
            ctrlFilterLicense1.DataBack += CtrlFilterLicense1_DataBack;
            lblApplicationDate.Text = DateTime.Now.ToString();
            _ApplicationFees = clsApplicationTypes.GetApplicationFeesByID((int)clsApplicationTypes.enApplicationTypes.ReplacementForDamaged);
            lblApplicationFees.Text = _ApplicationFees.ToString();
            lblCreatedBy.Text = clsGlobalSettings.LoggedInUser.UserName;

        }
        private clsLicense _OldLicense;
        private void CtrlFilterLicense1_DataBack(object sender, int LicenseID)
        {
            _OldLicense = clsLicense.FindByID(LicenseID);
            lblOldLicenseID.Text = LicenseID.ToString();
            llShowLicenseHistory.Enabled = true;
            if (!_OldLicense.IsActive)
            {
                MessageBox.Show("Selected License is not active!", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                btnIssueReplacement.Enabled = false;
                gbReplacementFor.Enabled = false;
                return; 
            }
            gbReplacementFor.Enabled = true;
            btnIssueReplacement.Enabled = true;
        }

        private void btnIssueReplacement_Click(object sender, EventArgs e)
        {
            clsLicenseClass LicenseClass = clsLicenseClass.GetLicenseClassByID(_OldLicense.LicenseClass);
            clsApplication Rapplication = new clsApplication();
            Rapplication.ApplicantPersonID = ctrlFilterLicense1.CurrentPersonID;
            Rapplication.ApplicationDate = DateTime.Now;
            if (rbDamagedLicense.Checked)
                Rapplication.ApplicationTypeID = (int)clsApplicationTypes.enApplicationTypes.ReplacementForDamaged;
            else
                Rapplication.ApplicationTypeID = (int)clsApplicationTypes.enApplicationTypes.ReplacementForLost;
            Rapplication.ApplicationStatus = (int)clsApplication.enApplicationStatus.Completed;
            Rapplication.LastStatusDate = DateTime.Now;
            Rapplication.PaidFees = _ApplicationFees + LicenseClass.Fees;
            Rapplication.CreatedByUserID = clsGlobalSettings.LoggedInUser.ID;
            if (Rapplication.Save())
            {
                lblRnewLicenseApplicationID.Text = Rapplication.ApplicationID.ToString();
                clsLicense Nlicense = new clsLicense();
                Nlicense.ApplicationID = Rapplication.ApplicationID;
                Nlicense.DriverID = _OldLicense.DriverID;
                Nlicense.LicenseClass = _OldLicense.LicenseClass;
                Nlicense.IssueDate = DateTime.Now;
                Nlicense.ExpirationDate = DateTime.Now.AddYears(LicenseClass.DefaultValidityLength);
                Nlicense.Notes = string.Empty;
                Nlicense.PaidFees = LicenseClass.Fees;
                Nlicense.IsActive = true;
                if (rbDamagedLicense.Checked)
                    Nlicense.IssueReason = (int)clsApplicationTypes.enApplicationTypes.ReplacementForDamaged;
                else
                    Nlicense.IssueReason = (int)clsApplicationTypes.enApplicationTypes.ReplacementForLost;
                Nlicense.CreatedByUserID = clsGlobalSettings.LoggedInUser.ID;

                if (Nlicense.AddNew())
                {
                    llShowNewLicenseInfo.Enabled = true;
                    lblRenewedLicenseID.Text = Nlicense.ApplicationID.ToString();
                    btnIssueReplacement.Enabled = false;
                    gbReplacementFor.Enabled = false;
                    if (!clsLicense.DisActiveLicense(_OldLicense.LicenseID))
                    {
                        MessageBox.Show($"Failed To disactivate Old license (license id ={_OldLicense.LicenseID}) ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
                MessageBox.Show("Failed to save renew application!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ReplacementForLostReasonChecked(object sender, EventArgs e)
        {
             if (rbDamagedLicense.Checked)
             {
                lblFormTitle.Text = "Replacement For Lost License";
                _ApplicationFees = clsApplicationTypes.GetApplicationFeesByID((int)clsApplicationTypes.enApplicationTypes.ReplacementForDamaged);
            }
             else
             {
                lblFormTitle.Text = "Replacement For Damaged License";
                _ApplicationFees = clsApplicationTypes.GetApplicationFeesByID((int)clsApplicationTypes.enApplicationTypes.ReplacementForLost);
             }
            lblApplicationFees.Text = _ApplicationFees.ToString();
            Text = lblFormTitle.Text;

        }

        private void llShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLicenseHistory frm = new frmLicenseHistory(ctrlFilterLicense1.CurrentPersonID);
            frm.ShowDialog();
        }

        private void llShowNewLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLicenseInfo frm = new frmLicenseInfo(Convert.ToInt32(lblRenewedLicenseID.Text));
            frm.ShowDialog();
        }
    }
}
