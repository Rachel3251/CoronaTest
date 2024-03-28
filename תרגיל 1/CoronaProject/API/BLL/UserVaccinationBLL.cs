using DAL;
using MODELS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class UserVaccinationBLL
    {
        private UserVaccinationDAL userVaccinationDAL;

        public UserVaccinationBLL(UserVaccinationDAL userVaccinationDAL)
        {
            this.userVaccinationDAL = userVaccinationDAL;
        }
        public bool AddUserVaccination(UserVaccinations userVaccination)
        {
            return userVaccinationDAL.AddUserVaccination(userVaccination);
        }

        public bool DeleteUserVaccination(int vaccinationID)
        {
            return userVaccinationDAL.DeleteUserVaccination(vaccinationID);
        }

        public List<UserVaccinations> GetUserVaccinationsByUserID(int userID)
        {
            return userVaccinationDAL.GetUserVaccinationsByUserID(userID);
        }
    }
}
