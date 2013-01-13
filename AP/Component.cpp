/*
 * Component.cpp
 *
 *  Created on: 2012-12-05
 *      Author: Luka
 */

#include "Component.h"
#include "Runnable.h"
Component::Component()
{
	activateInput();
	threadChannel=ChannelCreate(0);
	threadConnId=ConnectAttach(0,getpid(), threadChannel,0,0);
}
Component::~Component()
{

}
void Component::turnOffInputs() {

	return;
}
void Component::turnOnInputs() {

	return;
}
void Component::TurnOff()
{
	working=0;
}
void Component::TurnOn()
{
	working=1;
}
int Component::getConnId()
{
	return threadConnId;
}
void Component::DisactivateInput()
{
	inputActive=0;
}
void Component::activateInput()
{
	inputActive=1;
}

void Component::activateOutput()
{
	outputActive=1;
}
void Component::DisactivateOutput()
{
	outputActive=0;
}

void Component::Initialize()
{
	//sem_init(&actSem,0,1);

}
bool Component::addSuitcaseToComp(Suitcase * s)
{
	if(inputActive && suitcasesInComp.size()<stackSize)
	{

		s->setComponent(this);

		suitcasesInComp.push_front(s);

		return 1;
	}
	return 0;
}
string Component::toString()
{
	string message;
	stringstream out;

	out << componentId;
	message += out.str();
	message +=",";
	out.str("");

	out << working;
	message += out.str();
	message+=",";
	out.str("");

	return message;
}

string Component::toShortString()
{
	return toString();
}

void Component::addOutput(Component * c)
{
	outputs.push_back(c);
}
void Component::addInput(Component * c)
{
	inputs.push_back(c);
}

