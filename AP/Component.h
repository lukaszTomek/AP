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
	vector <Component*> outputs;

	unsigned stackSize;
	bool inputActive;
	bool outputActive;
	bool working;
	int componentId;

public:
	list <Suitcase*> suitcasesInComp;
	bool addSuitcaseToComp(Suitcase* s);          //1 isDone, 0 isnt possible

	int getComponentId()
	{
		return componentId;
	};
	Component();
	~Component();
	void turnOffInputs();
	void turnOnInputs();
	void TurnOn();
	void TurnOff();
	int getConnId();
	virtual void* Run()=0;
	void DisactivateInput();
	void activateInput();
	void DisactivateOutput();
	void activateOutput();
	string toString();
	string toShortString();
	virtual void Initialize();
	void addInput(Component *);
	void addOutput(Component *);

};

#endif /* COMPONENT_H_ */
