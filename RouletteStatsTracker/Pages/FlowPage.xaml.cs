namespace RouletteStatsTracker.Pages;

using RouletteStatsTracker.Helpers;
using RouletteStatsTracker.ViewModels;

public partial class FlowPage : ContentPage
{
    FlowViewModel vm;


	public FlowPage()
    {
        InitializeComponent();
        vm = ServiceHelper.GetService<FlowViewModel>();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        if (vm.FlowObjects.Count == 0) return;

        collectionView.ScrollTo(vm.FlowObjects.Count - 1, -1, ScrollToPosition.End, false);
    }

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);

        
    }
}