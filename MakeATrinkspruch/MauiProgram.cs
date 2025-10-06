using MakeATrinkspruch.Data;
using MakeATrinkspruch.Interfaces;
using MakeATrinkspruch.Services;
using MakeATrinkspruch.ViewModels;
using MakeATrinkspruch.Views;
using Microsoft.Extensions.Logging;

namespace MakeATrinkspruch;

public static class MauiProgram
{
	public static MauiAppBuilder UseSharedMauiApp(this MauiAppBuilder builder)
	{
		builder
			.UseMauiApp<App>()

			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		//ViewModels
		builder.Services.AddTransient<AboutPageViewModel>();
		builder.Services.AddTransient<FilterPageViewModel>();
		builder.Services.AddTransient<MainPageViewModel>();


		// Pages
		builder.Services.AddTransient<MainPage>();
		builder.Services.AddTransient<FilterPage>();
		builder.Services.AddTransient<AboutPage>();

		//Services
		builder.Services.AddSingleton<IDataService, MakeATrinkspruchDatabase>();
		builder.Services.AddSingleton<FilterState>();


#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder;
	}
}
