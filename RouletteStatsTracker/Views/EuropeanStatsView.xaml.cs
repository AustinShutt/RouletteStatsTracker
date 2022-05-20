namespace RouletteStatsTracker.Views;

using RouletteStatsTracker.ViewModels;
public partial class EuropeanStatsView : ContentView
{
	EuropeanStatsViewModel europeanStatsViewModel;
	public EuropeanStatsView(EuropeanStatsViewModel europeanStatsViewModel)
	{
		InitializeComponent();

		BindingContext = this.europeanStatsViewModel = europeanStatsViewModel;
	}
}