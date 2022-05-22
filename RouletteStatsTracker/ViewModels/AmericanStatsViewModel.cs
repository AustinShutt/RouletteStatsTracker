using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RouletteStatsTracker.Helpers;
using RouletteStatsTracker.Models;

namespace RouletteStatsTracker.ViewModels
{
    public class AmericanStatsViewModel
    {
        public DataStore dataStore { get; set; }
        public AmericanStatsViewModel()
        {
            dataStore = ServiceHelper.GetService<DataStore>();
        }
    }
}
