namespace API.Controllers
{
    using BLL;
    using DAL;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.ModelBinding;
    using MODELS;

    [ApiController]
    [Route("apiuservaccination")]
    public class UserVaccinationController
    {
        private UserVaccinationBLL userVaccinationBLL;

        public UserVaccinationController(UserVaccinationBLL userVaccinationBLL)
        {
            this.userVaccinationBLL = userVaccinationBLL;
        }

        [Route("delete")]
        [HttpPost]
        public bool DeleteUserVaccination(int vaccinationID)
        {
            return userVaccinationBLL.DeleteUserVaccination(vaccinationID);
        }
        [Route("add")]
        [HttpPost]
        public bool AddUserVaccination(UserVaccinations userVaccination)
        {
            return userVaccinationBLL.AddUserVaccination(userVaccination);
        }
        [Route("get")]
        [HttpGet]
        public List<UserVaccinations> GetUserVaccinationsByUserID(int userID)
        {
            return userVaccinationBLL.GetUserVaccinationsByUserID(userID);
        }
    }
}
