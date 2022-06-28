namespace RouletteStatsTracker.Pages;

using RouletteStatsTracker.Views;
using RouletteStatsTracker.Models;
using RouletteStatsTracker.Helpers;
using RouletteStatsTracker.ViewModels;

public partial class ValueInputPage : ContentPage
{
	AmericanInputView americanInputView;
	EuropeanInputView europeanInputView;
    InputViewModel vm;

    Settings Settings { get; set; }
    Settings.GameType GameType { get; set; }

	public ValueInputPage(AmericanInputView americanInputView, EuropeanInputView europeanInputView)
    {
        InitializeComponent();

        Settings = ServiceHelper.GetService<Settings>();

        this.americanInputView = americanInputView;
        this.europeanInputView = europeanInputView;

        this.BindingContext = vm = ServiceHelper.GetService<InputViewModel>();

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

    private async void SettingsButton_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(SettingsPage));
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        if(GameType != Settings.gameType)
        {
            SetGameType(Settings.gameType);
            GameType = Settings.gameType;
        }

        Task.Run(async delegate         //Todo: Very hacked solution, allows the entire page to load before setting the height of the element
        {
            await Task.Delay(1000);
            vm.SetMaxElements(sideBar.Height);
        });
    }
}