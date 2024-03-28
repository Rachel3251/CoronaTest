using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using MODELS;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace DAL
{
    public class VaccinationDAL(IConfiguration configuration)
    {
        private readonly string connectionString = configuration.GetConnectionString("DefaultConnection");
        private Vaccination MapReaderToUser(SqlDataReader reader)
        {
            Vaccination vaccination = new Vaccination();
            vaccination.UserID = Convert.ToInt32(reader["userID"]);
            vaccination.VaccinationDate = Convert.ToDateTime(reader["VaccinationDate"]);
            vaccination.VaccineManufacturer = reader["VaccineManufacturer"].ToString();
            return vaccination;
        }
        public bool DeleteVaccination(int vaccinationId)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                int rowsAffected = connection.Execute("DELETE FROM Vaccinations WHERE VaccinationId = @VaccinationId", new { VaccinationId = vaccinationId });
                return rowsAffected > 0;
            }
        }

        public int AddVaccination(Vaccination vaccination)
        {
            // בדיקת מספר החיסונים הקיימים עבור המשתמש
            string countQuery = "SELECT COUNT(*) FROM Vaccinations WHERE UserID = @UserID";
            int existingVaccinations;
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                existingVaccinations = connection.QuerySingle<int>(countQuery, new { UserID = vaccination.UserID });
            }

            // אם יש פחות מארבע חיסונים, ניתן להוסיף את החיסון החדש
            if (existingVaccinations < 4)
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = @"INSERT INTO Vaccinations (UserID, VaccinationDate, VaccineManufacturer)
                            VALUES (@UserID, @VaccinationDate, @VaccineManufacturer)";
                    int rowsAffected = connection.Execute(query, vaccination);
                    if (rowsAffected > 0)
                        return existingVaccinations + 1;
                }

            }
            return 0;
        }
   





        public bool UpdateVaccination(Vaccination vaccination)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                int rowsAffected = connection.Execute(
                    @"UPDATE Vaccinations 
              SET 
                VaccinationDate = @VaccinationDate,
                VaccineManufacturer = @VaccineManufacturer
              WHERE VaccinationId = @VaccinationId",
                    new
                    {
                        VaccinationDate = vaccination.VaccinationDate,
                        VaccineManufacturer = vaccination.VaccineManufacturer,
                        VaccinationId = vaccination.VaccinationID
                    });

                return rowsAffected > 0;
            }
        }


        public List<Vaccination> GetVaccinationsByUserID(int userId)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = @"
                    SELECT VaccinationID,UserID, VaccinationDate, VaccineManufacturer
                 
                    FROM Vaccinations
                    WHERE UserID = @UserID";

                var vaccinations = connection.Query<Vaccination>(query, new { UserID = userId }).ToList();
                return vaccinations;
            }

        }
        public List<Vaccination> GetVaccinationsByID(int vaccinationID)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = @"
                    SELECT VaccinationID,UserID, VaccinationDate, VaccineManufacturer              
                    FROM Vaccinations
                    WHERE VaccinationID = @vaccinationID";

                var vaccinations = connection.Query<Vaccination>(query, new { VaccinationID = vaccinationID }).ToList();
                return vaccinations;
            }

        }
    }


}