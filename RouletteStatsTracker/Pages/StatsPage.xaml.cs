namespace RouletteStatsTracker.Pages;

using RouletteStatsTracker.Views;
using RouletteStatsTracker.Helpers;
using RouletteStatsTracker.ViewModels;
using RouletteStatsTracker.Models;
using RouletteStatsTracker.Graphs;
using Microsoft.Maui.Controls;

public partial class StatsPage : ContentPage
{
    StatsViewModel vm;
    Settings Settings { get; set; }

	public StatsPage()
	{
		InitializeComponent();

        vm = ServiceHelper.GetService<StatsViewModel>();
        Settings = ServiceHelper.GetService<Settings>();
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();

        redBlackDonut.SetValues(vm.dataStore.Red, vm.dataStore.Black, vm.dataStore.Total);
        evenOddDonut.SetValues(vm.dataStore.Even, vm.dataStore.Odd, vm.dataStore.Total);
        highLowDonut.SetValues(vm.dataStore.High, vm.dataStore.Low, vm.dataStore.Total);

        columnTribar.SetValues(vm.dataStore.Column1, vm.dataStore.Column2, vm.dataStore.Column3, vm.dataStore.Total);
        thirdsTribar.SetValues(vm.dataStore.Third1, vm.dataStore.Third2, vm.dataStore.Third3, vm.dataStore.Total);
        radarGraph.SetValues(vm.dataStore.NumberArray, Settings.gameType == Settings.GameType.AMERICAN);

        RedBlackSurface.Invalidate();
        EvenOddSurface.Invalidate();
        HighLowSurface.Invalidate();
        ColumnSurface.Invalidate();
        ThirdsSurface.Invalidate();
        RadarSurface.Invalidate();
    }
}