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
}