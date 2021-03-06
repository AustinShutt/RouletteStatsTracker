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
		builder.Services.AddSingleton<UtilityDataService>();

		//Add ViewModel Singletons
		builder.Services.AddSingleton<InputViewModel>();
        builder.Services.AddSingleton<StatsViewModel>();
		builder.Services.AddSingleton<FlowViewModel>();

        //Add View Singletons
        builder.Services.AddSingleton<AmericanInputView>();
		builder.Services.AddSingleton<EuropeanInputView>();
		//Add Page Singletons
        builder.Services.AddSingleton<ValueInputPage>();
        builder.Services.AddSingleton<FlowPage>();
		builder.Services.AddSingleton<CTFlowPage>();
        builder.Services.AddSingleton<StatsPage>();
        builder.Services.AddSingleton<SettingsPage>();

        return builder.Build();
	}
}
