using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ProjectManager.Model.InputModel;
using ProjectManager.Repositories.Projects;
using ProjectManager.Repositories.Users;
using System.Collections.ObjectModel;

namespace ProjectManager.ViewModel
{
    public partial class AddUserViewModel(IUserRepository userRepository, IProjectRepository projectRepository) : ObservableObject
    {
        public ObservableCollection<string> Users { get; set; }
        = new ObservableCollection<string>();

        [ObservableProperty]
        string? projectName;

        [ObservableProperty]
        string? owner;

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
        public async Task AddProject()
        {
            if (!string.IsNullOrEmpty(ProjectName) && Owner is not null)
            {
                if (DeadLine < DateTime.Today)
                {
                    await Shell.Current.DisplayAlert("Erro", "A data selecionada deve ser maior ou igual a data de hoje.", "OK");
                }
                else
                {
                    int id = 0;

                    var allUsers = await userRepository.GetAllUsersAsync();

                    foreach (var user in allUsers)
                    {
                        if (user.FullName == Owner)
                        {
                            id = user.Id;
                        }
                    }

                    ProjectInputModel newProject = new(ProjectName.ToUpper(), DeadLine, id);

                    bool result = await projectRepository.AddProjectAsync(newProject);

                    if (result)
                    {
                        var newtoast = Toast.Make("Projeto Cadastrado Com Sucesso", CommunityToolkit.Maui.Core.ToastDuration.Long);

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
