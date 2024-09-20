using User.API.Models;

namespace User.API.Repositories.IRepositories
{
    public interface IUserRepository
    {
        IEnumerable<UserModel> GetUsers();
        UserModel GetUserById(int userId);
        UserModel CreateUser(UserModel user);
        bool UpdateUser(UserModel user);
        bool DeleteUser(int userId);
    }
}
