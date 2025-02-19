using ProjectManager.ViewModel;

namespace ProjectManager.View;

public partial class LoginView : ContentPage
{
	public LoginView(LoginViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;
	}
}