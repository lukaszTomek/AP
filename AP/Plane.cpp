/*
 * Plane.cpp
 *
 *  Created on: 2012-12-15
 *      Author: Admin
 */

#include "Plane.h"

Plane::Plane(int pId, int dTime) {
	// TODO Auto-generated constructor stub
	planeId=pId;
	departureTime=dTime;
}

Plane::~Plane() {
	// TODO Auto-generated destructor stub
}

string Plane::toString()
{
	string message;
	stringstream out;

	out << planeId;
	message += out.str();
	message +=",";
	out.str("");

	out << departureTime;
	message += out.str();
	message+=",";
	out.str("");

	return message;
}

string Plane::toShortString()
{
	return toString();
}
