using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RouletteStatsTracker.Models;

namespace RouletteStatsTracker.Helpers
{
    public class UtilityDataService
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

        public UtilityDataService(DataStore DataStore) 
        {
            this.DataStore = DataStore;
        }

        public void Add(String str) {
            
            FlowObject flowObject = new FlowObject();
            CTObject   ctObject   = new CTObject();

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


                ctObject.Num = DataStore.FlowObjects.Count + 1;
                ctObject.C1 = "0";
                ctObject.C2 = "-";
                ctObject.C3 = "-";
                ctObject.T1 = "-";
                ctObject.T2 = "-";
                ctObject.T3 = "-";


                DataStore.FlowObjects.Add(flowObject);
                DataStore.CTObjects.Add(ctObject);
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

                ctObject.Num = DataStore.FlowObjects.Count + 1;
                ctObject.C1 = "00";
                ctObject.C2 = "-";
                ctObject.C3 = "-";
                ctObject.T1 = "-";
                ctObject.T2 = "-";
                ctObject.T3 = "-";

                DataStore.FlowObjects.Add(flowObject);
                DataStore.CTObjects.Add(ctObject);
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

            ctObject.C1 = "";
            ctObject.C2 = "";
            ctObject.C3 = "";

            //Parse C1vC2vC3
            if (value % 3 == 1)
            {
                DataStore.Column1++;
                ctObject.C1 = "C1";
            }
            else if (value % 3 == 2)
            {
                DataStore.Column2++;
                ctObject.C2 = "C2";
            }
            else
            {
                DataStore.Column3++;
                ctObject.C3 = "C3";
            }


            ctObject.T1 = "";
            ctObject.T2 = "";
            ctObject.T3 = "";


            if (value <= 12)
            {
                DataStore.Third1++;
                ctObject.T1 = "T1";
            }

            else if (value <= 24)
            { 
                DataStore.Third2++;
                ctObject.T2 = "T2";
            }
            else
            {
                DataStore.Third3++;
                ctObject.T3 = "T3";  
            }

            //Add Totals and flowObject and return
            DataStore.Total++;
            flowObject.Num = DataStore.FlowObjects.Count + 1;
            ctObject.Num = DataStore.FlowObjects.Count + 1; 
            DataStore.FlowObjects.Add(flowObject);
            DataStore.CTObjects.Add(ctObject);
        }
        public void Delete(String str) {
            
            DataStore.FlowObjects.Remove(DataStore.FlowObjects.Last<FlowObject>());
            DataStore.CTObjects.Remove(DataStore.CTObjects.Last<CTObject>());

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

            DataStore.NumberArray[value]--;

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

        public void ClearAll()
        {
            DataStore.Red = 0;
            DataStore.Black = 0;
            DataStore.Even = 0;
            DataStore.Odd = 0;
            DataStore.High = 0;
            DataStore.Low = 0;
            DataStore.Column1 = 0;
            DataStore.Column2 = 0;
            DataStore.Column3 = 0;
            DataStore.Third1 = 0;
            DataStore.Third2 = 0;
            DataStore.Third3 = 0;
            DataStore.Total = 0;
            DataStore.FlowObjects.Clear();
            DataStore.CTObjects.Clear();

            for(int i = 0; i < DataStore.NumberArray.Length; i++)
            {
                DataStore.NumberArray[i] = 0;
            }
        }
    }
}
