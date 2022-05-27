namespace RouletteStatsTracker.Views;

using RouletteStatsTracker.ViewModels;
using RouletteStatsTracker.Models;
using RouletteStatsTracker.Helpers;

public partial class AmericanStatsView : ContentView
{
	AmericanStatsViewModel vm;
    
	public AmericanStatsView(AmericanStatsViewModel americanStatsViewModel)
    {
        InitializeComponent();
        BindingContext = this.vm = americanStatsViewModel;
    }

    public void Appearing() {
        radarGraph.SetValues(vm.dataStore.NumberArray);

        RadarSurface.Invalidate();
    }
}