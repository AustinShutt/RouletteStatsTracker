namespace RouletteStatsTracker.Views;

using RouletteStatsTracker.ViewModels;
public partial class EuropeanStatsView : ContentView
{
	StatsViewModel vm;
	public EuropeanStatsView(StatsViewModel vm)
	{
		InitializeComponent();

		BindingContext = this.vm = vm;
	}

    public void Appearing()
    {
        EradarGraph.SetValues(vm.dataStore.NumberArray);

        RadarSurface.Invalidate();
    }
}