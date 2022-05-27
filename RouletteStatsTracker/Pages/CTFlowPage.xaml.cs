namespace RouletteStatsTracker.Pages;

using RouletteStatsTracker.Helpers;
using RouletteStatsTracker.ViewModels;

public partial class CTFlowPage : ContentPage
{
	FlowViewModel vm;
	
	public CTFlowPage()
	{
		InitializeComponent();
		vm = ServiceHelper.GetService<FlowViewModel>();
	}
}