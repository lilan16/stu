// ConsoleApplicationCPP.cpp : 定义控制台应用程序的入口点。
//

#include "stdafx.h"
#include<Windows.h>
#include "VectoredEH.h"


void t_stdout();
int typeConvert();

int main_color_hw();
int access_system_space();
int manual_breakporint();
int exception_deal_how();
void unhandle_exception_filter();
void create_c_exp();

int main()
{
	//t_stdout();
	//typeConvert();
	//main_color_hw();
	//access_system_space();
	//manual_breakporint();
	//exception_deal_how();
	//main_veh();
	unhandle_exception_filter();
	//create_c_exp();

    return 0;
}


//0320
void create_c_exp()
{
	printf("aa", 1);
	printf("aa%d%d", 1);
	char *p = NULL;
	p = "aaaa";
}
//0310
void unhandle_exception_filter()
{
	printf("goint to assign vlue to null pointer");
	*(int *)0 = 1;
	
}

// 17.06.21
int exception_deal_how()
{
	int i, m, n;
	getchar();
	__try
	{
		m = 10;
		n = 0;
		i = m / n;
	}
	__except (EXCEPTION_EXECUTE_HANDLER)
	{
		//OutputDebugString("i got a exception");
		printf("i got a exception");
		return -1;
	}
	return 0;
}
// 12.22
int manual_breakporint()
{
	printf("aaaaaa");
	_asm int 3
	printf("bbbbbb");

	return 0;
}
//  16.12.19
int access_system_space()
{
	printf("i want to access kernal space \n");
	*(int*)0xa08080800 = 0x22;
	//stop work, appCrash
	//in .net ,what error?
	printf("i would never reach so far  ");
	return 0;
}
void t_stdout()
{
	fprintf(stdout, "std out");
	printf("  ");
	fprintf(stderr, "std err");
	printf("---------------");
	fprintf(stdout, "std out");
	printf("  ");
	fprintf(stderr, "std err");
}

int typeConvert()
{
	float a = 12.5;
	printf("%d\n", a);
	printf("%d\n", (int)a);
	printf("%d\n", *(int *)&a);
	return 0;
}

#include <windows.h>
//GetStdHandle和SetConsoleTextAttribute在头文件windows.h中
#include <iostream>
using namespace std;

//实现一个彩色的Hello World！
// call kernal32.dll

void SetColor(unsigned short ForeColor = 3, unsigned short BackGroundColor = 0)
//给参数默认值，使它
//可以接受0/1/2个参数
{
	HANDLE hCon = GetStdHandle(STD_OUTPUT_HANDLE); //本例以输出为例
	SetConsoleTextAttribute(hCon, ForeColor | BackGroundColor);
}
int main_color_hw()
{
	SetColor();
	std::cout << "Hello world!" << endl;
	SetColor(40, 30);
	std::cout << "Hello world!" << endl;
	std::cout << "Hello world!" << endl;
	return 0;
}
void coordinate(int x, int y)
{
	COORD c; //定义表示一个字符在控制台屏幕上的坐标的对象
	c.X = x;
	c.Y = y;
	SetConsoleCursorPosition(GetStdHandle(STD_OUTPUT_HANDLE), c);
	/*定位光标位置的函数，坐标为GetStdHandle（）返回标准的输出的句柄，也就是获得输出屏幕缓冲区的句柄，并赋值给对象c*/
}
