namespace API.Controllers;

using BLL;
using DAL;
using MODELS;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/vaccination")]
public class VaccinationController : ControllerBase
{
    private VaccinationBll vaccinationBll;

    public VaccinationController(VaccinationBll vaccinationBll)
    {
        this.vaccinationBll = vaccinationBll;
    }


    [Route("getvaccinationbyuserid/{userID}")]
    [HttpGet]
    public List<Vaccination> GetVaccinationsByUserID(int userID)
    {
        return vaccinationBll.GetVaccinationsByUserID(userID);
    }

    [Route("getvaccinationbyid/{vaccinationID}")]
    [HttpGet]
    public List<Vaccination> GetVaccinationsByID(int vaccinationID)
    {
        return vaccinationBll.GetVaccinationsByID(vaccinationID);
    }

    [Route("add")]
    [HttpPost]
    public int AddVaccination(Vaccination vaccination)
    {
        return vaccinationBll.AddVaccination(vaccination);
    }

    [Route("update")]
    [HttpPost]
    public bool UpdateVaccination(Vaccination vaccination)
    {
        return vaccinationBll.UpdateVaccination(vaccination);
    }

    [Route("delete/{vaccinationId}")]
    [HttpDelete]
    public bool DeleteVaccination(int vaccinationId)
    {
        return vaccinationBll.DeleteVaccination(vaccinationId);
    }


}




