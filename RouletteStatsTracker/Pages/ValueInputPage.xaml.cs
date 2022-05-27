namespace RouletteStatsTracker.Pages;

using RouletteStatsTracker.Views;
using RouletteStatsTracker.Models;
using RouletteStatsTracker.Helpers;
using RouletteStatsTracker.ViewModels;

public partial class ValueInputPage : ContentPage
{
	AmericanInputView americanInputView;
	EuropeanInputView europeanInputView;
    AmericanInputViewModel vm;

    Settings Settings { get; set; }
    Settings.GameType GameType { get; set; }

	public ValueInputPage(AmericanInputView americanInputView, EuropeanInputView europeanInputView)
    {
        InitializeComponent();

        Settings = ServiceHelper.GetService<Settings>();

        this.americanInputView = americanInputView;
        this.europeanInputView = europeanInputView;

        this.BindingContext = vm = ServiceHelper.GetService<AmericanInputViewModel>();

        SetGameType(Settings.gameType);
    }

    private void SetGameType(Settings.GameType type)
    {
        baseLayout.Clear();

        if (type == Settings.GameType.AMERICAN)
            baseLayout.Add(americanInputView);
        else
            baseLayout.Add(europeanInputView);

        (baseLayout as IView).InvalidateArrange();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        if(GameType != Settings.gameType)
        {
            SetGameType(Settings.gameType);
            GameType = Settings.gameType;
        }
    }
}