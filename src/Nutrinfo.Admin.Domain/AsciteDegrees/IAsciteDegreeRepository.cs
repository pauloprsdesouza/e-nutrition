namespace Nutrinfo.Admin.Domain.AsciteDegrees
{
    public interface IAsciteDegreeRepository
    {
        Task<List<AsciteDegree>> FindAll();
        Task<List<AsciteDegree>> FindByIds(List<int> ids);
    }
}
