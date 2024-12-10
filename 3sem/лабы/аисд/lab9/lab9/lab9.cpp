#include <iostream>
#include <Windows.h>
#include <limits.h>
#include <time.h>
#include <vector>
#include <string>
#include <algorithm>
using namespace std;

const int N = 9;
int cities[N][N]=
{
	/*0*/{0, 25, 40, 31, 27,14,8,44},
	/*1*/{ 5, 0, 17, 30, 25,11,28,45},
	/*2*/{ 19, 15, 0, 6, 1,10,19,22},
	/*3*/{ 9, 50, 24, 0, 6,14,28,29 },
	/*4*/{ 22, 8, 7, 10, 0,14,17,31 },
	/*5*/{14,15,29,41,15,0,12,11},
	/*6*/{7,15,22,1,37,19,0,37},
	/*7*/{15,13,14,7,81,9,4,0}
};
int cityamount = 8;
void deleteroad(int city1, int city2)
{
	cities[city1][city2] = INT_MAX;
	cities[city2][city1] = INT_MAX;
}
void addRoad(int city1, int city2, int length)
{
	cities[city1][city2] = length;
	cities[city2][city1] = length;
}
void addCity()
{
	srand(time(0));
	if (cityamount + 1 > N)
	{
		cout << "максимальное кол-во городов" << endl;
		return;
	}
	cityamount++;
	for (int i = 0; i < cityamount; i++)
	{
		cities[i][cityamount - 1] = rand() % 40 + 1;
		cities[cityamount-1][i] = rand() % 40 + 1;
	}
	cities[cityamount - 1][cityamount - 1] = 0;
}
int routeLength(string route)
{
	int length = 0;
	for (int i = 0; i < route.length(); i++)
	{
		int city1 = route[i] - 48;
		int city2 = route[(i + 1) % route.size()] - 48;
		length = length + cities[city1][city2];
	}
	return length;
}
void genPopulation(vector<string>& vpopulation, int amount)
{
	for (int i = 0; i < amount; i++)
	{
		string population = "0";
		for (int j = 1; j < cityamount; j++)
		{
			population += to_string(j);
		}
		population.append("0");
		random_shuffle((population.begin() + 1), (population.end()-1));
		vpopulation.push_back(population);
	}
}
int selection(vector<string>& vpopulation, int* fitness)
{
	int maxindex = -1;
	int maxfitness = 9999999;
	for (int i = 0; i < vpopulation.size(); i++)
	{
		if (fitness[i] < maxfitness)
		{
			maxindex = i;
			maxfitness = fitness[i];
		}
	}
	return maxindex;
}
void скрещивание(string parent1, string parent2, string& newchild1,string& newchild2)
{
	srand(time(0));
	bool istaken1[N] = {false};
	bool istaken2[N] = { false };
	newchild1[0] = '0';
	newchild1[cityamount - 1] = '0';
	for (int i = 0; i < cityamount; i++)
	{
		istaken1[i] = false;
		istaken2[i] = false;
	}
	istaken1[parent1[0] - 48] = true;
	istaken2[parent1[0] - 48] = true;

	int from = -1;
	int to = -1;
	do
	{
		from = rand() % (cityamount-1)+1;
		to = rand() % (cityamount-1)+1;

	} while (from >= to);
	for (int i = from; i <= to; i++)
	{
		newchild1[i] = parent1[i];
		istaken1[parent1[i] - 48] = true;
	}
	int counter = 1;
	for (int i = 0; i < cityamount; i++)
	{
		if (istaken1[parent2[i] - 48] == false and parent2[i] != '0')
		{
			while (counter < cityamount - 1 and newchild1[counter] != '0')
			{
				counter++;
			}
			if (counter < cityamount - 1)
			{
				newchild1[counter] = parent2[i];
			}
		}
	}
	do
	{
		from = rand() % (cityamount - 1) + 1;
		to = rand() % (cityamount - 1) + 1;
	} while (from >= to);
	for (int i = from; i <= to; i++)
	{
		newchild2[i] = parent2[i];
		istaken2[parent2[i] - 48] = true;
	}
	counter = 1;
	for (int i = 0; i < cityamount; i++)
	{
		if(istaken2[parent1[i]-48] == false)
	}
}
void mutation(string& route, int chance)
{
	srand(time(0));
	if ((rand() % 100) < chance)
	{
		int i = rand() % (route.length() - 1) + 1;
		int j = rand() & (route.length() - 1) + 1;
		std::swap(route[i], route[j]);
	}
}



int main()
{
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
	setlocale(LC_ALL, "russian");	
	srand(time(0));
	int population, скрещивани€, mutationchance, evolves;
	cout << "введите начальный размер попул€ции: "; cin >> population;
	cout << "\nкол-во скрещиваний: "; cin >> скрещивани€;
	cout << "\nпоказатель по мутации: "; cin >> mutationchance;
	cout << "\nкол-во эволюций: "; cin >> evolves;
	
	vector<string> startpopulation;
	genPopulation(startpopulation, population);
	for (int evolve = 0; evolve < evolves; evolve++)
	{
		int* fitness = new int[N];
		for (int i = 0; i < startpopulation.size(); i++)
		{
			fitness[i] = routeLength(startpopulation[i]);
		}
		int maxindex = selection(startpopulation, fitness);
		int minlength = fitness[maxindex];

		cout << "номер попул€ции " << evolve + 1 << endl;
		cout << "минимальный маршрут: " << startpopulation[maxindex] << endl;
		cout << "длина маршрута: " << minlength << endl;
		vector<string> newpopulation;
		for (int j = 0; j < скрещивани€; j++)
		{

		}

	}
	/*for (int i = 0; i < cityamount; i++)
	{
		fitness[i] = routeLength(startpopulation[i]);
		cout << fitness[i] << endl;
	}
	for (int i = 0; i < 15; i++)
	{
		cout << startpopulation[i] << endl;
	}*/

}