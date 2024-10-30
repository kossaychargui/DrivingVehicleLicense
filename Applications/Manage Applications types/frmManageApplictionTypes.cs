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
    public partial class frmManageApplictionTypes : Form
    {
        public frmManageApplictionTypes()
        {
            InitializeComponent();
        }

        private void _GetApplicationTypes()
        {
            dataGridView1.DataSource = clsApplicationTypes.GetAllApplicationTypes();
            lblRecordsNumber.Text = dataGridView1.RowCount.ToString();
        }

        private void frmManageApplictionTypes_Load(object sender, EventArgs e)
        {
            _GetApplicationTypes();
        }

        private void toolStripMenuItemEditApplicationTypes_Click(object sender, EventArgs e)
        {
            int ApplicationID = (int)dataGridView1.CurrentRow.Cells[0].Value;
            frmUpdateApplicationType frm = new frmUpdateApplicationType(ApplicationID);
            frm.ShowDialog();
            _GetApplicationTypes();


        }
    }
}
