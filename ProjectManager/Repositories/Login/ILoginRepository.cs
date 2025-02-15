using ProjectManager.Model.InputModel;
using ProjectManager.Model.Password;
using ProjectManager.Model.ResponseModel;

namespace ProjectManager.Repositories.Login
{
    public interface ILoginRepository
    {
        Task<LoginResponse> LoginAsync(LoginInputModel loginRequest);
        void RequestCode(PasswordRecoveryCode email);
    }
}
