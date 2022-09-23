namespace Nutrinfo.Admin.Domain.Ascites
{
    public interface IAsciteRepository
    {
        Task<List<Ascite>> FindByPatientId(int patientId);
        Task<List<Ascite>> FindByIdsIn(List<int> asciteIds);
    }
}
