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
    public class AmericanInputViewModel
    {
        DataStore dataStore;

        public AmericanInputViewModel()
        {
           dataStore = ServiceHelper.GetService<DataStore>();
        }
    }
}
