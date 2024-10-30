using DVLDDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static DVLDBusinessLayer.clsUser;

namespace DVLDBusinessLayer
{
    public class clsLocalDrivingLicenseApplication
    {
        public int LocalDrivingLicenseApplicationID {  get; set; }
        public int ApplicationID { get; set; }
        public int LicenseClassID { get; set; }
        public int PassedTests { get; set; }
        public string ClassName {  get; set; }

        private enum enMode { AddNew, Update};
        private enMode _Mode = enMode.AddNew;

        public clsLocalDrivingLicenseApplication()
        {
            this.LocalDrivingLicenseApplicationID = -1;
            this.ApplicationID = -1;
            this.LicenseClassID = -1;

            this._Mode = enMode.AddNew;
        }
        private clsLocalDrivingLicenseApplication(int LocalDrivingLicenseApplicationID, int ApplicationID, int LicenseClassID)
        {
            this.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            this.ApplicationID = ApplicationID;
            this.LicenseClassID = LicenseClassID;

            _Mode = enMode.Update;
        }
        private clsLocalDrivingLicenseApplication(int LocalDrivingLicenseApplicationID, string ClassName, int PassedTests)
        {
            this.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            this.PassedTests = PassedTests;
            this.ClassName = ClassName;
            GetApplicationIDAndClassID();

            _Mode = enMode.Update;
        }
        public static clsLocalDrivingLicenseApplication FindByID(int id)
        {
            int ApplicationID = -1, LicenseClassID = -1;

            if (LocalDrivingLicenseApplicationData.FindByID(id, ref ApplicationID, ref LicenseClassID))
            {
                return new clsLocalDrivingLicenseApplication(id, ApplicationID, LicenseClassID);
            }
            else
                return null;
        }

        public static clsLocalDrivingLicenseApplication FindViewByID(int ID)
        {
            string ClassName = string.Empty;
            int PassedTests = -1;
            if (LocalDrivingLicenseApplicationData.FindViewByID(ID, ref ClassName, ref PassedTests))
            {
                
                return new clsLocalDrivingLicenseApplication(ID, ClassName, PassedTests);
            }
            else { return null; }
        }
     
        private void GetApplicationIDAndClassID()
        {
            int ApplicationID = -1, LicenseClassID = -1;
            if (this.LocalDrivingLicenseApplicationID != -1)
            {
                if(LocalDrivingLicenseApplicationData.FindByID(this.LocalDrivingLicenseApplicationID, ref ApplicationID, ref LicenseClassID))
                {
                    this.ApplicationID = ApplicationID;
                    this.LicenseClassID = LicenseClassID;
                }
            }
        }
        private bool _AddNew()
        {
            this.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationData.AddNewApplication(this.ApplicationID, this.LicenseClassID);
            return this.LocalDrivingLicenseApplicationID != -1;
        }
        private bool _Update()
        {
            return LocalDrivingLicenseApplicationData.UpdateLocalDrivingLicenseApplication(this.LocalDrivingLicenseApplicationID, this.LicenseClassID);
        }
        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    if (_AddNew())
                    {
                        _Mode = enMode.Update;
                        return true;
                    }
                    break;
                case enMode.Update:
                    return _Update();
            }
            return false;
        }


        public static bool DeleteLocalDrivingLicenseApplication(int applicationID)
        {
            return LocalDrivingLicenseApplicationData.DeleteApplication(applicationID);
        }

        public static int IsPersonAppliedForThisClass(int personID, int LicenseClassID)
        {
            return LocalDrivingLicenseApplicationData.IsPersonAppliedForThisClass(personID, LicenseClassID);
        }

        public static DataTable GetAllLocalDrivingLicenseApplications()
        {
            return LocalDrivingLicenseApplicationData.GetAllLocalDrivingLicenseApplications();
        }

        public struct stLocalDrivingLicense
        {
            public int LocalDrivingLicenseApplicationID { get;set; }
            public string ClassName { get; set; }
            public string NationalNo { get; set; }
            public string FullName { get; set; }
            public DateTime ApplicationDate { get; set; }
            public int PassedTestCount { get; set; }
            public string Status { get; set; }

        }
        public static stLocalDrivingLicense GetLocalDrivingLicenseView(int LocalDrivingLicenseApplicationID)
        {
            string ClassName = string.Empty, NationalNo = string.Empty, FullName = string.Empty, Status = string.Empty;
            int PassedTestCount = -1;
            DateTime ApplicationDate = DateTime.Now;

            LocalDrivingLicenseApplicationData.GetLocalDrivingLicenseView(LocalDrivingLicenseApplicationID, ref ClassName,
                ref NationalNo, ref FullName, ref ApplicationDate, ref PassedTestCount, ref Status);
            
                return new stLocalDrivingLicense
                {
                    LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID,
                    ClassName = ClassName,
                    NationalNo = NationalNo,
                    FullName = FullName,
                    ApplicationDate = ApplicationDate,
                    PassedTestCount = PassedTestCount,
                    Status = Status
                };
            
            
              
        }

        public static int NumberOfTrialsOnTestType(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            return LocalDrivingLicenseApplicationData.NumberOfTrialsOnTestType(LocalDrivingLicenseApplicationID, TestTypeID);
        }

        public static bool DoesLocalDrivingApplicationHaveLicense(int LocalDrivingLicenseApplicationID)
        {
            clsLocalDrivingLicenseApplication LDLA = FindByID(LocalDrivingLicenseApplicationID);
            return LicenseData.IsExistByApplicationID(LDLA.ApplicationID);
        }
        public static bool HasLocalDrivingLicenseStartedTestProcess(int LocalDrivingLicenseApplicationID)
        {
            return LocalDrivingLicenseApplicationData.HasLocalDrivingLicenseStartedTestProcess(LocalDrivingLicenseApplicationID);
        }

        public static clsLocalDrivingLicenseApplication FindLocalDrivingApplicationByID(int LocalDrivingLicenseApplicationID)
        {
            int ApplicationID = -1, LicenseClass = -1;
            if (LocalDrivingLicenseApplicationData.FindByID(LocalDrivingLicenseApplicationID, ref ApplicationID, ref LicenseClass))
            {
                return new clsLocalDrivingLicenseApplication
                {
                    LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID,
                    ApplicationID = ApplicationID,
                    LicenseClassID = LicenseClass,
                };
            }
            else return null;
        }
        

        public static int GetApplicantID(int LocalDrivingLicenseApplicationID)
        {
             return LocalDrivingLicenseApplicationData.GetApplicantID(LocalDrivingLicenseApplicationID);
        }
    }
}
