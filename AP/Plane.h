/*
 * Plane.h
 *
 *  Created on: 2012-12-15
 *      Author: Admin
 */

#ifndef PLANE_H_
#define PLANE_H_
#include <string>
#include <sstream>
using namespace std;

class Plane {
private:
	int planeId;   //plane id
	int departureTime;
//TODO rêkaw czy cos?

public:
	string toString();
	string toShortString();
	Plane(int,int);
	virtual ~Plane();
};

#endif /* PLANE_H_ */
