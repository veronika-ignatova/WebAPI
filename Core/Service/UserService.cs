using Core.Entities;
using Core.Interface;
using Core.Interface.Repository;
using Core.Interface.Service;
using System.Reflection;

namespace Core.Service
{
    public class UserService : IUserService
    {
        protected readonly IUserRepository userRepository;
        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        public IUser GetUserById(Guid id)
        {
            return userRepository.GetUserById(id);
        }
        public bool CreateUser(IUser user)
        {

            user.Id = Guid.NewGuid();
            user.CreateDate = DateTime.Now;
            return userRepository.CreateUser(user);
        }

        public bool UpdateUser(IUser user)
        {
            var userFromDb = userRepository.GetUserById(user.Id);
            if (userFromDb == null)
            {
                return false;
            }
            userFromDb.Name = user.Name;
            userFromDb.Age = user.Age;
            userFromDb.Password = user.Password;

            if (user.Address != null)
            {
                if (userFromDb.Address != null)
                {
                    userFromDb.Address.Street = user.Address.Street;
                    userFromDb.Address.City = user.Address.City;
                    userFromDb.Address.Index = user.Address.Index;
                    userFromDb.Address.Country = user.Address.Country;
                }
                else
                {
                    userFromDb.Address = new Address
                    {
                        Street = user.Address.Street,
                        City = user.Address.City,
                        Index = user.Address.Index,
                        Country = user.Address.Country
                    };
                }
            }

            return userRepository.UpdateUser(user);
        }

        public bool IsUsedEmail(string email)
        {
            if (userRepository.GetUserByEmail(email) == null)
            {
                return false;
            }
            return true;
        }
        public IEnumerable<IUser> GetAllUsers()
        {
            return userRepository.GetAllUsers();
        }

        public IUser GetUserByEmail(string email)
        {
            return userRepository.GetUserByEmail(email);
        }
    }
}
