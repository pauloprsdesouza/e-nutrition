namespace Nutrinfo.Admin.Domain.Semiologies
{
    public interface ISemiologyRepository
    {
        Task<List<Semiology>> FindAll();
    }
}
