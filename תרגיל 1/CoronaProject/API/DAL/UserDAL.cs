using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Dapper;
using System.Runtime.InteropServices;

namespace DAL
{
    public class UserDAL(IConfiguration configuration)
    {
        private readonly string connectionString = configuration.GetConnectionString("DefaultConnection");
        private User MapReaderToUser(SqlDataReader reader)
        {
            User user = new User();
            user.UserID = Convert.ToInt32(reader["userID"]);
            user.ID = reader["ID"].ToString();
            user.FirstName = reader["FirstName"].ToString();
            user.LastName = reader["LastName"].ToString();
            user.AddressCity = reader["AddressCity"].ToString();
            user.AddressStreet = reader["AddressStreet"].ToString();
            user.AddressNumber = reader["AddressNumber"].ToString();
            user.DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]);
            user.Phone = reader["Phone"].ToString();
            user.MobilePhone = reader["MobilePhone"].ToString();
            if (reader["PositiveResultDate"] != DBNull.Value)
            {
                user.PositiveResultDate = Convert.ToDateTime(reader["PositiveResultDate"]);
            }

            if (reader["RecoveryDate"] != DBNull.Value)
            {
                user.RecoveryDate = Convert.ToDateTime(reader["RecoveryDate"]);
            }
            return user;
        }

        public List<User> GetAllUsers()
        {
            List<User> users = new List<User>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM users";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        User user = MapReaderToUser(reader);

                        users.Add(user);
                    }
                }
            }
            return users;
        }
        public User getUserByID(int ID)
        {
            User user = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Users WHERE ID = @ID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID", ID);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        user = MapReaderToUser(reader);
                    }
                }
            }
            return user;
        }
        public bool Update(User user)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                int rowsAffected = connection.Execute(@"UPDATE users 
                                                 SET FirstName = @FirstName,
                                                     LastName = @LastName,
                                                     AddressCity = @AddressCity,
                                                     AddressStreet = @AddressStreet,
                                                     AddressNumber = @AddressNumber,
                                                     DateOfBirth = @DateOfBirth,
                                                     Phone = @Phone,
                                                     MobilePhone = @MobilePhone,
                                                    RecoveryDate = @PositiveResultDate,
                                                    PositiveResultDate = @PositiveResultDate
                                                 WHERE ID = @ID", user);
                return rowsAffected > 0;
            }
        }
        public bool AddUser(User user)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = @"INSERT INTO Users (ID, FirstName, LastName, AddressCity, AddressStreet, AddressNumber, DateOfBirth, Phone, MobilePhone,PositiveResultDate, RecoveryDate)
                         VALUES (@ID, @FirstName, @LastName, @AddressCity, @AddressStreet, @AddressNumber, @DateOfBirth, @Phone, @MobilePhone, @PositiveResultDate, @RecoveryDate)";

                int rowsAffected = connection.Execute(query, user);
                return rowsAffected > 0;
            }
        }
        public bool DeleteUser(int ID)
        {
            // שליפת UserID על ידי ID
            List<int> vaccinationIDsToDelete = new List<int>();
            int userID;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string selectQuery = "SELECT UserID FROM Users WHERE ID = @ID";
                using (SqlCommand getCommand = new SqlCommand(selectQuery, connection))
                {

                    getCommand.Parameters.AddWithValue("@ID", ID);
                    userID = (int)getCommand.ExecuteScalar();
                }
            }

            //שליפת חיסונים למשתמש על ידי UserID
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string selectQuery = "SELECT VaccinationID FROM Vaccinations WHERE UserID = @UserID";
                using (SqlCommand command = new SqlCommand(selectQuery, connection))
                {
                    command.Parameters.AddWithValue("@UserID", userID);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        vaccinationIDsToDelete.Add(Convert.ToInt32(reader["VaccinationID"]));
                    }
                }
            }

            //מחיקת כל החיסונים של המשתמש הנוכחי
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                foreach (int vaccinationID in vaccinationIDsToDelete)
                {
                    string deleteQuery = "DELETE FROM Vaccinations WHERE VaccinationID = @VaccinationID";
                    using (SqlCommand command = new SqlCommand(deleteQuery, connection))
                    {
                        command.Parameters.AddWithValue("@VaccinationID", vaccinationID);
                        command.ExecuteNonQuery();
                    }
                }
            }

            // מחיקת המשתמש מטבלת המשתמשים
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string getQuery = "SELECT ID FROM Users WHERE ID = @ID";
                string userIDToDelete;
                using (SqlCommand getCommand = new SqlCommand(getQuery, connection))
                {
                    getCommand.Parameters.AddWithValue("@ID", ID);
                    userIDToDelete = (string)getCommand.ExecuteScalar();
                }

                string deleteQuery = "DELETE FROM Users WHERE ID = @ID";
                using (SqlCommand command = new SqlCommand(deleteQuery, connection))
                {
                    command.Parameters.AddWithValue("@ID", userIDToDelete);
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }
    }
}

