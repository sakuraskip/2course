#include <Windows.h>
#include <iostream>
using namespace std;

const int V = 8;
const int alot = 9999;
int roots[V];
int matrix[V][V] =
{
    {0, 2, 0, 8, 2, 0, 0, 0},
    {2, 0, 3, 10, 5, 0, 0, 0},
    {0, 3, 0, 0, 12, 0, 0, 7},
    {8, 10, 0, 0, 14, 3, 1, 0},
    {2, 5, 12, 14, 0, 11, 4, 8},
    {0, 0, 0, 3, 11, 0, 6, 0},
    {0, 0, 0, 1, 4, 6, 0, 9},
    {0, 0, 7, 0, 8, 0, 9, 0}
};
int getConnect(int a)
{
    while (roots[a] != a)
    {
        a = roots[a];
    }
    return a;
}

void connectVertexs(int i, int j)
{
    int a = getConnect(i);
    int b = getConnect(j);
    roots[a] = b;
}

void lab5_2()
{
    int min;
    int edgesCount = 0;
    for (int i = 0; i < V; i++)
    {
        roots[i] = i;
    }

    while (edgesCount < V - 1)
    {
        min = alot;
        int a = alot, b = alot;
        for (int i = 0; i < V; i++)
        {
            for (int j = 0; j < V; j++)
            {   
                if (getConnect(i) != getConnect(j) and matrix[i][j] < min and matrix[i][j] != 0)
                {
                    min = matrix[i][j];
                    a = i;
                    b = j;
                }
            }
        }
        connectVertexs(a, b);
        edgesCount++;
        cout << a + 1 << " -> " << b + 1 << " == " << min << endl;
    }
}


int main()
{
    lab5_2();
}

