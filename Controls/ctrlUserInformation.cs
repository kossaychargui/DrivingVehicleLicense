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
    public partial class ctrlUserInformation : UserControl
    {
        public ctrlUserInformation()
        {
            InitializeComponent();
        }

      
        public void FillUserInformation(int UserID)
        {
            _FillUserInformation(UserID);
        }

        private void _FillUserInformation(int UserID) {
            clsUser User = clsUser.FindUserByID(UserID);
            if (User != null) {
                lblUserID.Text = User.ID.ToString();
                lblUserName.Text = User.UserName;
                lblIsActive.Text = User.isActive?"Yes":"No";
                _FillPersonInformation(User.PersonID);
            }
        }
        private void _FillPersonInformation(int PersonID) { 
            cntrlPersonInformation1.LoadPersonInfo(PersonID);
        }



    }
}
