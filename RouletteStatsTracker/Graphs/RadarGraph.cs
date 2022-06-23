using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouletteStatsTracker.Graphs
{
    public class RadarGraph : IDrawable
    {
        static String red = "D92332";
        static String blue = "2C3E50";
        static String green = "27AE60";

        bool isAmerican = true;
        int[] NumberArray { get; set; }
        int[] OrderArray = {37,27,10,25,29,12,8,19,31,18,6,21,33,16,4,23,35,14,2,0,28,9,26,30,11,7,20,32,17,5,22,34,15,3,24,36,13,1};
        string[] ColorArray = {green, red, blue, red, blue, red, blue, red, blue, red, blue, red, blue, red, blue, red, blue, red, blue,
                               green, blue, red, blue, red, blue, red, blue, red, blue, red, blue, red, blue, red, blue, red, blue, red};

        int[] EOrderArray = { 0, 32, 15, 19, 4, 21, 2, 25, 17, 34, 6, 27, 13, 36, 11, 30, 8, 23, 10, 5, 24, 16, 33, 1, 20, 14, 31, 9, 22, 18, 29, 7, 28, 12, 35, 3, 26 };
        string[] EColorArray = {green, red, blue, red, blue, red, blue, red, blue, red, blue, red, blue, red, blue, red, blue, red, blue,
                                      red, blue, red, blue, red, blue, red, blue, red, blue, red, blue, red, blue, red, blue, red, blue};

        public RadarGraph()
        {
            NumberArray = new int[38];
        }

        public void SetValues(int[] NumberArray)
        {
            this.NumberArray = NumberArray;
        }

        public void SetValues(int[] NumberArray, bool isAmerican)
        {
            this.NumberArray = NumberArray;
            this.isAmerican = isAmerican;
        }

        public void Draw(ICanvas canvas, RectF rect)
        {
            if(isAmerican)
                DrawAmerican(canvas, rect);
            else
                DrawEuropean(canvas, rect);
        }

        public void DrawAmerican(ICanvas canvas, RectF rect)
        {//Scale
            canvas.Translate(rect.Center.X, rect.Center.Y);
            float scale = Math.Min(rect.Width / 200f, rect.Height / 200f);
            canvas.Scale(scale, scale);
            canvas.FontSize = 12;
            canvas.StrokeSize = 1.5F;
            canvas.StrokeColor = Color.FromArgb(blue);
            canvas.FillColor = Color.FromArgb("BDC3C7");
            canvas.DrawCircle(0, 0, 100);
            canvas.StrokeSize = 1F;
            canvas.SaveState();

            float max = NumberArray.Max();

            /*Draws all inner lines and numbers of the chart*/
            canvas.StrokeSize = .8F;
            int count = 0;
            for (float i = 0; i < 359; i += 9.473F)
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

                if (val.Equals("37")) val = "00";

                canvas.FontColor = Color.FromArgb(ColorArray[count]);

                canvas.DrawString(val, 0, -88, HorizontalAlignment.Center);
                count++;
                canvas.Rotate(9.473F / 2F);
                canvas.DrawLine(0, 0, 0, -100);
                canvas.Rotate(9.473F / 2F);
            }

            canvas.RestoreState(); //Resets rotation to where it says "SaveState" from above

            //Draws second outer circle
            canvas.StrokeColor = Color.FromArgb(blue);
            canvas.DrawCircle(0, 0, 86);
            //Draws small inner circle
            canvas.FillColor = Color.FromArgb(blue);
            canvas.FillCircle(0, 0, 10);

            canvas.ResetState();
        }
        public void DrawEuropean(ICanvas canvas, RectF rect)
        { //Scale
            canvas.Translate(rect.Center.X, rect.Center.Y);
            float scale = Math.Min(rect.Width / 200f, rect.Height / 200f);
            canvas.Scale(scale, scale);
            canvas.FontSize = 12;
            canvas.StrokeSize = 1.5F;
            canvas.StrokeColor = Color.FromArgb(blue);
            canvas.FillColor = Color.FromArgb("BDC3C7");
            canvas.DrawCircle(0, 0, 100);
            canvas.StrokeSize = 1F;
            canvas.SaveState();

            float max = NumberArray.Max();

            /*Draws all inner lines and numbers of the chart*/
            canvas.StrokeSize = .8F;
            int count = 0;

            float diff = 360F / 37F;

            for (float i = 0; i < 359; i += diff)
            {
                float proportion = NumberArray[EOrderArray[count]] / max;
                PathF path = new PathF();
                path.MoveTo(0, 0);
                path.LineTo(7F * proportion, -86F * proportion);
                path.LineTo(-7F * proportion, -86F * proportion);
                path.Close();
                canvas.FillColor = Color.FromArgb(red); //Color.FromArgb("BDC3C7");
                canvas.FillPath(path);

                string val = EOrderArray[count].ToString();

                //if (val.Equals("37")) val = "00";

                canvas.FontColor = Color.FromArgb(EColorArray[count]);

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
            canvas.FillCircle(0, 0, 10);

            canvas.ResetState();
        }
    }
}
