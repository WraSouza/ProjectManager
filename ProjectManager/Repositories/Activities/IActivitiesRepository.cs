using ProjectManager.Model.InputModel;
using ProjectManager.Model.ResponseModel;

namespace ProjectManager.Repositories.Activities
{
    public interface IActivitiesRepository
    {
        Task<List<ActivitiesResponse>> GetAllActivitiesByIdProjectAsync(int id);
        Task<bool> AddActivityAsync(ActivityInputModel activity);
        Task<bool> FinishActivityAsync(FinishActivityInputModel id);
    }
}
