using DVLDBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Course19DVLDProject.Users
{
    public partial class frmChangeUserPassword : Form
    {
        public frmChangeUserPassword(int UserID)
        {
            InitializeComponent();
            _UserID = UserID;
        }
        private int _UserID = -1;
        private clsUser _CurrentUser = null;
        private ErrorProvider _CurrentPasswordErrorProvider = new ErrorProvider();
        private ErrorProvider _EmptyFieldErrorProvider = new ErrorProvider();
        private void frmChangeUserPassword_Load(object sender, EventArgs e)
        {
            ctrlUserInformation1.FillUserInformation(_UserID);
            _CurrentUser = clsUser.FindUserByID(_UserID);
        }
        private void tbCurrentPassword_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbCurrentPassword.Text))
            {
                _EmptyFieldErrorProvider.SetError(tbCurrentPassword, "This Field Cannot be blank!");
                return;
            }
            else
            {
                _EmptyFieldErrorProvider.SetError(tbCurrentPassword, string.Empty);
            }

            if (tbCurrentPassword.Text != _CurrentUser.Password)
                _CurrentPasswordErrorProvider.SetError(tbCurrentPassword, "This Password Don't match Current Password!");
            else
                _CurrentPasswordErrorProvider.SetError(tbCurrentPassword, string.Empty);
        }

        private void tbNewPassword_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbNewPassword.Text))
            {
                _EmptyFieldErrorProvider.SetError(tbNewPassword, "This Field Cannot be blank!");
               
            }
            else
            {
                _EmptyFieldErrorProvider.SetError(tbNewPassword, string.Empty);
            }
        }

        private void tbConfirmPassword_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbConfirmPassword.Text))
            {
                _EmptyFieldErrorProvider.SetError(tbConfirmPassword, "This Field Cannot be blank!");
                return;
            }
            else
            {
                _EmptyFieldErrorProvider.SetError(tbConfirmPassword, string.Empty);
            }

            if (tbConfirmPassword.Text != tbNewPassword.Text)
                _CurrentPasswordErrorProvider.SetError(tbCurrentPassword, "This Password Don't match New Password!");
            else
                _CurrentPasswordErrorProvider.SetError(tbCurrentPassword, string.Empty);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (IsThereEmptyFields() || IsPasswordsDoNotMatch())
            {
                return;
            }
            _CurrentUser.Password = tbNewPassword.Text;
            if (_CurrentUser.Save())
            {
                MessageBox.Show("Password Changed Successfully:-).", "Successful", MessageBoxButtons.OK);
            }
            else
                MessageBox.Show("Failed To Change The password!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);


        }
        private bool IsThereEmptyFields()
        {
            if(_EmptyFieldErrorProvider.GetError(tbCurrentPassword) != string.Empty || 
                _EmptyFieldErrorProvider.GetError(tbNewPassword) != string.Empty ||
                _EmptyFieldErrorProvider.GetError(tbConfirmPassword) != string.Empty)
            {
                MessageBox.Show("There Are Empty Fields!");
                return true;
            }

            

            return false;
        }
        private bool IsPasswordsDoNotMatch()
        {
            if (_CurrentPasswordErrorProvider.GetError(tbConfirmPassword) != string.Empty)
            {
                MessageBox.Show("Passwords Don't match!");
                return true;
            }

            return false;
        }
    }
}
