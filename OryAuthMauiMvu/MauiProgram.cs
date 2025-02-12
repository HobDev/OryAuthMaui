using MauiReactor;
using Microsoft.Extensions.Logging;
using OryAuthMauiMvu.Resources.Styles;
using OryAuthMauiMvu.Pages;
using OryAuthMauiShared.Services.Interfaces;




namespace OryAuthMauiMvu;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
             .UseMauiReactorApp<AppShell>(app =>
            {
               app.UseTheme<AppTheme>();
            })
			.ConfigureServices()
            .ConfigurePages()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

            

#if DEBUG
    		builder.Logging.AddDebug();
#endif

        return builder.Build();
    }

    public static MauiAppBuilder ConfigureServices(this MauiAppBuilder builder)
	{
        // app services
		builder.Services.AddSingleton<IRegistrationService,RegistrationService>();
		builder.Services.AddSingleton<ILoginService,LoginService>();
		builder.Services.AddSingleton<IChangePasswordService,ChangePasswordService>();
		builder.Services.AddSingleton<IForgotPasswordService,ForgotPasswordService>();
		builder.Services.AddSingleton<ILogoutService,LogoutService>();
        builder.Services.AddSingleton<INavigationService, MauiNavigationService>();

        // other services
        builder.Services.AddSingleton<ISecureStorage>(SecureStorage.Default);

        return builder;
	}

    public static MauiAppBuilder ConfigurePages(this MauiAppBuilder builder)
	{
		builder.Services.AddTransient<RegisterPage>();
		builder.Services.AddTransient<LoginPage>();
		builder.Services.AddTransient<ForgotPasswordPage>();
		builder.Services.AddTransient<ChangePasswordPage>();
		builder.Services.AddTransient<MainPage>();
		return builder;
	}
}