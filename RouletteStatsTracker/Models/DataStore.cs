using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;



namespace RouletteStatsTracker.Models
{
    public class DataStore
    {
        public int Red { get; set; }
        public int Black { get; set; }
        public int Even { get; set; }
        public int Odd { get; set; }
        public int Low { get; set; }
        public int High { get; set; }
        public int Column1 { get; set; }
        public int Column2 { get; set; }
        public int Column3 { get; set; }
        public int Third1 { get; set; }
        public int Third2 { get; set; }
        public int Third3 { get; set; }
        public int Total { get; set; }
        public int[] NumberArray { get; set; }
        public ObservableCollection<FlowObject> FlowObjects {get; set; }

        public DataStore()
        {
            //0 , 1-36, 00
            NumberArray = new int[38];
            FlowObjects = new ObservableCollection<FlowObject>();
        }
    }
}
