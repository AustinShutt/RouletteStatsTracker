using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RouletteStatsTracker.Models;

namespace RouletteStatsTracker.ViewModels
{
    internal class EuropeanInputViewModel
    {
        DataStore dataStore;
        EuropeanInputViewModel(DataStore dataStore)
        {
            this.dataStore = dataStore;
        }
    }
}
