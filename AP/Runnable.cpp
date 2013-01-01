/*
 * Runnable.cpp
 *
 *  Created on: 2012-11-30
 *      Author: Luka
 */

#include "Runnable.h"

bool Runnable::Start()
{

	pthread_attr_init(&threadAttr);

	pthread_attr_setschedpolicy(&threadAttr, SCHED_FIFO);

	errvalue=pthread_create(&thread,&threadAttr, ThreadFunc, this);
	cout<<"Watek utworzony"<<endl;

	cout<<"Blad (lub nie):"<<errvalue<<endl;
	if (errvalue!=0)
	{
		cout<< "Cannot create server thread."<<endl;
		return 1;
	}
	cout<<"Watek serwera utworzony poprawnie"<<endl;
	return 0;
};


