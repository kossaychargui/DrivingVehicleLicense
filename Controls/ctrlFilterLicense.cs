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

namespace Course19DVLDProject.Controls
{
    public partial class ctrlFilterLicense : UserControl
    {
        public delegate void DataBackEventHandler(object sender, int LicenseID);

        public event DataBackEventHandler DataBack;
        public ctrlFilterLicense()
        {
            InitializeComponent();
        }
        public clsLicense _CurrentLicense = null;
        public int CurrentLicenseID = -1;
        public int CurrentPersonID = -1;
        private void btnSearchForPerson_Click(object sender, EventArgs e)
        {
            if (int.TryParse(tbLicenseID.Text, out int licenseID)) {
                _CurrentLicense = clsLicense.FindByID(licenseID);
                if(_CurrentLicense != null)
                {
                    CurrentLicenseID = _CurrentLicense.LicenseID;
                    _FillLicenseInfo();
                    DataBack?.Invoke(sender, _CurrentLicense.LicenseID);
                }
                else
                {
                    CurrentLicenseID = -1;
                    MessageBox.Show("Cannot Find License!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void _FindLicense(object sender, int LicenseID)
        {
            _CurrentLicense = clsLicense.FindByID(LicenseID);
            if (_CurrentLicense != null)
            {
                CurrentLicenseID = _CurrentLicense.LicenseID;
                _FillLicenseInfo();
                DataBack?.Invoke(sender, _CurrentLicense.LicenseID);
            }
            else
            {
                CurrentLicenseID = -1;
                MessageBox.Show("Cannot Find License!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void _FillLicenseInfo()
        {

            lblLicenseID.Text =_CurrentLicense.LicenseID.ToString();
            clsDriver Driver = clsDriver.FindDriverByID(_CurrentLicense.DriverID);
            clsPerson Person = clsPerson.Find(Driver.PersonID);
            CurrentPersonID = Person.ID;
            lblDriverName.Text = Person.FullName();
            lblNationalNo.Text = Person.NationalNo;
            lblIsActive.Text = _CurrentLicense.IsActive ? "Yes" : "No";
            lblDateOfBirth.Text = Person.DateOfBirth.ToString();
            lblGender.Text = Person.Gender;
            lblDriverID.Text = _CurrentLicense.DriverID.ToString();
            lblIssueDate.Text = _CurrentLicense.IssueDate.ToString();
            lblExpirationDate.Text = _CurrentLicense.ExpirationDate.ToString();
            lblIssueReason.Text = _CurrentLicense.IssueReason.ToString();
            if (_CurrentLicense.Notes == string.Empty)
                lblNotes.Text = "No Notes.";
            else
                lblNotes.Text = _CurrentLicense.Notes.ToString();
             lblIsDetained.Text = clsDetainedLicense.IsDetainedLicense(_CurrentLicense.LicenseID) ? "Yes" : "No";
            if (Person.ImagePath != string.Empty)
                pbPersonImage.ImageLocation = Person.ImagePath;
            else
            {
                pbPersonImage.Image = Person.Gender == "Male" ? Resources.person_boy : Resources.person_girl;

            }

        }
        private void tbLicenseID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        public void FillLicenseInfo(object sender, int LicenseID)
        {
            _FindLicense(sender, LicenseID);
            tbLicenseID.Text = LicenseID.ToString();
            gbFilter.Enabled = false;
            
        }
    }
}
