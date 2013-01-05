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
        int elapsedTime; 
        //dopisałem elapsed time, bo nie wiedziałem jak korzystac z DateTime, anie tego zrzutować, ani nic, a bierzemy pod uwagę okres czasu
        string planeName;
        public int id;
        int plane_sleeve;

        public string toString()
        {
            string s = "";
            s += id.ToString();
            s += ",";
            s += elapsedTime.ToString();
            s += ",";
            return s;
        }

        //Konstruktor dla deserializacji do dodawania samolotów do klasy MessageInfo w polu PlanesArray - samoloty przy rękawach;
        public Plane(int i, int t, int s)
        {
            id = i;
            elapsedTime = t;
            plane_sleeve = s;
        }

        //Konstruktor do dodawania samolotów do klasy MessageInfo w polu planesWaitingArray - samoloty oczekujące w kolejce, bez rekawow;
        public Plane(int i, int t)
        {
            id = i;
            elapsedTime = t;
        }
        public Plane()
        {
            planeName = "default name";
            id = 1;
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


    static class AirportState
    {
        public static List<Plane> planesArray;
        public static List<Plane> planesInUse;
        public static List<Suitcase> suitcasesArray;
        public static List<Component> components;

        public static void initialize()
        {
            planesArray = new List<Plane>();
            suitcasesArray = new List<Suitcase>();
            planesArray.Add(new Plane());          //test debug - do usuniecia

            components = new List<Component>();
            components.Add(new Component(110, 75, 500, 75, 410, ComponentType.CONVEYOR));
            components.Add(new Component(220, 195, 500, 195, 410, ComponentType.CONVEYOR));
            components.Add(new Component(330, 315, 500, 315, 410, ComponentType.CONVEYOR));
            components.Add(new Component(440, 435, 500, 435, 410, ComponentType.CONVEYOR));
            components.Add(new Component(1020, 90, 395, 180, 395, ComponentType.CONVEYOR));
            components.Add(new Component(2030, 210, 395, 300, 395, ComponentType.CONVEYOR));
            components.Add(new Component(3040, 330, 395, 420, 395, ComponentType.CONVEYOR));
            components.Add(new Component(4050, 450, 395, 540, 395, ComponentType.CONVEYOR));
            
            components.Add(new Component(10, 75, 395, 75, 395, ComponentType.CONNECTOR));
            components.Add(new Component(20, 195, 395, 195, 395, ComponentType.CONNECTOR));
            components.Add(new Component(30, 315, 395, 315, 395, ComponentType.CONNECTOR));
            components.Add(new Component(40, 435, 395, 435, 395, ComponentType.CONNECTOR));
            components.Add(new Component(50, 555, 395, 555, 395, ComponentType.CONNECTOR));

            components.Add(new Component(55, 585, 395, 585, 395, ComponentType.DRUG_TESTER));
            components.Add(new Component(60, 615, 395, 615, 395, ComponentType.CONNECTOR));

            components.Add(new Component(6070, 615, 380, 615, 290, ComponentType.CONVEYOR));

            components.Add(new Component(70, 615, 275, 615, 275, ComponentType.CONNECTOR));
            components.Add(new Component(75, 585, 275, 585, 275, ComponentType.DRUG_TESTER));

            //example suitcases for debug
            ////////////////////////////////
            suitcasesArray.Add(new Suitcase(selectedDangerous.NONE, 100, 1, 110,0));
            suitcasesArray.Add(new Suitcase(selectedDangerous.NONE, 100, 1, 110, 100));
            suitcasesArray.Add(new Suitcase(selectedDangerous.EXPLOSIVES, 100, 1, 110, 50));
            suitcasesArray.Add(new Suitcase(selectedDangerous.DRUGS, 100, 1, 60, 0));
            suitcasesArray.Add(new Suitcase(selectedDangerous.DRUGS, 100, 1, 70, 50));
            ////////////////////////////////
        }
        public static  List<Plane> getPlanes()
        {
            return planesArray;
        }

        public static void interpretMakeStatesQuery(string data, Client client)
        {
            Console.WriteLine("I1");
            MessageInfo MI = client.Deserialize(data);
            Console.WriteLine("I2");
            suitcasesArray = MI.suitcasesArray;
            planesArray = MI.planesWaitingArray;
            planesInUse = MI.planesArray;

        }

    };
}
