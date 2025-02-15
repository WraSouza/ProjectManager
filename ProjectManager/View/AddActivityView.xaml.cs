using ProjectManager.ViewModel;

namespace ProjectManager.View;

public partial class AddActivityView : ContentPage
{
    private readonly AddActivityViewModel _viewModel;

    public AddActivityView(AddActivityViewModel viewModel)
	{
		InitializeComponent();

        BindingContext = _viewModel = viewModel;

    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await _viewModel.GetAllUserss();
    }
}