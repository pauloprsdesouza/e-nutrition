namespace Nutrinfo.Admin.Domain.Semiologies
{
    public interface ISemiologyRepository
    {
        Task<Dictionary<string, List<Semiology>>> FindAllGrouped();
    }
}
