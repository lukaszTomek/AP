/*
 * SuitcaseQueue.h
 *
 *  Created on: 2013-01-13
 *      Author: Luka
 */

#ifndef SUITCASEQUEUE_H_
#define SUITCASEQUEUE_H_

#include "Component.h"

class SuitcaseQueue: public Component {

public:
	SuitcaseQueue();
	SuitcaseQueue(int id);
	virtual ~SuitcaseQueue();

	void* Run();
};

#endif /* SUITCASEQUEUE_H_ */
