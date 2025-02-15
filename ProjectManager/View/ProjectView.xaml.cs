using ProjectManager.ViewModel;

namespace ProjectManager.View;

public partial class ProjectView : ContentPage
{
    private readonly ProjectViewModel _viewModel;
    public ProjectView(ProjectViewModel viewModel)
	{
		InitializeComponent();

        BindingContext = _viewModel = viewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await _viewModel.GetAllProjects();
    }
}