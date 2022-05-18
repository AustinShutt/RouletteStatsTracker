namespace RouletteStatsTracker.Pages;

using RouletteStatsTracker.Views;
using RouletteStatsTracker.Models;
public partial class ValueInputPage : ContentPage
{
	AmericanInputView americanInputView;
	EuropeanInputView europeanInputView;

	public ValueInputPage(AmericanInputView americanInputView, EuropeanInputView europeanInputView)
    {
        InitializeComponent();

        this.americanInputView = americanInputView;
        this.europeanInputView = europeanInputView;

        baseLayout.Clear();
        baseLayout.Add(europeanInputView);
    }
}