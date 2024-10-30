using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography;
using DVLDDataAccessLayer;
using System.Runtime.InteropServices;
using System.Threading;

namespace DVLDBusinessLayer
{
    public class clsTestAppointment
    {
        public enum enAppointmentType { VisionTestAppointment = 1, WrittenTestAppointment = 2, PracticalTestAppointment = 3};
        public int TestAppointmentID { get; set; }
        public int TestTypeID {  get; set; }
        public int LocalDrivingLicenseApplicationID { get; set; }
        public DateTime AppointmentDate { get; set; }
        public decimal PaidFees { get; set; }
        public int CreatedByUserID {  get; set; }
        public bool IsLocked {  get; set; }

        private enum enMode { AddNew, Update};
        private enMode _Mode;
        public clsTestAppointment() {
            TestAppointmentID = -1;
            TestTypeID = -1;
            LocalDrivingLicenseApplicationID = -1;
            AppointmentDate = DateTime.Now;
            PaidFees = 0;
            CreatedByUserID = 0;
            IsLocked = false;
            _Mode = enMode.AddNew;

        }
        private clsTestAppointment(int testAppointmentID, int testTypeID, int localDrivingLicenseApplicationID, DateTime appointmentDate, decimal paidFees, int createdByUserID, bool isLocked)
        {
            TestAppointmentID = testAppointmentID;
            TestTypeID = testTypeID;
            LocalDrivingLicenseApplicationID = localDrivingLicenseApplicationID;
            AppointmentDate = appointmentDate;
            PaidFees = paidFees;
            CreatedByUserID = createdByUserID;
            IsLocked = isLocked;

            _Mode = enMode.Update;
        }

        
  
        public bool AddNew()
        {
            this.TestAppointmentID = TestAppointmentData.AddNew(TestTypeID, LocalDrivingLicenseApplicationID, AppointmentDate,
                PaidFees, CreatedByUserID, IsLocked);
            return TestAppointmentID != -1;
        }
        public static bool UpdateAppointment(int TestAppointmentID, DateTime TestAppointmentDate, bool IsLocked)
        {
            return TestAppointmentData.Update(TestAppointmentID, TestAppointmentDate, IsLocked);
        }
        public static bool LockTestAppointment(int TestAppointmentID, bool IsLocked)
        {
            return TestAppointmentData.UpdateLockState(TestAppointmentID, IsLocked);
        }
        public struct stTestAppointmentView
        {
            public int TestAppointmentID { get; set; }
            public int LocalDrivingLicenseApplicationID { get; set; }
            public string TestTypeTitle { get; set; }
            public string ClassName { get; set; }
            public DateTime AppointmentDate { get; set; }
            public decimal PaidFees { get; set; }
            public string FullName { get; set; }
            public bool IsLocked { get; set; }
        }
        public static stTestAppointmentView? FindAppointmentViewByID(int TestAppointmentID)
        {
                int LocalDrivingLicenseApplicationID = -1;
                string TestTypeTitle = string.Empty, ClassName = string.Empty, FullName = string.Empty;
                DateTime AppointmentDate = DateTime.Now;
                decimal PaidFees = -1; bool IsLocked = false;
                if (TestAppointmentData.FindAppointmentViewByID(TestAppointmentID, ref LocalDrivingLicenseApplicationID, ref TestTypeTitle,
                    ref ClassName, ref AppointmentDate, ref PaidFees, ref FullName, ref IsLocked))
                {
                    return new stTestAppointmentView{
                        TestAppointmentID = TestAppointmentID,
                        LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID,
                        TestTypeTitle = TestTypeTitle,
                        ClassName = ClassName,
                        AppointmentDate = AppointmentDate,
                        PaidFees = PaidFees,
                        FullName = FullName,
                        IsLocked = IsLocked

                    };
                }
                else
                    return null;
        }

        public static bool IsTestAppointmentLocked(int TestAppointmentID)
        {
            return TestAppointmentData.IsTestAppointmentLocked(TestAppointmentID);
        }
        
        public static DataTable GetVisionTestAppointments(string NationalNo)
        {
            return TestAppointmentData.GetTestAppointments(NationalNo, 1);   // 1 refers to the vision test type id
        }
        public static DataTable GetWrittenTestAppointments(string NationalNo)
        {
            return TestAppointmentData.GetTestAppointments(NationalNo, 2);   // 2 refers to the vision test type id
        }
        public static DataTable GetPracticalTestAppointments(string NationalNo)
        {
            return TestAppointmentData.GetTestAppointments(NationalNo, 3);   // 3 refers to the vision test type id
        }

        public static bool IsLocalDrivingLicenseHaveUnlockedTestAppointment(int LocalDrivingLicenseID, int TestTypeID)
        {
            return TestAppointmentData.IsLocalDrivingLicenseHaveUnlockedTestAppointment(LocalDrivingLicenseID, TestTypeID);
        }

        public static bool CheckLocalDrivingLicenseTestResult(int LocalDrivingLicense, int TestTypeID, bool PassedOrFailed)
        {
            return TestAppointmentData.CheckLocalDrivingLicenseTestResult(LocalDrivingLicense, TestTypeID, PassedOrFailed);
        }

        public static DateTime GetTestAppointmentDate(int TestAppointmentID)
        {
            return TestAppointmentData.GetTestAppointmentDate(TestAppointmentID);
        }

    }
}
