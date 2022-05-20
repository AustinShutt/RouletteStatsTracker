namespace RouletteStatsTracker.Pages;

using RouletteStatsTracker.ViewModels;

public partial class FlowPage : ContentPage
{
	FlowViewModel flowViewModel;
	public FlowPage(FlowViewModel flowViewModel)
    {
        InitializeComponent();
        BindingContext = this.flowViewModel = flowViewModel;
    }
}