namespace RouletteStatsTracker.Views;

using RouletteStatsTracker.ViewModels;
using RouletteStatsTracker.Pages;

public partial class EuropeanInputView : ContentView
{
	AmericanInputViewModel americanInputViewModel;
	public EuropeanInputView(AmericanInputViewModel americanInputViewModel)
    {
        InitializeComponent();

        BindingContext = this.americanInputViewModel = americanInputViewModel;
    }
    
    private async void SettingsButton_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(SettingsPage));
    }
}