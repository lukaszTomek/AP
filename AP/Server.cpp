/*
 * Server.cpp
 *
 *  Created on: 2012-11-30
 *      Author: Luka
 */

#include "Server.h"
#include "System.h"
#include <fstream>

Server::Server(int as_id, int ds_id ) {
	// TODO Auto-generated constructor stub
	maxPriority=0;
	aSConnectionId=as_id;
	dSConnectionId=ds_id;
}

Server::~Server() {
	// TODO Auto-generated destructor stub
	cout<<"Destruktor serwera"<<endl;
}

void* Server::Run()
{
	int result;
	serverSock = socket( AF_INET, SOCK_STREAM, IPPROTO_TCP);
	sockaddr_in sockaddr;
	memset( &sockaddr, 0, sizeof sockaddr );

	sockaddr.sin_family = AF_INET;
	sockaddr.sin_addr.s_addr = htonl(0);
	sockaddr.sin_port =  htons(PORT) ;

	result=bind( serverSock, (struct sockaddr *) &sockaddr, sizeof sockaddr );
	if ( result<0 )
	{
	    cout<<"could not start server";
	    return 0;
	}
	result=listen( serverSock, SOMAXCONN);

	socklen_t length;
	length = sizeof sockaddr;

	while(true)
	{
		clientSock = accept( serverSock, (struct sockaddr *) &sockaddr, &length );
		cout<<"Connection with some socket established"<<endl;
		int iResult;
		do
		{
			//WYKOMENTOWANE ¯EBYM MÓGL ZROBIC SWOJEGO REQUESTA DO DESERIALIZACJI
			//iResult=recv(clientSock, request, 1024, 0);
			iResult=2;
			//MOJ REQUEST
			string dane="25";
			for(int i=0;i<dane.length();i++)
				request[i]=dane[i];

			/*fstream plik;
			plik.open("request.txt", ios::in);
			if(plik.good())
				cout<<"OKEJ"<<endl<<endl;
			else
				cout<<"NIE OK"<<endl<<endl;
			getline( plik, request );*/

			if ( iResult > 0 )
			{
				cout<<"Bytes received: "<< iResult<<endl;
				cout<<endl<<"otrzymalem:"<<request<<endl;
			}
			else if ( iResult == 0 )
				printf("Connection closed\n");
			else
			{
				errvalue = errno;
				cout<<"The error generated was "<< errvalue<<endl;
				cout<<"That means: "<< strerror( errvalue )<<endl;
			}
			cout<<"Request";
			cout<<request<<endl;      //debug

			if(!Deserialize(request,msgInfo))
				cout<<"Problem with deserialization!"<<endl;

			switch(msgInfo.ReqType)
			{
			case GET_STATE:
				Serialize(reply,2);   //2 means command to send states
				break; 			//1 means succes and 0 failure

			case GET_FULL_STATE:
				Serialize(reply,3);   //2 means command to send states
				break; 					  //1 means succes and 0 failure

			case ADD_SUITCASE:
				MsgSendPulse(dSConnectionId, sched_get_priority_max(SCHED_FIFO), _PULSE_CODE_MAXAVAIL, (int)&(msgInfo.suitcaseInfo));
				Serialize(reply,1);
				break;

			case ADD_PLANE:
				//MsgSendPulse(dSConnectionId, sched_get_priority_max(SCHED_FIFO), _PULSE_CODE_MAXAVAIL, (int)&(msgInfo.planeInfo));
				Serialize(reply,1);
				break;

			case DROP_SUITCASE_FROM_CONVEYOR:
				MsgSendPulse(dSConnectionId, sched_get_priority_max(SCHED_FIFO), _PULSE_CODE_MAXAVAIL, (int)&(msgInfo.suitcaseInfo));
				Serialize(reply,1);
				break;

			case HURT_CONVEYOR:
				MsgSendPulse(dSConnectionId, sched_get_priority_max(SCHED_FIFO), _PULSE_CODE_MAXAVAIL, (int)&(msgInfo.componentInfo));
				Serialize(reply,1);
				break;

			default:
				cout<<"Urecognised command"<<endl;
				break;
			};

			iResult=send(clientSock,reply,strlen(reply),0);
			if ( iResult > 0 )
			{
				cout<<"Bytes send: "<<iResult<<endl;
				cout<<endl<<"Sended: "<<reply<<endl;
			}
			else if ( iResult == 0 )
				cout<<"Connection closed"<<endl;
			else
			{
				errvalue = errno;
				cout<<"The error generated was "<<errvalue ;
				cout<<"That means: "<<strerror( errvalue ) ;
				break;
			}

		}while(iResult);

	}
	return 0;
}

