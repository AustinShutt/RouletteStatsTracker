namespace RouletteStatsTracker.Views;

using RouletteStatsTracker.ViewModels;
using RouletteStatsTracker.Pages;
public partial class AmericanInputView : ContentView
{
	InputViewModel americanInputViewModel;

	public AmericanInputView(InputViewModel americanInputViewModel)
    {
        InitializeComponent();
        BindingContext = this.americanInputViewModel = americanInputViewModel;
    }

    private async void SettingsButton_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(SettingsPage));
    }
}