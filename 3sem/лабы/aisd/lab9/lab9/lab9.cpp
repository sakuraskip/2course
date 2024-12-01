#include <iostream>
#include <Windows.h>
#include <limits.h>
using namespace std;

//const int N = 5;
//int cities[N][N] = 
//{
//	{ INT_MAX, 25, 40, 31, 27},
//	{ 5, INT_MAX, 17, 30, 25},
//	{ 19, 15, INT_MAX, 6, 1},
//	{ 9, 50, 24, INT_MAX, 6 },
//	{ 22, 8, 7, 10, INT_MAX }
//};
const int N = 8;
int cities[N][N] =
{
	{ INT_MAX, 25, 40, 31, 27,14,8,44},
	{ 5, INT_MAX, 17, 30, 25,11,28,45},
	{ 19, 15, INT_MAX, 6, 1,10,19,22},
	{ 9, 50, 24, INT_MAX, 6,14,17,29 },
	{ 22, 8, 7, 10, INT_MAX,14,17,31 },
	{14,15,29,41,15,INT_MAX,12,11},
	{

}
};


int main()
{
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
	setlocale(LC_ALL, "russian");	

}