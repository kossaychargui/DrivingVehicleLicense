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
    public partial class frmManageTestTypes : Form
    {
        public frmManageTestTypes()
        {
            InitializeComponent();
        }
        private void _LoadTestTypes()
        {
            dataGridView1.DataSource = clsTestType.GetAllTestTypes();
            lblRecordsNumber.Text = dataGridView1.RowCount.ToString();
        }
        private void frmManageTestTypes_Load(object sender, EventArgs e)
        {
            _LoadTestTypes();
        }

        private void toolStripMenuItemEditTestType_Click(object sender, EventArgs e)
        {
            int TestTypeID = (int)dataGridView1.CurrentRow.Cells[0].Value;
            frmUpdateTestType frm = new frmUpdateTestType(TestTypeID);
            frm.ShowDialog();
            _LoadTestTypes();
        }

    }
}
