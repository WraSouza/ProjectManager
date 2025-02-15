using Flurl.Http;
using Newtonsoft.Json;
using ProjectManager.Helpers;
using ProjectManager.Model.InputModel;
using ProjectManager.Model.Password;
using ProjectManager.Model.ResponseModel;

namespace ProjectManager.Repositories.Login
{
    public class LoginRepository : ILoginRepository
    {
        public async Task<LoginResponse> LoginAsync(LoginInputModel loginRequest)
        {

            try
            {
                var result = await Constants.userLoginAPI.PutJsonAsync(loginRequest);

                if (result.ResponseMessage.IsSuccessStatusCode)
                {
                    var content = await result.ResponseMessage.Content.ReadAsStringAsync();

                    var token = JsonConvert.DeserializeObject<LoginResponse>(content);

                    return token;
                }

            }
            catch (FlurlHttpException ex)
            {
                if (ex.StatusCode >= 400)
                {
                    return new LoginResponse();
                }
            }



            return new LoginResponse();
        }

        public async void RequestCode(PasswordRecoveryCode email)
        {
            await Constants.recoverPasswordAPI.PostJsonAsync(email);
        }
    }
}
