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
using System.IO;
using Course19DVLDProject.Properties;
using Course19DVLDProject.People;

namespace Course19DVLDProject.Controls
{
    public partial class cntrlPersonInformation : UserControl
    {
        public cntrlPersonInformation()
        {

            InitializeComponent();

        }


        private string _NationalNo = string.Empty;
        private int _ID = -1;
        clsPerson CurrentPerson = null;

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAddEditPersonInfo frm = new frmAddEditPersonInfo(_ID);
            frm.FormClosing += new FormClosingEventHandler(frmAddEditPersonInfo_FormClosing);
            frm.ShowDialog();


        }
        private void frmAddEditPersonInfo_FormClosing(object sender, FormClosingEventArgs e)
        {
            _LoadPersonInformation();
        }
    
        public void LoadPersonInfo(int ID)
        {
            _ID = ID;
            _NationalNo = string.Empty;
            _LoadPersonInformation();
        }
        public void LoadPersonInfo(string NationalNo)
        {
            _NationalNo = NationalNo;
            _LoadPersonInformation();
        }

        private void _LoadPersonInformation()
        {
            clsPerson CurrentPerson = _NationalNo == string.Empty ? clsPerson.Find(_ID) : clsPerson.Find(_NationalNo);
            if (CurrentPerson != null)
            {
                lblPersonID.Text = CurrentPerson.ID.ToString();
                lblName.Text = CurrentPerson.FullName();
                lblNationalNo.Text = CurrentPerson.NationalNo;
                lblGender.Text = CurrentPerson.Gender;
                lblEmail.Text = CurrentPerson.Email;
                lblAddress.Text = CurrentPerson.Address;
                lblPhone.Text = CurrentPerson.Phone;
                lblCountry.Text = clsCountry.GetCountryName(CurrentPerson.NationalityCountryID);
                lblDateOfBirth.Text = CurrentPerson.DateOfBirth.ToString();
                if (File.Exists(CurrentPerson.ImagePath))
                {
                    pbPersonImage.Image = new Bitmap(CurrentPerson.ImagePath);
                 
                }
                else
                {
                    if (CurrentPerson.Gender == "Male")
                        pbPersonImage.Image = Resources.person_boy;
                    else
                        pbPersonImage.Image = Resources.person_girl;
                }
                pbPersonImage.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }


    }
}
