using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RouletteStatsTracker.Models;

namespace RouletteStatsTracker.ViewModels
{
    public class AmericanStatsViewModel
    {
        DataStore dataStore;
        AmericanStatsViewModel(DataStore dataStore)
        {
            this.dataStore = dataStore;
        }
    }
}
