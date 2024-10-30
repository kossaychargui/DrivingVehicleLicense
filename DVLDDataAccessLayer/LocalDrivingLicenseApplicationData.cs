using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DVLDDataAccessLayer
{
    public class LocalDrivingLicenseApplicationData
    {
        public static bool FindByID(int ID, ref int ApplicationID, ref int LicenseClassID)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string query = @"SELECT * FROM LocalDrivingLicenseApplications WHERE LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", ID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;
                    ApplicationID = (int)reader["ApplicationID"];
                    LicenseClassID = (int)reader["LicenseClassID"];
                }
            }
            catch (Exception ex)
            {
                isFound = false;
                Console.WriteLine(ex.Message);
            }
            finally { connection.Close(); }
            return isFound;

        }
        public static bool FindViewByID(int ID, ref string ClassName, ref int PassedTests)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string query = @"SELECT * FROM LocalDrivingLicenseApplications_View WHERE LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", ID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;
                    ClassName = (string)reader["ClassName"];
                    PassedTests = (int)reader["PassedTestCount"];
                }
            }
            catch (Exception ex)
            {
                isFound = false;
                Console.WriteLine(ex.Message);
            }
            finally { connection.Close(); }
            return isFound;

        }
        public static int AddNewApplication(int ApplicationID, int LicenseClassID)
        {
            int LocalDrivingLicenceApplicationID = -1;
            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string query = @"INSERT INTO LocalDrivingLicenseApplications VALUES(@ApplicationID, @LicenseClassID);
                            SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int id))
                {
                    LocalDrivingLicenceApplicationID = id;
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally { connection.Close(); }
            return LocalDrivingLicenceApplicationID;
        }

        public static bool UpdateLocalDrivingLicenseApplication(int LocalDrivingLicenseApplicationID,int LicenseClassID)
        {
            int AffectedRows = 0;
            SqlConnection connection = new SqlConnection( DataAccessSettings.ConnectionString);

            string query = @"UPDATE LocalDrivingLicenseApplications 
                             SET LicenseClassID = @LicenseClassID 
                             WHERE LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

            try
            {
                connection.Open();
                AffectedRows = command.ExecuteNonQuery();

            }
            catch (Exception ex) { Console.WriteLine(ex.Message ); } finally { connection.Close(); }

            return AffectedRows > 0;
        }

        public static bool DeleteApplication(int LocalDrivingLicenseApplicationID)
        {
            int AffectedRows = 0;
            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string query = @"DELETE FROM LocalDrivingLicenseApplications WHERE LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);

            try
            {
                connection.Open();
                AffectedRows = command.ExecuteNonQuery();
            }
            catch(Exception ex) { Console.WriteLine(ex.Message); } finally { connection.Close(); }
            return AffectedRows > 0;
        }

        public static int IsPersonAppliedForThisClass(int PersonID, int LicenseClassID)
        {
            int ApplicationID = -1;

            SqlConnection connection = new SqlConnection( DataAccessSettings.ConnectionString);

            string query = @"SELECT Applications.ApplicationID FROM LocalDrivingLicenseApplications
                            INNER JOIN Applications ON Applications.ApplicationID = LocalDrivingLicenseApplications.ApplicationID
                            WHERE LicenseClassID = @LicenseClassID AND Applications.ApplicantPersonID = @PersonID AND Applications.ApplicationStatus in (1, 3);";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int id))
                {

                    ApplicationID = id;
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message) ; } finally { connection.Close(); }
            return ApplicationID;
        }

        public static DataTable GetAllLocalDrivingLicenseApplications()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);
 
            string query = @"SELECT * FROM LocalDrivingLicenseApplications_View;";

            SqlCommand command = new SqlCommand(query, connection);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                    dt.Load(reader);


            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message) ;
            }
            finally { connection.Close(); }
            return dt; 
        }

        public static bool GetLocalDrivingLicenseView(int LocalDrivingLicenseApplicationID, ref string ClassName,
                ref string NationalNo, ref string FullName, ref DateTime ApplicationDate, ref int PassedTestCount, ref string Status)
        {
            bool isfound = false;
            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string query = @"SELECT * FROM LocalDrivingLicenseApplications_View where LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID;";
            SqlCommand command = new SqlCommand(query, connection) ;
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            try
            { 
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    ClassName = (string)reader["ClassName"];
                    NationalNo = (string)reader["NationalNo"];
                    FullName = (string)reader["FullName"];
                    ApplicationDate = (DateTime)reader["ApplicationDate"];
                    PassedTestCount = (int)reader["PassedTestCount"];
                    Status = (string)reader["Status"];
                    isfound = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                isfound = false;
            }
            finally { connection.Close(); }
            return isfound;
        }

        public static int NumberOfTrialsOnTestType(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            int NumberOfTrials = -1;

            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string query = @"SELECT TrialCount = COUNT(*) FROM TestAppointments INNER JOIN Tests ON Tests.TestAppointmentID = TestAppointments.TestAppointmentID
                            WHERE TestTypeID = @TestTypeID AND LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int Trials))
                    NumberOfTrials = Trials;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally { connection.Close(); }
            return NumberOfTrials;
        }

        public static bool HasLocalDrivingLicenseStartedTestProcess(int LocalDrivingLicenseApplicationID)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection( DataAccessSettings.ConnectionString);

            string query = @"SELECT DISTINCT Found=1 FROM TestAppointments WHERE LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null)
                    IsFound = true;


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally { connection.Close(); }
            return IsFound;
        }

        public static int GetApplicantID(int LocalDrivingLicenseApplicationID)
        {
            int ApplicantID = -1;
            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string query = @"SELECT Applications.ApplicantPersonID FROM LocalDrivingLicenseApplications
                            INNER JOIN Applications ON Applications.ApplicationID = LocalDrivingLicenseApplications.ApplicationID
                            WHERE LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int ID))
                {
                    ApplicantID = ID;
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { connection.Close(); }
            return ApplicantID;
        }
    }
}

