using ProjectManager.ViewModel;

namespace ProjectManager.View;

public partial class InformEmailView : ContentPage
{
	public InformEmailView(InformEmailViewModel viewModel)
	{
		InitializeComponent();

        BindingContext = viewModel;
    }
}