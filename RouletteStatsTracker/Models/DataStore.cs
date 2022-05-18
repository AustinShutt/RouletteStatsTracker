using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouletteStatsTracker.Models
{
    class DataStore
    {
        public bool American { get; set; }

        DataStore()
        {
            American = true; ;
        }
    }
}
