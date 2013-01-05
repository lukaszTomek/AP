/*
 * Drugs.h
 *
 *  Created on: 2012-12-19
 *      Author: Admin
 */

#ifndef DRUGS_H_
#define DRUGS_H_

#include "Component.h"

class Drugs: public Component {
public:
	Drugs(int b);
	virtual ~Drugs();
	void *Run();
};

#endif /* DRUGS_H_ */
