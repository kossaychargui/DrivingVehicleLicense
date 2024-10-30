using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using DVLDDataAccessLayer;

namespace DVLDBusinessLayer
{
    public class clsPerson
    {
        private enum enMode { AddNew = 0, Update = 1};
        private enMode _Mode;

        public int ID { get; set; }
        public string NationalNo { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName {  get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int NationalityCountryID { get; set; }
        public string ImagePath { get; set; }

        public string FullName()
        {
            return FirstName + " " + SecondName + " " + (ThirdName == string.Empty? "": ThirdName + " ")  + LastName;
        }

        private clsPerson(int ID, string NationalNo, string FirstName, string SecondName, string ThirdName, string LastName, DateTime DateOfBirth,
            string Gender, string Address, string Phone, string Email, int NationalityCountryID, string ImagePath)
        {
            this.ID = ID;
            this.NationalNo = NationalNo;
            this.FirstName = FirstName;
            this.SecondName = SecondName;
            this.ThirdName = ThirdName;
            this.LastName = LastName;
            this.DateOfBirth = DateOfBirth;
            this.Gender = Gender;
            this.Address = Address;
            this.Phone = Phone;
            this.Email = Email;
            this.NationalityCountryID = NationalityCountryID;
            this.ImagePath = ImagePath;

            this._Mode = enMode.Update;
        }

        public clsPerson()
        {
            this.ID = -1;
            NationalNo = string.Empty;
            FirstName = string.Empty;
            LastName = string.Empty;
            SecondName = string.Empty;
            ThirdName = string.Empty;
            LastName = LastName;
            this.DateOfBirth = DateTime.Now;
            this.Gender = Gender;
            this.Address = Address;
            this.Phone = Phone;
            this.Email = Email;
            this.NationalityCountryID = NationalityCountryID;
            this.ImagePath = ImagePath;

            this._Mode = enMode.AddNew;
        }

        public static string GetFullName(int PersonID)
        {
            clsPerson person = Find(PersonID);
            return person.FullName();
        }
        public static string GetNationalNo(int PersonID)
        {
            clsPerson clsPerson = Find(PersonID);
            return clsPerson.NationalNo;
        }

        public static clsPerson Find(int ID)
        {
            string NationalNo = "", FirstName = "", SecondName = "", ThirdName = "", LastName = "",Gender = "", Address = ""
                , Phone = "", Email = "", ImagePath = "";
            DateTime DateOfBirth = DateTime.Now;
            int NationalityCountryID = -1;
            if(PersonData.GetPersonInfoByID(ID, ref NationalNo, ref FirstName, ref SecondName, ref ThirdName, ref LastName, ref DateOfBirth,
                ref Gender, ref Address, ref Phone, ref Email, ref NationalityCountryID, ref ImagePath))
            {
                return new clsPerson(ID, NationalNo, FirstName, SecondName, ThirdName, LastName, DateOfBirth, Gender, Address, Phone, Email, NationalityCountryID, ImagePath);
            }
            else
                return null;
        }

        public static clsPerson Find(string NationalNo)
        {
            string FirstName = "", SecondName = "", ThirdName = "", LastName = "", Gender = "", Address = ""
                , Phone = "", Email = "", ImagePath = "";
            DateTime DateOfBirth = DateTime.Now;
            int ID = -1;
            int NationalityCountryID = -1;
            if (PersonData.GetPersonInfoByNationalNo( ref ID,  NationalNo, ref FirstName, ref SecondName, ref ThirdName, ref LastName, ref DateOfBirth,
                ref Gender, ref Address, ref Phone, ref Email, ref NationalityCountryID, ref ImagePath))
            {
                return new clsPerson(ID, NationalNo, FirstName, SecondName, ThirdName, LastName, DateOfBirth, Gender, Address, Phone, Email, NationalityCountryID, ImagePath);
            }
            else
                return null;
        }

        public bool AddNew()
        {
            this.ID = PersonData.AddNewPerson(this.NationalNo, this.FirstName, this.SecondName, this.ThirdName, this.LastName, this.DateOfBirth,
                this.Gender, this.Address, this.Phone, this.Email, this.NationalityCountryID, this.ImagePath);
            return (this.ID != -1);
        }

        public bool Update() {
            return PersonData.UpdatePerson(this.ID, this.NationalNo, this.FirstName, this.SecondName, this.ThirdName, this.LastName, this.DateOfBirth,
                this.Gender, this.Address, this.Phone, this.Email, this.NationalityCountryID, this.ImagePath);
        }

        public bool Save()
        {
            switch (_Mode) {
                case enMode.AddNew:
                    if (AddNew())
                    {
                        this._Mode = enMode.Update;
                        return true;
                    }
                    else
                        return false;
                case enMode.Update:
                    return Update();
            }
            return false;
        }

        public static bool Delete(int ID)
        {
            return PersonData.DeletePerson(ID);
        }

        public static bool isPersonExist(int ID)
        {
            return PersonData.isPersonExist(ID);
        }

        public static bool isPersonExist(string NationalNo)
        {
            return PersonData.isPersonExist(NationalNo);
        }

        public static DataTable GetAllPeople()
        {
            return PersonData.GetAllPeople();
   
        }

    
    }
}
