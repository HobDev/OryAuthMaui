using MauiReactor;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using OryAuthNetMaui.Resources.Styles;
using Ory.Client.Api;
using Ory.Client.Client;
using OryAuthNetMaui.Services;

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
			.ConfigureServices()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

#if DEBUG
		builder.Logging.AddDebug();
		 builder.Services.AddLogging(configure => configure.AddDebug());
#endif

//         var oryBasePath = builder.Configuration.GetValue<string>("ORY_BASEPATH") ?? "http://localhost:4000";
// var ory = new FrontendApi(new Configuration
// {
// 	BasePath = oryBasePath
// });



		return builder.Build();
	}


	public static MauiAppBuilder ConfigureServices(this MauiAppBuilder builder)
	{
		builder.Services.AddSingleton<OryService>();
		return builder;
	}
	
}
