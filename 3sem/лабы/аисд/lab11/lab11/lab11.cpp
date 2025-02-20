#include <iostream>
#include <vector>
#include <random>
#include <algorithm>
using namespace std;
int main()
{

	setlocale(LC_ALL, "russian");
	int N;
	int randCounter = 0;
	int algoCounter = 0;
	do
	{
		cout << "введите кол-во раундов сравнения (от 1 до 100): ";
		cin >> N;
	} while (N < 0 or N>1000);
	
	srand(time(0));
	vector<int>numbers(100);

	for (int i = 0; i < 100; i++)
	{
		numbers[i] = i;
	}
	random_device rand;
	mt19937 gen(rand());
	for (int i = 0; i < N; i++)
	{
		cout << "----------- Раунд " << i+1 << " -----------" << endl;
		shuffle(numbers.begin(), numbers.end(), gen);


		int counter1 = 0;
		int counter2 = 0;


		for (int j = 0; j < 100; j++)
		{
			int nextnum = j;
			bool found = false;
			for (int k = 0; k < 50; k++)
			{
				if (j == numbers[nextnum] and found == false)
				{
					counter1++;
					found == true;
					break;
				}
				else
				{
					nextnum = numbers[nextnum];
				}
			}
		}
		cout << "выбором номера в коробке : " << counter1 << endl;
		if (counter1 == 100)
		{
			algoCounter++;
		}
		for (int j = 0; j < 100; j++)
		{
			for (int k = 0; k < 50; k++)
			{
				int randnum = gen() % 100;
				if (j == randnum)
				{
					counter2++;
					break;
				}
			}
			
		}
		
		if (counter2 == 100)
		{
			randCounter++;
		}
	}

	cout << "рандом победил " << randCounter << " раз" << endl;
	cout << "алгоритм победил " << algoCounter << " раз" << endl;
	

}