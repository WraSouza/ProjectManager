using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ProjectManager.Model.InputModel;
using ProjectManager.Repositories.Login;
using ProjectManager.View;

namespace ProjectManager.ViewModel
{
    public partial class LoginViewModel(ILoginRepository repository) : ObservableObject
    {
        [ObservableProperty]
        string email;

        [ObservableProperty]
        string senha;

        [RelayCommand]
        public async Task GoToAddUserlPage()
     => await Shell.Current.GoToAsync(nameof(AddUserView));

        [RelayCommand]
        public async Task GoToInformEmailPage()
    => await Shell.Current.GoToAsync(nameof(InformEmailView));

        [RelayCommand]
        public async Task Login()
        {
            LoginInputModel login = new (email, senha);

            var token = await repository.LoginAsync(login);

            if (token is null)
            {
                await Shell.Current.DisplayAlert("", "Dados Informados Incorretos", "OK");

                return;
            }

            Preferences.Set("Token", token.ToString());

            await Shell.Current.GoToAsync($"//{nameof(MainPage)}");

        }
    }
}
