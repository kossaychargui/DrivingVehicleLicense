using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DVLDDataAccessLayer
{
    public class DetainLicenseData
    {
        public static int DetainLicense(int LicenseID, DateTime DetainDate, decimal FineFees, int CreatedByUserID, bool IsReleased)
        {
            int DetainID = -1;
            
            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string query = @"INSERT INTO DetainedLicenses VALUES(@LicenseID, @DetainDate, @FineFees, @CreatedByUserID, @IsReleased, @ReleaseDate, @ReleasedByUserID, @ReleaseApplicationID);
                            SELECT SCOPE_IDENTITY();";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LicenseID", LicenseID);
            command.Parameters.AddWithValue("@DetainDate", DetainDate);
            command.Parameters.AddWithValue("@FineFees", FineFees);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            command.Parameters.AddWithValue("@IsReleased", IsReleased);
            command.Parameters.AddWithValue("@ReleaseDate", DBNull.Value);
            command.Parameters.AddWithValue("@ReleasedByUserID", DBNull.Value);
            command.Parameters.AddWithValue("@ReleaseApplicationID", DBNull.Value);
            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int ID))
                {
                    DetainID = ID;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally { connection.Close(); }
            return DetainID;
            

        }

        public static bool IsDetainedLicense(int LicenseID)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string query = @"SELECT Found=1 FROM DetainedLicenses WHERE LicenseID = @LicenseID AND IsReleased =0 ;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LicenseID", LicenseID);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null)
                {
                    IsFound = true;
                    
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally { connection.Close(); }
            return IsFound;
        }

        public static bool FindByID(int DetainID, ref int LicenseID, ref DateTime DetainDate, ref decimal FineFees, ref int CreatedByUserID, ref bool IsReleased,
            ref DateTime? ReleaseDate, ref int? ReleasedByUserID, ref int? ReleaseApplicationID)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection( DataAccessSettings.ConnectionString );

            string query = @"SELECT * FROM DetainedLicenses WHERE DetainID = @DetainID;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@DetainID", DetainID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    LicenseID = (int)reader["LicenseID"];
                    DetainDate = (DateTime)reader["DetainDate"];
                    FineFees = (decimal)reader["FineFees"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                    IsReleased = Convert.ToInt32(reader["IsReleased"]) == 1;
                    if (reader["ReleaseDate"] == DBNull.Value)
                        ReleaseDate = null;
                    else
                        ReleaseDate = (DateTime)reader["ReleaseDate"];
                    if (reader["ReleasedByUserID"] == DBNull.Value)
                        ReleasedByUserID = null;
                    else
                        ReleasedByUserID = (int)reader["ReleasedByUserID"];
                    if (reader["ReleaseApplicationID"] == DBNull.Value)
                        ReleaseApplicationID = null;
                    else
                        ReleaseApplicationID = (int)reader["ReleaseApplicationID"];
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

        public static bool FindByLicenseID(ref int DetainID, int LicenseID, ref DateTime DetainDate, ref decimal FineFees, ref int CreatedByUserID, ref bool IsReleased,
            ref DateTime? ReleaseDate, ref int? ReleasedByUserID, ref int? ReleaseApplicationID)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string query = @"SELECT * FROM DetainedLicenses WHERE LicenseID = @LicenseID AND IsReleased = 0;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LicenseID", LicenseID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    DetainID = (int)reader["DetainID"];
                    DetainDate = (DateTime)reader["DetainDate"];
                    FineFees = (decimal)reader["FineFees"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                    IsReleased = Convert.ToInt32(reader["IsReleased"]) == 1;
                    if (reader["ReleaseDate"] == DBNull.Value)
                        ReleaseDate = null;
                    else
                        ReleaseDate = (DateTime)reader["ReleaseDate"];
                    if (reader["ReleasedByUserID"] == DBNull.Value)
                        ReleasedByUserID = null;
                    else
                        ReleasedByUserID = (int)reader["ReleasedByUserID"];
                    if (reader["ReleaseApplicationID"] == DBNull.Value)
                        ReleaseApplicationID = null;
                    else
                        ReleaseApplicationID = (int)reader["ReleaseApplicationID"];
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

        public static bool UpdateDetainedLicense(int DetainID, DateTime? ReleaseDate, int? ReleasedByUserID, int? ReleaseApplicationID, bool IsReleased)
        {
            int AffectedRows = 0;
            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string query = @"UPDATE DetainedLicenses
                            SET ReleaseDate = @ReleaseDate,
	                            ReleasedByUserID = @ReleasedByUserID,
                            	ReleaseApplicationID = @ReleaseApplicationID,
                                IsReleased = @IsReleased 
                            WHERE DetainID = @DetainID;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@DetainID", DetainID);
            command.Parameters.AddWithValue("@ReleaseDate", ReleaseDate);
            command.Parameters.AddWithValue("@ReleasedByUserID", ReleasedByUserID);
            command.Parameters.AddWithValue("@ReleaseApplicationID", ReleaseApplicationID);
            command.Parameters.AddWithValue("@IsReleased", IsReleased);
            try
            {
                connection.Open();
                AffectedRows = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally { connection.Close(); }
            return AffectedRows > 0;
        }

        public static DataTable GetAllDetainedLicenses()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string query = @"SELECT DetainID AS 'D.ID', LicenseID AS 'L.ID', DetainDate AS 'D.Date',
                            IsReleased AS 'Is Released', FineFees AS 'Fine Fees', ReleaseDate AS 'Release Date',
                            People.NationalNo AS 'N.No.',
                            CASE
	                            WHEN ThirdName IS NULL THEN FirstName + ' ' + SecondName + ' ' + LastName
	                            ELSE FirstName + ' ' + SecondName + ' ' + ThirdName + ' ' + LastName
                            END AS 'Full Name', ReleaseApplicationID AS 'Release App.ID'
                            FROM DetainedLicenses LEFT JOIN Applications ON DetainedLicenses.ReleaseApplicationID = Applications.ApplicationID
                            LEFT JOIN People ON Applications.ApplicantPersonID = People.PersonID;";

            SqlCommand command = new SqlCommand(query, connection);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                    dt.Load(reader);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally { connection.Close(); }
            return dt;
        } 
    }

}
