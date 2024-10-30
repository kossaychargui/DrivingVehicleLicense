using Course19DVLDProject.Applications.Detain_Licenses.Detain_License;
using Course19DVLDProject.Applications.Detain_Licenses.Release_Detained_License;
using Course19DVLDProject.Applications.Manage_Applications.Local_Driving_License_Applications;
using Course19DVLDProject.People;
using DVLDBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Course19DVLDProject.Applications.Detain_Licenses.Manage_Detained_Licenses
{
    public partial class frmManageDetainedLicenses : Form
    {
        public frmManageDetainedLicenses()
        {
            InitializeComponent();
        }

        DataView dv;
        private void frmManageDetainedLicenses_Load(object sender, EventArgs e)
        {
            _LoadDetainedLicenses();
            cbIsReleased.SelectedIndex = 0;
            cbFilterBy.SelectedIndex = 0;


        }
        private void _LoadDetainedLicenses()
        {
            dv = new DataView(clsDetainedLicense.GetAllDetainedLicenses());
            dataGridView1.DataSource = dv;
            lblRecordsNumber.Text = dv.Count.ToString();
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbFilterBy.SelectedIndex)
            {
                case 0:
                dv.RowFilter = string.Empty;
                    cbIsReleased.Visible = false;
                    tbFilterBy.Visible = false;
                    break;
                case 2:
                    cbIsReleased.Visible = true;
                    tbFilterBy.Visible = false;
                    break;
                default:
                    cbIsReleased.Visible = false;
                    tbFilterBy.Visible = true;
                    break;
            }
   
        }

        private void tbFilterBy_TextChanged(object sender, EventArgs e)
        {
            switch (cbFilterBy.SelectedIndex)
            {
                case 1:
                    if(int.TryParse(tbFilterBy.Text, out int DetainID))
                        dv.RowFilter = $"[{dv.Table.Columns["D.ID"].ColumnName}] = {DetainID}";
                    break;
                case 3:
                    dv.RowFilter = $"[{dv.Table.Columns["N.No."].ColumnName}] LIKE '%{tbFilterBy.Text}%'";
                    break;
                case 4:
                    dv.RowFilter = $"[{dv.Table.Columns["Full Name"].ColumnName}] LIKE '%{tbFilterBy.Text}%'";
                    break;
                case 5:
                    if (int.TryParse(tbFilterBy.Text, out int RAppID))
                        dv.RowFilter = $"[{dv.Table.Columns["Release App.ID"].ColumnName}] = {RAppID}";
                    break;
            }
        }

        private void btnDetanLicense_Click(object sender, EventArgs e)
        {
            frmDetainLicense frm = new frmDetainLicense();
            frm.ShowDialog();
            _LoadDetainedLicenses();
        }

        private void btnReleaseLicense_Click(object sender, EventArgs e)
        {
            frmReleaseLicense frm = new frmReleaseLicense();
            frm.ShowDialog();
            _LoadDetainedLicenses();
        }

        private void cbIsReleased_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbIsReleased.SelectedIndex)
            {
                case 0:
                    dv.RowFilter = string.Empty;
                    break;
                case 1:
                    dv.RowFilter = $"[{dv.Table.Columns["Is Released"].ColumnName}] = true";
                    break;
                default:
                    dv.RowFilter = $"[{dv.Table.Columns["Is Released"].ColumnName}] = false";
                    break;

            }

        }

        private void toolStripMenuItemShowPersonDetails_Click(object sender, EventArgs e)
        {
            string NationalNo = (string)dataGridView1.CurrentRow.Cells[6].Value;
            frmPersonDetails frm = new frmPersonDetails(NationalNo);
            frm.ShowDialog();
        }

        private void toolStripMenuItemsShowLicenseDetails_Click(object sender, EventArgs e)
        {
            int LicenseID = (int)dataGridView1.CurrentRow.Cells[1].Value;
            frmLicenseInfo frm = new frmLicenseInfo(LicenseID);
            frm.ShowDialog();
        }

        private void toolStripMenuItemShowPersonLicenseHistory_Click(object sender, EventArgs e)
        {
            string NationalNo = (string)dataGridView1.CurrentRow.Cells[6].Value;
            frmLicenseHistory frm = new frmLicenseHistory(NationalNo);
            frm.ShowDialog();
        }

        private void toolStripMenuItemReleaseDetainedLicense_Click(object sender, EventArgs e)
        {
            int LicenseID = (int)dataGridView1.CurrentRow.Cells[1].Value;
            frmReleaseLicense frm = new frmReleaseLicense(LicenseID);
            frm.ShowDialog();
        }



        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            toolStripMenuItemReleaseDetainedLicense.Enabled = !(bool)dataGridView1.CurrentRow.Cells[3].Value; ;
       
        }
    }
}
