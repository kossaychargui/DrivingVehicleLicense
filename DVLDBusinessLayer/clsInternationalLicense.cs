using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DVLDDataAccessLayer;
namespace DVLDBusinessLayer
{
    public class clsInternationalLicense
    {
        public int InternationalLicenseID { get; set; }
        public int ApplicationID { get; set; }
        public int DriverID { get; set; }
        public int IssuedUsingLocalDrivingLicenseID {  get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public bool IsActive { get; set; }
        public int CreatedByUserID { get; set; }
        public clsInternationalLicense()
        {
            InternationalLicenseID = -1;
            ApplicationID = -1;
            DriverID = -1;
            IssuedUsingLocalDrivingLicenseID = -1;
            IssueDate = DateTime.Now;
            ExpirationDate = DateTime.Now;
            IsActive = false;
            CreatedByUserID = -1;
        }
        private clsInternationalLicense(int InternationalLicenseID, int ApplicationID, int DriverID, int IssuedUsingLocalDrivingLicenseID, 
            DateTime IssueDate, DateTime ExpirationDate, bool IsActive, int CreatedByUserID)
        {
            this.InternationalLicenseID = InternationalLicenseID;
            this.ApplicationID = ApplicationID;
            this.DriverID = DriverID;
            this.IssuedUsingLocalDrivingLicenseID = IssuedUsingLocalDrivingLicenseID;
            this.IssueDate = IssueDate;
            this.ExpirationDate = ExpirationDate;
            this.IsActive = IsActive;
            this.CreatedByUserID = CreatedByUserID;
        }

        public static DataTable GetInternationalLicensesByPersonID(int PersonID)
        {
            clsDriver driver = clsDriver.FindDriverByPersonID(PersonID);
            return InternationalLicenseData.GetDriverInternationalLicenses(driver.ID);
        }

        public bool AddNew() {
            this.InternationalLicenseID = InternationalLicenseData.AddNew(ApplicationID, DriverID, IssuedUsingLocalDrivingLicenseID, 
                IssueDate, ExpirationDate, IsActive, CreatedByUserID);
            return this.InternationalLicenseID != -1;
        }


        public static clsInternationalLicense FindByID(int InternationalLicenseID)
        {
            int ApplicationID = -1, DriverID = -1, IssuedUsingLocalDrivingLicenseID = -1;
            DateTime IssueDate = DateTime.Now, ExpirationDate = DateTime.Now;
            bool IsActive = false; int CreatedByUserID = -1;

            if (InternationalLicenseData.FindByID(InternationalLicenseID, ref ApplicationID, ref DriverID, ref IssuedUsingLocalDrivingLicenseID, ref IssueDate,
                    ref ExpirationDate, ref IsActive, ref CreatedByUserID))
            {
                return new clsInternationalLicense(InternationalLicenseID,ApplicationID,DriverID, IssuedUsingLocalDrivingLicenseID, IssueDate,
                    ExpirationDate, IsActive, CreatedByUserID);
            }
            else
                return null;

        }

        public static int GetDriverInternationalLicenseID(int DriverID)
        {
            return InternationalLicenseData.GetDriverInternationalLicenseID(DriverID);
        }

        public static DataTable GetAllInternationalLicenses()
        {
            return InternationalLicenseData.GetAllInternationalLicenses();
        }
    }
}
