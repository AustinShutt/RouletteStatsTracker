namespace RouletteStatsTracker.Views;

using RouletteStatsTracker.ViewModels;
using RouletteStatsTracker.Models;
using RouletteStatsTracker.Helpers;

public partial class AmericanStatsView : ContentView
{
	StatsViewModel vm;
    
	public AmericanStatsView(StatsViewModel vm)
    {
        InitializeComponent();
        BindingContext = this.vm = vm;
    }

    public void Appearing() {
        radarGraph.SetValues(vm.dataStore.NumberArray);

        RadarSurface.Invalidate();
    }
}