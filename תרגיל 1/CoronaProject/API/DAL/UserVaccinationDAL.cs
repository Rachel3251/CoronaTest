using Microsoft.Extensions.Configuration;
using MODELS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;

namespace DAL
{
    public class UserVaccinationDAL(IConfiguration configuration)
    {
        private readonly string connectionString = configuration.GetConnectionString("DefaultConnection");

        public bool AddUserVaccination(UserVaccinations userVaccination)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"INSERT INTO UserVaccinations (UserID, VaccinationID)
                                 VALUES (@UserID, @VaccinationID)";

                int rowsAffected = connection.Execute(query, userVaccination);
                return rowsAffected > 0;
            }
        }

        public bool DeleteUserVaccination(int vaccinationID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"DELETE FROM UserVaccinations WHERE VaccinationID = @VaccinationID";
                int rowsAffected = connection.Execute(query, new { VaccinationID = vaccinationID });
                return rowsAffected > 0;
            }
        }

        public List<UserVaccinations> GetUserVaccinationsByUserID(int userID)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // בביצוע שאילתת SQL, מומלץ להשתמש בפרמטרים על מנת למנוע SQL Injection
                string query = @"
                    SELECT VaccinationID
                    FROM Vaccinations
                    WHERE userID = @UserID";

                // ביצוע שאילתת SQL עם פרמטר
                var userVaccinations = connection.Query<UserVaccinations>(query, new { UserID = userID }).ToList();
                return userVaccinations;
            }
        }
    }
}

