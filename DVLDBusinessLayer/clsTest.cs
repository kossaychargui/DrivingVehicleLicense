using DVLDDataAccessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DVLDBusinessLayer
{
    public class clsTest
    {
        public int TestID { get; set; }
        public int TestAppointmentID { get; set; }
        public bool TestResult { get; set; }
        public string Notes { get; set; }
        public int CreatedByUserID { get; set; }

        public clsTest() {
            TestID = -1;
            TestAppointmentID = -1;
            TestResult = false;
            Notes = string.Empty;
            CreatedByUserID = -1;
        }
        public clsTest(int TestID, int TestAppointmentID, bool TestResult, string Notes, int CreatedByUserID) {
            this.TestID = TestID;
            this.TestAppointmentID = TestAppointmentID;
            this.TestResult = TestResult;
            this.Notes = Notes;
            this.CreatedByUserID = CreatedByUserID;
        }
        public bool AddNew()
        {
            TestID = TestData.AddNewTest(TestAppointmentID, TestResult, Notes, CreatedByUserID);
            return TestID != -1;
        }
        public bool TakeTest()
        {
            return TestData.UpdateTest(this.TestID, this.TestResult, this.Notes);
        }
      
        public static clsTest FindTestByTestAppointmentID(int TestAppointment)
        {
            int TestID = -1, CreatedByUserID = -1;
            bool TestResult = false;
            string Notes = string.Empty;
            if (TestData.FindTestInfoByTestAppointmentID(TestAppointment, ref TestID, ref TestResult, ref Notes, ref CreatedByUserID))
            {
                return new clsTest
                {
                    TestID = TestID,
                    TestAppointmentID = TestAppointment,
                    TestResult = TestResult,
                    Notes = Notes,
                    CreatedByUserID = CreatedByUserID
                };
            }
            else
                return null;
        }
     

    }
}
