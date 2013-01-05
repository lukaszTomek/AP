/*
 * Runnable.cpp
 *
 *  Created on: 2012-11-30
 *      Author: Luka
 */

#include "Runnable.h"

bool Runnable::start()
{

	pthread_attr_init(&threadAttr);

	pthread_attr_setschedpolicy(&threadAttr, SCHED_FIFO);

	errvalue=pthread_create(&thread,&threadAttr, ThreadFunc, this);

	if (errvalue!=0)
	{
		cout<< "Cannot create thread."<<endl;
		return 1;
	}

	return 0;
};


