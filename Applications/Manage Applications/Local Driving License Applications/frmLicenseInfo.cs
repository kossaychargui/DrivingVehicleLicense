using Course19DVLDProject.Properties;
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
    public partial class frmLicenseInfo : Form
    {
        public frmLicenseInfo(int ApplicationID, bool ByApplicationID)
        {
            InitializeComponent();
            _ApplicationID = ApplicationID;
            _ByApplicationID = true;
        }
        public frmLicenseInfo(int LicenseID)
        {
            InitializeComponent();
            _LicenseID = LicenseID;

        }
        private int _LicenseID = -1;
        private int _ApplicationID = -1;
        private bool _ByApplicationID = false;
        private void frmLicenseInfo_Load(object sender, EventArgs e)
        {
            if(_ApplicationID != -1 || _LicenseID != -1)
            {
                FillLicenseInfo();
            }
        }
        private void FillLicenseInfo()
        {
            clsLicense License = _ByApplicationID? clsLicense.FindByApplicationID(_ApplicationID): clsLicense.FindByID(_LicenseID);
            if (License != null) {
                _LicenseID = License.LicenseID;
                lblLicenseID.Text = License.LicenseID.ToString();
                clsDriver Driver = clsDriver.FindDriverByID(License.DriverID);
                clsPerson Person = clsPerson.Find(Driver.PersonID);
                lblDriverName.Text = Person.FullName();
                lblNationalNo.Text = Person.NationalNo;
                lblIsActive.Text = License.IsActive ? "Yes" : "No";
                lblDateOfBirth.Text = Person.DateOfBirth.ToString();
                lblGender.Text = Person.Gender;
                lblDriverID.Text = License.DriverID.ToString();
                lblIssueDate.Text = License.IssueDate.ToString();
                lblExpirationDate.Text = License.ExpirationDate.ToString();
                lblIssueReason.Text = License.IssueReason.ToString();
                if (License.Notes == string.Empty)
                    lblNotes.Text = "No Notes.";
                else
                    lblNotes.Text = License.Notes.ToString();
                lblIsDetained.Text = clsDetainedLicense.IsDetainedLicense(_LicenseID) ? "Yes" : "No";
                if(Person.ImagePath != string.Empty)
                    pbPersonImage.ImageLocation = Person.ImagePath;
                else
                {
                    pbPersonImage.Image = Person.Gender == "Male" ? Resources.person_boy : Resources.person_girl;

                }
            }
            else
            {
                MessageBox.Show("Failed To Load License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
