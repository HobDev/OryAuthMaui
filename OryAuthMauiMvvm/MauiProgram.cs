

namespace OryAuthMauiMvvm;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureServices()
			.ConfigurePages()
			.ConfigureViewModels()
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
		builder.Services.AddSingleton<IRegistrationService, RegistrationService>();
		builder.Services.AddSingleton<ILoginService, LoginService>();
		builder.Services.AddSingleton<IForgotPasswordService, ForgotPasswordService>();
		builder.Services.AddSingleton<IChangePasswordService, ChangePasswordService>();
		builder.Services.AddSingleton<ILogoutService, LogoutService>();
        builder.Services.AddSingleton<INavigationService, MauiNavigationService>();
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

	public static MauiAppBuilder ConfigureViewModels(this MauiAppBuilder builder)
	{
		builder.Services.AddTransient<RegisterViewModel>();
		builder.Services.AddTransient<LoginViewModel>();
		builder.Services.AddTransient<ForgotPasswordViewModel>();
		builder.Services.AddTransient<ChangePasswordViewModel>();
		builder.Services.AddTransient<MainViewModel>();
		return builder;
	}
}
