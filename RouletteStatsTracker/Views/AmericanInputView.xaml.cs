namespace RouletteStatsTracker.Views;

using RouletteStatsTracker.ViewModels;
public partial class AmericanInputView : ContentView
{
	AmericanInputViewModel americanInputViewModel;

	public AmericanInputView(AmericanInputViewModel americanInputViewModel)
    {
        InitializeComponent();
        BindingContext = this.americanInputViewModel = americanInputViewModel;
    }
}