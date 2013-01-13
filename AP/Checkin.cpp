/*
 * Checkin.cpp
 *
 *  Created on: 2012-12-19
 *      Author: Admin
 */

#include "Checkin.h"
#include "System.h"
Checkin::Checkin(int b) {
	componentId=b;
	working=1;

	activateInput();
	stackSize=1;
	// TODO Auto-generated constructor stub
}

Checkin::~Checkin() {
	// TODO Auto-generated destructor stub
}

void *Checkin::Run()
{
	_pulse pdata;
	for (;;)
	{

		MsgReceivePulse(threadChannel , (void *)&pdata, sizeof(pdata), NULL);
		cout<<"IM HERE"<<endl;
		delay(CHECKIN_TIME);
		cout<<"END HERE"<<endl;
		if(outputs[0]->addSuitcaseToComp(suitcasesInComp.front()))
		{
			cout<<"OK"<<endl;
			suitcasesInComp.pop_front();
			MsgSendPulse(suitcaseQueue->getConnId(), sched_get_priority_max(SCHED_FIFO), _PULSE_CODE_MAXAVAIL, 0);
		}
		else
		{
			cout<<"O NIE"<<endl;
		}
	}
	return 0;
}
