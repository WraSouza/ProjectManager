using Flurl.Http;
using ProjectManager.Helpers;
using ProjectManager.Model.InputModel;
using ProjectManager.Model.ResponseModel;

namespace ProjectManager.Repositories.Projects
{
    public class ProjectRepository : IProjectRepository
    {
        public async Task<bool> AddProjectAsync(ProjectInputModel project)
        {
            bool result = false;

            try
            {
                var newProject = await Constants.projectAPI.PostJsonAsync(project);

                if (newProject.ResponseMessage.IsSuccessStatusCode)
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

        public async Task<bool> FinishProjectAsync(UpdateProjectInputModel id)
        {
            bool result = false;

            try
            {
                var project = await Constants.finishProjectAPI.PutJsonAsync(id);

                if (project.ResponseMessage.IsSuccessStatusCode)
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

        public async Task<List<ProjectResponse>> GetAllProjectAsync()
        {
            List<ProjectResponse> project = [];
            try
            {
                var allProjects = await Constants.projectAPI.GetJsonAsync<List<ProjectResponse>>();
                return allProjects;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                throw new Exception();
            }

            return project;
        }
    }
}
