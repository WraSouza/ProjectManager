using ProjectManager.ViewModel;

namespace ProjectManager.View;

public partial class AddProjectView : ContentPage
{
	public AddProjectView(AddActivityViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;
    }
}