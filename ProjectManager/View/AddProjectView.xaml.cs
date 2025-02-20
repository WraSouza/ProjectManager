using ProjectManager.ViewModel;
using Syncfusion.Maui.Toolkit.Carousel;

namespace ProjectManager.View;

public partial class AddProjectView : ContentPage
{
    private readonly AddProjectViewModel _viewModel;

    public AddProjectView(AddProjectViewModel viewModel)
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