bool Server::Serialize(string msg, int replyInfo)
{
	switch(replyInfo)
		{
		case ADD_SUITCASE:
			{
				msg="1";
				break;
			}
		case ADD_PLANE:
			{
				msg="1";
				break;
			}
		case HURT_CONVEYOR:
			{
				msg="1";
				break;
			}
		case DROP_SUITCASE_FROM_CONVEYOR:
			{
				msg="1";
				break;
			}
		case GET_FULL_STATE:
			{
				msg=makeFullState();
				break;
			}
		case GET_STATE:
			{
				msg=makeState();
				break;
			}
		default:
			cout<<"Unrecognised Request Type"<<endl;
			msg="0";
			return 0;
		}
	cout<<msg;
	return 1;
}
bool Server::Deserialize(string msg, MessageInfo& MI)
{
	switch((int)msg[0]-(int)'0')
	{
	case ADD_SUITCASE:
	{
		string value;
		int start=1, step=0, i=1;
		int id,planeId,weight,drug=0,bomb=0;
		do
		{
			if(msg[i]==','||i==(msg.length()))
			{
				value=msg.substr(start,i-start);
				if(step==0)
					id=atoi(value.c_str());
				else if (step==1)
					planeId=atoi(value.c_str());
				else if (step==2)
					weight=atoi(value.c_str());
				else if (step==3)
				{
					if(value=="n")
						{drug=1; bomb=0;}
					else if(value=="w")
						{bomb=1; drug=0;}
					else if(value=="0")
						{drug=0; bomb=0;}
					else
						cout<<"Error of value of drugs/bombs, acceptable is 0,n,w";
				}
				else
					cout<<"Error value of message for suitcaseInfo";
				start=i+1;
				step++;
			}
			i++;

		} while (i<=msg.length());

		MI.deallocateSuitcase();
		MI.allocateSuitcase(id,planeId,weight,drug,bomb);

		cout<<"Allocate Suitcase "<<"Id "<<id<<"plane id "<<planeId<<"weight "<<weight<<"drug "<<drug<<"Bomb "<<bomb<<endl;

		break;
	}
	case ADD_PLANE:
	{
		string value;
		int start=1, step=0, i=1;
		int idP,time;
		do
		{
			if(msg[i]==','||i==(msg.length()))
			{
				value=msg.substr(start,i-start);
				cout<<"step = "<<step<<" value = "<<value<<" start = "<<start<<" i= "<<i<<endl;
				if(step==0)
					idP=atoi(value.c_str());
				else if (step==1)
					time=atoi(value.c_str());
				else
					cout<<"Error value of message for planeInfo";
				start=i+1;
				step++;
			}
			i++;

		} while (i<=msg.length());
		MI.deallocatePlane();
		MI.allocatePlane(idP,time);

		cout<<"AllocatePlane "<<"Plane Id "<<idP<<" time "<<time<<endl;

		break;
	}

	case HURT_CONVEYOR:
	{
		string value;
		int conveyorNumber; //conveyor to hurt

		value=msg.substr(1,msg.length()-1);
		conveyorNumber=atoi(value.c_str());
		MI.GetComponentInfo();

		cout<<"hurt conveyor no: "<<conveyorNumber<<". "<<endl;

		break;
	}
	case DROP_SUITCASE_FROM_CONVEYOR:
		{
			string value;
			int sId; //conveyor to hurt

			value=msg.substr(1,msg.length()-1);
			sId=atoi(value.c_str());

			MI.componentInfo->TurnOff();//TODO JAK TO WYWALIÆ Z TEJ TASMY/HOW TO DROP IT OFF?

			cout<<"drop suitcase from conveyor "<<sId<<" "<<endl;

			break;
		}
	case GET_FULL_STATE:
		{
			cout<<"Client want to get a full state"<<endl;
			break;
		}
	case GET_STATE:
		{
			cout<<"Client want to get a state"<<endl;
			break;
		}
	default:
		cout<<"Urecognised Request Type"<<endl;
		return 0;
	}

	return true;
}


