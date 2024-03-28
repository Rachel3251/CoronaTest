using MODELS;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class VaccinationBll
    {
        private VaccinationDAL vaccinationDal;

        public VaccinationBll(VaccinationDAL vaccinationDal)
        {
            this.vaccinationDal = vaccinationDal;
        }

        public List<Vaccination> GetVaccinationsByUserID(int userId)
        {
            return vaccinationDal.GetVaccinationsByUserID(userId);
        }

        public int AddVaccination(Vaccination vaccination)
        {
           return vaccinationDal.AddVaccination(vaccination);
        }

        public bool UpdateVaccination(Vaccination vaccination)
        {
           return vaccinationDal.UpdateVaccination(vaccination);
        }

        public bool DeleteVaccination(int vaccinationId)
        {
            return vaccinationDal.DeleteVaccination(vaccinationId);
        }

        public List<Vaccination> GetVaccinationsByID(int vaccinationID)
        {
            return vaccinationDal.GetVaccinationsByID(vaccinationID);
        }
    }
}
