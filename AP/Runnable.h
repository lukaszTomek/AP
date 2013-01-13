/*
 * Runnable.h
 *
 *  Created on: 2012-11-29
 *      Author: Luka
 */

#ifndef RUNNABLE_H_
#define RUNNABLE_H_

#include "Main_Header.h"

using namespace std;

class Runnable {
protected:
	bool maxPriority;  //means whether the thread has maxPriority or no
	pthread_t thread;
	pthread_attr_t threadAttr;
	int policy;
	sched_param param;
	int errvalue;
	int threadChannel;
	int threadConnId;
public:

	bool start();
	virtual void* Run()=0;
	static void* ThreadFunc(void * arg)
	{
		Runnable * p=(reinterpret_cast<Runnable*>(arg));
		pthread_getschedparam( p->thread, &(p->policy), &(p->param));
		if(p->maxPriority)
			(p->param).sched_priority = sched_get_priority_max(p->policy);
		else
			(p->param).sched_priority = sched_get_priority_min(p->policy);
		cout<<"priorytet ustawiany: "<<(p->param).sched_priority<<endl;
		//int r=pthread_setschedparam(p->thread,p->policy,&(p->param));
		sched_param parameters;
		pthread_getschedparam( p->thread, &(p->policy), &parameters);

		return p->Run();
	};

};

#endif /* RUNNABLE_H_ */
