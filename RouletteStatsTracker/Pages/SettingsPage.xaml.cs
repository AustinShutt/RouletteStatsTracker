namespace RouletteStatsTracker.Pages;

using RouletteStatsTracker.Models;
using RouletteStatsTracker.Helpers;
public partial class SettingsPage : ContentPage
{
	Settings Settings { get; set; }

	public SettingsPage()
	{
		InitializeComponent();

		Settings = ServiceHelper.GetService<Settings>();
	}

    private void CheckedChanged_American(object sender, CheckedChangedEventArgs e)
    {
        Settings.gameType = Settings.GameType.AMERICAN;
    }

    private void CheckedChanged_European(object sender, CheckedChangedEventArgs e)
    {
        Settings.gameType = Settings.GameType.EUROPEAN;
    }

    private void SaveSettingsEvent(object sender, EventArgs e)
    {
        if (Settings.gameType == Settings.GameType.AMERICAN)
            Preferences.Default.Set("GameType", "AMERICAN");
        else
            Preferences.Default.Set("GameType", "EUROPEAN");
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        if (Settings.gameType == Settings.GameType.AMERICAN)
            AmericanOption.IsChecked = true;
        else
            EuropeanOption.IsChecked = true;
    }
}