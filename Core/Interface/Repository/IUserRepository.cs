
namespace Core.Interface.Repository
{
    public interface IUserRepository
    {
        IUser GetUserById(Guid id);
        bool CreateUser(IUser user);
        IUser GetUserByEmail(string email);
        IEnumerable<IUser> GetAllUsers();
        bool UpdateUser(IUser user);
    }
}
