﻿using System;
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
        static int iteration;
        public Drawer(Graphics g)
        {
            graphics = g;
            iteration = 0;
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
        public void stop()
        {
            isDrawingPossible = false;
        }
        public void draw()
        {
            if (!isDrawingPossible)
                return;
            graphics.DrawImage(mapImage, new Point(0, 0));
            graphics.DrawString(iteration.ToString(), SystemFonts.DefaultFont, Brushes.Black, new PointF(50, 50));
            foreach (Suitcase s in AirportState.suitcasesArray)
            {
                s.draw();
            }
            iteration++;
        }
    }
}