#include <iostream>
#include <locale>
#include "Auxil.h"                            // вспомогательные функции 
#include "stdafx.h"
#include "fibo.h"


#define  CYCLE  500000                       // количество циклов  

int main()
{

	double  av1 = 0, av2 = 0;
	clock_t  t1 = 0, t2 = 0,t3=0,t4=0;
	int fibnum;

	setlocale(LC_ALL, "rus");

	auxil::start();                          // старт генерации 
	t1 = clock();                            // фиксаци€ времени 
	for (int i = 0; i < CYCLE; i++)
	{
		av1 += (double)auxil::iget(-100, 100); // сумма случайных чисел 
		av2 += auxil::dget(-100, 100);         // сумма случайных чисел 
	}
	t2 = clock();                            // фиксаци€ времени 


	std::cout << std::endl << "количество итераций:         " << CYCLE;
	std::cout << std::endl << "среднее значение (int):    " << av1 / CYCLE;
	std::cout << std::endl << "среднее значение (double): " << av2 / CYCLE;
	std::cout << std::endl << "продолжительность (у.е):   " << (t2 - t1);
	std::cout << std::endl << "                  (сек):   "
		<< ((double)(t2 - t1)) / ((double)CLOCKS_PER_SEC);
	std::cout << std::endl;
	std::cout << std::endl;
	std::cout << std::endl;	std::cout << std::endl;
	std::cout << "числа фибоначчи" << std::endl;

	std::cout << "введите n-ое число "; std::cin >> fibnum;
	t3 = clock();
	long long res = fibo::fibonachi(fibnum);
	std::cout << res << std::endl;
	t4 = clock();
	std::cout << std::endl << "продолжительность (у.е):   " << (t4 - t3);
	std::cout << std::endl << "                  (сек):   "
		<< ((double)(t4 - t3)) / ((double)CLOCKS_PER_SEC);
	std::cout << std::endl;


	return 0;
}