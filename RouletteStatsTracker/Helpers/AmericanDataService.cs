using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RouletteStatsTracker.Models;

namespace RouletteStatsTracker.Helpers
{
    public class AmericanDataService
    {
        private DataStore DataStore { get; set; }
                       //Null  //1     2     3      4      5      6      7      8      9    10
        bool[] isRed = {false, true, false, true, false,  true, false,  true, false, true, false,
                                //11   12    13     14     15     16     17     18     19   20
                                false, true, false, true, false, true, false, true, true, false,
                                //21    22   23     24     25     26     27     28     29   30
                                true, false, true, false, true, false, true, false, false, true,
                                //31    32   33     34     35     36
                                false, true, false, true, false, true};

        public AmericanDataService(DataStore DataStore) 
        {
            this.DataStore = DataStore;
        }

        public void Add(String str) {
            
            FlowObject flowObject = new FlowObject();

            if(str.Equals("0"))
            {
                DataStore.NumberArray[0]++;
                DataStore.Total++;

                flowObject.Num = DataStore.FlowObjects.Count + 1;
                flowObject.Red   = "0";
                flowObject.Black = "-";
                flowObject.Even  = "-";
                flowObject.Odd   = "-";
                flowObject.Low   = "-";
                flowObject.High  = "-";

                DataStore.FlowObjects.Add(flowObject);
                return;
            }
            if(str.Equals("00"))
            {
                DataStore.NumberArray[37]++;
                DataStore.Total++;

                flowObject.Num = DataStore.FlowObjects.Count + 1;
                flowObject.Red   = "00";
                flowObject.Black = "-";
                flowObject.Even  = "-";
                flowObject.Odd   = "-";
                flowObject.Low   = "-";
                flowObject.High  = "-";

                DataStore.FlowObjects.Add(flowObject);
                return;
            }
            //Convert string to integer value
            int value = int.Parse(str);

            DataStore.NumberArray[value]++;

            // Parse RED / BLACK
            if (isRed[value])
            {
                DataStore.Red++;
                flowObject.Red = str;
                flowObject.Black = "";
            }
            else
            {
                DataStore.Black++;
                flowObject.Black = str;
                flowObject.Red = "";
            }
                
            //Parse EVEN/ODD
            if(value % 2 == 0)
            {
                DataStore.Even++;
                flowObject.Even = "E";
                flowObject.Odd = "";
            }
            else
            {
                DataStore.Odd++;
                flowObject.Even = "";
                flowObject.Odd = "O";
            }

            //Parse Hi/Low
            if(value > 18)
            {
                DataStore.High++;
                flowObject.High = "H";
                flowObject.Low = "";
            }
            else
            {
                DataStore.Low++;
                flowObject.High = "";
                flowObject.Low = "L";
            }

            //Parse C1vC2vC3
            if (value % 3 == 1)
                DataStore.Column1++;
            else if (value % 3 == 2)
                DataStore.Column2++;
            else
                DataStore.Column3++;

            if (value <= 12)
                DataStore.Third1++;
            else if (value <= 24)
                DataStore.Third2++;
            else
                DataStore.Third3++;

            //Add Totals and flowObject and return
            DataStore.Total++;
            flowObject.Num = DataStore.FlowObjects.Count + 1;
            DataStore.FlowObjects.Add(flowObject);
        }
        public void Delete(String str) {
            
            DataStore.FlowObjects.Remove(DataStore.FlowObjects.Last<FlowObject>());
            
            if (str.Equals("0"))
            {
                DataStore.NumberArray[0]--;
                DataStore.Total--;
                

                return;
            }
            if (str.Equals("00"))
            {
                DataStore.NumberArray[37]--;
                DataStore.Total--;
                return;
            }
            //Convert string to integer value
            int value = int.Parse(str);

            DataStore.NumberArray[value]++;

            // Parse RED / BLACK
            if (isRed[value])
            {
                DataStore.Red--;
            }
            else
            {
                DataStore.Black--;
            }

            //Parse EVEN/ODD
            if (value % 2 == 0)
            {
                DataStore.Even--;
            }
            else
            {
                DataStore.Odd--;
            }

            //Parse Hi/Low
            if (value > 18)
            {
                DataStore.High--;
            }
            else
            {
                DataStore.Low--;
            }

            //Parse C1vC2vC3
            if (value % 3 == 1)
                DataStore.Column1--;
            else if (value % 3 == 2)
                DataStore.Column2--;
            else
                DataStore.Column3--;

            if (value <= 12)
                DataStore.Third1--;
            else if (value <= 24)
                DataStore.Third2--;
            else
                DataStore.Third3--;

            //Add Totals and flowObject and return
            DataStore.Total--;
        }
    }
}
