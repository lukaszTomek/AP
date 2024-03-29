/*
 * SuitcaseQueue.cpp
 *
 *  Created on: 2013-01-13
 *      Author: Luka
 */

#include "SuitcaseQueue.h"

SuitcaseQueue::SuitcaseQueue() {
	// TODO Auto-generated constructor stub
	stackSize=1000;
	maxPriority=1;
}

SuitcaseQueue::SuitcaseQueue(int id)
{
	stackSize=1000;
	maxPriority=1;
	componentId=id;
}

SuitcaseQueue::~SuitcaseQueue() {
	// TODO Auto-generated destructor stub
}

void* SuitcaseQueue::Run()
{
	_pulse pdata;
	for (;;)
	{
		cout<<" th id "<<threadChannel<<" conn id "<<threadConnId<<endl;
		MsgReceivePulse(threadChannel , (void *)&pdata, sizeof(pdata), NULL);
		cout<<"puls w kolejce"<<endl;
		for(unsigned i=0;i<outputs.size();i++)
		{

			if(suitcasesInComp.empty()) break;
			if(outputs[i]->addSuitcaseToComp(suitcasesInComp.front()))
			{
				MsgSendPulse(outputs[i]->getConnId(), sched_get_priority_max(SCHED_FIFO), _PULSE_CODE_MAXAVAIL, 0);
				suitcasesInComp.pop_front();
			}

		}

	}
	return 0;
}
