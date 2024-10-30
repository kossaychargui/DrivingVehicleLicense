using Course19DVLDProject.Applications.Detain_Licenses.Detain_License;
using Course19DVLDProject.Applications.Detain_Licenses.Manage_Detained_Licenses;
using Course19DVLDProject.Applications.Detain_Licenses.Release_Detained_License;
using Course19DVLDProject.Applications.Driving_Licence_Services.New_Driving_Licence.Local_Driving_Licence;
using Course19DVLDProject.Applications.Driving_Licence_Services.Renew_Driving_License;
using Course19DVLDProject.Applications.Driving_Licence_Services.Replacement_For_Lost_Or_Damaged_License;
using Course19DVLDProject.Applications.Manage_Applications.International_Driving_License_Applications;
using Course19DVLDProject.Applications.Manage_Applications.Local_Driving_License_Applications;
using Course19DVLDProject.Applications.Manage_Applications_types;
using Course19DVLDProject.Applications.Manage_Test_Types;
using Course19DVLDProject.Drivers;
using Course19DVLDProject.People;
using Course19DVLDProject.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Course19DVLDProject
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }



        private void peopleToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmManagePeople frm = new frmManagePeople();
            frm.ShowDialog();
        }

        private void toolStripMenuSignOut_Click(object sender, EventArgs e)
        {
            clsGlobalSettings.LoggedInUser = null;
            this.Close();
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageUsers frm = new frmManageUsers();
            frm.ShowDialog();
        }

        private void toolStripMenuCurrentUserInfo_Click(object sender, EventArgs e)
        {
            frmUserDetails frm = new frmUserDetails(clsGlobalSettings.LoggedInUser.ID);
            frm.ShowDialog();
        }

        private void toolStripMenuChangePassword_Click(object sender, EventArgs e)
        {
            frmChangeUserPassword frm = new frmChangeUserPassword(clsGlobalSettings.LoggedInUser.ID);
            frm.ShowDialog();
        }

        private void toolStripMenuItemManageApplicationTypes_Click(object sender, EventArgs e)
        {
            frmManageApplictionTypes frm = new frmManageApplictionTypes();
            frm.ShowDialog();
        }

        private void toolStripMenuItemManageTestTypes_Click(object sender, EventArgs e)
        {
            frmManageTestTypes frm = new frmManageTestTypes();
            frm.ShowDialog();
        }

        private void localLicenceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNewDrivingLicenseApplication frm = new frmNewDrivingLicenseApplication(-1);
            frm.ShowDialog();
        }

        private void driversToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManagerDrivers frm = new frmManagerDrivers();
            frm.ShowDialog();
        }

        private void toolStripMenuItemLocalDrivingLicenseApplications_Click(object sender, EventArgs e)
        {
            frmLocalDrivingLicenseApplications frm = new frmLocalDrivingLicenseApplications();
            frm.ShowDialog();
        }

        private void toolStripMenuItemInternationalDrivingLicenseApplications_Click(object sender, EventArgs e)
        {
            frmInternationalLicenseApplications frm = new frmInternationalLicenseApplications();
            frm.ShowDialog();
        }

        private void internationalLicenceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNewInternationalLicenseApplication frm = new frmNewInternationalLicenseApplication();
            frm.ShowDialog();
        }

        private void renewDrivingLicenceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRenewLocalDrivingLicense frm = new frmRenewLocalDrivingLicense();
            frm.ShowDialog();
        }

        private void replacementForLostOrDamagedLicenceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReplaceLicenseForDamagedOrLost frm = new frmReplaceLicenseForDamagedOrLost();
            frm.ShowDialog();
        }

        private void retakeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLocalDrivingLicenseApplications frm = new frmLocalDrivingLicenseApplications();
            frm.ShowDialog();
        }

        private void releaseDrivingLicenceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReleaseLicense   frm = new frmReleaseLicense();
            frm.ShowDialog();
        }

        private void toolStripMenuItemDetainLicense_Click(object sender, EventArgs e)
        {
            frmDetainLicense frm = new frmDetainLicense();
            frm.ShowDialog();
        }

        private void toolStripMenuItemReleaseDetainedLicense_Click(object sender, EventArgs e)
        {
            frmReleaseLicense frm = new frmReleaseLicense();
            frm.ShowDialog();
        }

        private void toolStripMenuItemManageDetainedLicenses_Click(object sender, EventArgs e)
        {
            frmManageDetainedLicenses frm = new frmManageDetainedLicenses();
            frm.ShowDialog();
        }
    }
}
