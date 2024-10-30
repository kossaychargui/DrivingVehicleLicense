using DVLDDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDBusinessLayer
{
    public class clsTestType
    {
        public enum enTestType {VisionTest = 1, WrittenTest = 2, PracticalTest = 3};
        public int ID { get; set; }

        public string Title { get; set; }

        public string Description { get; set; } 

        public decimal Fees { get; set; }

        private clsTestType(int ID, string Title, string Description, decimal Fees)
        {
            this.ID = ID;
            this.Title = Title;
            this.Description = Description;
            this.Fees = Fees;
        }
        public static clsTestType GetTestTypeByID(int id)
        {

            string Title = string.Empty,  Description = string.Empty;
            decimal Fees = 0;
            if (TestTypeData.GetTestTypeByID(id, ref Title, ref Description, ref Fees))
            {
                return new clsTestType(id, Title, Description, Fees);
            }
            else
                return null;
        }
        public bool UpdateTestType(string NewTitle, string NewDescription, decimal NewFees)
        {
            return TestTypeData.UpdateTestType(this.ID, NewTitle, NewDescription, NewFees);
        }

        public static DataTable GetAllTestTypes()
        {
            return TestTypeData.GetAllTestTypes();
        }
    }
}
