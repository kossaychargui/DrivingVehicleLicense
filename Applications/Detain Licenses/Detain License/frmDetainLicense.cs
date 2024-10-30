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

namespace Course19DVLDProject.Applications.Detain_Licenses.Detain_License
{
    public partial class frmDetainLicense : Form
    {
        public frmDetainLicense()
        {
            InitializeComponent();
        }

        private void frmDetainLicense_Load(object sender, EventArgs e)
        {
            ctrlFilterLicense1.DataBack += CtrlFilterLicense1_DataBack;
            lblDetainDate.Text = DateTime.Now.ToString();
            lblCreatedBy.Text = clsGlobalSettings.LoggedInUser.UserName;

        }
       
        private void CtrlFilterLicense1_DataBack(object sender, int LicenseID)
        {
            lblLicenseID.Text = LicenseID.ToString();
            llShowLicenseHistory.Enabled = true;
            if (clsDetainedLicense.IsDetainedLicense(LicenseID))
            {
                MessageBox.Show("Selected License is already Detained, choose another one!", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                btnDetain.Enabled = false;
                llShowLicenseInfo.Enabled = false;
                return;
            }
            btnDetain.Enabled = true;

        }
        private void btnDetain_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbFees.Text))
            {
                MessageBox.Show("Please Fill the Detail fine Fees!", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            clsDetainedLicense DetainL = new clsDetainedLicense();
            DetainL.LicenseID = ctrlFilterLicense1._CurrentLicense.LicenseID;
            DetainL.DetainDate = DateTime.Now;
            DetainL.FineFees = Convert.ToDecimal(tbFees.Text.Trim());
            DetainL.CreatedByUserID = clsGlobalSettings.LoggedInUser.ID;
            if (DetainL.DetainLicense())
            {
                MessageBox.Show($"License Detained Successfully with Detain Id = {DetainL.DetainID}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                llShowLicenseInfo.Enabled = true;
                btnDetain.Enabled=false;
            }
            else
            {
                MessageBox.Show("Failed To Detain License!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tbFees_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void llShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLicenseHistory frm = new frmLicenseHistory(ctrlFilterLicense1.CurrentPersonID);
            frm.ShowDialog();
        }

        private void llShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLicenseInfo frm = new frmLicenseInfo(ctrlFilterLicense1.CurrentLicenseID);
            frm.ShowDialog();
        }
    }
}
