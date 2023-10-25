using Core.Interface.Repository;

namespace DataBase
{
    public class AddressRepository: IAddressRepository
    {
        protected readonly MyDbContext _myDbContext;
        public AddressRepository(MyDbContext myDbContext)
        {
            _myDbContext = myDbContext;
        }
    }
}
