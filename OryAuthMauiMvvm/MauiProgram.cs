

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
		builder.Services.AddSingleton<IOryService, OryService>();
		return builder;
	}

	public static MauiAppBuilder ConfigurePages(this MauiAppBuilder builder)
	{
		builder.Services.AddTransient<RegisterPage>();
		return builder;
	}

	public static MauiAppBuilder ConfigureViewModels(this MauiAppBuilder builder)
	{
		builder.Services.AddTransient<RegisterViewModel>();
		return builder;
	}
}
