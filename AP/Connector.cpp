/*
 * Connector.cpp
 *
 *  Created on: 2012-12-19
 *      Author: Admin
 */

#include "Connector.h"

Connector::Connector(int b)
{
	componentId=b;
	working=1;

}

Connector::~Connector() {
	// TODO Auto-generated destructor stub
}

void *Connector::Run()
{
	return 0;
}
