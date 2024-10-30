using DVLDBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Course19DVLDProject.People
{
    public partial class frmManagePeople : Form
    {
        public frmManagePeople()
        {
            InitializeComponent();
        }

        
        private DataView dv ;
     
        private void frmManagePeople_Load(object sender, EventArgs e)
        {
            DataTable People = clsPerson.GetAllPeople();
            dv = new DataView(People);
            lblNumberOfRecords.Text = dv.Count.ToString(); ;
            dataGridView1.DataSource = dv;
            cbFilterBy.SelectedIndex = 0;
            tbFilterBy.Visible = false;
        }

    
        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dv == null || dv.Count == 0)
            {
                MessageBox.Show("No data available for sorting.");
                return;
            }
            if(cbFilterBy.SelectedIndex == 0)
            {
                tbFilterBy.Visible = false;
                RefrechDataGridView();
                return;
            }
            tbFilterBy.Visible = true;

            switch (cbFilterBy.SelectedIndex)
            {

                case 1:
                    dv.Sort = "PersonID desc";
              
                    break;
                case 2:
                    dv.Sort = "NationalNo desc";

                    break;
                case 3:
                    dv.Sort = "FirstName desc";
                  
                    break;
                case 4:
                    dv.Sort = "SecondName desc";
                   
                    break;
                case 5:
                    dv.Sort = "ThirdName desc";
                   
                    break;
                case 6:
                    dv.Sort = "LastName desc";
                    
                    break;
                case 7:
                    dv.Sort = "Nationality desc";
               
                    break;
                case 8:
                    dv.Sort = "Gendor desc";
              
                    break;
                case 9:
                    dv.Sort = "Phone desc";
                    break;
                default:
                    dv.Sort = "Email desc";
                    break;
            }
            dataGridView1.DataSource = dv;
        }

        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            frmAddEditPersonInfo frm = new frmAddEditPersonInfo(-1);// adding new person 
            frm.ShowDialog();
            RefrechDataGridView();
        }
        private void RefrechDataGridView()
        {
            dv = new DataView(clsPerson.GetAllPeople());
            dataGridView1.DataSource = dv;
        }

        private void toolStripMenuShowDetails_Click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["PersonID"].Value);
            frmPersonDetails frm = new frmPersonDetails(ID);
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();

        }

        private void toolStripMenuAddNewPerson_Click(object sender, EventArgs e)
        {
            frmAddEditPersonInfo frm = new frmAddEditPersonInfo(-1);
            frm.ShowDialog();
            RefrechDataGridView();
        }

        private void toolStripMenuEditPerson_Click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["PersonID"].Value);
            frmAddEditPersonInfo frm = new frmAddEditPersonInfo(ID);
            frm.ShowDialog();
            RefrechDataGridView();
        }

        private void toolStripMenuDeletePerson_Click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["PersonID"].Value);

            if (MessageBox.Show("Are You sure You want to delete this person?", "Check", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                if (clsPerson.Delete(ID))
                    MessageBox.Show("Person Delted Successfully", "Information", MessageBoxButtons.OK);
                else
                    MessageBox.Show("Failed To delte person", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            RefrechDataGridView();
        }

        private void toolStripMenuSendEmail_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Functionality is not implemented Yet", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void toolStripMenuPhoneCall_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Functionality is not implemented Yet", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void tbFilterBy_TextChanged(object sender, EventArgs e)
        {
            if (cbFilterBy.SelectedItem == null || string.IsNullOrEmpty(tbFilterBy.Text))
                return;

            string SelectedItem = cbFilterBy.SelectedItem.ToString();
            if(SelectedItem == "PersonID")
            {
                if (int.TryParse(tbFilterBy.Text.Trim(), out int id))
                    dv.RowFilter = $"{SelectedItem} = {id}";
            }
            else
            {
                dv.RowFilter = $"{SelectedItem} LIKE '%{tbFilterBy.Text}%'";
            }
            dataGridView1.DataSource = dv;

        }

        private void tbFilterBy_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (cbFilterBy.SelectedIndex)
            {

                case 1:
                    AcceptOnlyDigits(e);

                    break;

                case 3:
                    AcceptOnlyLetters(e);

                    break;
                case 4:
                    AcceptOnlyLetters(e);

                    break;
                case 5:
                    AcceptOnlyLetters(e);

                    break;
                case 6:
                    AcceptOnlyLetters(e);

                    break;
                case 7:
                    AcceptOnlyLetters(e);

                    break;
                case 8:
                    AcceptOnlyLetters(e);
                    break;

            }

        }
        private void AcceptOnlyLetters(KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }
        private void AcceptOnlyDigits(KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }
    }
    }

 

