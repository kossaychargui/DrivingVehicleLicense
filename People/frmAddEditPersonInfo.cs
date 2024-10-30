using Course19DVLDProject.Properties;
using DVLDBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Course19DVLDProject.People
{
    public partial class frmAddEditPersonInfo : Form
    {
        public delegate void DataBackEventHandler(object sender, int PersonID);

        public event DataBackEventHandler DataBack;
        public frmAddEditPersonInfo(int ID)
        {
            InitializeComponent();

            if (ID == -1)
            {
                _ID = -1;
                _Mode = enMode.AddNew;
                this.Text = "Add New Person";
            }
            else
            {
                _ID = ID;
                _Mode = enMode.Update;
                this.Text = "Update User With UserID " + _ID.ToString();
                tbNationalNo.ReadOnly = true;
            }
        }

        private enum enMode { AddNew = 0, Update = 1 };

        private enMode _Mode = enMode.AddNew;
        private int _ID;

        private ErrorProvider _ErrorProvider = new ErrorProvider();
        private bool isImageSet = false;
        private string _ImagePath = string.Empty;
        private void _LoadPersonInfo(int ID)
        {
            clsPerson clsPerson = clsPerson.Find(ID);
            if (clsPerson != null)
            {
                lblPersonID.Text = clsPerson.ID.ToString();
                tbFirstName.Text = clsPerson.FirstName;
                tbLastName.Text = clsPerson.LastName;
                tbSecondName.Text = clsPerson.SecondName;
                tbThirdName.Text = clsPerson.ThirdName;
                tbNationalNo.Text = clsPerson.NationalNo;
                dtpDateOfBirth.Value = clsPerson.DateOfBirth;
                if(clsPerson.Gender == "Male")
                {
                    rbMale.Checked = true;
                    rbFemale.Checked = false;
                }
                else
                {
                    rbMale.Checked = false;
                    rbFemale.Checked = true;
                }
                tbPhone.Text = clsPerson.Phone;
                tbEmail.Text = clsPerson.Email;
                cbCountry.SelectedIndex = clsPerson.NationalityCountryID;
                tbAddress.Text = clsPerson.Address;
                if (clsPerson.ImagePath != string.Empty)
                {
                    pbPersonImage.Image = new Bitmap(clsPerson.ImagePath);
                    isImageSet = true;
                    _ImagePath = clsPerson.ImagePath;
                }
                else
                    isImageSet = false;
            }

            else 
                MessageBox.Show("Cannot Find this Person!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void frmAddEditPersonInfo_Load(object sender, EventArgs e)
        {

            dtpDateOfBirth.MaxDate = new DateTime(DateTime.Now.Year - 18, DateTime.Now.Month, 1);
            cbCountry.DataSource = clsCountry.GetAllCountries();
            cbCountry.DisplayMember = "CountryName";
            cbCountry.ValueMember = "CountryID";
            cbCountry.SelectedIndex = 177; // It's tunisia Country ID in the db
            pbPersonImage.Image = Resources.person_boy;
            pbPersonImage.SizeMode = PictureBoxSizeMode.Zoom;
            if (_Mode == enMode.Update)
            {
                lblFormMode.Text = "Update Person With ID" + _ID.ToString();
                _LoadPersonInfo(_ID);
            }
           
        }

        private void tbNationalNo_TextChanged(object sender, EventArgs e)
        {
            if (clsPerson.isPersonExist(tbNationalNo.Text) && _Mode == enMode.AddNew) 
                _ErrorProvider.SetError(tbNationalNo, "NationalNo is used for another person!");
            else
                _ErrorProvider.SetError(tbNationalNo, string.Empty);
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rbGender_CheckedChanged(object sender, EventArgs e)
        {
            if (!isImageSet)
            {
                if (rbMale.Checked)
                    pbPersonImage.Image = Resources.person_boy;
                else
                    pbPersonImage.Image = Resources.person_girl;
            }
        }

        private void tbEmail_TextChanged(object sender, EventArgs e)
        {
            if (!clsValidation.IsValidEmail(tbEmail.Text) && tbEmail.Text != string.Empty)
            {
                _ErrorProvider.SetError(tbEmail, "enter a valid Email!");
            }
            else
                _ErrorProvider.SetError(tbEmail, string.Empty);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (IsThereAreEmpyFields())
            {
                MessageBox.Show("Please Fill All the Fields");
                return;
            }
            if (_Mode == enMode.Update)
            {
                clsPerson PersonToUpdate = UpdatePersonInfo();
                if (PersonToUpdate.Save())
                {
                    MessageBox.Show("Person Updated Successfully", "Successful Operation", MessageBoxButtons.OK);
                }
                else
                    MessageBox.Show("Failed Operation", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                clsPerson PersonToAdd = _FillPersonToAddInfo();
                if(PersonToAdd.Save())
                {
                    MessageBox.Show("Person Added Successfully", "Successful Operation", MessageBoxButtons.OK);
                    _ID = PersonToAdd.ID;
                }
                else
                    MessageBox.Show("Failed Operation", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            
            this.Close();

        }
        //private string GetImagePath()
        //{
        //    string ImagePathGuid = Guid.NewGuid().ToString();
        //    if (isImageSet)
        //    {
        //        if(_Mode == enMode.AddNew)
        //        {
                    

        //            try
        //            {
        //                if (File.Exists(_ImagePath))
        //                    File.Copy(_ImagePath, $"C:\\DVLD-PeopleImages\\{ImagePathGuid}");
        //                else
        //                    MessageBox.Show("File Source Does not exixt");
        //            }
        //            catch (Exception ex)
        //            {
        //                MessageBox.Show(ex.Message);
        //                return string.Empty;
        //            }   
                    
        //        }
                
        //        else
        //        {
        //            try
        //            {
        //                if (File.Exists(_ImagePath))
        //                    File.Copy(_ImagePath, $"C:\\DVLD-PeopleImages\\{ImagePathGuid}", true);
        //                else
        //                    MessageBox.Show("File Source Does not exixt");
        //            }
        //            catch (Exception ex)
        //            {
        //                MessageBox.Show(ex.Message);
        //                return string.Empty;
        //            }
        //        }
        //        return ImagePathGuid;
        //    }
        //    else
        //        return string.Empty;
        //}
        // well I have shown this function to chat and he gave a hints about clean code and logic
        private string GetImagePath()
        {
            if (!isImageSet)
                return string.Empty;
            if (!File.Exists(_ImagePath))
            {
                MessageBox.Show("File source does not exist");
                return string.Empty;
            }
            string ImagePathGuid = Guid.NewGuid().ToString();
            string TargetDirectory = @"C:\DVLD-PeopleImages";
            string ImageExtension = _ImagePath.Substring(_ImagePath.Length - 4);
            string TargetImagePath = Path.Combine(TargetDirectory, ImagePathGuid + ImageExtension);

         

            

            try
            {
                if (_Mode == enMode.AddNew)
                    File.Copy(_ImagePath, TargetImagePath);
                else
                    File.Copy(_ImagePath, TargetImagePath, true);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

            return TargetImagePath;


        }
        private clsPerson _FillPersonToAddInfo()
        {
            string ImagePath = GetImagePath();
            if(ImagePath != string.Empty)
                File.Copy(pbPersonImage.ImageLocation, "C:\\DVLD-PeopleImages");
            return new clsPerson
            {
                ID = -1,
                NationalNo = tbNationalNo.Text,
                FirstName = tbFirstName.Text,
                SecondName = tbSecondName.Text,
                ThirdName = tbThirdName.Text,
                LastName = tbLastName.Text,
                DateOfBirth = dtpDateOfBirth.Value,
                Gender = rbMale.Checked ? "Male" : "Female",
                Address = tbAddress.Text,
                Phone = tbPhone.Text,
                Email = tbEmail.Text,
                NationalityCountryID = cbCountry.SelectedIndex,
                ImagePath = ImagePath// to edit later


            };
        }
        private clsPerson UpdatePersonInfo()
        {
            
            clsPerson PersonToAdd = clsPerson.Find(_ID);

            PersonToAdd.NationalNo = tbNationalNo.Text;
            PersonToAdd.FirstName = tbFirstName.Text;
            PersonToAdd.SecondName = tbSecondName.Text;
            PersonToAdd.ThirdName = tbThirdName.Text;
            PersonToAdd.LastName = tbLastName.Text;
            PersonToAdd.DateOfBirth = dtpDateOfBirth.Value;
            PersonToAdd.Gender = rbMale.Checked ? "Male" : "Female";
            PersonToAdd.Address = tbAddress.Text;
            PersonToAdd.Phone = tbPhone.Text;
            PersonToAdd.Email = tbEmail.Text;
            PersonToAdd.NationalityCountryID = cbCountry.SelectedIndex;
            PersonToAdd.ImagePath = GetImagePath();
            
            return PersonToAdd;
        }

        private void llSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

            if (openFileDialog.ShowDialog() == DialogResult.OK )
            {
                pbPersonImage.Image = new Bitmap(openFileDialog.FileName);
                pbPersonImage.SizeMode = PictureBoxSizeMode.Zoom;
                isImageSet = true;
                _ImagePath = openFileDialog.FileName;
            }
        }

        private void llRemoveImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            isImageSet = false;
            _ImagePath = string.Empty;
            rbGender_CheckedChanged(sender, e);
        }

        private void frmAddEditPersonInfo_FormClosed(object sender, FormClosedEventArgs e)
        {
            DataBack?.Invoke(this, _ID);
        }

        private bool IsThereAreEmpyFields()
        {
            if (string.IsNullOrEmpty(tbFirstName.Text) || string.IsNullOrEmpty(tbSecondName.Text) || string.IsNullOrEmpty(tbLastName.Text))
                return true;
            if(string.IsNullOrEmpty(tbNationalNo.Text) || string.IsNullOrEmpty(tbAddress.Text) || string.IsNullOrEmpty(tbPhone.Text)) return true;

            return false ;
        }
    }
}
