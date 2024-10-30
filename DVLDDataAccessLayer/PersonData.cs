using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace DVLDDataAccessLayer
{
    public class PersonData
    {
        public static bool GetPersonInfoByID(int ID, ref string NationalNo, ref string FirstName, ref string SecondName, ref string ThirdName, ref string LastName,
            ref DateTime DateOfBirth, ref string Gender, ref string Address, ref string Phone, ref string Email, ref int NationalCountyID, ref string ImagePath)
        {
            bool isFound = false;
            SqlConnection Connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string query = @"SELECT * FROM People WHERE PersonID = @ID;";
            SqlCommand Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@ID", ID);

            try
            {
                Connection.Open();
                SqlDataReader reader = Command.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;
                    NationalNo = (string)reader["NationalNo"];
                    FirstName = (string)reader["FirstName"];
                    SecondName = (string)reader["SecondName"];
                    if (reader["ThirdName"] != DBNull.Value)
                        ThirdName = (string)reader["ThirdName"];// We need to check for null value
                    else
                        ThirdName = string.Empty;
                    LastName = (string)reader["LastName"];
                    DateOfBirth = (DateTime)reader["DateOfBirth"];
                    // con ert the integer to gender in words
                        Gender = Convert.ToInt32(reader["Gendor"]) == 0 ? "Male" : "Female";
                   // Gender = "Male";
                    Address = (string)reader["Address"];
                    Phone = (string)reader["Phone"];
                    if(reader["Email"] != DBNull.Value)
                        Email = (string)reader["Email"];// Check for null value
                    else
                        Email = string.Empty;
                    NationalCountyID = (int)reader["NationalityCountryID"];
                    if (reader["ImagePath"] != DBNull.Value)
                        ImagePath = (string)reader["ImagePath"];// check for null value
                    else
                        ImagePath = string.Empty;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                
                isFound = false;
                Console.WriteLine(ex.Message);
                
            }
            finally
            {
                Connection.Close();
           
            }
            return isFound;
        }

        public static bool GetPersonInfoByNationalNo(ref int ID, string NationalNo, ref string FirstName, ref string SecondName, ref string ThirdName, ref string LastName,
            ref DateTime DateOfBirth, ref string Gender, ref string Address, ref string Phone, ref string Email, ref int NationalCountyID, ref string ImagePath)
        {
            bool isFound = false;
            SqlConnection Connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string query = @"SELECT * FROM People WHERE NationalNo = @NationalNo;";
            SqlCommand Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@NationalNo", NationalNo);

            try
            {
                Connection.Open();
                SqlDataReader reader = Command.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;
                    ID = (int)reader["PersonID"];
                    FirstName = (string)reader["FirstName"];
                    SecondName = (string)reader["SecondName"];
                    if (reader["ThirdName"] != DBNull.Value)
                        ThirdName = (string)reader["ThirdName"];// We need to check for null value
                    else
                        ThirdName = string.Empty;
                    LastName = (string)reader["LastName"];
                    DateOfBirth = (DateTime)reader["DateOfBirth"];
                    Gender = Convert.ToInt32(reader["Gendor"]) == 0 ? "Male" : "Female";// con ert the integer to gender in words
                    Address = (string)reader["Address"];
                    Phone = (string)reader["Phone"];
                    if (reader["Email"] != DBNull.Value)
                        Email = (string)reader["Email"];// Check for null value
                    else
                        Email = string.Empty;
                    NationalCountyID = (int)reader["NationalityCountryID"];
                    if (reader["ImagePath"] != DBNull.Value)
                        ImagePath = (string)reader["ImagePath"];// check for null value
                    else
                        ImagePath = string.Empty;
                }
                reader.Close();
            }
            catch (Exception ex)
            {

                isFound = false;
                //Console.WriteLine("Error :" + ex.Message);

            }
            finally
            {
                Connection.Close();

            }
            return isFound;
        }

        public static int AddNewPerson(string NationalNo, string FirstName, string SecondName, string ThirdName, string LastName, DateTime DateOfBirth,
        string Gender, string Address, string Phone, string Email, int NationalityCountryID, string ImagePath)
        {
            int ID = -1;
            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string query = @"INSERT INTO People Values(@NationalNo, @FirstName, @SecondName, @ThirdName, @LastName, @DateOfBirth, @Gendor, @Address
                             , @Phone, @Email, @NationalityCountryID, @ImagePath);
                            SELECT SCOPE_IDENTITY();";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@NationalNo", NationalNo);
            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@SecondName", SecondName);
            if (ThirdName != "")
                command.Parameters.AddWithValue("@ThirdName", ThirdName);
            else
                command.Parameters.AddWithValue("@ThirdName", DBNull.Value);
            command.Parameters.AddWithValue("@LastName", LastName);
            command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            int GenderValue = Gender == "Male" ? 0 : 1;
            command.Parameters.AddWithValue("@Gendor", GenderValue);
            command.Parameters.AddWithValue("@Address", Address);
            command.Parameters.AddWithValue("@Phone", Phone);
            if(Email != "")
                command.Parameters.AddWithValue("@Email", Email);
            else
                command.Parameters.AddWithValue("@Email", DBNull.Value);
            command.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);
            if(ImagePath != "")
                command.Parameters.AddWithValue("@ImagePath", ImagePath);
            else
                command.Parameters.AddWithValue("@ImagePath", DBNull.Value);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int id))
                {
                    ID = id;
                }
            }
            catch (Exception ex)
            {
                // Console.WriteLine("Error :" + ex.Message);
                
            }
            finally { connection.Close(); }
            


            return ID;
        }

        public static bool UpdatePerson(int ID, string NationalNo, string FirstName, string SecondName, string ThirdName, string LastName, DateTime DateOfBirth,
        string Gender, string Address, string Phone, string Email, int NationalityCountryID, string ImagePath)
        {
            int AffectedRows  = 0;
            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string query = @"UPDATE People " +
                "SET NationalNo = @NationalNo," +
                "FirstName = @FirstName," +
                "SecondName = @SecondName," +
                "ThirdName = @ThirdName," +
                "LastName = @LastName," +
                "DateOfBirth = @DateOfBirth," +
                "Gendor = @Gender," +
                "Address = @Address," +
                "Phone = @Phone," +
                "Email = @Email," +
                "NationalityCountryID = @NationalityCountryID," +
                "ImagePath = @ImagePath " +
                "WHERE PersonID = @PersonID;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", ID);
            command.Parameters.AddWithValue("@NationalNo", NationalNo);
            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@SecondName", SecondName);
            if (ThirdName != "")
                command.Parameters.AddWithValue("@ThirdName", ThirdName);
            else
                command.Parameters.AddWithValue("@ThirdName", DBNull.Value);
            command.Parameters.AddWithValue("@LastName", LastName);
            command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            int GenderValue = Gender == "Male"? 0 : 1;
            command.Parameters.AddWithValue("@Gender", GenderValue);
            command.Parameters.AddWithValue("@Address", Address);
            command.Parameters.AddWithValue("@Phone", Phone);
            if (Email != "")
                command.Parameters.AddWithValue("@Email", Email);
            else
                command.Parameters.AddWithValue("@Email", DBNull.Value);
            command.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);
            if (ImagePath != "")
                command.Parameters.AddWithValue("@ImagePath", ImagePath);
            else
                command.Parameters.AddWithValue("@ImagePath", DBNull.Value);
            try
            {
                connection.Open();
                AffectedRows = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
               // Console.WriteLine(ex.Message);
            }
            finally { connection.Close(); }
            return AffectedRows > 0;
        }

        public static bool DeletePerson(int ID)
        {
            int AffectedRows = 0;

            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string query = @"DELETE FROM People WHERE PersonID = @PersonID;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", ID);

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

        public static bool isPersonExist(int ID)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection( DataAccessSettings.ConnectionString);
            string query = @"SELECT Found = 1 WHERE PersonID = @PersonID;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", ID);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null)
                    isFound = true;
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally { connection.Close(); }
            return isFound;

        }

        public static bool isPersonExist(string NationalNo)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string query = @"SELECT Found = 1 FROM People WHERE NationalNo = @NationalNo;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@NationalNo", NationalNo);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null)
                    isFound = true;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally { connection.Close(); }
            return isFound;

        }

        public static DataTable GetAllPeople()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string query = @"SELECT PersonID, NationalNo, FirstName, SecondName, ThirdName, LastName, DateOfBirth,
                            CASE
                                  WHEN Gendor = 0 THEN 'Male' 
                                  ELSE 'Female'
                            End AS Gendor, 
                            Address, Phone, Email, Countries.CountryName AS Nationality, ImagePath
                            FROM People 
			                        INNER JOIN Countries ON Countries.CountryID = People.NationalityCountryID;";


            SqlCommand cmd = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader != null)
                {
                    dt.Load(reader);
                }
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
