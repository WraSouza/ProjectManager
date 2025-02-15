using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ProjectManager.Model.InputModel;
using ProjectManager.Model.ProjectModel;
using ProjectManager.Repositories.Activities;
using ProjectManager.Repositories.Projects;
using ProjectManager.Repositories.Users;
using System.Collections.ObjectModel;

namespace ProjectManager.ViewModel
{
    [QueryProperty(nameof(ChoosenProject), nameof(ChoosenProject))]
    public partial class AddActivityViewModel(IUserRepository userRepository,IProjectRepository projectRepository, IActivitiesRepository activityRepository) : ObservableObject
    {
        public ObservableCollection<string> Users { get; set; }
       = new ObservableCollection<string>();

        private Project _project;
        public Project ChoosenProject
        {
            get => _project;
            set
            {
                SetProperty(ref _project, value);

                if (value != null)
                {
                    projectName = value.ProjectName;                   

                }
            }
        }        

        [ObservableProperty]
        string? projectName;       

        [ObservableProperty]
        string activityName;

        [ObservableProperty]
        string owner;

        [ObservableProperty]
        DateTime deadLine = DateTime.Today;

        [RelayCommand]
        public async Task GetAllUserss()
        {
            var allUsers = await userRepository.GetAllUsersAsync();

            foreach (var user in allUsers)
            {
                Users.Add(user.FullName);
            }
        }

        [RelayCommand]
        public async Task AddActivity()
        {
            if (!string.IsNullOrEmpty(ActivityName) && Owner is not null)
            {
                if (DeadLine < DateTime.Today)
                {
                    await Shell.Current.DisplayAlert("Erro", "A data selecionada deve ser maior ou igual a data de hoje.", "OK");
                }
                else
                {
                    int idUser = 0;

                    var allUsers = await userRepository.GetAllUsersAsync();

                    foreach (var user in allUsers)
                    {
                        if (user.FullName == owner)
                        {
                            idUser = user.Id;
                        }
                    }

                    string nameProject = Preferences.Get("ProjectName", "default_value");

                    int idProject = 0;

                    var allProjects = await projectRepository.GetAllProjectAsync();

                    foreach (var project in allProjects)
                    {
                        if (project.ProjectName == nameProject)
                        {
                            idProject = project.Id;
                        }
                    }

                    ActivityInputModel newActivity = new(ActivityName,idUser,idProject, DeadLine);

                    bool result = await activityRepository.AddActivityAsync(newActivity);

                    if (result)
                    {
                        Preferences.Clear();

                        var newtoast = Toast.Make("Atividade Cadastrada Com Sucesso", CommunityToolkit.Maui.Core.ToastDuration.Long);

                        await newtoast.Show();

                        await Shell.Current.GoToAsync("..");
                    }
                }

            }
            else
            {
                await Shell.Current.DisplayAlert("Erro", "Os Campos Devem Ser Preenchidos", "OK");
            }

        }
    }
}
