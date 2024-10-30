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

namespace Course19DVLDProject.Drivers
{
    public partial class frmManagerDrivers : Form
    {
        public frmManagerDrivers()
        {
            InitializeComponent();
        }

       private  DataView dv = null;
        private void _LoadDrivers()
        {
            dv = new DataView(clsDriver.GetDrivers());
            dataGridView1.DataSource = dv;
            lblNumberOfRecords.Text = dv.Count.ToString ();
        }
        private void frmManagerDrivers_Load(object sender, EventArgs e)
        {
            cbFilterBy.SelectedIndex = 0;
            _LoadDrivers();
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbFilterBy.Visible = cbFilterBy.SelectedIndex == 0 ? false : true;
        }

        private void tbFilterBy_TextChanged(object sender, EventArgs e)
        {
            if(cbFilterBy.SelectedIndex == 1 || cbFilterBy.SelectedIndex == 2)
            {
                if(int.TryParse(tbFilterBy.Text, out int id))
                {
                    dv.RowFilter = $"{cbFilterBy.SelectedItem} = {id}";
                }   
            }
            else
            {
                dv.RowFilter = $"{cbFilterBy.SelectedItem} LIKE '%{tbFilterBy.Text.Trim()}%'";
            }
        }


        private void tbFilterBy_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (cbFilterBy.SelectedIndex)
            {
                case 0:
                    return;
                case 1:
                    if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                    {
                        e.Handled = true;
                    }
                    break;
                case 2:
                    if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                    {
                        e.Handled = true;
                    }
                    break;
                case 4:
                    if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
                    {
                        e.Handled = true;
                    }
                    break;
            }

            }
    }
}
