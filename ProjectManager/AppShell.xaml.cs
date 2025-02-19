using ProjectManager.View;

namespace ProjectManager
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(ProjectView), typeof(ProjectView));
            Routing.RegisterRoute(nameof(DetailsProjectView), typeof(DetailsProjectView));
            Routing.RegisterRoute(nameof(LoginView), typeof(LoginView));
            Routing.RegisterRoute(nameof(AddUserView), typeof(AddUserView));
            Routing.RegisterRoute(nameof(AddProjectView), typeof(AddProjectView));
            Routing.RegisterRoute(nameof(AddActivityView), typeof(AddActivityView));
            Routing.RegisterRoute(nameof(InitialView), typeof(InitialView));

        }
    }
}