string Server::makeFullState()
{
	string msg;
	msg[0]='4';

/*INFO BAGA¯E*/

	for(int i=0;i<NOC;i++)
	{
		for(list<Suitcase>::iterator it=Components[i]->getsuitcasesInComp().begin();it!=Components[i]->getsuitcasesInComp().end();it++)
		{
			pthread_rwlock_rdlock(&componentArrayLock);
			msg+=(*it).toString();
			msg+=";";
			pthread_rwlock_unlock(&componentArrayLock);
		}
	}

	for(list<Suitcase>::iterator it=suitcasesArray.begin();it!=suitcasesArray.end();it++)
	{
		pthread_rwlock_rdlock(&suitcasesArrayArrayLock);
		msg+=(*it).toString();
		msg+=";";
		pthread_rwlock_unlock(&suitcasesArrayArrayLock);
	}
	msg+="/";

/*INFO KOMPONENETY*/

	for(int i=0;i<NOC;i++)
	{
		pthread_rwlock_rdlock(&componentArrayLock);
		msg+=Components[i]->toString();
		pthread_rwlock_unlock(&componentArrayLock);
		msg+=";";
	}

	msg+="/";

/*INFO SAMOLOTY*/

	for(int i=0;i<NOP;i++)
	{
		pthread_rwlock_rdlock(&planesArrayLock);
		msg+=Planes[i]->toString();
		pthread_rwlock_unlock(&planesArrayLock);
		msg+=";";
	}
	msg+="/";
/*KOLEJKA SAMOLOTÓW*/

	for(list<Plane>::iterator it=planesArray.begin();it!=planesArray.end();it++)
	{
		pthread_rwlock_rdlock(&planesArrayArrayLock);
		msg+=(*it).toString();
		pthread_rwlock_unlock(&planesArrayArrayLock);
		msg+=";";
	}

	msg+="/";
	/*FLAGA WYKRYCIA NARKOTYKÓW*/
	msg+="/";
	/*FLAGA WYKRYCIA WYBUCHOWYCH*/
	msg+="/";
	/*ILOSC NARKOTYKOW*/
	msg+="/";
	/*ILOSC WYBUCHOWYCH*/
	msg+="/";

	return msg;

}

string Server::makeState()
{
	string msg;
	msg[0]='5';

	/*INFO BAGA¯E*/

		for(int i=0;i<NOC;i++)
		{
			for(list<Suitcase>::iterator it=Components[i]->getsuitcasesInComp().begin();it!=Components[i]->getsuitcasesInComp().end();it++)
			{
				pthread_rwlock_rdlock(&componentArrayLock);
				msg+=(*it).toShortString();
				msg+=";";
				pthread_rwlock_unlock(&componentArrayLock);
			}
		}

	msg+="/";
	/*kolejka do check-inow*/
	for(list<Suitcase>::iterator it=suitcasesArray.begin();it!=suitcasesArray.end();it++)
	{
		pthread_rwlock_rdlock(&suitcasesArrayArrayLock);
		msg+=(*it).toShortString();
		msg+=";";
		pthread_rwlock_unlock(&suitcasesArrayArrayLock);
	}

	msg+="/";

/*INFO KOMPONENETY*/

	for(int i=0;i<NOC;i++)
	{
		pthread_rwlock_rdlock(&componentArrayLock);
		msg+=Components[i]->toShortString();
		pthread_rwlock_unlock(&componentArrayLock);
		msg+=";";
	}

	msg+="/";


	/*INFO SAMOLOTY*/

		for(int i=0;i<NOP;i++)
		{
			pthread_rwlock_rdlock(&planesArrayLock);
			msg+=Planes[i]->toShortString();
			pthread_rwlock_unlock(&planesArrayLock);
			msg+=";";
		}
		msg+="/";
	/*KOLEJKA SAMOLOTÓW*/

		for(list<Plane>::iterator it=planesArray.begin();it!=planesArray.end();it++)
		{
			pthread_rwlock_rdlock(&planesArrayArrayLock);
			msg+=(*it).toShortString();
			pthread_rwlock_rdlock(&planesArrayArrayLock);
			msg+=";";
		}

	msg+="/";
	/*FLAGA WYKRYCIA NARKOTYKÓW*/
	msg+="/";
	/*FLAGA WYKRYCIA WYBUCHOWYCH*/
	msg+="/";
	/*ILOSC NARKOTYKOW*/
	msg+="/";
	/*ILOSC WYBUCHOWYCH*/
	msg+="/";

	return msg;

}




/*
bool Server::Init()
{

	pthread_attr_init(&serverThreadAttr);
	param.sched_priority = sched_get_priority_min(policy);
	pthread_attr_setschedpolicy(&serverThreadAttr, SCHED_FIFO);

	cout<<"Tworzenie watku..."<<endl;
	errvalue=pthread_create(&serverThread,&serverThreadAttr, proces, NULL);
	cout<<"Watek utworzony"<<endl;
	if (errvalue!=0)
	{
		cout<< "Cannot create server thread."<<endl;
		return 1;
	}
	cout<<"Watek serwera utworzony poprawnie"<<endl;
	return 0;
}*/

