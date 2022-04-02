using System.Collections.Generic;

namespace NutrInfo.Admin.Api.Models.Patients
{
    public class GetPatientResponse
    {
        public IEnumerable<PatientResponse> Patients { get; set; }
    }
}
