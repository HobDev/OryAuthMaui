using MauiReactor;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using OryAuthNetMaui.Resources.Styles;

namespace OryAuthNetMaui;

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
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

#if DEBUG
		builder.Logging.AddDebug();
		 builder.Services.AddLogging(configure => configure.AddDebug());
#endif

		return builder.Build();
	}
}
