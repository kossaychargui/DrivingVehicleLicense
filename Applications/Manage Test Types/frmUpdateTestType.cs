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

namespace Course19DVLDProject.Applications.Manage_Test_Types
{
    public partial class frmUpdateTestType : Form
    {
        public frmUpdateTestType(int TestTypeId)
        {
            InitializeComponent();
            _TestTypeId = TestTypeId;
        }

        private clsTestType _CurrentTestType = null;
        private int _TestTypeId = -1;
        private void frmUpdateTestType_Load(object sender, EventArgs e)
        {
            _CurrentTestType = clsTestType.GetTestTypeByID(_TestTypeId);
            _LoadTestTypeInfo();
        }
        private void _LoadTestTypeInfo()
        {
            if (_CurrentTestType != null)
            {
                lblID.Text = _CurrentTestType.ID.ToString();
                tbTitle.Text = _CurrentTestType.Title;
                tbDescription.Text = _CurrentTestType.Description;
                tbFees.Text = _CurrentTestType.Fees.ToString();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            if (IsThereEmptyFields() || !IsFeesAccepted())
                return;

            if(_CurrentTestType.UpdateTestType(tbTitle.Text, tbDescription.Text, Convert.ToDecimal(tbFees.Text)))
            {
                MessageBox.Show("Test Type Update Successfully", "Successful", MessageBoxButtons.OK);
            }
            else
                MessageBox.Show("Failed To Update Test", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private ErrorProvider _EmptyFieldErrorProvider = new ErrorProvider();
        private bool IsThereEmptyFields()
        {
            if (_EmptyFieldErrorProvider.GetError(tbTitle) != string.Empty
                || _EmptyFieldErrorProvider.GetError(tbFees) != string.Empty 
                || _EmptyFieldErrorProvider.GetError(tbDescription) != string.Empty)
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

        private void tbTitle_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbTitle.Text))
                _EmptyFieldErrorProvider.SetError(tbTitle, "tile Cannot be empty");
            else
                _EmptyFieldErrorProvider.SetError(tbTitle, string.Empty);
        }

        private void tbDescription_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbDescription.Text))
                _EmptyFieldErrorProvider.SetError(tbDescription, "tile Cannot be empty");
            else
                _EmptyFieldErrorProvider.SetError(tbDescription, string.Empty);
        }

        private void tbFees_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbFees.Text))
                _EmptyFieldErrorProvider.SetError(tbFees, "tile Cannot be empty");
            else
                _EmptyFieldErrorProvider.SetError(tbFees, string.Empty);
        }
    }
}
