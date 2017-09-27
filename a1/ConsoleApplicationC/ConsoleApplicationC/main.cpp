#include <stdio.h>
#include <Windows.h>

#include <stdlib.h>
#include <signal.h>
#include <tchar.h>

//通过内存布局完成局部变量访问解析

void a()
{
	int arr[10];
	int i;
	for (i = 0; i<10; i++)
	{
		arr[i] = i;           //  初始化数组arr[]  
	}
}

void b()
{
	int arr2[100000000] = { 123 };
	int i;
	for (i = 0; i<10; i++)
	{
		printf("%d", arr2[i]); //未初始化arr2[]，直接输出它的值 
		printf("\n"); 
	}
	// 结果是输出0123456789  
}

//--------------------------------------
//signal 
void SignalHandler(int signal)
{
	if (signal == SIGABRT) {
		// abort signal handler code
		printf("SIGABRT");

	}
	else {
		// ...
		printf("other signal");
	}
}

int TestSignal()
{
	typedef void(*SignalHandlerPointer)(int);

	SignalHandlerPointer previousHandler;
	previousHandler = signal(SIGABRT, SignalHandler);

	abort();
	raise(SIGFPE);
	Sleep(2000);
	raise(SIGILL);
	Sleep(2000);
	raise(SIGINT);
	Sleep(2000);
	printf("press  ctrl + c");
	Sleep(10000);

}

//int _tmain(int argc, char* argv[])  Error	1	error LNK1561: entry point must be defined	d:\Users\v-shacui\documents\visual studio 2013\Projects\ConsoleApplicationC\ConsoleApplicationC\LINK	ConsoleApplicationC
int main(int argc, char* argv[])
{
	/*a();
	b();*/

	TestSignal();
	getchar();
	return 0;  //must return a value
}