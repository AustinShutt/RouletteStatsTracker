namespace RouletteStatsTracker.Pages;

using RouletteStatsTracker.Views;
using RouletteStatsTracker.Helpers;
using RouletteStatsTracker.ViewModels;
using RouletteStatsTracker.Models;
public partial class StatsPage : ContentPage
{
    AmericanStatsView americanStatsView;
    EuropeanStatsView europeanStatsView;
    AmericanStatsViewModel vm;
    Settings Settings { get; set; }

    Settings.GameType type;

	public StatsPage()
	{
		InitializeComponent();

        americanStatsView = ServiceHelper.GetService<AmericanStatsView>();
        europeanStatsView = ServiceHelper.GetService<EuropeanStatsView>();
        vm = ServiceHelper.GetService<AmericanStatsViewModel>();
        Settings = ServiceHelper.GetService<Settings>();

        SetGameType(Settings.gameType);
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();

        if (type != Settings.gameType)
        {
            SetGameType(Settings.gameType);
            type = Settings.gameType;
        }

        americanStatsView.Appearing();
        europeanStatsView.Appearing();

        redBlackDonut.SetValues(vm.dataStore.Red, vm.dataStore.Black, vm.dataStore.Total);
        evenOddDonut.SetValues(vm.dataStore.Even, vm.dataStore.Odd, vm.dataStore.Total);
        highLowDonut.SetValues(vm.dataStore.High, vm.dataStore.Low, vm.dataStore.Total);

        columnTribar.SetValues(vm.dataStore.Column1, vm.dataStore.Column2, vm.dataStore.Column3, vm.dataStore.Total);
        thirdsTribar.SetValues(vm.dataStore.Third1, vm.dataStore.Third2, vm.dataStore.Third3, vm.dataStore.Total);

        RedBlackSurface.Invalidate();
        EvenOddSurface.Invalidate();
        HighLowSurface.Invalidate();
        ColumnSurface.Invalidate();
        ThirdsSurface.Invalidate();
    }

    private void SetGameType(Settings.GameType type)
    {
        radarView.Clear();

        if (type == Settings.GameType.AMERICAN)
            radarView.Add(americanStatsView);
        else
            radarView.Add(europeanStatsView);

        (radarView as IView).InvalidateArrange();
    }
}