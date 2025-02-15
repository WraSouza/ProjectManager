using Flurl.Http;
using Newtonsoft.Json;
using ProjectManager.Helpers;
using ProjectManager.Model.InputModel;
using ProjectManager.Model.ResponseModel;
using System.Web;

namespace ProjectManager.Repositories.Activities
{
    public class ActivitiesRepository : IActivitiesRepository
    {
        public async Task<bool> AddActivityAsync(ActivityInputModel activity)
        {
            bool result = false;

            try
            {
                var newActivity = await Constants.ActivitiesAPI.PostJsonAsync(activity);

                if (newActivity.ResponseMessage.IsSuccessStatusCode)
                {
                    result = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return result;
        }

        public async Task<List<ActivitiesResponse>> GetActivitiesByIdAsync(int id)
        {
            List<ActivitiesResponse> activity = [];
            try
            {
                var allActivities = await Constants.ActivitiesAPI.GetJsonAsync<List<ActivitiesResponse>>();
                return allActivities.Where(x => x.idProject == id).ToList();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                throw new Exception();
            }

            return activity;
            //List<ActivitiesResponse> activities = [];

            // HttpClientHandler clientHandler = new HttpClientHandler();
            // clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            // string url = $"https://1xchrq8n-5177.brs.devtunnels.ms/api/Activities/{id}";


            // using (var client = new HttpClient(clientHandler))
            // {
            //     var responseLogin = client.GetAsync(url);

            //     string dataInDB = await responseLogin.Result.Content.ReadAsStringAsync();

            //     List<ActivitiesResponse> allItems = JsonConvert.DeserializeObject<List<ActivitiesResponse>>(dataInDB);

            //     return allItems;
            // }


        }
    }
}
