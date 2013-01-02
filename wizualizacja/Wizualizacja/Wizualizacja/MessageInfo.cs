using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wizualizacja
{
    enum RequestType
    {
        addSuitcase,
        getState,
        // to fill
    }
    class StateInfo
    {
        //info o componencie
    }
    class MessageInfo
    {
        public List<Suitcase> suitcasesArray;   //jeśli reqType = addSuitcase  to suitcaseArray zawiera tylko jeden suitcase
        public List<Plane> planesArray;         //analogicznie ^
        public List<StateInfo> statesArray;  // informacje o stanach komponentów
        public RequestType reqType;
        public bool problems;   //zapytania add suitcase itd w odpowiedzi zrotnej dostają kod 1 albo 0. ta informacja jest przechowywana tutaj

        public MessageInfo()
        {
            suitcasesArray = new List<Suitcase>();
            planesArray = new List<Plane>();
            statesArray = new List<StateInfo>();
        }
        public MessageInfo(Suitcase s)   //constructor when adding new suitcase. Example of using in Form1.cs
        {
            reqType = RequestType.addSuitcase;
            suitcasesArray = new List<Suitcase>();
            suitcasesArray.Add(s);
        }
    }
}
