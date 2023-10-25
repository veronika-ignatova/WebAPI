
namespace Core.Interface.Service
{
    public interface IUserService
    {
        IUser GetUserById(Guid id);
        bool CreateUser(IUser user);
        bool IsUsedEmail(string email);
        IEnumerable<IUser> GetAllUsers();
        bool UpdateUser(IUser user);
        IUser GetUserByEmail(string email);
    }
}
