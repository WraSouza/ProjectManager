using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ProjectManager.Model.InputModel;
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

            Thread.Sleep(1000);

            try
            {
                var allProject = await _repository.GetAllProjectAsync();

                foreach (var project in allProject)
                {
                    if(project.IsFinished == false)
                    {
                        Project newProject = new(project.Id, project.ProjectName, project.UserName, project.FinishedAt.ToShortDateString(), project.DeadLine.ToShortDateString(), project.IdUser, project.IsFinished, project.CreatedAt.ToShortDateString());

                        Projects.Add(newProject);
                    }
                   
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
        public async Task UpdateProjects()
        {
            await GetAllProjects();
        }

        [RelayCommand]
        public async Task GoToAddProjectView()
  => await Shell.Current.GoToAsync(nameof(AddProjectView));

        [RelayCommand]
        public async Task FinishProject(Project project)
        {
            try
            {         
                var newUpdateProject = new FinishProjectInputModel
                {
                    id = project.Id
                };

                bool result = await _repository.FinishProjectAsync(newUpdateProject);

                if (result)
                {
                    var newtoast = Toast.Make("Projeto Finalizado Com Sucesso", CommunityToolkit.Maui.Core.ToastDuration.Long);

                    await newtoast.Show();

                    await GetAllProjects();
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
