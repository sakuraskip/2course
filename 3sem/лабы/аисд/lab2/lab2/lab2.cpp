#include <iostream>
#include <queue>
#include <stack>
#include <vector>
using namespace std;

struct Edge
{
	int start;
	int finish;
};
bool visited[10] = {};

vector<Edge>list =
{
	{0,1},{0,4},{1,6},{1,7},{2,7},{3,5},{3,8},{4,5},{5,8},{6,7},{8,9}
};
vector<vector<int>> adjList(10);
int graphMatrix[10][10]{
{0,1,0,0,1,0,0,0,0,0},
{1,0,0,0,0,0,1,1,0,0},
{0,0,0,0,0,0,0,1,0,0},
{0,0,0,0,0,1,0,0,1,0},
{1,0,0,0,0,1,0,0,0,0},
{0,0,0,1,1,0,0,0,1,0}, 
{0,1,0,0,0,0,0,1,0,0},
{0,1,1,0,0,0,1,0,0,0},
{0,0,0,1,0,1,0,0,0,1},
{0,0,0,0,0,0,0,0,1,0},
};


void dfSearch(int start)
{
	stack<int> stack;
	stack.push(start);
	visited[start] = true;
	cout << start + 1 << " ";
	while (!stack.empty()) {
		int currentVertex = stack.top();
		stack.pop();
		if (visited[currentVertex] == false)
		{
		     cout << currentVertex + 1 << " ";
			 visited[currentVertex] = true;
		}

		for (int i = 10 - 1; i >= 0; i--)
		{
			if (graphMatrix[currentVertex][i] == true and visited[i] == false)
			{
				stack.push(i);
			}


		}
		

	}
}

void bfSearch(int start)
{
	bool visited[10] = {};
	queue<int> que;

	visited[start] = true;
	que.push(start);
	cout << start+1 << " ";
	int current;
	while (!que.empty())
	{
		current = que.front();
		que.pop();
		for (int i = 0; i <10; i++)
		{
			if (visited[i] == false and graphMatrix[current][i] == true)
			{
				visited[i] = true;
				que.push(i);
				cout << i+1 << " ";
			}
		}
	}
}



int main()
{
	setlocale(LC_ALL, "russian");
	int buff;
	cout << "ввод начальной вершины(от 1 до 10) " << endl;
	cin >> buff;
	if (buff > 10 or buff < 1)
	{
		cout << "введены неверные данные";
		return 0;
	}
	buff--;
	cout << "обход в ширину: " << endl;
	bfSearch(buff);
	cout << endl;
	cout << "обход в глубину: " << endl;
	dfSearch(buff);
}