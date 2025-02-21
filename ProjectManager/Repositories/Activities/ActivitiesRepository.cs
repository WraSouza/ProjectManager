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

        public async Task<bool> FinishActivityAsync(FinishActivityInputModel id)
        {
            bool result = false;

            try
            {
                var activity = await Constants.FinishActivityURL.PutJsonAsync(id);

                if (activity.ResponseMessage.IsSuccessStatusCode)
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

        public async Task<List<ActivitiesResponse>> GetAllActivitiesByIdProjectAsync(int id)
        {
            List<ActivitiesResponse> activity = [];
            try
            {
                var allActivities = await Constants.ActivitiesAPI.GetJsonAsync<List<ActivitiesResponse>>();
                return allActivities.Where(x => x.idProject == id && x.IsActive == true).ToList();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                throw new Exception();
            }

            return activity;
        }
    }
}
