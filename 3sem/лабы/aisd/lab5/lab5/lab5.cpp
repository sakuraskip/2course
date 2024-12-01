#include <iostream>

using namespace std;

const int V = 8;
const int alot = 99999;

int matrix[20][20] = 
{
    {0, 2, 0, 8, 2, 0, 0, 0},
    {2, 0, 3, 10, 5, 0, 0, 0},
    {0, 3, 0, 0, 12, 0, 0, 7},
    {8, 10, 0, 0, 14, 3, 1, 0},
    {2, 5, 12, 14, 0, 11, 4, 8},
    {0, 0, 0, 3, 11, 0, 6, 0},
    {0, 0, 0, 1, 4, 6, 0, 9},
    {0, 0, 7, 0, 8, 0, 9, 0},
};

void lab5()
{
    bool included[V] = { false };
    int minEdges[V];
    int prevVertex[V];

    for (int i = 0; i < V; ++i)
    {
        minEdges[i] = alot;
        prevVertex[i] = -1 ;
    }
    minEdges[7] = 0;
    prevVertex[7] = -1;

    for (int i = 0; i < V - 1; i++)
    {
        int minEdge = alot, minindex =-1;
        for (int j = 0; j < V; j++)
        {
            if (included[j] == false and minEdges[j] < minEdge)
            {
                minEdge = minEdges[j];
                minindex = j;
            }
        }
        included[minindex] = true;
        
        for (int k = 0; k < V; k++)
        {
            if (matrix[minindex][k] and !included[k] and matrix[minindex][k] < minEdges[k])
            {
                prevVertex[k] = minindex;
                minEdges[k] = matrix[minindex][k];
            }
        }
    }

    cout << "Ребро \tВес\n";
    for (int i = 0; i < V; i++) {
        if(prevVertex[i]+1 !=0)
        cout << (prevVertex[i]+1) << " - " << (i+1) << "\t" << matrix[i][prevVertex[i]] << "\n";
    }
}

int main()
{
    setlocale(LC_ALL, "russian");
    
    lab5();


    
}