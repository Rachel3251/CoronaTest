using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELS
{
    public class Vaccination
    {
      
            public int VaccinationID { get; set; }
            public int UserID { get; set; }
            public DateTime? VaccinationDate { get; set; }
            public string VaccineManufacturer { get; set; }
       
         
    }
}
