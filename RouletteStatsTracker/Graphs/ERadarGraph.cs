using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouletteStatsTracker.Graphs
{
    public class ERadarGraph : IDrawable
    {
        static String red = "D92332";
        static String blue = "2C3E50";
        static String green = "27AE60";

        int[] NumberArray { get; set; }
        int[] OrderArray = {0,32,15,19,4,21,2,25,17,34,6,27,13,36,11,30,8,23,10,5,24,16,33,1,20,14,31,9,22,18,29,7,28,12,35,3,26};
        string[] ColorArray = {green, red, blue, red, blue, red, blue, red, blue, red, blue, red, blue, red, blue, red, blue, red, blue,
                                      red, blue, red, blue, red, blue, red, blue, red, blue, red, blue, red, blue, red, blue, red, blue};

        public ERadarGraph()
        {
            NumberArray = new int[38];
        }

        public void SetValues(int[] NumberArray)
        {
            this.NumberArray = NumberArray;
        }

        public void Draw(ICanvas canvas, RectF rect)
        {
            //Scale
            canvas.Translate(rect.Center.X, rect.Center.Y);
            float scale = Math.Min(rect.Width / 200f, rect.Height / 200f);
            canvas.Scale(scale, scale);
            canvas.FontSize = 12;
            canvas.StrokeSize = 1.5F;
            canvas.StrokeColor = Color.FromArgb(blue);
            canvas.FillColor   = Color.FromArgb("BDC3C7");
            canvas.DrawCircle(0, 0, 100);
            canvas.StrokeSize = 1F;
            canvas.SaveState();

            float max = NumberArray.Max();

            /*Draws all inner lines and numbers of the chart*/
            canvas.StrokeSize = .8F;
            int count = 0;

            float diff = 360F / 37F;

            for (float i = 0; i < 359; i+= diff)
            {
                float proportion = NumberArray[OrderArray[count]] / max;
                PathF path = new PathF();
                path.MoveTo(0, 0);
                path.LineTo(7F * proportion, -86F * proportion);
                path.LineTo(-7F * proportion, -86F * proportion);
                path.Close();
                canvas.FillColor = Color.FromArgb(red); //Color.FromArgb("BDC3C7");
                canvas.FillPath(path);

                string val = OrderArray[count].ToString();

                //if (val.Equals("37")) val = "00";

                canvas.FontColor = Color.FromArgb(ColorArray[count]);

                canvas.DrawString(val, 0, -88, HorizontalAlignment.Center);
                count++;
                canvas.Rotate(diff / 2F);
                canvas.DrawLine(0, 0, 0, -100);
                canvas.Rotate(diff / 2F);
            }

            canvas.RestoreState(); //Resets rotation to where it says "SaveState" from above
            
            //Draws second outer circle
            canvas.StrokeColor = Color.FromArgb(blue);
            canvas.DrawCircle(0, 0, 86);
            //Draws small inner circle
            canvas.FillColor = Color.FromArgb(blue);
            canvas.FillCircle(0,0,10);

            canvas.ResetState();
        }
    }
}
