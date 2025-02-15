using Flurl.Http;
using ProjectManager.Helpers;
using ProjectManager.Model.ResponseModel;
using ProjectManager.Model.UserModel;

namespace ProjectManager.Repositories.Users
{
    public class UserRepository : IUserRepository
    {
        public async Task<bool> AddUserAsync(User user)
        {

            try
            {
                var addUser = await Constants.userAPI.PostJsonAsync(user);

                if (addUser.ResponseMessage.IsSuccessStatusCode)
                {
                    return true;
                }

                return false;

            }
            catch (FlurlHttpException ex)
            {
                if (ex.StatusCode == 400)
                    await Shell.Current.DisplayAlert("", "Não Foi Possível Adicionar o Usuário, Tente Novamente", "OK");

                if (ex.StatusCode > 400)
                    await Shell.Current.DisplayAlert("", "Houve Um Problema Interno e Não Foi Possível Adicionar o Usuário Na Base De Dados", "OK");
            }

            return false;
        }

        public async Task<List<UserResponse>> GetAllUsersAsync()
        {
            List<UserResponse> users = [];

            try
            {
                return await Constants.userAPI
                    .GetJsonAsync<List<UserResponse>>();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return users;
        }
    }
}
