using Core.Interface;
using Core.Interface.Repository;
using Core.Interface.Service;

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
            return userRepository.UpdateUser(user);
        }
        public bool IsUsedEmail(string email)
        {
            if(userRepository.GetUserByEmail(email) == null)
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
