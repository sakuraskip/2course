#include <iostream>
#include <locale>
#include "Auxil.h"                            // ��������������� ������� 
#include "stdafx.h"
#include "fibo.h"


#define  CYCLE  500000                       // ���������� ������  

int main()
{

	double  av1 = 0, av2 = 0;
	clock_t  t1 = 0, t2 = 0,t3=0,t4=0;
	int fibnum;

	setlocale(LC_ALL, "rus");

	auxil::start();                          // ����� ��������� 
	t1 = clock();                            // �������� ������� 
	for (int i = 0; i < CYCLE; i++)
	{
		av1 += (double)auxil::iget(-100, 100); // ����� ��������� ����� 
		av2 += auxil::dget(-100, 100);         // ����� ��������� ����� 
	}
	t2 = clock();                            // �������� ������� 


	std::cout << std::endl << "���������� ��������:         " << CYCLE;
	std::cout << std::endl << "������� �������� (int):    " << av1 / CYCLE;
	std::cout << std::endl << "������� �������� (double): " << av2 / CYCLE;
	std::cout << std::endl << "����������������� (�.�):   " << (t2 - t1);
	std::cout << std::endl << "                  (���):   "
		<< ((double)(t2 - t1)) / ((double)CLOCKS_PER_SEC);
	std::cout << std::endl;
	std::cout << std::endl;
	std::cout << std::endl;	std::cout << std::endl;
	std::cout << "����� ���������" << std::endl;

	std::cout << "������� n-�� ����� "; std::cin >> fibnum;
	t3 = clock();
	long long res = fibo::fibonachi(fibnum);
	std::cout << res << std::endl;
	t4 = clock();
	std::cout << std::endl << "����������������� (�.�):   " << (t4 - t3);
	std::cout << std::endl << "                  (���):   "
		<< ((double)(t4 - t3)) / ((double)CLOCKS_PER_SEC);
	std::cout << std::endl;


	return 0;
}