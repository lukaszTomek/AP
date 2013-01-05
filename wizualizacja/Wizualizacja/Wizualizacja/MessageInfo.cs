using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wizualizacja
{
    enum RequestType
    {
        addSuitcase,
        addPlane,
        hurtConveyor,
        dropSuitcaseFromConveyor,
        getFullState,
        getState
    }

    class StateInfo
    {
        public int id;
        public int state;

        public StateInfo(int comp_id, int st)
        {
            id=comp_id;
            state=st;
        }
    }

    class MessageInfo
    {
        public RequestType reqType;

        public List<Suitcase> suitcasesArray;   //jeśli reqType = addSuitcase  to suitcaseArray zawiera tylko jeden suitcase
        public List<Plane> planesArray;         //planes on sleeves
        public List<Plane> planesWaitingArray;         
        public List<StateInfo> statesArray;  // informacje o stanach komponentów
        public bool problems;   //zapytania add suitcase itd w odpowiedzi zrotnej dostają kod 1 albo 0. ta informacja jest przechowywana tutaj

        public bool detected_drug;
        public bool detected_bomb;
        public int number_drugs;
        public int number_bombs;

        public MessageInfo()
        {
            suitcasesArray = new List<Suitcase>();
            planesArray = new List<Plane>();
            statesArray = new List<StateInfo>();
            planesWaitingArray = new List<Plane>();
        }
        public MessageInfo(Suitcase s)   //constructor when adding new suitcase. Example of using in Form1.cs
        {
            reqType = RequestType.addSuitcase;
            suitcasesArray = new List<Suitcase>();
            suitcasesArray.Add(s);
        }
        public MessageInfo(RequestType rType)
        {
            reqType = rType;
        }
    }
}
