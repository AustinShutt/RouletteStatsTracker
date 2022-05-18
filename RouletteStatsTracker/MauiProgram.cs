namespace RouletteStatsTracker;

using RouletteStatsTracker.Models;
using RouletteStatsTracker.Views;
using RouletteStatsTracker.Pages;
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

		builder.Services.AddSingleton<App>();
		builder.Services.AddSingleton<DataStore>();
		builder.Services.AddSingleton<Settings>();
		builder.Services.AddSingleton<AmericanInputView>();
		builder.Services.AddSingleton<EuropeanInputView>();
		builder.Services.AddSingleton<ValueInputPage>();

		return builder.Build();
	}
}
