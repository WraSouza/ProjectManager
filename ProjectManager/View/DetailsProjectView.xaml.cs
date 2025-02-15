using ProjectManager.ViewModel;

namespace ProjectManager.View;

public partial class DetailsProjectView : ContentPage
{
    private readonly DetailsProjectViewModel _viewModel;

    public DetailsProjectView(DetailsProjectViewModel viewModel)
	{
		InitializeComponent();

        BindingContext = _viewModel = viewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await _viewModel.GetActivities();
    }
}