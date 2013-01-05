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
	start();
}
Conveyor::~Conveyor()
{
	// TODO Auto-generated destructor stub
}

void *Conveyor::Run()
{
	while(true)
	{
		delay(200);
		cout<<"a"<<endl;
		if(!suitcasesInComp.empty())
		{
			Suitcase* s= suitcasesInComp.front();
			s->setProgress((s->getProgress()+5)%100);
		}
	}
}
