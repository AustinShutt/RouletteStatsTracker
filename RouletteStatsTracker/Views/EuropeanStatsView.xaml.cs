namespace RouletteStatsTracker.Views;

using RouletteStatsTracker.ViewModels;
public partial class EuropeanStatsView : ContentView
{
	AmericanStatsViewModel vm;
	public EuropeanStatsView(AmericanStatsViewModel europeanStatsViewModel)
	{
		InitializeComponent();

		BindingContext = this.vm = europeanStatsViewModel;
	}

    public void Appearing()
    {
        EradarGraph.SetValues(vm.dataStore.NumberArray);

        RadarSurface.Invalidate();
    }
}