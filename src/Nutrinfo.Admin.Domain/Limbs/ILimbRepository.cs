namespace Nutrinfo.Admin.Domain.Limbs
{
    public interface ILimbRepository
    {
        Task<List<Limb>> FindAll();
        Task<List<Limb>> FindByIdsIn(List<int> amputatedLimbIds);
    }
}
