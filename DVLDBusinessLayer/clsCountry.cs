using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DVLDDataAccessLayer;

namespace DVLDBusinessLayer
{
    public class clsCountry
    {
        public int CountryId { get; set; }

        public string CountryName { get; set; }

        public static DataTable GetAllCountries()
        {
            return CountryData.GetAllCountries() ;
        }

        public static string GetCountryName(int countryId)
        {
            return CountryData.GetCountryNameByID(countryId) ;
        }
    }
}
