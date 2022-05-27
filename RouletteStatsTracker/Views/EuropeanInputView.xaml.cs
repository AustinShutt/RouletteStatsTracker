namespace RouletteStatsTracker.Views;

using RouletteStatsTracker.ViewModels;
using RouletteStatsTracker.Pages;

public partial class EuropeanInputView : ContentView
{
	InputViewModel americanInputViewModel;
	public EuropeanInputView(InputViewModel americanInputViewModel)
    {
        InitializeComponent();

        BindingContext = this.americanInputViewModel = americanInputViewModel;
    }
    
    private async void SettingsButton_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(SettingsPage));
    }
}