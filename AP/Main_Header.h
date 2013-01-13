/*
 * Main_Header.h
 *
 *  Created on: 2012-12-10
 *      Author: Luka
 */

#ifndef MAIN_HEADER_H_
#define MAIN_HEADER_H_
#include <iostream>
#include <stdlib.h>
#include <pthread.h>
#include <sys/socket.h>
#include <sys/types.h>
#include <arpa/inet.h>
#include <sys/neutrino.h>
#include <unistd.h>
#include <errno.h>
#include <string>


#define SPECIAL_PORT 5678
#define STATES_PORT 5679

#define NOC 27 /*number of components*/
#define NOP 3 /*number of planes, IT ISN'T a QUEUE OF PLANES!*/

#define CHECKIN_TIME 10000


enum RequestType
{
	ADD_SUITCASE,
	ADD_PLANE,
	HURT_CONVEYOR,
	DROP_SUITCASE_FROM_CONVEYOR,
	GET_FULL_STATE,
	GET_STATE,
};


#endif /* MAIN_HEADER_H_ */
