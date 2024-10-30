using DVLDDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO.Pipes;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DVLDBusinessLayer
{
    public class clsLicense
    {
        public int LicenseID {  get; set; }
        public int ApplicationID { get; set; }
        public int DriverID { get; set; }
        public int LicenseClass { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Notes { get; set; }
        public decimal PaidFees {  get; set; }
        public bool IsActive { get;set; }
        public int IssueReason { get; set; }
        public int CreatedByUserID { get; set; }

        private enum enMode { AddNew = 1, Update = 2 }
        private enMode _Mode;
        public clsLicense()
        {
            LicenseID = -1;
            ApplicationID = -1;
            DriverID = -1;
            LicenseClass = -1;
            IssueDate = DateTime.Now;
            ExpirationDate = DateTime.Now;
            Notes = string.Empty;
            IsActive = false;
            IssueReason = -1;
            CreatedByUserID = -1;

            _Mode = enMode.AddNew;
        }

        private clsLicense(int LicenseID, int ApplicationID, int DriverID, int LicenseClass, DateTime IssueDate,
            DateTime ExpirationDate, string Notes, decimal PaidFees, bool IsActive, int IssueReason, int CreatedByUserID)
        {
            this.LicenseID = LicenseID;
            this.ApplicationID = ApplicationID;
            this.LicenseClass = LicenseClass;
            this.DriverID = DriverID;
            this.IssueDate = IssueDate;
            this.ExpirationDate = ExpirationDate;
            this.Notes = Notes;
            this.PaidFees = PaidFees;
            this.IsActive = IsActive;
            this.IssueReason = IssueReason;
            this.CreatedByUserID = CreatedByUserID;

            _Mode = enMode.Update;

        }

        public bool AddNew()
        {
            this.LicenseID = LicenseData.AddNew(this.ApplicationID, this.DriverID, this.LicenseClass, this.IssueDate,
                this.ExpirationDate, this.Notes, this.PaidFees, this.IsActive, this.IssueReason, this.CreatedByUserID);
            return this.LicenseID != -1;
        }

    
        public static clsLicense FindByID(int LicenseID)
        {
            int ApplicationID = -1, DriverID = -1, LicenseClass = -1, IssueReason = -1, CreatedByUserID = -1;
            DateTime IssueDate = DateTime.Now, ExpirationDate = DateTime.Now;
            string Notes = string.Empty;
            decimal PaidFees = -1;
            bool IsActive= false;
            if (LicenseData.FindByID(LicenseID, ref ApplicationID, ref DriverID, ref LicenseClass, ref IssueDate, ref ExpirationDate,
                ref Notes, ref PaidFees, ref IsActive, ref IssueReason, ref CreatedByUserID))
            {
                if (ExpirationDate < DateTime.Now)
                {
                    LicenseData.DisActivateLicense(LicenseID);
                    IsActive = false;
                }
                return new clsLicense(LicenseID,ApplicationID, DriverID, LicenseClass, IssueDate,
                         ExpirationDate, Notes, PaidFees, IsActive, IssueReason, CreatedByUserID);
            }
            else
                return null;
        }
        public static clsLicense FindByApplicationID(int ApplicationID)
        {
            int LicenseID = -1, DriverID = -1, LicenseClass = -1, IssueReason = -1, CreatedByUserID = -1;
            DateTime IssueDate = DateTime.Now, ExpirationDate = DateTime.Now;
            string Notes = string.Empty;
            decimal PaidFees = -1;
            bool IsActive = false;
            if (LicenseData.FindByApplicationID(ref LicenseID, ApplicationID, ref DriverID, ref LicenseClass, ref IssueDate, ref ExpirationDate,
                ref Notes, ref PaidFees, ref IsActive, ref IssueReason, ref CreatedByUserID))
            {
                return new clsLicense(LicenseID, ApplicationID, DriverID, LicenseClass, IssueDate,
                         ExpirationDate, Notes, PaidFees, IsActive, IssueReason, CreatedByUserID);
            }
            else
                return null;
        }

        public static DataTable GetPersonAllLicenses(int PersonID)
        {
            clsDriver driver = clsDriver.FindDriverByPersonID(PersonID);
            return LicenseData.GetDriverAllLicenses(driver.ID);
        }

       public static bool DisActiveLicense(int LicenseID)
       {
            return LicenseData.DisActivateLicense(LicenseID);
       }

    }
}
