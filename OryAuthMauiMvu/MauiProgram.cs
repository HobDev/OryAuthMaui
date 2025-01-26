using MauiReactor;
using Microsoft.Extensions.Logging;
using OryAuthMauiMvu.Resources.Styles;
using OryAuthMauiMvu.Pages;


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
 #if DEBUG
          //  .EnableMauiReactorHotReload()
#endif
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
		builder.Services.AddSingleton<OryService>();
		return builder;
	}
}