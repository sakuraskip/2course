#include <iostream>
using namespace std;

const int V = 6;
const int alot = 999999;

int distmatrix[V][V] =
{
	{0, 28, 21, 59, 12, 27},
	{7, 0, 24, alot, 21, 9},
	{9, 32, 0, 13, 11, alot},
	{8, alot, 5, 0, 16, alot},
	{14, 13, 15, 10, 0, 22},
	{15, 18, alot, alot, 6, 0}
};



int pathmatrix[V][V] =
{
	{0, 2, 3, 4, 5, 6},
	{1, 0, 3, 4, 5, 6},
	{1, 2, 0, 4, 5, 6},
	{1, 2, 3, 0, 5, 6},
	{1, 2, 3, 4, 0, 6},
	{1, 2, 3, 4, 5, 0}
};

void lab4() {
	for (int k = 0; k < V; k++)
	{
		for (int i = 0; i < V; i++)
		{
			for (int j = 0; j < V; j++)
			{   
				if (distmatrix[i][k] != alot and distmatrix[k][j] != alot)
				{
					if (distmatrix[i][j] > distmatrix[i][k] + distmatrix[k][j])
					{
						distmatrix[i][j] = distmatrix[i][k] + distmatrix[k][j];
						pathmatrix[i][j] = pathmatrix[i][k];
					}
				}
			}
		}
	}
}

void print() {
	cout << "Длины путей:" << endl;
	cout << "\t1.\t2.\t3.\t4.\t5.\t6.\n";
	for (int i = 0; i < V; i++)
	{
		cout << i + 1 << ".\t";
		for (int j = 0; j < V; j++)
		{
			if (distmatrix[i][j] == alot)
			{
				cout << "infinity\t";
			}
			else
			{
				cout << distmatrix[i][j] << "\t";
			}
		}
		cout << "\n";
	}

	cout << "Матрица путей:" << endl;
	cout << "\t1.\t2.\t3.\t4.\t5.\t6.\n";
	for (int i = 0; i < V; i++)
	{
		cout << i + 1 << ".\t";
		for (int j = 0; j < V; j++)
		{
			cout << pathmatrix[i][j] << "\t";
		}
		cout << "\n";
	}
}

int main()
{
	setlocale(0, "");
	lab4();
	print();

	return 0;
}
