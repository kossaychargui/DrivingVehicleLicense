using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Course19DVLDProject.People
{
    public partial class frmPersonDetails : Form
    {
        public frmPersonDetails(int PersonID)
        {
            InitializeComponent();
            _ID = PersonID;
        
        }
        public frmPersonDetails(string NationalNo)
        {
            InitializeComponent();
            _NationalNo = NationalNo;
        }
        private int _ID = -1;
        private string _NationalNo = string.Empty;
        private void frmPersonDetails_Load(object sender, EventArgs e)
        {
            if (_NationalNo == string.Empty)
            {
                cntrlPersonInformation1.LoadPersonInfo(_ID);
            }
            else
                cntrlPersonInformation1.LoadPersonInfo(_NationalNo);
        }
    }
}
