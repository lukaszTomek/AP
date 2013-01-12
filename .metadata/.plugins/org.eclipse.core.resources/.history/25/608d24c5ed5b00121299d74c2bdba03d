#include <iostream>
#include <stdlib.h>
#include <pthread.h>
#include <sys/socket.h>
#include <sys/types.h>
#include <arpa/inet.h>
#include <errno.h>
#include "System.h"
using namespace std;
//ABRAKADABRA
int main(int argc, char *argv[])
{

	cout<<"Start programu"<<endl;
	if(run())
	{
		cout<<"System nie zostal zaladowany poprawnie. Nastapi wylaczenie programu."<<endl;
		return 0;
	}
	while(getOn())
	{
		delay(1000);
	}
return EXIT_SUCCESS;
}
