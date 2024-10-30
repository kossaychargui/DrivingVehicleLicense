using DVLDBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Course19DVLDProject.Users
{
    public partial class frmManageUsers : Form
    {
        public frmManageUsers()
        {
            InitializeComponent();
        }

        DataView dv;
        private void frmManageUsers_Load(object sender, EventArgs e)
        {
            _LoadUsers();
            cbFilterBy.SelectedIndex = 0;
            cbIsActive.SelectedIndex = 0;
            lblRecordsNumber.Text = dv.Count.ToString();


        }
        private void _LoadUsers()
        {
            DataTable Users = clsUser.GetAllUsers();
            if (Users != null)
            {
                dv = new DataView(Users);
                dataGridView1.DataSource = dv;
            }
        }

        private void tbFilterBy_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbFilterBy.Text))
                return;

            string SelectedFilter = cbFilterBy.SelectedItem.ToString();
            if(cbFilterBy.SelectedIndex == 1)
            {
                if (int.TryParse(tbFilterBy.Text.Trim(), out int id))
                {
                    dv.RowFilter = $"{SelectedFilter} = {id}";
                }
                else
                    dv.RowFilter = string.Empty;
                
            }
            else
            {
                dv.RowFilter = $"{SelectedFilter} LIKE '%{tbFilterBy.Text.Trim()}%'";
            }
             
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            dv.RowFilter = string.Empty;
            if (cbFilterBy.SelectedIndex == 0)
            {
                tbFilterBy.Visible = false;
                cbIsActive.Visible = false;
                return;
            }

            if (cbFilterBy.SelectedIndex == 4)
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

        private void tbFilterBy_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.SelectedIndex == 3)// when the user selects the filter fullname it should only search by letters
            {
                if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
            else if (cbFilterBy.SelectedIndex == 1)// in case of search by id (accepts only numbers)
            {
                {
                    if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                    { e.Handled = true; }
                }
            }
        }

        private void cbIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cbIsActive.SelectedIndex == 1)
            {
                dv.RowFilter = $"{dv.Table.Columns["IsActive"]} = true";
            }
            else if (cbIsActive.SelectedIndex == 2)
            {
                dv.RowFilter = $"{dv.Table.Columns["IsActive"]} = false";
            }
            else
                dv.RowFilter = string.Empty;
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            frmAddUpdateUser frm = new frmAddUpdateUser(-1);
            frm.ShowDialog();
            _LoadUsers();
        }

        private void toolStripMenuItemShowDetails_Click(object sender, EventArgs e)
        {
            int UserID = (int)dataGridView1.CurrentRow.Cells[0].Value;
            frmUserDetails frm = new frmUserDetails(UserID);
            frm.ShowDialog();
            _LoadUsers();
        }

        private void toolStripMenuItemAddNewUser_Click(object sender, EventArgs e)
        {
            btnAddUser_Click(sender, e);
            _LoadUsers();
        }

        private void toolStripMenuItemEditUser_Click(object sender, EventArgs e)
        {
            int UserID = (int) dataGridView1.CurrentRow.Cells[0].Value;
            frmAddUpdateUser frm = new frmAddUpdateUser(UserID);
            frm.ShowDialog();
            _LoadUsers();
        }

        private void toolStripMenuItemDeleteUser_Click(object sender, EventArgs e)
        {
            int UserID = (int)dataGridView1.CurrentRow.Cells[0].Value;
            if (MessageBox.Show($"Are you sure you want to delete this User With UserID = {UserID} ?", "Check", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                if (clsUser.DeleteUser(UserID))
                {
                    MessageBox.Show("User Deleted Successfully");
                    _LoadUsers();
                }
                else
                {
                    MessageBox.Show("Cannot Delete User due data connected To it");
                }
            }
        }

        private void toolStripMenuItemSendEmail_Click(object sender, EventArgs e)
        {
            MessageBox.Show("this Functionality is not Implemented Yet");
        }

        private void toolStripMenuItemPhoneCall_Click(object sender, EventArgs e)
        {
            MessageBox.Show("this Functionality is not Implemented Yet");
        }

        private void toolStripMenuItemChangePassword_Click(object sender, EventArgs e)
        {
            int UserID = (int)dataGridView1.CurrentRow.Cells[0].Value;
            frmChangeUserPassword frm = new frmChangeUserPassword(UserID);
            frm.ShowDialog();
        }
    }
}
