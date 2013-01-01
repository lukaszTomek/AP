/*
 * System.cpp
 *
 *  Created on: 2012-11-30
 *      Author: Luka
 */

#include "System.h"
#include "Server.h"


using namespace std;

//extern pthread_rwlock_t conveyorArrayLock;
pthread_rwlock_t componentArrayLock;
pthread_rwlock_t planesArrayArrayLock;
//extern pthread_rwlock_t connectorArrayLock;
//extern pthread_rwlock_t checkinArrayLock;
//extern pthread_rwlock_t drugsArrayLock;
//extern pthread_rwlock_t explosivesArrayLock;
pthread_rwlock_t suitcasesArrayArrayLock;
//extern pthread_rwlock_t plantArrayLock;
pthread_rwlock_t planesArrayLock;

/*
 * shortcuts:
 *
 * aS - addSuitcase
 * dS - dropSuitcase
 * hC - hurtConveyor
 */
pthread_rwlock_t conveyorArrayLock;
pthread_t aSIThread;
pthread_attr_t aSIThreadAttr;
int aSIChId;
pthread_t dSIThread;
pthread_attr_t dSIThreadAttr;
int dSIChId;

list <Suitcase> suitcasesArray;
list <Plane> planesArray;
Component* Components[NOC];
Plane* Planes[NOP];

Server* server;
unsigned qSize;
bool on;

void destroySystem()
{
	// TODO Auto-generated destructor stub
	cout<<"destruktor systemu"<<endl;
}


void* aSThreadFunc(void * arg)
{
	struct _pulse pdata;
	/* Scheduling policy: FIFO or RR */
	int policy;
	/* Structure of other thread parameters */
	struct sched_param param;
	cout<<"ASprzed"<<endl;
	/* Read modify and set new thread priority */
	pthread_getschedparam( pthread_self(), &policy, &param);
	param.sched_priority = sched_get_priority_max(policy);
	pthread_setschedparam( pthread_self(), policy, &param);

	/* Create new channel */
	aSIChId = ChannelCreate(0);
	for (;;)
	{
		MsgReceivePulse(aSIChId, (void *)&pdata, sizeof(pdata), NULL);
	}

	return 0;
}
void* dSThreadFunc(void * arg)
{
	struct _pulse pdata;
	/* Scheduling policy: FIFO or RR */
	int policy;
	/* Structure of other thread parameters */
	struct sched_param param;
	cout<<"DSprzed"<<endl;
	/* Read modify and set new thread priority */
	pthread_getschedparam( pthread_self(), &policy, &param);
	param.sched_priority = sched_get_priority_max(policy);
	pthread_setschedparam( pthread_self(), policy, &param);

	/* Create new channel */
	dSIChId = ChannelCreate(0);

	for (;;)
	{
		MsgReceivePulse(dSIChId, (void *)&pdata, sizeof(pdata), NULL);

	}
	return 0;
}

/* LISTA BAGA¯Y W KOLEJCE PRZED CHECKINAMI
 * front - element pierwszy który wychodzi - pocztek kolejki
 * back - element ostatni, tam ustawimy
 *
 *
 * */
bool addSuitcaseToQueue(Suitcase s)
{
	if(suitcasesArray.size()==qSize)
		return 0;
	suitcasesArray.push_back(s);
	return 1;
}

void dropSuitcase(Suitcase suitcase, int conveyor_id)
{
	return;
}

bool run(){

	on=1;
	qSize=1024;

	//pthread_rwlock_init(&conveyorArrayLock, NULL);
	//pthread_rwlock_init(&connectorArrayLock, NULL);
	pthread_rwlock_init(&componentArrayLock, NULL);
	pthread_rwlock_init(&planesArrayArrayLock, NULL);
	//pthread_rwlock_init(&checkinArrayLock, NULL);
	//pthread_rwlock_init(&drugsArrayLock, NULL);
	//pthread_rwlock_init(&explosivesArrayLock, NULL);
	pthread_rwlock_init(&suitcasesArrayArrayLock, NULL);
	//pthread_rwlock_init(&plantArrayLock, NULL);
	pthread_rwlock_init(&planesArrayLock, NULL);



	pthread_attr_init(&aSIThreadAttr);
	pthread_attr_setschedpolicy(&aSIThreadAttr, SCHED_FIFO);

	/* Start thread */
	if (pthread_create( &aSIThread, NULL, aSThreadFunc, &aSIThreadAttr)) {
		cout<< "Cannot create AS_Thread."<<endl;
		return 1;
	}
	delay(100);
	pthread_attr_init(&dSIThreadAttr);
	pthread_attr_setschedpolicy(&dSIThreadAttr, SCHED_FIFO);

		/* Start thread */
	if (pthread_create( &dSIThread, NULL, dSThreadFunc, &dSIThreadAttr)) {
		cout<< "Cannot create DS_Thread."<<endl;
		return 1;
	}

	server=new Server(aSIChId,dSIChId);
	if(server->Start())
	{
		cout<<"Wystapil blad"<<endl;
		return 1;
	}
	else
		cout<<"Serwer zaladowany"<<endl;
	return 0;
}

bool getOn()
{
	return on;
}
