using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ProjectManager.Model.Password;
using ProjectManager.Repositories.Login;

namespace ProjectManager.ViewModel
{
    public partial class InformEmailViewModel(ILoginRepository repository) : ObservableObject
    {
        [ObservableProperty]
        string? email;

        [RelayCommand]
        public async Task SendEmail()
        {
            var emailRecovery = new PasswordRecoveryCode
            {
                Email = email
            };

            Preferences.Set("EmailUser", email);

            repository.RequestCode(emailRecovery);

            await Shell.Current.DisplayAlert("", "Se o E-mail Informado Estiver em Nosso Cadastro, Você Receberá Uma Nova Senha de Acesso.", "OK");

            await Shell.Current.GoToAsync("..");
        }
    }
}
