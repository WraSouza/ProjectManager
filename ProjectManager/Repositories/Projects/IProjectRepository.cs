using ProjectManager.Model.InputModel;
using ProjectManager.Model.ResponseModel;

namespace ProjectManager.Repositories.Projects
{
    public interface IProjectRepository
    {
        Task<List<ProjectResponse>> GetAllProjectAsync();
        Task<bool> AddProjectAsync(ProjectInputModel project);
        Task<bool> FinishProjectAsync(FinishProjectInputModel id);
    }
}
