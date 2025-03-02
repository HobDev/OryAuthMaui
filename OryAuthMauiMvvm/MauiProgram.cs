

using CommunityToolkit.Maui;

namespace OryAuthMauiMvvm;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
            .UseMauiCommunityToolkit()
			.ConfigureServices()
			.ConfigurePages()
			.ConfigureViewModels()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

            builder.Services.AddSingleton<AppShell>();

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}

	 public static MauiAppBuilder ConfigureServices(this MauiAppBuilder builder)
	{
        // app services
		builder.Services.AddSingleton<IRegistrationService, RegistrationService>();
		builder.Services.AddSingleton<ILoginService, LoginService>();
		builder.Services.AddSingleton<IRecoveryService, RecoveryService>();
		builder.Services.AddSingleton<ILogoutService, LogoutService>();
        builder.Services.AddSingleton<INavigationService, MauiNavigationService>();
        builder.Services.AddSingleton<ILoginStatusService, LoginStatusService>();

        // other services
        builder.Services.AddSingleton<ISecureStorage>(SecureStorage.Default);

		return builder;
	}

	public static MauiAppBuilder ConfigurePages(this MauiAppBuilder builder)
	{
		builder.Services.AddTransient<RegisterPage>();
		builder.Services.AddTransient<LoginPage>();
		builder.Services.AddTransient<RecoverPasswordPage>();
		builder.Services.AddTransient<MainPage>();
		return builder;
	}

	public static MauiAppBuilder ConfigureViewModels(this MauiAppBuilder builder)
	{
		builder.Services.AddTransient<RegisterViewModel>();
		builder.Services.AddTransient<LoginViewModel>();
		builder.Services.AddTransient<RecoverPasswordViewModel>();
		builder.Services.AddTransient<MainViewModel>();
		return builder;
	}
}
