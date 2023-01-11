using Nutrinfo.Admin.Domain.Pagination;

namespace Nutrinfo.Admin.Domain.Patients
{
    public interface IPatientRepository
    {
        Task<Patient> FindById(int id);
        Task<Patient> Create(Patient patient);
        Task<Patient> Update(Patient patient);
        Task<PagedList<Patient>> FindPaged(string name, int page);
    }
}
