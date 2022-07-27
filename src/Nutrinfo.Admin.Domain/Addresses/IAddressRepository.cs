namespace Nutrinfo.Admin.Domain.Addresses
{
    public interface IAddressRepository
    {
        Task<Address> Create(Address address);
    }
}
