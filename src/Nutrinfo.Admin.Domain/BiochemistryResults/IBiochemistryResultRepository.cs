namespace Nutrinfo.Admin.Domain.BiochemistryResults
{
    public interface IBiochemistryResultRepository
    {
        Task<BiochemistryResult> FindByBiochemistry(int biochemistryId);
    }
}
