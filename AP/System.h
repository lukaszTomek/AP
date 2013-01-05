/*
 * System.h
 *
 *  Created on: 2012-11-30
 *      Author: Luka
 */

#ifndef SYSTEM_H_
#define SYSTEM_H_

#include "Main_Header.h"
#include "Component.h"
#include "Plane.h"

using namespace std;


extern pthread_rwlock_t componentsArrayLock;
extern pthread_rwlock_t planesArrayLock;
extern pthread_rwlock_t suitcasesArrayLock;
extern pthread_rwlock_t actPlanesLock;

extern Component * componentsArray[NOC];
extern list <Plane*> actPlanes;
extern list <Plane*> planesArray;
extern list <Suitcase*> suitcasesArray;

//TODO jeszcze inne locki

void* addPlaneInterruptionThread(void * arg);
void* addSuitcaseInterruptionThread(void * arg);
void* dropSuitcaseInterruptionThread(void * arg);
void* hurtConveyorInterruptionThread(void * arg);

bool initSystem();
void destroySystem();
bool run();
bool getOn();

bool addSuitcaseToQueue(Suitcase s);
void dropSuitcase(Suitcase s,int conveyor_id);


#endif /* SYSTEM_H_ */
