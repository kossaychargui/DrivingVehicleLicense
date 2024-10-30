using Course19DVLDProject.Applications.Manage_Applications.Local_Driving_License_Applications;
using DVLDBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Course19DVLDProject.Applications.Detain_Licenses.Release_Detained_License
{
    public partial class frmReleaseLicense : Form
    {
        public frmReleaseLicense()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
        }
        public frmReleaseLicense(int LicenseID)
        {
            InitializeComponent();
            _LicenseID = LicenseID;
            _Mode = enMode.Update;
        }
        private enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode = enMode.AddNew;
        private int _LicenseID = -1;
        private void frmReleaseLicense_Load(object sender, EventArgs e)
        {
            ctrlFilterLicense1.DataBack += CtrlFilterLicense1_DataBack;
            lblApplicationFees.Text = clsApplicationTypes.GetApplicationFeesByID((int)clsApplicationTypes.enApplicationTypes.ReleaseDetainedDrivingLicense).ToString();
            if (_Mode == enMode.Update)
            {
                ctrlFilterLicense1.FillLicenseInfo(sender, _LicenseID);
               
            }
            else
            {

                lblCreatedBy.Text = clsGlobalSettings.LoggedInUser.UserName;
            }
          
        }
        clsDetainedLicense _DetainLicense = null;
        private void CtrlFilterLicense1_DataBack(object sender, int LicenseID)
        {
            lblLicenseID.Text = LicenseID.ToString();
            llShowLicenseHistory.Enabled = true;
            if (!clsDetainedLicense.IsDetainedLicense(LicenseID)) {
                MessageBox.Show("Selected License is not Detained, Please choose another license!", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                btnRelease.Enabled = false;
                llShowLicenseInfo.Enabled = false;
                return;
            }
            _DetainLicense = clsDetainedLicense.FindByLicenseID(LicenseID);
            if (_DetainLicense != null)
            {
                _FillDetainLicenseInfo();
                btnRelease.Enabled = true;
            }
            else
                MessageBox.Show("Cannot Load Detain Info!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            


        }
        private void _FillDetainLicenseInfo()
        {
            lblDetainID.Text = _DetainLicense.DetainID.ToString();
            lblDetainDate.Text = _DetainLicense.DetainDate.ToString();
            lblFineFees.Text = _DetainLicense.FineFees.ToString();
            lblTotlaFees.Text = (Convert.ToDecimal(lblApplicationFees.Text) + _DetainLicense.FineFees).ToString();
        }

        private void btnRelease_Click(object sender, EventArgs e)
        {
            if((MessageBox.Show("Are you sure you want to release this License", "Verification", MessageBoxButtons.OK, MessageBoxIcon.Question) != DialogResult.OK))
                    return;
            clsApplication Rapplication = new clsApplication();
            Rapplication.ApplicantPersonID = ctrlFilterLicense1.CurrentPersonID;
            Rapplication.ApplicationDate = DateTime.Now;
            Rapplication.ApplicationTypeID = (int)clsApplicationTypes.enApplicationTypes.ReleaseDetainedDrivingLicense;
            Rapplication.ApplicationStatus = (int)clsApplication.enApplicationStatus.Completed;
            Rapplication.LastStatusDate = DateTime.Now;
            Rapplication.PaidFees = Convert.ToDecimal(lblTotlaFees.Text);
            Rapplication.CreatedByUserID = clsGlobalSettings.LoggedInUser.ID;
            if (Rapplication.Save())
            {
                  lblApplicationID.Text = Rapplication.ApplicationID.ToString();
                    _DetainLicense.ReleasedDate = DateTime.Now;
                    _DetainLicense.ReleasedByUserID = clsGlobalSettings.LoggedInUser.ID;
                    _DetainLicense.ReleaseApplicationID = Rapplication.ApplicationID;
                

                if (_DetainLicense.Release())
                {
                    llShowLicenseInfo.Enabled = true;
                    btnRelease.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Failed To Release License!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if(!clsApplication.DeleteApplication(Rapplication.ApplicationID))
                        MessageBox.Show("Failed even to delete the application that has been made, the system may be not connedted the the DataBase please contact the troubltshooting team!", "Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                
                
            }
            else
                MessageBox.Show("Failed to save Release application!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void llShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLicenseHistory frm = new frmLicenseHistory(ctrlFilterLicense1.CurrentPersonID);
            frm.ShowDialog();
        }

        private void llShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLicenseInfo frm = new frmLicenseInfo(ctrlFilterLicense1._CurrentLicense.LicenseID);
            frm.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void _FillDetainInfo(int LicenseID)
        {
            _DetainLicense = clsDetainedLicense.FindByLicenseID(LicenseID);
            lblDetainID.Text = _DetainLicense.DetainID.ToString();
            lblLicenseID.Text = _DetainLicense.LicenseID.ToString();
   
            lblDetainDate.Text = _DetainLicense.DetainDate.ToString();
            lblCreatedBy.Text = _DetainLicense.CreatedByUserID.ToString();

            lblFineFees.Text = _DetainLicense.FineFees.ToString();
            lblTotlaFees.Text = (Convert.ToDecimal(lblApplicationFees.Text) + _DetainLicense.FineFees).ToString();
            lblApplicationID.Text = _DetainLicense.ReleaseApplicationID.ToString();

        }
    }
}
