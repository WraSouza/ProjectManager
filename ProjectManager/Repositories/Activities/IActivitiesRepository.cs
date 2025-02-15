using ProjectManager.Model.InputModel;
using ProjectManager.Model.ResponseModel;

namespace ProjectManager.Repositories.Activities
{
    public interface IActivitiesRepository
    {
        Task<List<ActivitiesResponse>> GetActivitiesByIdAsync(int id);
        Task<bool> AddActivityAsync(ActivityInputModel activity);
    }
}
