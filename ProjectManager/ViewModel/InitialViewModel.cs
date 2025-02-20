using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ProjectManager.Model.ChartModel;
using ProjectManager.Model.ProjectModel;
using ProjectManager.Model.ResponseModel;
using ProjectManager.Repositories.Projects;
using System.Collections.ObjectModel;

namespace ProjectManager.ViewModel
{
    public partial class InitialViewModel(IProjectRepository repository) : ObservableObject
    {

        public ObservableCollection<ProjectChartData> Projects { get; set; }
            = new ObservableCollection<ProjectChartData>();

        List<Project> allProjectInitial = [];

        private readonly string updatedProject = "Projetos Em Dia";

        private readonly string delaiedProject = "Projetos Atrasados";

        [ObservableProperty]
        string totalProjects;

        [ObservableProperty]
        string owner;

        [ObservableProperty]
        string projectName;

        [ObservableProperty]
        string deadLine;

        [ObservableProperty]
        string totalProjectsForActualMonth;

        [ObservableProperty]
        string totalProjectForToday;

        [ObservableProperty]
        string qtdyProjectsFinishedCurrentMonth;


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

                qtdyProjectsUpdated = allProject.Where(d => d.DeadLine >= DateTime.Now && d.IsFinished == false).Count();

                qtdyDelaiedProject = allProject.Where(d => d.DeadLine < DateTime.Now && d.IsFinished == false).Count();

                TotalProjectsForActualMonth = allProject.Where(d => d.DeadLine.Month == DateTime.Now.Month && d.IsFinished == false).Count().ToString();

                TotalProjectForToday = allProject.Where(d => d.DeadLine == DateTime.Today && d.IsFinished == false).Count().ToString();

                QtdyProjectsFinishedCurrentMonth = allProject.Where(d => d.FinishedAt.Month == DateTime.Now.Month && d.IsFinished == true).Count().ToString();

                ProjectChartData chartDataUpdated = new(updatedProject, qtdyProjectsUpdated);

                Projects.Add(chartDataUpdated);

                chartDataUpdated = new ProjectChartData(delaiedProject, qtdyDelaiedProject);

                Projects.Add(chartDataUpdated);

                //Preencher a tela com o mais novo projeto mais novo cadastrado
                for(int i = 0; i < allProject.Count; i++)
                {
                    if (i == 0)
                    {
                        Project projectResponse = new Project(allProject[i].Id,allProject[i].ProjectName, allProject[i].UserName, allProject[i].FinishedAt.ToShortDateString(), allProject[i].DeadLine.ToShortDateString(), allProject[i].IdUser, allProject[i].IsFinished, allProject[i].CreatedAt.ToShortDateString());

                        allProjectInitial.Add(projectResponse);
                    }
                    else
                    {
                        if (DateTime.Today - allProject[i].CreatedAt  < DateTime.Today - allProject[0].CreatedAt)
                        {
                            Project projectResponse = new Project(allProject[i].Id, allProject[i].ProjectName, allProject[i].UserName, allProject[i].FinishedAt.ToShortDateString(), allProject[i].DeadLine.ToShortDateString(), allProject[i].IdUser, allProject[i].IsFinished, allProject[i].CreatedAt.ToShortDateString());

                            allProjectInitial.Add(projectResponse);
                        }
                    }
                }

                foreach(var project in allProjectInitial)
                {
                   
                        Owner = project.UserName;
                        ProjectName = project.ProjectName;
                        DeadLine = project.DeadLine;
                    
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine("Stack Trace: " + ex.Message);
            }


        }
    }
}
