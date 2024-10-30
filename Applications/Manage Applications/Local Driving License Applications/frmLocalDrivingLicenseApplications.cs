using Course19DVLDProject.Applications.Driving_Licence_Services.New_Driving_Licence.Local_Driving_Licence;
using Course19DVLDProject.Applications.Manage_Applications.Local_Driving_License_Applications.Schedule_Tests;
using DVLDBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Course19DVLDProject.Applications.Manage_Applications.Local_Driving_License_Applications
{
    public partial class frmLocalDrivingLicenseApplications : Form
    {
        public frmLocalDrivingLicenseApplications()
        {
            InitializeComponent();
        }

        private void btnAddNewLocalDrivingLicenseApplication_Click(object sender, EventArgs e)
        {
            frmNewDrivingLicenseApplication frm = new frmNewDrivingLicenseApplication(-1);
            frm.ShowDialog();
            _LoadLocalDrivingLicenseApplications();
        }

        private DataView dv = null;
        private void _LoadLocalDrivingLicenseApplications()
        {
            dv = new DataView(clsLocalDrivingLicenseApplication.GetAllLocalDrivingLicenseApplications());
            dataGridView1.DataSource = dv;
            lblNumberOfRecords.Text = dv.Count.ToString();
            
        }
        private void frmLocalDrivingLicenseApplications_Load(object sender, EventArgs e)
        {
            _LoadLocalDrivingLicenseApplications();
            cbFilterBy.SelectedIndex = 0;
            cbStatus.SelectedIndex = 0;

        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilterBy.SelectedIndex == 0)
            {
                dv.RowFilter = string.Empty;
                tbFilterBy.Visible = false;
                cbStatus.Visible = false;
            }
            else if (cbFilterBy.SelectedIndex == 4)
            {
                tbFilterBy.Visible = false;
                cbStatus.Visible = true;
            }
            else
            {
                tbFilterBy.Visible = true;
                cbStatus.Visible = false;
            }

        }

        private void tbFilterBy_TextChanged(object sender, EventArgs e)
        {
            if (cbFilterBy.SelectedIndex == 1) // filter by id
            {
                if (int.TryParse(tbFilterBy.Text, out int id))
                {
                    dv.RowFilter = $"{cbFilterBy.SelectedItem} = {id}";
                }
            }
            else if (cbFilterBy.SelectedIndex == 2 || cbFilterBy.SelectedIndex == 3)
            {
                dv.RowFilter = $"{cbFilterBy.SelectedItem} LIKE '%{tbFilterBy.Text.Trim()}%'";
            }
        }

        private void cbFilterBy_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.SelectedIndex == 1) // Accept Only Numbers
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                    e.Handled = true;
            }
            else if (cbFilterBy.SelectedIndex == 2) // Accpet only letters
            {
                if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
                    e.Handled = true;
            }
        }

        private void cbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbStatus.SelectedIndex)
            {
                case 0:
                    dv.RowFilter = string.Empty;
                    break;
                case 1:
                    dv.RowFilter = $"{dv.Table.Columns["Status"]} LIKE '%New%'";
                    break;
                case 2:
                    dv.RowFilter = $"{dv.Table.Columns["Status"]}  LIKE '%Cancelled%'";
                    break;
                case 3:
                    dv.RowFilter = $"{dv.Table.Columns["Status"]} LIKE '%Completed%'";
                    break;

            }
        }

        private void toolStripMenuItemScheduleVisionTest_Click(object sender, EventArgs e)
        {
            int LocalDrivingApplicationID = (int)dataGridView1.CurrentRow.Cells[0].Value;
            frmTestAppointment frm = new frmTestAppointment(LocalDrivingApplicationID, (int)clsTestAppointment.enAppointmentType.VisionTestAppointment);
            frm.ShowDialog();
            _LoadLocalDrivingLicenseApplications();
        }

        private void toolStripMenuItemShceduleWrittenTest_Click(object sender, EventArgs e)
        {
            int LocalDrivingApplicationID = (int)dataGridView1.CurrentRow.Cells[0].Value;
            frmTestAppointment frm = new frmTestAppointment(LocalDrivingApplicationID, (int)clsTestAppointment.enAppointmentType.WrittenTestAppointment);
            frm.ShowDialog();
            _LoadLocalDrivingLicenseApplications();
        }

        private void toolStripMenuItemScheduleStreetTest_Click(object sender, EventArgs e)
        {
            int LocalDrivingApplicationID = (int)dataGridView1.CurrentRow.Cells[0].Value;
            frmTestAppointment frm = new frmTestAppointment(LocalDrivingApplicationID, (int)clsTestAppointment.enAppointmentType.PracticalTestAppointment);
            frm.ShowDialog();
            _LoadLocalDrivingLicenseApplications();
        }




        private void toolStripMenuItemShowApplicationDetails_Click(object sender, EventArgs e)
        {
            int LocalDrivingApplicationID = (int)dataGridView1.CurrentRow.Cells[0].Value;
            frmShowLocalDrivingLicenseApplicationDetails frm = new frmShowLocalDrivingLicenseApplicationDetails(LocalDrivingApplicationID);
            frm.ShowDialog();

        }

        private void toolStripMenuItemEditApplication_Click(object sender, EventArgs e)
        {
            int LocalDrivingApplicationID = (int)dataGridView1.CurrentRow.Cells[0].Value;
            frmNewDrivingLicenseApplication frm = new frmNewDrivingLicenseApplication(LocalDrivingApplicationID);
            frm.ShowDialog();
            _LoadLocalDrivingLicenseApplications();
        }

        private void toolStripMenuItemDeleteApplication_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delte this application", "Verification", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                int LocalDrivingApplicationID = (int)dataGridView1.CurrentRow.Cells[0].Value;
                clsLocalDrivingLicenseApplication localDrivingLicenseApplication = clsLocalDrivingLicenseApplication.FindByID(LocalDrivingApplicationID);
                clsApplication application = clsApplication.FindByID(localDrivingLicenseApplication.ApplicationID);
                if (application.Cancel())
                {
                    if (clsLocalDrivingLicenseApplication.DeleteLocalDrivingLicenseApplication(LocalDrivingApplicationID))
                    {
                        MessageBox.Show("Driving License Deleted Successfully", "Success", MessageBoxButtons.OK);
                    }
                    else
                        MessageBox.Show("Failed to delte Driving License", "Error", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("Cannot cancel application", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            _LoadLocalDrivingLicenseApplications();
        }

        private void toolStripMenuItemIssueDrivingLicense_Click(object sender, EventArgs e)
        {
            int LocalDrivingApplicationID = (int)dataGridView1.CurrentRow.Cells[0].Value;
            frmIssueDriverLicenseForTheFirstTime frm = new frmIssueDriverLicenseForTheFirstTime(LocalDrivingApplicationID);
            frm.ShowDialog();
            _LoadLocalDrivingLicenseApplications();
        }

        private void toolStripMenuItemCancelApplication_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to cancel this application", "Verification", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                int LocalDrivingApplicationID = (int)dataGridView1.CurrentRow.Cells[0].Value;
                clsLocalDrivingLicenseApplication LocalDrivingApplication = clsLocalDrivingLicenseApplication.FindLocalDrivingApplicationByID(LocalDrivingApplicationID);
                if (clsApplication.CancelApplication(LocalDrivingApplication.ApplicationID))
                    MessageBox.Show("Application Cancelled successfully", "Success", MessageBoxButtons.OK);
                else
                    MessageBox.Show("Failed To Cancel Application", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            _LoadLocalDrivingLicenseApplications();
        }

        private void toolStripMenuItemShowLicense_Click(object sender, EventArgs e)
        {
            int LocalDrivingApplicationID = (int)dataGridView1.CurrentRow.Cells[0].Value;
            clsLocalDrivingLicenseApplication LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.FindLocalDrivingApplicationByID(LocalDrivingApplicationID);
            frmLicenseInfo frm = new frmLicenseInfo(LocalDrivingLicenseApplication.ApplicationID, true);
            frm.ShowDialog();

        }

        private void toolStripMenuItemShowPersonLicenseHistory_Click(object sender, EventArgs e)
        {
            int LocalDrivingApplicationID = (int)dataGridView1.CurrentRow.Cells[0].Value;
             int ApplicantID = clsLocalDrivingLicenseApplication.GetApplicantID(LocalDrivingApplicationID);
            frmLicenseHistory frm = new frmLicenseHistory(ApplicantID);
            frm.ShowDialog();
        }

        private void contextMenuStrip1_Opened(object sender, EventArgs e)
        {
            int LocalDrivingLicenseApplicationID = (int)dataGridView1.CurrentRow.Cells[0].Value;
            int PassedTestCount = (int)dataGridView1.CurrentRow.Cells[5].Value;
            string Status = (string)dataGridView1.CurrentRow.Cells[6].Value;
            if (Status == "Cancelled")
            {
                toolStripMenuItemIssueDrivingLicense.Enabled = false;
                toolStripMenuItemEditApplication.Enabled = false;
                toolStripMenuItemCancelApplication.Enabled = false;
                toolStripMenuItemScheduleTests.Enabled = false;
                toolStripMenuItemShowLicense.Enabled = false;
                toolStripMenuItemDeleteApplication.Enabled = true;
                return;
            }
            if (!clsLocalDrivingLicenseApplication.HasLocalDrivingLicenseStartedTestProcess(LocalDrivingLicenseApplicationID))
            {
                toolStripMenuItemIssueDrivingLicense.Enabled = false;
                toolStripMenuItemShowLicense.Enabled = false;
                toolStripMenuItemEditApplication.Enabled = true;
                toolStripMenuItemScheduleTests.Enabled = true;
                toolStripMenuItemCancelApplication.Enabled = true;
                toolStripMenuItemDeleteApplication.Enabled = true;
                toolStripMenuItemScheduleTests.Enabled = true;
                toolStripMenuItemScheduleVisionTest.Enabled = true;
                toolStripMenuItemShceduleWrittenTest.Enabled = false;
                toolStripMenuItemScheduleStreetTest.Enabled = false;
            }
            else
            {
                // if he has started the testing process he cannot edit the application!
                toolStripMenuItemEditApplication.Enabled = false;

                switch (PassedTestCount)
                {
                    case 0:
                        toolStripMenuItemScheduleVisionTest.Enabled = true;
                        toolStripMenuItemShceduleWrittenTest.Enabled = false;
                        toolStripMenuItemScheduleStreetTest.Enabled = false;
                        return;
                    case 1:
                        toolStripMenuItemScheduleVisionTest.Enabled = false;
                        toolStripMenuItemShceduleWrittenTest.Enabled = true;
                        toolStripMenuItemScheduleStreetTest.Enabled = false;
                        return;
                    case 2:
                        toolStripMenuItemScheduleVisionTest.Enabled = false;
                        toolStripMenuItemShceduleWrittenTest.Enabled = false;
                        toolStripMenuItemScheduleStreetTest.Enabled = true;
                        return;
                    case 3:
                        toolStripMenuItemScheduleTests.Enabled = false;
                        break;
                }


                if (clsLocalDrivingLicenseApplication.DoesLocalDrivingApplicationHaveLicense(LocalDrivingLicenseApplicationID))
                {
                    toolStripMenuItemShowLicense.Enabled = true;
                    toolStripMenuItemIssueDrivingLicense.Enabled = false;
                    toolStripMenuItemScheduleTests.Enabled = false;
                    toolStripMenuItemCancelApplication.Enabled = false;
                    toolStripMenuItemEditApplication.Enabled = false;
                    toolStripMenuItemDeleteApplication.Enabled = false;

                }
                else
                {

                    toolStripMenuItemIssueDrivingLicense.Enabled = true;

                }

            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

