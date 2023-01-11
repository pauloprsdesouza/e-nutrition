using System.Collections.Generic;
using NutrInfo.Admin.Contracts.Paginations;

namespace NutrInfo.Admin.Contracts.Patients
{
    public class GetPatientResponse
    {
        public IEnumerable<PatientResponse> Patients { get; set; }
        public PaginationResponse Pagination { get; set; }
    }
}
