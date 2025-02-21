using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ProjectManager.Model.ActivityModel;
using ProjectManager.Model.InputModel;
using ProjectManager.Model.ProjectModel;
using ProjectManager.Model.ResponseModel;
using ProjectManager.Repositories.Activities;
using ProjectManager.View;
using System.Collections.ObjectModel;

namespace ProjectManager.ViewModel
{
    [QueryProperty(nameof(ChoosenProject), nameof(ChoosenProject))]
    public partial class DetailsProjectViewModel() : ObservableObject
    {
        public ObservableCollection<Atividade> Activities { get; set; }
       = new ObservableCollection<Atividade>();

        private readonly IActivitiesRepository _repository;
        public DetailsProjectViewModel(IActivitiesRepository repository) : this()
        {
            _repository = repository;
        }


        private Project _project;
        public Project ChoosenProject
        {
            get => _project;
            set
            {
                SetProperty(ref _project, value);

                if (value != null)
                {
                    ProjectName = value.ProjectName;
                    Owner = value.UserName;
                    DeadLine = value.DeadLine;
                    id = value.Id;

                }
            }
        }

        [ObservableProperty]
        int id;

        [ObservableProperty]
        string? projectName;

        [ObservableProperty]
        string? owner;

        [ObservableProperty]
        string? deadLine;

        [ObservableProperty]
        double totalActivity;

        [ObservableProperty]
        double totalUpdatedActivities;

        [RelayCommand]
        public async Task GetActivities()
        {
            Activities.Clear();

            try
            {
                var activities = await _repository.GetAllActivitiesByIdProjectAsync(id);

                TotalActivity = activities.Count;

                TotalUpdatedActivities = activities.Where(x => x.DeadLine >= DateTime.Today).Count();

                foreach (var activity in activities)
                {
                    Atividade newActivity = new()
                    {
                        Id = activity.Id,
                        ActivityName = activity.ActivityName,
                        UserName = activity.UserName,
                        ProjectName = activity.ProjectName,
                        DeadLine = activity.DeadLine.ToShortDateString(),
                        FinishedAt = activity.FinishedAt.ToShortDateString()
                    };

                    Activities.Add(newActivity);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        [RelayCommand]
        public async Task FinishActivity(Atividade atividade)
        {
            try
            {
                var newUpdateActivity = new FinishActivityInputModel
                {
                    Id = atividade.Id
                };

                bool result = await _repository.FinishActivityAsync(newUpdateActivity);

                if (result)
                {
                    var newtoast = Toast.Make("Atividade Finalizada Com Sucesso", CommunityToolkit.Maui.Core.ToastDuration.Long);

                    await newtoast.Show();

                    await GetActivities();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        [RelayCommand]
        public async Task GoToAddProjectView()
 => await Shell.Current.GoToAsync(nameof(AddActivityView));
    }
}
