namespace RouletteStatsTracker.Views;

using RouletteStatsTracker.ViewModels;

public partial class AmericanStatsView : ContentView
{
	AmericanStatsViewModel vm;
	public AmericanStatsView(AmericanStatsViewModel americanStatsViewModel)
    {
        InitializeComponent();
        BindingContext = this.vm = americanStatsViewModel;
    }


    public void Appearing() {

        redBlackDonut.SetValues(vm.dataStore.Red, vm.dataStore.Black, vm.dataStore.Total);
        evenOddDonut.SetValues(vm.dataStore.Even, vm.dataStore.Odd, vm.dataStore.Total);
        highLowDonut.SetValues(vm.dataStore.High, vm.dataStore.Low, vm.dataStore.Total);

        RedBlackSurface.Invalidate();
        EvenOddSurface.Invalidate();
        HighLowSurface.Invalidate();
    }
}