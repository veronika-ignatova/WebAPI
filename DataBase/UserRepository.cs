using Core.Interface;
using Core.Interface.Repository;
using Microsoft.EntityFrameworkCore;

namespace DataBase
{
    public class UserRepository : IUserRepository
    {
        protected readonly MyDbContext _myDbContext;
        public UserRepository(MyDbContext myDbContext)
        {
            _myDbContext = myDbContext;
        }
        private IUser CastToIUser(Models.User? user)
        {
            if (user == null) return null;
            return new Core.Entities.User
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Age = user.Age,
                CreateDate = user.CreateDate,
                Password = user.Password,
                AddressId = user.AddressId,
                Address = CastToIAddress(user.Address)
            };
        }

        private IAddress? CastToIAddress(Models.Address? address)
        {
            if (address == null) return null;
            return new Core.Entities.Address
            {
                City = address.City,
                Country = address.Country,
                Id = address.Id,
                Index = address.Index,
                Street = address.Street
            };
        }

        public IUser GetUserById(Guid id)
        {
            return CastToIUser(_myDbContext.Users.Include(x => x.Address).FirstOrDefault(x => x.Id == id));
        }

        public bool CreateUser(IUser user)
        {
            try
            {
                _myDbContext.Users.Add(new Models.User
                {
                    Id = user.Id,
                    Name = user.Name,
                    Email = user.Email,
                    Age = user.Age,
                    CreateDate = user.CreateDate,
                    Password = user.Password
                });
                _myDbContext.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
        public bool UpdateUser(IUser user)
        {
            try
            {
                var dbUser = _myDbContext.Users.FirstOrDefault(x => x.Id == user.Id);
                if (dbUser == null)
                {
                    return false;
                }
                dbUser.Name = user.Name;
                dbUser.Age = user.Age;
                dbUser.Password = user.Password;
                if (user.Address != null)
                {
                    var dbAddress = _myDbContext.Addresses.FirstOrDefault(x => x.Id == user.Address.Id);
                    if (dbAddress != null && dbAddress.Id != 0)
                    {
                        dbAddress.Street = user.Address.Street;
                        dbAddress.City = user.Address.City;
                        dbAddress.Index = user.Address.Index;
                        dbAddress.Country = user.Address.Country;
                    }
                    else
                    {
                        dbUser.Address = new Models.Address
                        {
                            Street = user.Address.Street,
                            City = user.Address.City,
                            Index = user.Address.Index,
                            Country = user.Address.Country,
                        };
                    }
                }

                _myDbContext.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public IUser GetUserByEmail(string email)
        {
            return CastToIUser(_myDbContext.Users.FirstOrDefault(x => x.Email != null && email != null && x.Email.ToLower() == email.ToLower()));
        }

        public IEnumerable<IUser> GetAllUsers()
        {
            return _myDbContext.Users.Include(x => x.Address).ToList().Select(CastToIUser);
        }
    }
}
