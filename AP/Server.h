/*
 * Server.h
 *
 *  Created on: 2012-11-30
 *      Author: Luka
 */

#ifndef SERVER_H_
#define SERVER_H_

#include "Runnable.h"
#include "Component.h"
#include "Plane.h"

using namespace std;

class MessageInfo
{
private:
	int object_id;


public:
	RequestType reqType;

		Plane * planeInfo;
		Component * componentInfo;
		Suitcase * suitcaseInfo;
	void allocateSuitcase(int idS, int pI, int w, int d, int b)
	{
		suitcaseInfo=new Suitcase(idS,pI,w,d,b);
	};
	void deallocateSuitcase()
	{
		delete[] suitcaseInfo;
	};
	Plane * GetPlaneInfo()
	{
		return planeInfo;
	};
	Component * GetComponentInfo()
	{
		return componentInfo;
	};
	void allocatePlane(int pId, int dT)
	{
		planeInfo=new Plane(pId,dT);
	};
	void deallocatePlane()
	{
		delete[] planeInfo;
	};
};


/////////////////////////
class Server : public Runnable{
private:

	int aSConnectionId;
	int dSConnectionId;
	char request[1024];
	char reply[1024];
	int clientSock;  //client's socket
	int serverSock;	 //server's socket

public:

	MessageInfo msgInfo;
	Server(int as_id,int ds_id);
	virtual ~Server();

	//bool Init();            //returns 1 when error occurs
	void* Run();

	bool Serialize(string msg, int reply_info);
	bool Deserialize(string msg, MessageInfo& MI);
	string makeFullState();
	string makeState();
};

#endif /* SERVER_H_ */
