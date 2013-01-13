/*
 * Conveyor.cpp
 *
 *  Created on: 2012-12-18
 *      Author: Admin
 */

#include "Conveyor.h"

Conveyor::Conveyor(int b)
{
	componentId=b;
	working=1;
	maxPriority=1;
	stackSize=50;
	activateInput();
}
Conveyor::~Conveyor()
{
	// TODO Auto-generated destructor stub
}

void *Conveyor::Run()
{
	while(true)
	{
		delay(20);
		if(!suitcasesInComp.empty())
		{
			Suitcase* s= suitcasesInComp.front();                //zamiast pierwszego bierz wszystkie. ustaw w mainheader szybkosc i
																//obliczaj na jej podstawie o jaki progres zmienic suitcasea ( korzystajac z dlug.jak dojdzie do 100% to przenosisz do nastepnego komponentu (oczywiscie jesli to mozliwe)
			s->setProgress((s->getProgress()+1)%100);
		}
	}
	return 0;
}
