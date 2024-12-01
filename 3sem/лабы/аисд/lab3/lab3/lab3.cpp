#include <iostream>
#include <string>
using namespace std;

const int V = 9;
int alot = 9999999;

int graph[V][V] =

{//       
	{0,7,10,0,0,0,0,0,0},
	{7,0,0,0,0,9,27,0,0},
	{10,0,0,0,31,8,0,0,0},
	{0,0,0,0,32,0,0,17,21},
	{0,0,31,32,0,0,0,0,0},
	{0,9,8,0,0,0,0,11,0},
	{0,27,0,0,0,0,0,0,15},
	{0,0,0,17,0,11,0,0,15},
	{0,0,0,21,0,0,15,15,0}
};

void algorithm(int start)
{
    int distance[V]; 
    bool visited[V];
    for (int i = 0; i < V; i++)
    {
        distance[i] = alot;
        visited[i] = false;

    }
    distance[start] = 0;
    string charVertex[V] = { "A(1)","B(2)","C(3)","D(4)","E(5)","F(6)","G(7)","H(8)","I(9)"};
    int minIndex = start;

    for (int i = 0; i < V; i++)
    {
        visited[minIndex] = true;

        for (int j = 0; j < V; j++)
        {    
            if (visited[j] == false and graph[minIndex][j] > 0 and
                (distance[minIndex] + graph[minIndex][j]) < distance[j])
            {
                distance[j] = distance[minIndex] + graph[minIndex][j];
            }

        }

        minIndex = -1;
        int minDistance = alot;
        for (int j = 0; j < V; j++)
        {
            if (visited[j] == false and distance[j] < minDistance)
            {
                minDistance = distance[j];
                minIndex = j;
            }
        }
        if (minIndex == -1)
        {
            break;
        }
    }

    for (int k = 0; k < V; k++)
    {
        cout << "расстояние от вершины " << charVertex[start] << " до вершины "
            << charVertex[k] << " = ";
        if (distance[k] == alot)
        {
            cout << "inf" << endl;
        }
        else
        {
            cout << distance[k] << endl;
        }
    }
    
}

int main()
{
    setlocale(LC_ALL, "russian");
    int buff;
    cout << "введите стартовую вершину(от 1 до 9): ";
    cin >> buff;
    if (buff > 9 or buff < 1)
    {
        cout << "введен неверный номер вершины" << endl;
        return 0;
    }
    buff--;
    algorithm(buff);
}