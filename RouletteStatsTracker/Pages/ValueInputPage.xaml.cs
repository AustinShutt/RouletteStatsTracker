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

        SetToAmerican();
    }

    public void SetToAmerican()
    {
        baseLayout.Clear();
        baseLayout.Add(americanInputView);
    }

    public void SetToEuropean()
    {
        baseLayout.Clear();
        baseLayout.Add(europeanInputView);
    }
}