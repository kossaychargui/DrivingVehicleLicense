using Course19DVLDProject.People;
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

namespace Course19DVLDProject.Controls
{
    public partial class ctrlFilterPerson : UserControl
    {
        public ctrlFilterPerson()
        {
            InitializeComponent();
        }

        private void tbFilterBy_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.SelectedIndex == 1) {
                if(!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                    e.Handled = true;
            }
            
        }

        private void ctrlFilterPerson_Load(object sender, EventArgs e)
        {
            cbFilterBy.SelectedIndex = 0;
        }

        private void btnSearchForPerson_Click(object sender, EventArgs e)
        {
            clsPerson PersonToLookFor = null;
            if (cbFilterBy.SelectedIndex == 0)
            {
                PersonToLookFor = clsPerson.Find(tbFilterBy.Text.Trim());
            }
            else
            {   if(int.TryParse(tbFilterBy.Text, out int id))
                    PersonToLookFor = clsPerson.Find(id);
            }

            if (PersonToLookFor == null)
            {
                MessageBox.Show("Invalid Person", "Cannot Find Person!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            cntrlPersonInformation1.LoadPersonInfo(PersonToLookFor.ID);
            this.PersonID = PersonToLookFor.ID;

        }

        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            frmAddEditPersonInfo frm = new frmAddEditPersonInfo(-1);
            frm.DataBack += Frm_DataBack;
            frm.ShowDialog();
        }

        private void Frm_DataBack(object sender, int PersonID)
        {
            this.PersonID = PersonID;
            if(this.PersonID != -1)
            {
                cntrlPersonInformation1.LoadPersonInfo(this.PersonID);
                cbFilterBy.SelectedIndex = 1;
                tbFilterBy.Text = this.PersonID.ToString();
            }
        }
        public int PersonID = -1;

        public void FillPersonData(int PersonID)
        {
            this.PersonID = PersonID;
            cntrlPersonInformation1.LoadPersonInfo(PersonID);
            tbFilterBy.Text = PersonID.ToString();
            cbFilterBy.SelectedIndex = 1;
            groupBox1.Enabled = false;
            
        }
    }
}
