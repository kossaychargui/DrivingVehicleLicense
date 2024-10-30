using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using DVLDDataAccessLayer;
using System.Data;
namespace DVLDBusinessLayer
{
    public class clsUser
    {
        public int ID { get; set; }

        public int PersonID { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public bool isActive { get; set; }

        public enum enMode { AddNew = 0, Update = 1 };

        public enMode Mode;
        public clsUser()
        {

            ID = -1;
            PersonID = -1;
            UserName = string.Empty;
            Password = string.Empty;
            isActive = false;

            Mode = enMode.AddNew;
        }

        private clsUser(int ID, int PersonID, string UserName, string Password, bool isActive)
        {
            this.ID = ID;
            this.PersonID = PersonID;
            this.UserName = UserName;
            this.Password = Password;
            this.isActive = isActive;

            Mode = enMode.Update;
        }

        public static clsUser FindUserByID(int ID)
        {
            int PersonID = -1;
            string UserName = string.Empty, Password = string.Empty;
            bool isActive = false;
            if (UserData.FindUserByID(ID, ref PersonID, ref UserName, ref Password, ref isActive))
                return new clsUser(ID, PersonID, UserName, Password, isActive);

            return null;
        }

        public static clsUser FindUserByCredentials(string UserName, string Password)
        {
            int PersonID = -1, ID = -1;
            bool isActive = false;
            if (UserData.FindUserByCredentials(ref ID, ref PersonID, UserName, Password, ref isActive))
                return new clsUser(ID, PersonID, UserName, Password, isActive);

            return null;
        }

        public static string GetUserName(int ID)
        {
            clsUser clsUser = FindUserByID(ID);
            return clsUser.UserName;
        }
        private bool _AddNew()
        {
            this.ID = UserData.AddNewUser(this.PersonID, this.UserName, this.Password, this.isActive);
            return this.ID != -1;
        }

        private bool _UpdateUser()
        {
            return UserData.UpdateUser(this.ID, this.UserName, this.Password, this.isActive);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNew())
                    {
                        this.Mode = enMode.Update;
                        return true;
                    }
                    else
                        return false;

                case enMode.Update:
                    return _UpdateUser();

            }
            return false;
        }

        public static bool DeleteUser(int UserID)
        {
            return UserData.DeleteUser(UserID);
        }

        public static bool IsUserExist(int UserID)
        {
            return UserData.IsUserExist(UserID);
        }

        public static DataTable GetAllUsers()
        {
            return UserData.GetAllUsers();
        }

        public static bool IsUserNameExist(string UserName)
        {
            return UserData.IsUserNameExist(UserName);
        }

        public static bool IsPersonLinkedWithUser(int ID)
        {
            return UserData.IsPersonLinkedWithUser(ID);
        }

    }
}

