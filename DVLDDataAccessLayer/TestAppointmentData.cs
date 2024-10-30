using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Security.Cryptography;

namespace DVLDDataAccessLayer
{
    public class TestAppointmentData
    {
        public static int AddNew(int TestTypeID, int LocalDrivingLicenseApplicationID, DateTime AppointmentDate,
                decimal PaidFees, int CreatedByUserID, bool IsLocked)
        {
            int TestAppointmentID = -1;
            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string query = @"INSERT INTO TestAppointments VALUES(@TestTypeID, @LocalDrivingLicenseApplicationID,
                            @AppointmentDate, @PaidFees, @CreatedByUserID, @IsLocked);
                            SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@AppointmentDate", AppointmentDate);
            command.Parameters.AddWithValue("@PaidFees", PaidFees);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            command.Parameters.AddWithValue("@IsLocked", IsLocked);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int id))
                {
                    TestAppointmentID = id;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally { connection.Close(); }
            return TestAppointmentID;
        }

        public static bool Update(int TestAppointmentID, DateTime AppointmentDate, bool IsLocked)
        {
            int AffectedRows = 0;
            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string query = @"UPDATE TestAppointments 
                             SET AppointmentDate = @AppointmentDate,
                             IsLocked = @IsLocked WHERE TestAppointmentID = @TestAppointmentID;";

            SqlCommand command = new SqlCommand(@query, connection);
            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
            command.Parameters.AddWithValue("@AppointmentDate", AppointmentDate);
            command.Parameters.AddWithValue("@IsLocked", IsLocked);
            try
            {
                connection.Open();
                AffectedRows = command.ExecuteNonQuery();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); } finally { connection.Close(); }
            return AffectedRows > 0;
        }
        public static bool UpdateLockState(int TestAppointmentID, bool IsLocked)
        {
            int AffectedRows = 0;
            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string query = @"UPDATE TestAppointments 
                             SET IsLocked = @IsLocked WHERE TestAppointmentID = @TestAppointmentID;";

            SqlCommand command = new SqlCommand(@query, connection);
            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);

            command.Parameters.AddWithValue("@IsLocked", IsLocked);
            try
            {
                connection.Open();
                AffectedRows = command.ExecuteNonQuery();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { connection.Close(); }
            return AffectedRows > 0;
        }
        public static bool FindAppointmentViewByID(int TestAppointmentID, ref int LocalDrivingLicenseApplicationID, ref string TestTypeTitle,
                   ref string ClassName, ref DateTime AppointmentDate, ref decimal PaidFees, ref string FullName, ref bool IsLocked)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string query = @"SELECT * FROM TestAppointments_View WHERE TestAppointmentID = @TestAppointmentID;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    LocalDrivingLicenseApplicationID = (int)reader["LocalDrivingLicenseApplicationID"];
                    TestTypeTitle = (string)reader["TestTypeTitle"];
                    ClassName = (string)reader["ClassName"];
                    AppointmentDate = (DateTime)reader["AppointmentDate"];
                    PaidFees = (decimal)reader["PaidFees"];
                    FullName = (string)reader["FullName"];
                    IsLocked = Convert.ToInt32(reader["IsLocked"]) == 1;
                    IsFound = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                IsFound = false;
            }
            finally { connection.Close(); }
            return IsFound;
        }
        public static DataTable GetTestAppointments(string NationalNo, int TestTypeID)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string query = @"SELECT TestAppointmentID, AppointmentDate, PaidFees, IsLocked FROM TestAppointments
                            INNER JOIN LocalDrivingLicenseApplications_View ON LocalDrivingLicenseApplications_View.LocalDrivingLicenseApplicationID = TestAppointments.LocalDrivingLicenseApplicationID
                            WHERE NationalNo = @NationalNo AND TestAppointments.TestTypeID = @TestTypeID;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@NationalNo", NationalNo);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                    dt.Load(reader);
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { connection.Close(); }
            return dt;

        }

        public static bool IsLocalDrivingLicenseHaveUnlockedTestAppointment(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string query = @"SELECT Found=1 FROM TestAppointments
                            WHERE TestTypeID = @TestTypeID and LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID AND IsLocked = 0;";

            // I stopped here where I have checked if a person have a unlocked test appointement!!
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null)
                    IsFound = true;
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { connection.Close(); }

            return IsFound;
        }

        public static bool CheckLocalDrivingLicenseTestResult(int LocalDrivingLicenseApplicationID, int TestTypeID, bool PassedOrFailed)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string query = @"SELECT Found=1 FROM TestAppointments INNER JOIN Tests ON Tests.TestAppointmentID = TestAppointments.TestAppointmentID
                            WHERE TestTypeID = @TestTypeID AND LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID AND TestResult = @TestResult;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@TestResult", PassedOrFailed);
            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null)
                    IsFound = true;
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { connection.Close(); }

            return IsFound;



        }


        public static bool IsTestAppointmentLocked(int TestAppointmentID)
        {
            bool IsLocked = false;
            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string query = @"SELECT IsLocked FROM TestAppointments WHERE TestAppointmentID = @TestAppointmentID;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if(reader.Read())
              
                {
                    IsLocked = Convert.ToInt32(reader["IsLocked"]) == 1;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(
                ex.Message);
            }
            finally { connection.Close(); }
            return IsLocked;




        }

        public static DateTime GetTestAppointmentDate(int TestAppointmentID)
        {
            DateTime TestAppointmentDate
                = DateTime.Now;

            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string query = @"SELECT AppointmentDate FROM Appointments WHERE TestAppointmentID = @TestAppointmentID;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    TestAppointmentDate = (DateTime)reader["TestAppointmentDate"];
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally { connection.Close(); }
            return TestAppointmentDate;

        }
    } 
}
