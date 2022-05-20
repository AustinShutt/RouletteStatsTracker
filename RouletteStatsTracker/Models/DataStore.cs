using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouletteStatsTracker.Models
{
    public class DataStore
    {
        public bool American { get; set; }
        public bool European { get; set; }

        DataStore()
        {
            American = true; ;
        }
    }
}
