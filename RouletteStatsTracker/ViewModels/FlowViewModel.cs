using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RouletteStatsTracker.Helpers;
using RouletteStatsTracker.Models;

namespace RouletteStatsTracker.ViewModels
{
    public class FlowViewModel
    {
        DataStore dataStore;
        public ObservableCollection<FlowObject> FlowObjects { get; set; }
        public FlowViewModel()
        {
            dataStore = ServiceHelper.GetService<DataStore>();
            
            FlowObjects = new ObservableCollection<FlowObject>();
        }
    }
}
