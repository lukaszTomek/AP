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
        bool isDrawingPossible;

        public Drawer(Graphics g)
        {
            graphics = g;

            try
            {
                mapImage  = new Bitmap(Wizualizacja.Properties.Resources.mapa);
                isDrawingPossible = true;
            }
            catch (System.IO.FileNotFoundException)
            {
                MessageBox.Show("There was an error opening the bitmap." +
                    "Please check the path.");
                isDrawingPossible = false;
            }
            
        }

        public void draw()
        {
            if (!isDrawingPossible)
                return;
            graphics.DrawImage(mapImage, new Point(0, 0));


        }
    }
}
