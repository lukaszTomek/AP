/*
 * Component.h
 *
 *  Created on: 2012-12-05
 *      Author: Luka
 */

#ifndef COMPONENT_H_
#define COMPONENT_H_

#include "Suitcase.h"
#include "Runnable.h"
#include <vector>
#include <semaphore.h>
#include <list>


using namespace std;

class Component : public Runnable {

protected:
	vector <Component*> inputs;
	vector <Component*> oututs;
	int inputsSize,outputsSize;
	bool inputActive;
	bool outputActive;
	bool working;
	sem_t actSem;
	int componentId;
	list <Suitcase> suitcasesInComp;

public:
	list <Suitcase> getsuitcasesInComp()
	{
		return suitcasesInComp;
	};
	int getComponentId()
	{
		return componentId;
	};
	Component();
	~Component();
	void TurnOffInputs();
	void TurnOnInputs();
	void TurnOn();
	void TurnOff();
	virtual void* Run()=0;
	void DisactivateInput();
	void ActivateInput();
	void DisactivateOutput();
	void ActivateOutput();
	string toString();
	string toShortString();
	virtual void Initialize();

};

#endif /* COMPONENT_H_ */
