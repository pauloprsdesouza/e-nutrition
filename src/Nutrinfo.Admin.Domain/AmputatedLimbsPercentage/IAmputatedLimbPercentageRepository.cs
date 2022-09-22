namespace Nutrinfo.Admin.Domain.AmputatedLimbsPercentage
{
    public interface IAmputatedLimbPercentageRepository
    {
        Task<List<AmputatedLimbPercentage>> FindAll();
        Task<List<AmputatedLimbPercentage>> FindByIdsIn(List<int> amputatedLimbPercentilIds);
    }
}
