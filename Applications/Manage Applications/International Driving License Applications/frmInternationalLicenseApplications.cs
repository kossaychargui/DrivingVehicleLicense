using Course19DVLDProject.Applications.Driving_Licence_Services.New_Driving_Licence.Local_Driving_Licence;
using Course19DVLDProject.Applications.Manage_Applications.Local_Driving_License_Applications;
using Course19DVLDProject.People;
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
    public partial class frmInternationalLicenseApplications : Form
    {
        public frmInternationalLicenseApplications()
        {
            InitializeComponent();
        }

        private DataView dv;
        private void frmInternationalLicenseApplications_Load(object sender, EventArgs e)
        {
            _LoadInternationalLicenses();
            cbFilterBy.SelectedIndex = 0;
            cbIsActive.SelectedIndex = 0;
        }
        private void _LoadInternationalLicenses()
        {
            dv = new DataView(clsInternationalLicense.GetAllInternationalLicenses());
            dataGridView1.DataSource = dv;
            lblNumberOfRecords.Text = dv.Count.ToString();
        }
        private void btnAddNewLocalDrivingLicenseApplication_Click(object sender, EventArgs e)
        {
            frmNewInternationalLicenseApplication frm = new frmNewInternationalLicenseApplication();
            frm.ShowDialog();
            _LoadInternationalLicenses();
        }
        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilterBy.SelectedIndex == 0)
            {
                dv.RowFilter = string.Empty;
                tbFilterBy.Visible = false;
                cbIsActive.Visible = false;
            }
            else if(cbFilterBy.SelectedIndex == 5)
            {
                tbFilterBy.Visible = false;
                cbIsActive.Visible = true;
            }
            else
            {
                tbFilterBy.Visible = true;
                cbIsActive.Visible = false;
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tbFilterBy_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void tbFilterBy_TextChanged(object sender, EventArgs e)
        {
            if(int.TryParse(tbFilterBy.Text, out int value))
                dv.RowFilter = $"[{cbFilterBy.SelectedItem}] = {value}";
        }

        private void cbIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbIsActive.SelectedIndex == 0)
            {
                dv.RowFilter = string.Empty;
            }
            else
            {
                if (cbIsActive.SelectedIndex == 1)
                    dv.RowFilter = $"[Is Active] = true";
                else
                    dv.RowFilter = $"[Is Active] = false";
            }
        }

        private void toolStripMenuItemShowPersonDetails_Click(object sender, EventArgs e)
        {
            int DriverID = (int)dataGridView1.CurrentRow.Cells[2].Value;
            clsDriver driver = clsDriver.FindDriverByID(DriverID);
            frmPersonDetails frm = new frmPersonDetails(driver.PersonID);
            frm.ShowDialog();
        }

        private void toolStripMenuItemShowLicenseDetails_Click(object sender, EventArgs e)
        {
            int IntLicenseID = (int)dataGridView1.CurrentRow.Cells[0].Value;
            frmInternationalLicenseInfo frm = new frmInternationalLicenseInfo(IntLicenseID);
            frm.ShowDialog();
        }

        private void toolStripMenuItemShowPersonLicenseHistory_Click(object sender, EventArgs e)
        {
            int DriverID = (int)dataGridView1.CurrentRow.Cells[2].Value;
            clsDriver driver = clsDriver.FindDriverByID(DriverID);
            frmLicenseHistory frm = new frmLicenseHistory(driver.PersonID);
            frm.ShowDialog();
        }
    }
}
