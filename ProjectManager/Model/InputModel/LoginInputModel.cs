namespace ProjectManager.Model.InputModel
{
    public class LoginInputModel
    {
        public LoginInputModel()
        {

        }
        public LoginInputModel(string email, string password)
        {
            Email = email;
            Password = password;
        }

        public string Email { get; private set; }
        public string Password { get; private set; }
    }
}
