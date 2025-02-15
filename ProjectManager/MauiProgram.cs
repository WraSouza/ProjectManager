using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using ProjectManager.Repositories.Activities;
using ProjectManager.Repositories.Projects;
using ProjectManager.Repositories.Users;
using ProjectManager.View;
using ProjectManager.ViewModel;
using Syncfusion.Maui.Toolkit.Hosting;
using UraniumUI;

namespace ProjectManager;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureSyncfusionToolkit()
            .UseUraniumUI()
            .UseUraniumUIMaterial()
            .ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("Montserrat-SemiBold.ttf", "MontserratSemibold");
                fonts.AddFont("Montserrat-Bold.ttf", "MontserratBold");
                fonts.AddFont("Montserrat-Medium.ttf", "MontserratMedium");
                fonts.AddFont("Montserrat-Regular.ttf", "MontserratRegular");
            });

#if DEBUG
		builder.Logging.AddDebug();
#endif

		builder.Services.AddSingleton<IProjectRepository, ProjectRepository>();
        builder.Services.AddSingleton<IUserRepository, UserRepository>();
        builder.Services.AddSingleton<IActivitiesRepository, ActivitiesRepository>();

        builder.Services.AddSingleton<ProjectViewModel>();
        builder.Services.AddSingleton<LoginViewModel>();
        builder.Services.AddSingleton<AddUserViewModel>();
        builder.Services.AddSingleton<DetailsProjectViewModel>();
        builder.Services.AddSingleton<AddProjectViewModel>();
        builder.Services.AddSingleton<InformEmailViewModel>();
        builder.Services.AddSingleton<AddActivityViewModel>();


        builder.Services.AddSingleton<ProjectView>();
        builder.Services.AddSingleton<InformEmailView>();
        builder.Services.AddSingleton<DetailsProjectView>();
        builder.Services.AddSingleton<LoginView>();
        builder.Services.AddSingleton<AddUserView>();
        builder.Services.AddSingleton<AddProjectView>();
        builder.Services.AddSingleton<AddActivityView>();

        return builder.Build();
	}
}
