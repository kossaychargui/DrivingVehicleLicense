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

namespace Course19DVLDProject.Applications.Manage_Applications_types
{
    public partial class frmUpdateApplicationType : Form
    {
        public frmUpdateApplicationType(int ApplicationTypeID)
        {
            InitializeComponent();
            _ID = ApplicationTypeID;
        }

        private int _ID = -1;
        private clsApplicationTypes _CurrentApplicationType = null;
        private void frmUpdateApplicationType_Load(object sender, EventArgs e)
        {
            btnClose.Focus();
            _CurrentApplicationType = clsApplicationTypes.GetApplicationByID(_ID);
            FillApplicationInfo();
        }
        private void FillApplicationInfo()
        {
            if (_CurrentApplicationType != null)
            {
                lblID.Text = _CurrentApplicationType.ID.ToString();
                tbTitle.Text = _CurrentApplicationType.Title;
                tbFees.Text = _CurrentApplicationType.Fees.ToString();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private ErrorProvider _EmptyFieldErrorProvider = new ErrorProvider();

        private void tbTitle_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbTitle.Text))
                _EmptyFieldErrorProvider.SetError(tbTitle, "This Field Cannot be empty!");
            else
                _EmptyFieldErrorProvider.SetError(tbTitle, string.Empty);

        }

        private void tbFees_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbFees.Text))
                _EmptyFieldErrorProvider.SetError(tbFees, "This Field Cannot be empty!");
            else
                _EmptyFieldErrorProvider.SetError(tbFees, string.Empty);
        }
        private bool IsThereEmptyFields()
        {
            if(_EmptyFieldErrorProvider.GetError(tbTitle) != string.Empty 
                || _EmptyFieldErrorProvider.GetError(tbFees) != string.Empty)
            {
                MessageBox.Show("Please Fill Empty filed before saving!");
                return true;
            }
            return false;
        }
        private bool IsFeesAccepted()
        {
            if (Convert.ToDecimal(tbFees.Text) <= 0)
            {
                MessageBox.Show("Fees Should be > 0");
                return false;
            }
            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (IsThereEmptyFields() || !IsFeesAccepted())
                return;

            if(_CurrentApplicationType.UpdateApplicationType(tbTitle.Text, Convert.ToDecimal(tbFees.Text)))
            {
                MessageBox.Show("Application Type Update Successfully", "Successful Operation", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Failed To Update Application Type", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
         
        }
    }
}
