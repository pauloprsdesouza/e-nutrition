
namespace Nutrinfo.Admin.Domain.Patients
{
    public interface IPatientRepository
    {
        Task<Patient> FindById(int id);
    }
}
