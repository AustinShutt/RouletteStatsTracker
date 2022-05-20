namespace RouletteStatsTracker.Views;

using RouletteStatsTracker.ViewModels;

public partial class AmericanStatsView : ContentView
{
	AmericanStatsViewModel americanStatsViewModel;
	public AmericanStatsView(AmericanStatsViewModel americanStatsViewModel)
    {
        InitializeComponent();
        BindingContext = this.americanStatsViewModel = americanStatsViewModel;
    }
}