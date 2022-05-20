namespace RouletteStatsTracker.Views;

using RouletteStatsTracker.ViewModels;
public partial class EuropeanInputView : ContentView
{
	EuropeanInputViewModel europeanInputViewModel;
	public EuropeanInputView(EuropeanInputViewModel europeanInputViewModel)
    {
        InitializeComponent();

        BindingContext = this.europeanInputViewModel = europeanInputViewModel;
    }
}