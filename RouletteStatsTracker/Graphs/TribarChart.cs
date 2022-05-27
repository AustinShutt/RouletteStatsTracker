using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouletteStatsTracker.Graphs
{
    public class TribarChart : IDrawable
    {

        float ratioLeft;
        float ratioCenter;
        float ratioRight;

        string titleLeft;
        string titleCenter;
        string titleRight;
        public TribarChart()
        {
            SetValues(0, 0, 0, 0);
        }


        public TribarChart(string titleLeft, string titleCenter, string titleRight, bool invertColors = false)
        {
            SetValues(0, 0, 0, 0);
            this.titleLeft = titleLeft;
            this.titleCenter = titleCenter;
            this.titleRight = titleRight;
        }

        public void SetTitles(string titleLeft, string titleCenter, string titleRight)
        {
            this.titleLeft = titleLeft;
            this.titleCenter = titleCenter;
            this.titleRight = titleRight;
        }
        public void SetValues(float left, float center, float right, float total)
        {
            if (total == 0)
            {
                ratioLeft   = .33F;
                ratioCenter = .33F;
                ratioRight  = .33F;
                return;
            }

            ratioLeft = left / total;
            ratioCenter = center / total;
            ratioRight = right / total;
        }

        public void Draw(ICanvas canvas, RectF rect)
        {
            float scale = Math.Min(rect.Width / 50f, rect.Height / 50f);
            canvas.Scale(scale, scale);
            
            canvas.Translate(5, 20);

            float totalWidth = 400F;
            float ratioTotal = ratioLeft + ratioCenter + ratioRight;


            float A = (ratioLeft /ratioTotal) * totalWidth;
            float B = (ratioCenter/ratioTotal) * totalWidth;
            float C = (ratioRight / ratioTotal) * totalWidth;

            canvas.FillColor = Color.FromArgb("2C3E50");
            canvas.FillRectangle(0, 0, A, 40);

            canvas.FillColor = Color.FromArgb("D92332");
            canvas.FillRectangle(A, 0, B, 40);

            canvas.FillColor = Color.FromArgb("2C3E50");
            canvas.FillRectangle(A + B, 0, C, 40);
           
           
            canvas.FontSize = 16;
            canvas.FontColor = Colors.White;

            int heightText = 18;
            int heightNum =  33;

#if WINDOWS10_0_17763_0_OR_GREATER
            heightText = 12;
            heightNum = 28;
#endif

            if(A > 25F)
            {
                canvas.DrawString(titleLeft, A / 2, heightText, HorizontalAlignment.Center);
                canvas.DrawString((ratioLeft * 100).ToString("0.0") + "%", A / 2, heightNum, HorizontalAlignment.Center);
            }
            if(B> 25F)
            {
                canvas.DrawString(titleCenter, A + (B / 2), heightText, HorizontalAlignment.Center);
                canvas.DrawString((ratioCenter * 100).ToString("0.0") + "%", A + (B / 2), heightNum, HorizontalAlignment.Center);
            }
            if(C> 25F)
            {
                canvas.DrawString(titleRight, A + B + (C / 2), heightText, HorizontalAlignment.Center);
                canvas.DrawString((ratioRight * 100).ToString("0.0") + "%", A + B + (C / 2), heightNum, HorizontalAlignment.Center);
            }
            
            canvas.Translate(-5, -20);
            canvas.ResetState();
        }
    }
}