using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
namespace Wizualizacja
{
    class Drawer
    {
        Graphics graphics;
        
        Bitmap mapImage;
        Bitmap bufforBmp;

        public static Bitmap suitcaseBmp;
        public static Bitmap drugsBmp;
        public static Bitmap bombBmp;

        bool isDrawingPossible;
        static int iteration;
        public Drawer(Graphics g)
        {
            graphics = g;
            iteration = 0;
            try
            {
                mapImage  = new Bitmap(Wizualizacja.Properties.Resources.mapa);
                isDrawingPossible = true;
                suitcaseBmp = new Bitmap(Wizualizacja.Properties.Resources.suitcase);
                drugsBmp = new Bitmap(Wizualizacja.Properties.Resources.drugs);
                bombBmp = new Bitmap(Wizualizacja.Properties.Resources.bomb);
            }
            catch (System.IO.FileNotFoundException)
            {
                MessageBox.Show("There was an error opening the bitmap." +
                    "Please check the path.");
                isDrawingPossible = false;
            }
            
        }
        public void stop()
        {
            isDrawingPossible = false;
        }
        public void draw()
        {
            if (!isDrawingPossible)
                return;
            Graphics bufferG;
            bufforBmp = new Bitmap(mapImage);
            bufferG = Graphics.FromImage(bufforBmp);
            bufferG.DrawString(iteration.ToString(), SystemFonts.DefaultFont, Brushes.Black, new PointF(50, 50));
            foreach (Suitcase s in AirportState.suitcasesArray)
            {
                s.draw(bufferG);
            }
            iteration++;
            graphics.DrawImage(bufforBmp, 0, 0);
        }
    }
}
