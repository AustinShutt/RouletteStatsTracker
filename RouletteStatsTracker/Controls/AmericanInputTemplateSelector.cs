using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouletteStatsTracker.Controls
{
    public class AmericanInputTemplateSelector : DataTemplateSelector
    {
        public DataTemplate RedRow { get; set; }
        public DataTemplate BlackRow { get; set; }
        public DataTemplate GreenRow { get; set; }

        bool[] isRed = {false, true, false, true, false,  true, false,  true, false, true, false,
                                //11   12    13     14     15     16     17     18     19   20
                                false, true, false, true, false, true, false, true, true, false,
                                //21    22   23     24     25     26     27     28     29   30
                                true, false, true, false, true, false, true, false, false, true,
                                //31    32   33     34     35     36
                                false, true, false, true, false, true};

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            if (((string)item).Equals("0") || ((string)item).Equals("00"))
                return GreenRow;

            else if (isRed[int.Parse((string)item)])
                return RedRow;
            else
                return BlackRow;
        }
    }
}