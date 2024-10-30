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
    public partial class frmShowLocalDrivingLicenseApplicationDetails : Form
    {
        public frmShowLocalDrivingLicenseApplicationDetails(int LocalDrivingLicenseApplicationID)
        {
            InitializeComponent();
            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
        }
        private int _LocalDrivingLicenseApplicationID = -1;
        private void frmShowLocalDrivingLicenseApplicationDetails_Load(object sender, EventArgs e)
        {
            ctrlDrivingLicenseApplicationInfo1.FillApplicationInfo(_LocalDrivingLicenseApplicationID);
        }
    }
}
