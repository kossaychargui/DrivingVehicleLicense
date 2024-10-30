using DVLDDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DVLDBusinessLayer
{
    public class clsDetainedLicense
    {
        public int DetainID {  get; set; }
        public int LicenseID { get; set; }
        public DateTime DetainDate { get; set; }
        public decimal FineFees { get; set; }
        public int CreatedByUserID { get; set; }
        public bool IsReleased {  get; set; }
        public DateTime? ReleasedDate { get; set; } 
        public int? ReleasedByUserID { get;set; }
        public int? ReleaseApplicationID { get; set; }
        public clsDetainedLicense()
        {
            DetainID = -1;
            LicenseID = -1;
            DetainDate = DateTime.Now;
            FineFees = 0;
            CreatedByUserID = -1;
            IsReleased = false;
            ReleasedDate = null;
            ReleasedByUserID = null;
            ReleaseApplicationID = null;

        }
        public static bool IsDetainedLicense(int LicenseID)
        {
            return DetainLicenseData.IsDetainedLicense(LicenseID);
        }
        public bool DetainLicense() {
            bool IsReleased = false;
            this.DetainID = DetainLicenseData.DetainLicense(this.LicenseID, this.DetainDate, this.FineFees, this.CreatedByUserID, IsReleased);
            return this.DetainID != -1;
        }

        private clsDetainedLicense(int detainID, int licenseID, DateTime detainDate, decimal fineFees, int createdByUserID, bool isReleased, DateTime? releasedDate, int? releasedByUserID, int? releaseApplicationID)
        {
            DetainID = detainID;
            LicenseID = licenseID;
            DetainDate = detainDate;
            FineFees = fineFees;
            CreatedByUserID = createdByUserID;
            IsReleased = isReleased;
            ReleasedDate = releasedDate;
            ReleasedByUserID = releasedByUserID;
            ReleaseApplicationID = releaseApplicationID;
        }

        public static clsDetainedLicense FindByLicenseID(int LicenseID)
        {
            int DetainID = -1, CreatedByUserID = -1;
            DateTime DetainDate = DateTime.Now;
            decimal FineFees = -1;
            bool IsReleased = false;
            DateTime? ReleasedDate = null;
            int? ReleasedByUserID = null;
            int? ReleaseApplicationID = null;
            if (DetainLicenseData.FindByLicenseID(ref DetainID, LicenseID, ref DetainDate, ref FineFees, ref CreatedByUserID,
                ref IsReleased, ref ReleasedDate, ref ReleasedByUserID, ref ReleaseApplicationID))
            {
                return new clsDetainedLicense(DetainID, LicenseID, DetainDate, FineFees, CreatedByUserID, IsReleased,
                     ReleasedDate, ReleasedByUserID, ReleaseApplicationID);
            }
            else
                return null;
            
        }
        public static clsDetainedLicense FindByID(int DetainID)
        {
            int LicenseID = -1, CreatedByUserID = -1;
            DateTime DetainDate = DateTime.Now;
            decimal FineFees = -1;
            bool IsReleased = false;
            DateTime? ReleasedDate = null;
            int? ReleasedByUserID = null;
            int? ReleaseApplicationID = null;
            if (DetainLicenseData.FindByID(DetainID, ref LicenseID, ref DetainDate, ref FineFees, ref CreatedByUserID,
                ref IsReleased, ref ReleasedDate, ref ReleasedByUserID, ref ReleaseApplicationID))
            {
                return new clsDetainedLicense(DetainID, LicenseID, DetainDate, FineFees, CreatedByUserID, IsReleased,
                     ReleasedDate, ReleasedByUserID, ReleaseApplicationID);
            }
            else
                return null;

        }

        public bool Release()
        {
            bool IsReleased = true;
            return DetainLicenseData.UpdateDetainedLicense(this.DetainID, this.ReleasedDate, this.ReleasedByUserID, this.ReleaseApplicationID, IsReleased);
        }

        public static DataTable GetAllDetainedLicenses()
        {
            return DetainLicenseData.GetAllDetainedLicenses();
        }
    }
}
