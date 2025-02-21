using ProjectManager.ViewModel;

namespace ProjectManager.View;

public partial class AddUserView : ContentPage
{
	public AddUserView(AddUserViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;

    }
}