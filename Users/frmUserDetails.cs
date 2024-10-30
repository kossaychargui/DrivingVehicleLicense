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
    public partial class frmUserDetails : Form
    {
        public frmUserDetails(int userID)
        {
            InitializeComponent();
            _UserID = userID;
        }
        private int _UserID = -1;
        private void frmUserDetails_Load(object sender, EventArgs e)
        {
            ctrlUserInformation1.FillUserInformation(_UserID);
        }
    }
}
