using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;


namespace Wizualizacja
{
    class Suitcase
    {
        static int maxSuitcaseId = -1;

        int id;
        selectedDangerous dangerous;
        int weight;
        int progress;
        int planeId;
        int compId;
        Component component;
        Point positionToDraw;

        public Suitcase(selectedDangerous s_d, int w, int p_id)
        {
            dangerous = s_d;
            weight = w;
            planeId = p_id;

            positionToDraw = new Point();

            if ((id = getNextSuitcaseId()) < 0)
                System.Windows.Forms.MessageBox.Show("Cannot create Suitcase");
            System.Windows.Forms.MessageBox.Show(this.ToString());
        }

        public Suitcase(selectedDangerous s_d, int w, int p_id, int comp_id, int prog)
        {
            dangerous = s_d;
            weight = w;
            planeId = p_id;
            compId = comp_id;
            progress = prog;

            positionToDraw = new Point();

        }

        static int getNextSuitcaseId()
        {
            if (maxSuitcaseId < 0)
            {
                System.Windows.Forms.MessageBox.Show("Cannot assign ID without system connection");
                return -1;
            }
            else
            {
                maxSuitcaseId++;
                return maxSuitcaseId;
            }
        }

        public void draw(Graphics graphics)
        {
            if (component == null || component.getId() != compId)
                foreach (Component c in AirportState.components)
                    if (c.getId() == compId)
                    {
                        component = c;
                        break;
                    }
            if (component.getId() != compId)
            {
                System.Windows.Forms.MessageBox.Show("Incorrect component ID");
            }
            positionToDraw=component.getPosition(progress);
            positionToDraw.X -= Drawer.suitcaseBmp.Width / 2;
            positionToDraw.Y -= Drawer.suitcaseBmp.Height / 2;
            switch(dangerous)
            {
                case selectedDangerous.NONE:
                    graphics.DrawImage(Drawer.suitcaseBmp,positionToDraw);
                    break;
                case selectedDangerous.EXPLOSIVES:
                    graphics.DrawImage(Drawer.bombBmp, positionToDraw);
                    break;
                case selectedDangerous.DRUGS:
                    graphics.DrawImage(Drawer.drugsBmp, positionToDraw);
                    break;
            }
            

        }

        public override string ToString()
        {
            return id.ToString() + " " + weight.ToString() + "kg";
        }
    };
}
