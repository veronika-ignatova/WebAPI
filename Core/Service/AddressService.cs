using Core.Interface.Repository;
using Core.Interface.Service;

namespace Core.Service
{
    public class AddressService : IAddressService
    {
        protected readonly IAddressRepository addressRepository;
        public AddressService(IAddressRepository addressRepository)
        {
            this.addressRepository = addressRepository;
        }
    }
}
