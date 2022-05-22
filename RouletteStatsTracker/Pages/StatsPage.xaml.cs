namespace RouletteStatsTracker.Pages;

using RouletteStatsTracker.Views;
using RouletteStatsTracker.Helpers;
public partial class StatsPage : ContentPage
{
    AmericanStatsView americanStatsView;
    EuropeanStatsView europeanStatsView;

	public StatsPage()
	{
		InitializeComponent();

        americanStatsView = ServiceHelper.GetService<AmericanStatsView>();
        europeanStatsView = ServiceHelper.GetService<EuropeanStatsView>();

        SetToAmerican();
	}

    public void SetToAmerican()
    {
        baseLayout.Clear();
        baseLayout.Add(americanStatsView);
    }

    public void SetToEuropean()
    {
        baseLayout.Clear();
        baseLayout.Add(europeanStatsView);
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        americanStatsView.Appearing();
    }
}