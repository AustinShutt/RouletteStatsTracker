﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RouletteStatsTracker.Helpers;
using RouletteStatsTracker.Models;

namespace RouletteStatsTracker.ViewModels
{
    public class EuropeanInputViewModel
    {
        DataStore dataStore;
        public EuropeanInputViewModel()
        {
            dataStore = ServiceHelper.GetService<DataStore>();
        }
    }
}
