using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouletteStatsTracker.Graphs
{
    public class DonutChart : IDrawable
    {

        float ratioLeft;
        float ratioRight;

        string titleLeft;
        string titleRight;
        public DonutChart() {

            SetValues(0, 0, 0);
        }


        public DonutChart(string titleLeft, string titleRight)
        {
            SetValues(0, 0, 0);
            this.titleLeft = titleLeft;
            this.titleRight = titleRight;
        }

        public void SetTitles(string titleLeft, string titleRight)
        {
            this.titleLeft = titleLeft;
            this.titleRight = titleRight;
        }
        public void SetValues(float left, float right, float total)
        {
            if (total == 0)
            {
                ratioLeft = .5F;
                ratioRight = .5F;
                return;
            }
                
            ratioLeft  = left  / total;
            ratioRight = right / total;
        }
        
        public void Draw(ICanvas canvas, RectF rect)
        {
            float proportion;
            float scale = Math.Min(rect.Width / 200f, rect.Height / 200f);
            canvas.Scale(scale, scale);
            canvas.StrokeSize = 60;

            if (ratioRight == 1F || ratioLeft == 0F) 
            {
                canvas.StrokeColor = Color.FromArgb("2C3E50");
                canvas.Translate(40, 40);
                canvas.DrawArc(0, 0, 120, 120, 89, 90, true, false);
                canvas.Translate(-40, -40);
            }
            else if(ratioLeft == 1F || ratioRight == 0F)
            {
                canvas.StrokeColor = Color.FromArgb("D92332");
                canvas.Translate(40, 40);
                canvas.DrawArc(0, 0, 120, 120, 89, 90, true, false);
                canvas.Translate(-40, -40);
            }
            else
            {
                proportion = (360F * ratioLeft) + 90;
                if (proportion > 360F) proportion -= 360F;

                canvas.StrokeColor = Color.FromArgb("2C3E50");
                canvas.Translate(40, 40);
                canvas.DrawArc(0, 0, 200 - 80, 200 - 80, 90, proportion, true, false);
                canvas.StrokeColor = Color.FromArgb("D92332");
                canvas.DrawArc(0, 0, 200 - 80, 200 - 80, proportion, 90, true, false);
                canvas.Translate(-40, -40);
            }

            canvas.FontSize = 20;
            canvas.FontColor = Colors.White;
            canvas.DrawString(titleLeft, 50, 140, HorizontalAlignment.Center);
            canvas.DrawString(titleRight, 150, 140, HorizontalAlignment.Center);
            canvas.DrawString((ratioRight * 100).ToString("0.0") + "%", 150, 70, HorizontalAlignment.Center);
            canvas.DrawString((ratioLeft * 100).ToString("0.0") + "%", 50, 70, HorizontalAlignment.Center);
            canvas.ResetState();
        }
    }
}
