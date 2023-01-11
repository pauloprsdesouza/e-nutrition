
namespace NutrInfo.Admin.Contracts.Patients
{
    public class GetPatientsQuery
    {
        public string Name { get; set; }
        public string Cpf { get; set; }
        public int Page { get; set; }
    }
}
