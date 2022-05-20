using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouletteStatsTracker.Models
{
    public class DataStore
    {
        public int Red { get;  set; }
        public int Black { get;  set; }
        public int Even { get;  set; }
        public int Odd { get;  set; }
        public int Low { get;  set; }
        public int High { get;  set; }
        public int Column1 { get; set; }
        public int Column2 { get; set; }
        public int Column3 { get; set; }
        public int Third1 { get; set; }
        public int Third2 { get; set; }
        public int Third3 { get; set; }

        public int[] numberArray;

        public DataStore()
        {
            //0 , 1-36, 00
            numberArray = new int[38]; 
        }
    }
}
