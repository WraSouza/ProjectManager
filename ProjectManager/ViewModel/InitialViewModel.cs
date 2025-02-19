using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ProjectManager.Model.ChartModel;
using ProjectManager.Repositories.Projects;
using System.Collections.ObjectModel;

namespace ProjectManager.ViewModel
{
    public partial class InitialViewModel(IProjectRepository repository) : ObservableObject
    {

        public ObservableCollection<ProjectChartData> Projects { get; set; }
            = new ObservableCollection<ProjectChartData>();

        private readonly string updatedProject = "Projetos Em Dia";

        private readonly string delaiedProject = "Projetos Atrasados";

        [ObservableProperty]
        string totalProjects;


        [RelayCommand]
        public async Task GetAllProjects()
        {
            List<ProjectChartData> projects = [];

            Projects.Clear();

            int qtdyProjectsUpdated = 0;

            int qtdyDelaiedProject = 0;

            try
            {
                var allProject = await repository.GetAllProjectAsync();

                TotalProjects = allProject.Count().ToString();

                qtdyProjectsUpdated = allProject.Where(d => d.DeadLine >= DateTime.Now).Count();

                qtdyDelaiedProject = allProject.Where(d => d.DeadLine < DateTime.Now).Count();

                ProjectChartData chartDataUpdated = new(updatedProject, qtdyProjectsUpdated);

                Projects.Add(chartDataUpdated);

                chartDataUpdated = new ProjectChartData(delaiedProject, qtdyDelaiedProject);

                Projects.Add(chartDataUpdated);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Stack Trace: " + ex.Message);
            }


        }
    }
}
