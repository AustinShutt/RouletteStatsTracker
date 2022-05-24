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

        columnTribar.SetValues(vm.dataStore.Column1, vm.dataStore.Column2, vm.dataStore.Column3, vm.dataStore.Total);
        thirdsTribar.SetValues(vm.dataStore.Third1, vm.dataStore.Third2, vm.dataStore.Third3, vm.dataStore.Total);

        radarGraph.SetValues(vm.dataStore.NumberArray);

        RedBlackSurface.Invalidate();
        EvenOddSurface.Invalidate();
        HighLowSurface.Invalidate();
        ColumnSurface.Invalidate();
        ThirdsSurface.Invalidate();
        RadarSurface.Invalidate();
    }
}