/*
 * Suitcase.cpp
 *
 *  Created on: 2012-12-10
 *      Author: Luka
 */

#include "Suitcase.h"
#include "Component.h"

Suitcase::Suitcase(int sId, int pId, int w, int d, int b)
{
	// TODO How to contruct suitcase with a reference to its component
	suitcaseId=sId;
	planeId=pId;
	drugs=d;
	weight=w;
	explosive=b;
	progress=0;
}

Suitcase::Suitcase()
{
	// TODO Auto-generated constructor stub
}


Suitcase::~Suitcase()
{
	// TODO Auto-generated destructor stub
}


int Suitcase::getCompId()
{
	return component->getComponentId();
}
string Suitcase::toString()
{
	string addon;
	if(drugs==1)
		addon="n";
	else if(explosive==1)
		addon="w";
	else
		addon=="0";

	string message;
	stringstream out;

	out << suitcaseId;
	message += out.str();
	message +=",";
	out.str("");

	out << planeId;
	message += out.str();
	message +=",";
	out.str("");

	out << weight;
	message += out.str();
	message +=",";
	out.str("");

	message+=addon;
	message +=",";
	out.str("");

	message+=getCompId();
	message+=",";
	out.str("");

	message+=progress;
	message+=",";
	out.str("");

	return message;
}

string Suitcase::toShortString()
{
	string message;
	stringstream out;

	out << suitcaseId;
	message += out.str();
	message +=",";
	out.str("");

	message+=getCompId();
	message+=",";
	out.str("");

	message+=progress;
	message+=",";
	out.str("");

	return message;
}
