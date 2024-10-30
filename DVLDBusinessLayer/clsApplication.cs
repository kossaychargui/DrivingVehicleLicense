using DVLDDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using static DVLDBusinessLayer.clsApplication;
using static System.Net.Mime.MediaTypeNames;

namespace DVLDBusinessLayer
{
    public class clsApplication
    {
        public enum enApplicationStatus { New = 1, Cancelled = 2, Completed = 3 };
        
        public int ApplicationID { get; set; }
        public int ApplicantPersonID { get; set; }
        public DateTime ApplicationDate { get; set; }
        public int ApplicationTypeID { get; set; }
        public int ApplicationStatus { get; set; }
        public DateTime LastStatusDate{ get; set; }
        public decimal PaidFees { get; set; }
        public int CreatedByUserID {  get; set; }

        private enum enMode { AddNew , Update};
        private enMode _Mode { get; set; }

       
        public clsApplication()
        {
            
            ApplicationID = -1;
            ApplicantPersonID = -1;
            ApplicationDate = DateTime.Now;
            ApplicationTypeID = -1;
            ApplicationStatus = (int)enApplicationStatus.New;
            LastStatusDate = DateTime.Now;
            PaidFees = -1;
            CreatedByUserID = -1;
            _Mode = enMode.AddNew;
        }
        private clsApplication(int applicationID, int applicantPersonID, DateTime applicationDate, int applicationTypeID, int applicationStatus, DateTime lastStatusDate, decimal paidFees, int createdByUserID)
        {
            ApplicationID = applicationID;
            ApplicantPersonID = applicantPersonID;
            ApplicationDate = applicationDate;
            ApplicationTypeID = applicationTypeID;
            ApplicationStatus = applicationStatus;
            LastStatusDate = lastStatusDate;
            PaidFees = paidFees;
            CreatedByUserID = createdByUserID;

            _Mode = enMode.Update;
        }
        public static clsApplication FindByID(int ApplicationID)
        {
            int  ApplicantPersonID = -1, ApplicationTypeID = -1, CreatedByUserID = -1, ApplicationStatus = -1;
            decimal PaidFees = -1;
            DateTime ApplicationDate = DateTime.Now, LastStatusDate = DateTime.Now;
            if (ApplicationData.FindByID(ApplicationID, ref ApplicantPersonID, ref ApplicationDate, ref ApplicationTypeID, ref ApplicationStatus,
            ref LastStatusDate, ref PaidFees, ref CreatedByUserID))
            {
                return new clsApplication(ApplicationID, ApplicantPersonID, ApplicationDate, ApplicationTypeID, ApplicationStatus, LastStatusDate, PaidFees, CreatedByUserID);
            }
            else
                return null;
        }

        private bool _AddNew()
        {
            this.ApplicationID = ApplicationData.AddNewApplication(this.ApplicantPersonID, this.ApplicationDate
                ,this.ApplicationTypeID, this.ApplicationStatus, this.LastStatusDate, this.PaidFees, this.CreatedByUserID);
            return this.ApplicationID != -1;
        }
        private bool _Update()
        {
            return ApplicationData.UpdateApplication(this.ApplicationID, this.ApplicationStatus, this.LastStatusDate);
        }
        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    if (_AddNew())
                    {
                        _Mode = enMode.Update;
                        return true;
                    }
                    break;
                case enMode.Update:
                    return _Update();
            }
            return false;
        }   
        public bool Cancel()
        {
            this.ApplicationStatus = (int)enApplicationStatus.Cancelled;
            this.LastStatusDate = DateTime.Now;
            return Save();
        }
        public bool Complete()
        {
            this.ApplicationStatus = (int)enApplicationStatus.Completed;
            this.LastStatusDate = DateTime.Now;
            return Save();
        }
        public static bool CancelApplication(int ApplicationID)
        {
            return ApplicationData.UpdateApplication(ApplicationID, (int)enApplicationStatus.Cancelled, DateTime.Now);
        }
        public static bool CompleteApplication(int ApplicationID)
        {
            return ApplicationData.UpdateApplication(ApplicationID, (int)enApplicationStatus.Completed, DateTime.Now);
        }
        public static DataTable GetAllApplications()
        {
            return ApplicationData.GetAllApplications();
        }

        public static bool DeleteApplication(int applicationID)
        {
            return ApplicationData.DeleteApplication(applicationID);
        }
        public static int GetApplicationStatus(int applicationID)
        {
            clsApplication application = FindByID(applicationID);
            if (application != null)
                return application.ApplicationStatus;
            return -1;
        }
       

    }
}
