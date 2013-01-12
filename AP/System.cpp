/*
 * System.cpp
 *
 *  Created on: 2012-11-30
 *      Author: Luka
 */

#include "System.h"
#include "Server.h"
#include "Checkin.h"
#include "Conveyor.h"
#include "Connector.h"
#include "Drugs.h"
#include "Explosives.h"
#include "Sorting.h"



using namespace std;


pthread_rwlock_t componentsArrayLock;
pthread_rwlock_t planesArrayLock;
pthread_rwlock_t suitcasesArrayLock;
pthread_rwlock_t actPlanesLock;

/*
 * shortcuts:
 *
 * aS - addSuitcase
 * dS - dropSuitcase
 * hC - hurtConveyor
 */

pthread_t aSIThread;
pthread_attr_t aSIThreadAttr;
int aSIChId;
pthread_t dSIThread;
pthread_attr_t dSIThreadAttr;
int dSIChId;

list <Suitcase*> suitcasesArray;
list <Plane*> planesArray;
Component* componentsArray[NOC];
list <Plane*> actPlanes;

Server* specialEventsServer;
Server* statesCheckingServer;
unsigned qSize;
bool on;

void destroySystem()
{
	// TODO Auto-generated destructor stub
	cout<<"destruktor systemu"<<endl;
}

void makeConnetion()
{

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
		cout<<"nowy suitcase"<<endl;
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
bool addSuitcaseToQueue(Suitcase* s)
{
	cout<<"dodawanie suitcase'a"<<endl;
	if(suitcasesArray.size()==qSize)
		return 0;
	suitcasesArray.push_back(s);
	return 1;
}

bool makeConnection(Component * a, Component * b)
{

	b->addInput(a);
	a->addOutput(b);
	return true;
}

void dropSuitcase(Suitcase suitcase, int conveyor_id)
{
	return;
}

bool run(){

	on=1;
	qSize=1024;
	/*TWORZENIE KOMPONENTÓW*/
	componentsArray[0]=new Drugs(55);
	componentsArray[1]=new Explosives(75);
	componentsArray[2]=new Sorting(95);
	int i=3;
	for(int n=1;n<=4;n++,i++)
		componentsArray[i]=new Checkin(n);
	for(int n=10;n<=90;i++,n=n+10)
		componentsArray[i]=new Connector(n);
	for(int n=110;n<=440;i++,n=n+110)
		componentsArray[i]=new Conveyor(n);
	for(int n=1020;n<=4050;i++,n=n+1010)
		componentsArray[i]=new Conveyor(n);
	componentsArray[i]=new Conveyor(6070);
	componentsArray[++i]=new Conveyor(8090);

	//debug - dodawanie nowej walizki do systemu.
	componentsArray[5]->addsuitcaseToComp(new Suitcase(9,125,125,1,0,componentsArray[8]));
	componentsArray[24]->addsuitcaseToComp(new Suitcase(9,125,125,1,0,componentsArray[24]));

	for(int i=0;i<4;i++)
	{
		makeConnection(componentsArray[i+3],componentsArray[i+16]);
		makeConnection(componentsArray[i+16],componentsArray[i+7]);
		makeConnection(componentsArray[i+7],componentsArray[i+20]);
		makeConnection(componentsArray[i+20],componentsArray[i+8]);
	}
	makeConnection(componentsArray[11],componentsArray[0]);
	makeConnection(componentsArray[0],componentsArray[12]);

	makeConnection(componentsArray[12],componentsArray[24]);
	makeConnection(componentsArray[24],componentsArray[13]);
	makeConnection(componentsArray[13],componentsArray[1]);
	makeConnection(componentsArray[1],componentsArray[14]);
	makeConnection(componentsArray[14],componentsArray[25]);
	makeConnection(componentsArray[25],componentsArray[15]);
	makeConnection(componentsArray[15],componentsArray[2]);

	//pthread_rwlock_init(&conveyorArrayLock, NULL);
	//pthread_rwlock_init(&connectorArrayLock, NULL);
	pthread_rwlock_init(&componentsArrayLock, NULL);
	pthread_rwlock_init(&planesArrayLock, NULL);
	//pthread_rwlock_init(&checkinArrayLock, NULL);
	//pthread_rwlock_init(&drugsArrayLock, NULL);
	//pthread_rwlock_init(&explosivesArrayLock, NULL);
	pthread_rwlock_init(&suitcasesArrayLock, NULL);
	//pthread_rwlock_init(&plantArrayLock, NULL);
	pthread_rwlock_init(&actPlanesLock, NULL);



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

	specialEventsServer =new Server(aSIChId,dSIChId,SPECIAL_PORT);
	if(specialEventsServer->start())
	{
		cout<<"Wystapil blad przy ladowaniu serwera"<<endl;
		return 1;
	}
	else
		cout<<"Serwer zaladowany"<<endl;

	statesCheckingServer =new Server(aSIChId,dSIChId,STATES_PORT);
	if(statesCheckingServer->start())
	{
		cout<<"Wystapil blad przy ladowaniu serwera"<<endl;
		return 1;
	}
	else
		cout<<"Serwer zaladowany"<<endl;

	//DEBBUG

	cout<<"Metoda zwrocila"<<statesCheckingServer->makeFullState()<<endl;
	///////
	return 0;

}

bool getOn()
{
	return on;
}
