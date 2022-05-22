namespace RouletteStatsTracker;

using RouletteStatsTracker.Models;
using RouletteStatsTracker.Views;
using RouletteStatsTracker.Pages;
using RouletteStatsTracker.ViewModels;
using RouletteStatsTracker.Helpers;
public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		/**
		 * Summary:
		 * Adding these as singletons with the builder allows constructor dependency injection through the
		 * shell. If we require access to a class of a particular type, try to request it through the 
		 * constructor. If the class is added here, it will be passed to the constructor automatically.
		 */

		builder.Services.AddSingleton<App>();
		//Add Model Singletons
		builder.Services.AddSingleton<DataStore>();
		builder.Services.AddSingleton<Settings>();
		builder.Services.AddSingleton<AmericanDataService>();

		//Add ViewModel Singletons
		builder.Services.AddSingleton<AmericanInputViewModel>();
        builder.Services.AddSingleton<EuropeanInputViewModel>();
        builder.Services.AddSingleton<AmericanStatsViewModel>();
        builder.Services.AddSingleton<EuropeanStatsViewModel>();
		builder.Services.AddSingleton<FlowViewModel>();

        //Add View Singletons
        builder.Services.AddSingleton<AmericanInputView>();
		builder.Services.AddSingleton<EuropeanInputView>();
		builder.Services.AddSingleton<AmericanStatsView>();
        builder.Services.AddSingleton<EuropeanStatsView>();
		//Add Page Singletons
        builder.Services.AddSingleton<ValueInputPage>();
        builder.Services.AddSingleton<FlowPage>();
        builder.Services.AddSingleton<StatsPage>();
        builder.Services.AddSingleton<SettingsPage>();

        return builder.Build();
	}
}
