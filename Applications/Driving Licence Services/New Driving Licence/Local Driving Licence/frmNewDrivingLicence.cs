using Course19DVLDProject.Controls;
using DVLDBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DVLDBusinessLayer.clsApplication;
using static System.Net.Mime.MediaTypeNames;

namespace Course19DVLDProject.Applications.Driving_Licence_Services.New_Driving_Licence.Local_Driving_Licence
{
    public partial class frmNewDrivingLicenseApplication : Form
    {

        
        public frmNewDrivingLicenseApplication(int ApplicationID)
        {
            InitializeComponent();

            if (ApplicationID != -1)
            {
                _ApplicationID = ApplicationID;
                _Mode = enMode.Update;
                Text = "Update Driving License Application";
                lblFormMode.Text = "Update Driving License Application";
            }
            else
                _Mode = enMode.AddNew; 
        }
        private enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode = enMode.AddNew;
        private int _ApplicationID = -1;
        private clsApplication _CurrentApplication = null;
        private clsLocalDrivingLicenseApplication _CurrentLocalDrivingLicenseApplication = null;

        private void btnNext_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(1);
        }

        private void frmNewDrivingLicenseApplication_Load(object sender, EventArgs e)
        {
            cbLicenseClasses.DataSource = clsLicenseClass.GetAllLicenseClasses();
            cbLicenseClasses.DisplayMember = "ClassName";
            cbLicenseClasses.ValueMember = "LicenseClassID";

            if (_Mode == enMode.AddNew)
            {
                lblApplicationDate.Text = DateTime.Now.ToString("d");
                lblCreatedBy.Text = clsGlobalSettings.LoggedInUser.UserName;
                cbLicenseClasses.SelectedIndex = 2;

            }
            else
            {
                _LoadApplicationInfo();
                if (clsLocalDrivingLicenseApplication.HasLocalDrivingLicenseStartedTestProcess(_ApplicationID))
                {
                    ctrlFilterPerson1.Enabled = false;
                    cbLicenseClasses.Enabled = false;
                    btnSave.Enabled = false;
                    lblNote.Visible = true;

                }

            }
            
    
        }
        private void _LoadApplicationInfo()
        {
            _CurrentLocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.FindByID(_ApplicationID);
            _CurrentApplication = clsApplication.FindByID(_CurrentLocalDrivingLicenseApplication.ApplicationID);
            if (_CurrentLocalDrivingLicenseApplication == null || _CurrentApplication == null)
            {
                MessageBox.Show("Cannot Load LocalDrivingApplication/Application Details!");
            }
            ctrlFilterPerson1.FillPersonData(_CurrentApplication.ApplicantPersonID);
            lblApplicationID.Text = _CurrentLocalDrivingLicenseApplication.ApplicationID.ToString();
            lblApplicationDate.Text = _CurrentApplication.ApplicationDate.ToString();
            cbLicenseClasses.SelectedIndex = _CurrentLocalDrivingLicenseApplication.LicenseClassID - 1;
            lblApplicationFees.Text = _CurrentApplication.PaidFees.ToString();
            lblCreatedBy.Text = _CurrentApplication.CreatedByUserID.ToString();
        }

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if(tabControl1.SelectedTab == tabControl1.TabPages[1])
            {
                if(ctrlFilterPerson1.PersonID == -1)
                {
                    MessageBox.Show("Please Select A Person First!");
                    tabControl1.SelectedIndex = 0;
                    return;
                }

            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int appid = 0;
            if ((appid = clsLocalDrivingLicenseApplication.IsPersonAppliedForThisClass(ctrlFilterPerson1.PersonID, cbLicenseClasses.SelectedIndex + 1)) != -1)
            {
                MessageBox.Show($"This Person Already Applied for this class (application id = {appid})");
                return;
            }if (_Mode == enMode.AddNew)
            {
                _CurrentApplication = _FillCurrentApplication();


                if (_CurrentApplication.Save())
                {
                    _CurrentLocalDrivingLicenseApplication = _FillCurrentLocalDrivingLicenseApplication();
                    if (_CurrentLocalDrivingLicenseApplication.Save())
                    {
                       
                         MessageBox.Show("Application Saved Successfully", "Successful Operation", MessageBoxButtons.OK);
                         _Mode = enMode.Update;
                       
                    }
                }
                else
                    MessageBox.Show("Couldn't Save The Application", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); ;

            }
            else
            {
                _CurrentLocalDrivingLicenseApplication.LicenseClassID = cbLicenseClasses.SelectedIndex + 1;
                if (_CurrentLocalDrivingLicenseApplication.Save())
                {
                    MessageBox.Show("Application Updated successuflly", "Ok", MessageBoxButtons.OK);

                }
                else
                    MessageBox.Show("Failed To update application", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error ); 
            }
        }
        private clsApplication _FillCurrentApplication()
        {
            
            return new clsApplication
            {
                ApplicantPersonID = ctrlFilterPerson1.PersonID,
                ApplicationDate = DateTime.Now.Date,
                ApplicationTypeID = (int)clsApplicationTypes.enApplicationTypes.NewLocalDrivingLicense,
                ApplicationStatus = (int)clsApplication.enApplicationStatus.New,
                LastStatusDate = DateTime.Now.Date,
                PaidFees = clsApplicationTypes.GetApplicationFeesByID((int)clsApplicationTypes.enApplicationTypes.NewLocalDrivingLicense),
                CreatedByUserID = clsGlobalSettings.LoggedInUser.ID


            };
        }

        private clsLocalDrivingLicenseApplication _FillCurrentLocalDrivingLicenseApplication()
        {

            return new clsLocalDrivingLicenseApplication
            {
                ApplicationID = _CurrentApplication.ApplicationID,
                LicenseClassID = cbLicenseClasses.SelectedIndex +1
            };
        }
    }
}
