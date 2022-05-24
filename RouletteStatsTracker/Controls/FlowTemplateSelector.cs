using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RouletteStatsTracker.Models;

namespace RouletteStatsTracker.Controls
{
    public class FlowTemplateSelector : DataTemplateSelector
    {
        public DataTemplate GreenRow { get; set; }
        public DataTemplate OtherRow { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            FlowObject flowObject = item as FlowObject;

            return flowObject.Red.Equals("0") || flowObject.Red.Equals("00") ? GreenRow : OtherRow;
        }
    }
}
