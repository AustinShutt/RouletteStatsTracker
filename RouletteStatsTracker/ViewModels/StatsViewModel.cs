using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RouletteStatsTracker.Helpers;
using RouletteStatsTracker.Models;

namespace RouletteStatsTracker.ViewModels
{
    public class StatsViewModel
    {
        public DataStore dataStore { get; set; }
        public StatsViewModel()
        {
            dataStore = ServiceHelper.GetService<DataStore>();
        }
    }
}
