using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DVLDDataAccessLayer;
using System.IO;
namespace DVLDBusinessLayer
{
    public class clsDriver
    {
        public int ID { get;set; }
        public int PersonID {  get;set; }
        public int CreatedByUserID {  get;set; }
        public DateTime CreatedDate {  get;set; }

        public clsDriver()
        {
            this.ID = -1;
            this.PersonID = -1;
            this.CreatedDate = DateTime.Now;
            this.CreatedByUserID = -1;
        }
        public bool AddDriver()
        {
            this.ID = DriverData.AddDriver(this.PersonID, this.CreatedByUserID,  this.CreatedDate);
            return this.ID != -1;
        }
        private clsDriver(int DriverID, int PersonID, int CreatedByUserID, DateTime CreatedDate)
        {
            ID = DriverID;
            this.PersonID = PersonID;
            this.CreatedByUserID = CreatedByUserID;
            this.CreatedDate = CreatedDate;
        }
        public static clsDriver FindDriverByID(int DriverID) {
            int PersonID = -1, CreatedByUserID = -1;
            DateTime CreatedDate = DateTime.Now;
            if (DriverData.FindByID(DriverID, ref PersonID, ref CreatedByUserID, ref CreatedDate))
            {
                return new clsDriver(DriverID, PersonID, CreatedByUserID, CreatedDate);
            }
            else
                return null;
        }
        public static clsDriver FindDriverByPersonID(int PersonID)
        {
            int DriverID = -1, CreatedByUserID = -1;
            DateTime CreatedDate = DateTime.Now;
            if (DriverData.FindByPersonID(ref DriverID, PersonID, ref CreatedByUserID, ref CreatedDate))
            {
                return new clsDriver(DriverID, PersonID, CreatedByUserID, CreatedDate);
            }
            else
                return null;
        }
        public static DataTable GetDrivers()
        {
            return DriverData.GetAllDrivers();
        }

        public static bool IsPersonAlreadyADriver(int PersonID)
        {
            return DriverData.IsPersonAlreadyADriver(PersonID);
        }

        public static int IsDriverHasActiveLicenseFromSameClassAndGetID(int DriverID, int LicenseClass)
        {
            return DriverData.IsDriverHasActiveLicenseFromSameClass(DriverID, LicenseClass);
        }
    }
}
