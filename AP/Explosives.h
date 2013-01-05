/*
 * Explosives.h
 *
 *  Created on: 2012-12-19
 *      Author: Admin
 */

#ifndef EXPLOSIVES_H_
#define EXPLOSIVES_H_

#include "Component.h"

class Explosives: public Component {
public:
	Explosives(int b);
	virtual ~Explosives();
	void *Run();
};

#endif /* EXPLOSIVES_H_ */
