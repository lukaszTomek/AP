/*
 * Suitcase.h
 *
 *  Created on: 2012-12-10
 *      Author: Luka
 */

#ifndef SUITCASE_H_
#define SUITCASE_H_


#include <string>
#include <sstream>

using namespace std;

class Component;

class Suitcase {
private:
	int suitcaseId;   //suitcase id
	int planeId;
	bool drugs;
	int weight;
	bool explosive;
	int progress; // value from 0 to 100
	Component* component;

public:

	Suitcase(int,int,int,int,int,Component*);
	Suitcase(int,int,int,int,int);
	Suitcase();
	virtual ~Suitcase();
	string toString();
	string toShortString();
	int getCompId();
	int getProgress();
	void setComponent(Component* comp);
	void setProgress(int prog);
};

#endif /* SUITCASE_H_ */
