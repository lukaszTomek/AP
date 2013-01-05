/*
 * Connector.h
 *
 *  Created on: 2012-12-19
 *      Author: Admin
 */

#ifndef CONNECTOR_H_
#define CONNECTOR_H_

#include "Component.h"

class Connector: public Component {
public:
	Connector(int b);
	virtual ~Connector();
	void *Run();
};



#endif /* CONNECTOR_H_ */
