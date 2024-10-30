using DVLDDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DVLDBusinessLayer
{
    public class clsApplicationTypes
    {
        public enum enApplicationTypes
        {
            NewLocalDrivingLicense = 1, RenewDrivingLicense = 2, ReplacementForLost = 3,
            ReplacementForDamaged = 4, ReleaseDetainedDrivingLicense = 5, NewInternationalDrivingLicense = 6
        };

        public static string GetApplicationTypeNameByID(int ApplicationTypeID)
        {
            switch (ApplicationTypeID) {
                case 1:
                    return enApplicationTypes.NewLocalDrivingLicense.ToString();
                case 2:
                    return enApplicationTypes.RenewDrivingLicense.ToString();
                case 3:
                    return enApplicationTypes.ReplacementForLost.ToString();
                case 4:
                    return enApplicationTypes.ReplacementForDamaged.ToString();
                case 5:
                    return enApplicationTypes.ReleaseDetainedDrivingLicense.ToString();
                case 6:
                    return enApplicationTypes.NewInternationalDrivingLicense.ToString();
            }
            return string.Empty;
        }

        public int ID { get; set; }

        public string Title {  get; set; }

        public decimal Fees { get; set; }

        private clsApplicationTypes(int ID, string Title, decimal Fees)
        {
            this.ID = ID;
            this.Title = Title;
            this.Fees = Fees;
        }
        public static clsApplicationTypes GetApplicationByID(int id)
        {

            string Title = string.Empty;
            decimal Fees = 0;
            if (ApplicationTypesData.GetApplicationByID(id, ref Title, ref Fees))
            {
                return new clsApplicationTypes(id, Title, Fees);
            }
            else
                return null;
        }
        public bool UpdateApplicationType (string NewTitle, decimal NewFees)
        {
            return ApplicationTypesData.UpdateApplicationType(this.ID,  NewTitle, NewFees);
        }

        public static DataTable GetAllApplicationTypes()
        {
            return ApplicationTypesData.GetAllApplications();
        }

        public static decimal GetApplicationFeesByID(int ID)
        {
            return ApplicationTypesData.GetApplicationFeesByID(ID);
        }
    }
}
