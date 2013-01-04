using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Wizualizacja
{
    enum ComponentType
    {
        CHECKIN,
        CONVEYOR,
        CONNECTOR,
        DRUG_TESTER,
        EXPLOSIVES_TESTER
    };

    class Component
    {
        int startX, startY, endX, endY;
        
        int id;
        bool state;
        ComponentType compType;


        public Component(int id, int sX,int sY,int eX,int eY,ComponentType cType)
        {
            this.id = id;
            startX = sX;
            startY = sY;
            endX = eX;
            endY = eY;
            compType = cType;
        }
        public int getId()
        {
            return id;
        }
        public Point getPosition(int progress)
        {
            return new Point(startX + ((endX - startX) * progress) / 100, startY+ ((endY - startY) * progress) / 100);
        }
    }
}
