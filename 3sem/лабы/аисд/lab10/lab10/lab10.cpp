#include <iostream>
#include <vector>
#include <random>
#include <string>
#include <limits>
#include <algorithm>
#include <cmath>

using namespace std;

#define MAX_DIST 100

void printMatrix(const vector<vector<int>>& matrix) {
    for (const auto& row : matrix) {
        for (int val : row) {
            if (val == numeric_limits<int>::max()) {
                cout << "INF ";
            }
            else {
                cout << val << " ";
            }
        }
        cout << endl;
    }
}

void fillPheromons(vector<vector<int>>& pheromons, const vector<vector<int>>& graph,int startphero) {
    for (int i = 0; i < graph.size(); ++i)
    {
        for (int j = 0; j < graph.size(); ++j)
        {
                pheromons[i][j] = startphero;
        }
    }
}
vector<vector<int>> generateRandomGraph(int N) {
    vector<vector<int>> graph(N, vector<int>(N, 0));
    srand(time(0));
    for (int i = 0; i < N; ++i)
    {
        for (int j = 0; j < N; ++j)
        {
            if (i != j)
            {
                graph[i][j] = rand()%MAX_DIST;
            }
            else {
                graph[i][j] = numeric_limits<int>::max();
            }
        }
    }
    return graph;
}

void fillProbabilities(const vector<vector<int>>& graph, const vector<vector<int>>& pheromons, vector<double>& probabilities, const vector<bool>& notVisited, int alpha, int beta, int current) {
    double sum = 0.0;
    probabilities.resize(graph.size());

    for (int i = 0; i < notVisited.size(); i++)
    {
        if (notVisited[i] and i != current)
        {
            sum += pow(1.0 / graph[current][i], beta) * pow(pheromons[current][i], alpha);
        }
    }

    for (int i = 0; i < probabilities.size(); i++)
    {
        if (notVisited[i])
        {
            probabilities[i] = 100.0 * (pow(1.0 / graph[current][i], beta) * pow(pheromons[current][i], alpha)) / sum;
        }
        else
        {
            probabilities[i] = 0;
        }
    }
}

int makeChoice(const vector<double>& probabilities)
{
    double random = static_cast<double>(rand()) / RAND_MAX * 100.0;
    double sum = 0.0;

    for (int i = 0; i < probabilities.size(); i++)
    {
        if (probabilities[i] == 0) continue;
        sum += probabilities[i];
        if (sum >= random)
        {
            return i;
        }
    }
    return 0;
}

void antAlgorithm(const vector<vector<int>>& graph, vector<vector<int>>& pheromons, int iterations, int alpha, int beta, int start) {
    int bestDistance = 999999;
    vector<int> bestPath;
    vector<vector<int>> pher�nons = pheromons;
    for (int iter = 0; iter < iterations; iter++)
    {
        int current = start;
        vector<bool> notVisited(graph.size(), true);
        vector<int> path;
        int distance = 0;

        path.push_back(current);
        notVisited[current] = false;

        while (find(notVisited.begin(), notVisited.end(), true) != notVisited.end())
        {
            vector<double> probabilities;
            fillProbabilities(graph, pheromons, probabilities, notVisited, alpha, beta, current);

            int nextCity = makeChoice(probabilities);
            distance += graph[current][nextCity];
            current = nextCity;
            path.push_back(current);
            notVisited[current] = false;
        }
        double newpheromons = 1 / distance;
        for (int i = 0; i < path.size()-1; i++)
        {
            int from = path[i];
            int to = path[i + 1];
            pheromons[from][to] += newpheromons;
            pheromons[to][from] += newpheromons;
        }
        for (int i = 0; i < pheromons.size(); i++)
        {
            for (int j = 0; j < pheromons[i].size(); j++)
            {
                pher�nons[i][j] *= 0.36;
            }
        }
        if (distance < bestDistance) {
            bestDistance = distance;
            bestPath = path;
        }
        cout << "������ ���� �� �������� " << iter + 1 << ": ";
        for (int city : bestPath) {
            cout << city << " ";
        }
        cout << "\n����� ����: " << bestDistance << endl;
    }

   
}

int main()
{
    setlocale(0, "russian");
    int iterations;
    int N;
    double alpha, beta;
    int startpos = 0;
    double startpheromons;
    cout << "������� �������� �����: ";
    cin >> alpha;
    cout << "\n������� �������� ����: ";
    cin >> beta;
    do
    {
        cout << "\n������� ���-�� ��������: ";
        cin >> iterations;
        
        cout << "\n������� ���-�� �������: ";
        cin >> N;
        cout << "\n��������� ���-�� ���������(�� 0 �� 1): ";
        cin >> startpheromons;
    } while (iterations < 0 and (startpos < 0 or startpos>N) and N<0 and (startpheromons >1 or startpheromons<0));
    vector<vector<int>> cities = generateRandomGraph(N);

    vector<vector<int>> pheromons = cities;
    fillPheromons(pheromons, cities,startpheromons*100);
    cout << "������� ���������: " << endl;
    printMatrix(cities);
    antAlgorithm(cities, pheromons, iterations, alpha, beta, startpos);

    return 0;
}