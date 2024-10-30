using DVLDDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDBusinessLayer
{
    public class clsLicenseClass
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int MinimumAllowedAge { get; set; }

        public int DefaultValidityLength { get; set; }

        public decimal Fees {  get; set; }

        public static clsLicenseClass GetLicenseClassByID(int id)
        {
            string Name = string.Empty, Description = string.Empty;
            int MinAllowedAge = -1, DefaultValidityLength = -1;
            decimal Fees = 0;
            if (LicenseClassesData.GetLicenseClassByID(id, ref Name, ref Description, ref MinAllowedAge, ref DefaultValidityLength, ref Fees))
            {
                return new clsLicenseClass
                {
                    ID = id,
                    Name = Name,
                    Description = Description,
                    MinimumAllowedAge = MinAllowedAge,
                    DefaultValidityLength = DefaultValidityLength,
                    Fees = Fees
                };
            }
            else
                return null;
        }

        public static DataTable GetAllLicenseClasses()
        {
            return LicenseClassesData.GetAllLicenseClasses();
        }

       
    }
}
