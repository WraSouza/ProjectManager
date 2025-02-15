namespace ProjectManager.Model.UserModel
{
    public class User
    {
        public User(string fullName, string email, string password)
        {
            FullName = fullName;
            Email = email;
            Password = password;
        }


        public string FullName { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
    }
}
