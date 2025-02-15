using ProjectManager.Model.ResponseModel;
using ProjectManager.Model.UserModel;

namespace ProjectManager.Repositories.Users
{
    public interface IUserRepository
    {
        Task<bool> AddUserAsync(User user);
        Task<List<UserResponse>> GetAllUsersAsync();
    }
}
