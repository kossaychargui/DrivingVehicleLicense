using Course19DVLDProject.Applications.Manage_Applications.International_Driving_License_Applications;
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
    public partial class frmLicenseHistory : Form
    {
        public frmLicenseHistory(int ApplicantID)
        {
            InitializeComponent();
            _ApplicantID = ApplicantID;
        }
        public frmLicenseHistory(string NationalNo)
        {
            InitializeComponent();
            clsPerson clsPerson = clsPerson.Find(NationalNo);
            _ApplicantID = clsPerson.ID;
        }
        private int _ApplicantID = -1;

        private void frmLicenseHistory_Load(object sender, EventArgs e)
        {
         
            ctrlFilterPerson1.FillPersonData(_ApplicantID);
            _LoadLocalDrivingLicenses();
            _LocalInternationalDrivingLicenses();
        }
        private void _LoadLocalDrivingLicenses()
        {
            dataGridView1.DataSource = clsLicense.GetPersonAllLicenses(_ApplicantID);
            lblLocalDrivingLicensesNumber.Text = dataGridView1.RowCount.ToString();
        }
        private void _LocalInternationalDrivingLicenses()
        {
            dataGridView2.DataSource = clsInternationalLicense.GetInternationalLicensesByPersonID(_ApplicantID);
            lblInternationalDrivingLicenseNumber.Text = dataGridView2.RowCount.ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void toolStripMenuItemShowLicenseInfo_Click(object sender, EventArgs e)
        {
            int LicenseID = 0;
            if (tabControl1.SelectedIndex == 0)
            {
                LicenseID = (int)dataGridView1.CurrentRow.Cells[0].Value;
                frmLicenseInfo frm = new frmLicenseInfo(LicenseID);
                frm.ShowDialog();
            }
            else
            {
                LicenseID = (int)dataGridView2.CurrentRow.Cells[0].Value;
                frmInternationalLicenseInfo frm = new frmInternationalLicenseInfo(LicenseID);
                frm.ShowDialog();
            }
        }
    }
}
