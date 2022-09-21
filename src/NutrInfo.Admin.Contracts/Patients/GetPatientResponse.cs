using System.Collections.Generic;

namespace NutrInfo.Admin.Contracts.Patients
{
    public class GetPatientResponse
    {
        public IEnumerable<PatientResponse> Patients { get; set; }
    }
}
