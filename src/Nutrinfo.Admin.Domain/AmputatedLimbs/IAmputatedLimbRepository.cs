namespace Nutrinfo.Admin.Domain.AmputatedLimbs
{
    public interface IAmputatedLimbRepository
    {
        Task<List<AmputatedLimb>> FindByPatientId(int patientId);
        Task<List<AmputatedLimb>> FindByIdsIn(List<int> amputatedLimbsIds, int patientId);
    }
}
