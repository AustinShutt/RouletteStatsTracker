using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RouletteStatsTracker.Models;

namespace RouletteStatsTracker.Controls
{
    public class CTTemplateSelector : DataTemplateSelector
    {
        public DataTemplate GreenRow { get; set; }
        public DataTemplate OtherRow { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            CTObject flowObject = item as CTObject;

            return flowObject.C1.Equals("0") || flowObject.C1.Equals("00") ? GreenRow : OtherRow;
        }
    }
}
