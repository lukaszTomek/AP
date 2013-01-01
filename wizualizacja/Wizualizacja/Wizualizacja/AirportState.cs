using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wizualizacja;

namespace Wizualizacja
{
    class Plane
    {
        static int maxPlaneId=-1;
        DateTime departureTime;
        string planeName;
        int id;
        public Plane()
        {
            planeName = "default name";
            departureTime = DateTime.Now;
        }
        static int getNextPlaneId()
        {
            if (maxPlaneId < 0)
            {
                System.Windows.Forms.MessageBox.Show("Cannot assign ID without system connection");
                return -1;
            }
            else
            {
                
                maxPlaneId++;
                return maxPlaneId;
            }
        }
        public override string ToString()
        {
            return planeName + " " + departureTime.ToShortTimeString();
        }
    };


    class Suitcase
    {
        static int maxSuitcaseId=-1;
        
        int id;
        selectedDangerous dangerous;
        int weight;
        int planeId;
        int compId;

        public Suitcase(selectedDangerous s_d, int w, int p_id)
        {
            dangerous = s_d;
            weight = w;
            planeId = p_id;
            if((id = getNextSuitcaseId())<0)
                System.Windows.Forms.MessageBox.Show("Cannot create Suitcase");
            System.Windows.Forms.MessageBox.Show(this.ToString());
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
        public void draw()
        {

        }
        public override string ToString()
        {
            return id.ToString()+" "+weight.ToString()+"kg";
        }
    };


    static class AirportState
    {
        public static List<Plane> planesArray;
        public static List<Suitcase> suitcasesArray;

        public static void initialize()
        {
            planesArray = new List<Plane>();
            suitcasesArray = new List<Suitcase>();
            planesArray.Add(new Plane());
        }
        public static  List<Plane> getPlanes()
        {
            return planesArray;
        }
    };
}
