using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ProjectManager.Model.ProjectModel;
using ProjectManager.Repositories.Projects;
using ProjectManager.View;
using System.Collections.ObjectModel;

namespace ProjectManager.ViewModel
{
    public partial class ProjectViewModel : ObservableObject
    {
        private readonly IProjectRepository _repository;

        public ObservableCollection<Project> Projects { get; set; }
        = new ObservableCollection<Project>();

        public ProjectViewModel(IProjectRepository repository)
        {
            _repository = repository;
        }

        [RelayCommand]
        public async Task GetAllProjects()
        {
            Projects.Clear();

            try
            {
                var allProject = await _repository.GetAllProjectAsync();

                foreach (var project in allProject)
                {
                    Project newProject = new(project.Id, project.ProjectName, project.UserName, project.FinishedAt.ToShortDateString(), project.DeadLine.ToShortDateString(), project.IdUser, project.IsFinished);

                    Projects.Add(newProject);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        [RelayCommand]
        public async Task GoToDetailsProjectPage(Project project)
        {
            try
            {
                var navigationParams = new Dictionary<string, object>
                {
                    {"ChoosenProject", project }
                };

                Preferences.Set("ProjectName", project.ProjectName);

                await Shell.Current.GoToAsync(nameof(DetailsProjectView), navigationParams);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        [RelayCommand]
        public async Task GoToAddProjectView()
  => await Shell.Current.GoToAsync(nameof(AddProjectView));
    }
}
