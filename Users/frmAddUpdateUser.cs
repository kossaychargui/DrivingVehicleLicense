using Course19DVLDProject.Controls;
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

namespace Course19DVLDProject.Users
{
    public partial class frmAddUpdateUser : Form
    {
        public frmAddUpdateUser(int UserID)
        {
            InitializeComponent();
            if (UserID != -1)
            {
                _UserID = UserID;
                _Mode = enMode.Update;
                this.Text = "Update User";
                lblFormMode.Text = "Update User";
            }
            else
            {
                _Mode = enMode.AddNew;
                this.Text = "Add New User";
                lblFormMode.Text = "Add New User";
            }
        }
        private int _UserID = -1;
        private enum enMode { AddNew, Update };
        private enMode _Mode;
        private ErrorProvider _ErrorProvider = new ErrorProvider();

        private int _PersonID = -1;

        private void btnNext_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabControl1.TabPages[1];
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tbUserName_TextChanged_1(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (string.IsNullOrEmpty(tb.Text))
                _EmptyFieldErrorProvider.SetError(tb, "This Field Cannot be blank!");
            else
                _EmptyFieldErrorProvider.SetError(tb, string.Empty);

            if (tbPassword.Text != tbConfirmPassword.Text)
                _ErrorProvider.SetError(tbConfirmPassword, "Passwords don't much!");
            else
                _ErrorProvider.SetError(tbConfirmPassword, string.Empty);


            if (clsUser.IsUserNameExist(tbUserName.Text))
                _ErrorProvider.SetError(tbUserName, "UserName Already exists!");
            else
                _ErrorProvider.SetError(tbUserName, string.Empty);

        }

        private ErrorProvider _EmptyFieldErrorProvider = new ErrorProvider();


        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            
            if (tabControl1.SelectedTab == tabControl1.TabPages[1])
            {
                if (ctrlFilterPerson1.PersonID == -1)
                {
                    MessageBox.Show("Please select a person First!");
                    tabControl1.SelectedTab = tabControl1.TabPages[0];
                    return;
                }
                else if (clsUser.IsPersonLinkedWithUser(ctrlFilterPerson1.PersonID) && _Mode == enMode.AddNew)
                {
                    tabControl1.SelectedTab = tabControl1.TabPages[0];
                    MessageBox.Show("This Person Is Already Linked with a user!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

            }
        }

        private bool _IsThereEmptyFields()
        {
            if(ctrlFilterPerson1.PersonID == -1)
            {
                MessageBox.Show("Please Choose a person For the User");
                return true;
            }
            if(string.IsNullOrEmpty(tbUserName.Text) || string.IsNullOrEmpty(tbPassword.Text) || string.IsNullOrEmpty(tbConfirmPassword.Text))
            {
                MessageBox.Show("Please Fill Empty Fields(UserName/Password)!");
                return true;
            }
            return false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_IsThereEmptyFields())
                return;
            
            if (_Mode == enMode.AddNew)
            {
                clsUser UserToAdd = _FillNewUserToAddInfo();
                if (UserToAdd.Save())
                {
                    MessageBox.Show("User Added Successfully", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _UserID = UserToAdd.ID;
                    _Mode = enMode.Update;
                    this.Text = "Update User";
                    lblFormMode.Text = "Update User";

                }
                else
                    MessageBox.Show("Failed To Add User", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                clsUser UserToUpdate = clsUser.FindUserByID(_UserID);
                _FillUserToUpdateInfo(ref UserToUpdate);
                if (UserToUpdate.Save())
                {
                    MessageBox.Show("User Updated Successfully", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Failed To Update User", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmAddUpdateUser_Load(object sender, EventArgs e)
        {
            if (_Mode == enMode.Update)
            {
                _LoadUserToUpdateInfo();
            }

        }
        private void _LoadUserToUpdateInfo()
        {
            clsUser User = clsUser.FindUserByID(_UserID);
            if (User != null)
            {
                ctrlFilterPerson1.FillPersonData(User.PersonID);
                tbUserName.Text = User.UserName;
                tbPassword.Text = User.Password;
                tbConfirmPassword.Text = User.Password;
                cbIsActive.Checked = User.isActive;
            }
            else
            {
                if (MessageBox.Show("Cannot Load User info!") == DialogResult.OK)
                    this.Close();
            }
        }

        private clsUser _FillNewUserToAddInfo()
        {

            _PersonID = ctrlFilterPerson1.PersonID;
            return new clsUser
            {
                ID = _UserID,
                PersonID = _PersonID,
                UserName = tbUserName.Text.Trim(),
                Password = tbPassword.Text.Trim(),
                isActive = cbIsActive.Checked,
            };
        }

        private void _FillUserToUpdateInfo(ref clsUser User)
        {
            User.UserName = tbUserName.Text.Trim();
            User.Password = tbPassword.Text.Trim();
            User.isActive = cbIsActive.Checked;
        }

        
    }
}
