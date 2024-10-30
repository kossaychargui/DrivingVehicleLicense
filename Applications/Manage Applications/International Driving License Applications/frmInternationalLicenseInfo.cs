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

namespace Course19DVLDProject.Applications.Manage_Applications.International_Driving_License_Applications
{
    public partial class frmInternationalLicenseInfo : Form
    {
        public frmInternationalLicenseInfo(int InternationalLicenseID)
        {
            InitializeComponent();
            _InternationalLicenseID = InternationalLicenseID;
        }

        private int _InternationalLicenseID = -1;

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmInternationalLicenseInfo_Load(object sender, EventArgs e)
        {
            _LoadInternationalLicenseInfo();
        }
        private void _LoadInternationalLicenseInfo()
        {
            clsInternationalLicense InternationalLicense = clsInternationalLicense.FindByID(_InternationalLicenseID);
            if (InternationalLicense != null)
            {
                clsDriver driver = clsDriver.FindDriverByID(InternationalLicense.DriverID);
                clsPerson person = clsPerson.Find(driver.PersonID);
                lblPersonName.Text = person.FullName();
                lblInternationalLicneseID.Text = InternationalLicense.InternationalLicenseID.ToString();
                lblApplictionID.Text = InternationalLicense.ApplicationID.ToString();
                lblLocalLicenseID.Text = InternationalLicense.IssuedUsingLocalDrivingLicenseID.ToString();
                lblIsActive.Text = InternationalLicense.IsActive ? "Yes" : "No";
                lblNationalNo.Text = person.NationalNo;
                lblDateOfBirth.Text = person.DateOfBirth.ToString();
                lblGender.Text = person.Gender;
                lblDriverID.Text = driver.ID.ToString();
                lblIssueDate.Text = InternationalLicense.IssueDate.ToString();
                lblExpirationDate.Text = InternationalLicense.ExpirationDate.ToString();
                if (person.ImagePath != string.Empty)
                {
                    pbPersonImage.ImageLocation = person.ImagePath;
                }
                else
                {
                    if (person.Gender == "Male")
                        pbPersonImage.Image = Resources.person_boy;
                    else
                        pbPersonImage.Image = Resources.person_girl;
                }
            }
            else
                MessageBox.Show("Cannot Load International License!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
    }
}
