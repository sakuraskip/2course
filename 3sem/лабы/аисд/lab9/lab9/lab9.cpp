#include <iostream>
#include <vector>
#include <string>
#include <limits.h>
#include <algorithm>
#include <ctime>

using namespace std;


vector<vector<int>> cities;
int cityamount = 0;


void deleteroad(int city1, int city2) {
    if (city1 < 0 || city2 < 0 || city1 >= cityamount || city2 >= cityamount) {
        cout << "Некорректные номера городов.\n";
        return;
    }
    cities[city1][city2] = INT_MAX;
    cities[city2][city1] = INT_MAX;
}

void addRoad(int city1, int city2, int length)
{
    if (city1 < 0 || city2 < 0 || city1 >= cityamount || city2 >= cityamount)
    {
        cout << "Некорректные номера городов.\n";
        return;
    }
    cities[city1][city2] = length;
}

void addCity() {
    cityamount++;
    for (auto& row : cities) {
        row.push_back(INT_MAX);
    }
    cities.push_back(vector<int>(cityamount, INT_MAX)); 

    cities[cityamount - 1][cityamount - 1] = 0;

    for (int i = 0; i < cityamount - 1; i++)
    {
        int distance;
        cout << "Введите расстояние между городом " << i << " и " << cityamount - 1 << ": ";
        cin >> distance;
        addRoad(i, cityamount - 1, distance);
        cout << "Введите расстояние между городом " << cityamount-1 << " и " << i << ": ";
        cin >> distance;
        addRoad(cityamount-1, i, distance);
    }
}
void addCityNoLog() {
    cityamount++;
    for (auto& row : cities)
    {
        row.push_back(INT_MAX); 
    }
    cities.push_back(vector<int>(cityamount, INT_MAX));

    cities[cityamount - 1][cityamount - 1] = 0;
}

void deleteCity(int city) {
    if (city < 0 || city >= cityamount) {
        cout << "Некорректный номер города.\n";
        return;
    }

    cities.erase(cities.begin() + city);

    for (auto& row : cities) {
        row.erase(row.begin() + city);
    }

    cityamount--;
    cout << "Город " << city << " удален.\n";
}

int routeLength(string route) {
    int length = 0;
    for (int i = 0; i < route.length() - 1; i++) {
        int city1 = route[i] - '0';
        int city2 = route[i + 1] - '0';
        if (cities[city1][city2] == INT_MAX)
        {
            return INT_MAX;
        }
        length += cities[city1][city2];
    }
    return length;
}

void genPopulation(vector<string>& vpopulation, int amount) {
    for (int i = 0; i < amount; i++)
    {
        string population = "0";
        for (int j = 1; j < cityamount; j++)
        {
            population += to_string(j);
        }
        population += "0";
        random_shuffle(population.begin() + 1, population.end() - 1);
        vpopulation.push_back(population);
    }
}

int selection(vector<string>& vpopulation, int* fitness) {
    int bestIndex = 0;
    int bestFitness = fitness[0];
    for (int i = 1; i < vpopulation.size(); i++)
    {
        if (fitness[i] < bestFitness)
        {
            bestFitness = fitness[i];
            bestIndex = i;
        }
    }
    return bestIndex;
}

void deleteWorstOnes(vector<string>& vpopulation, int* fitness, int diff)
{
    for (int i = 0; i < diff; i++)
    {
        auto worstIt = max_element(fitness, fitness + vpopulation.size());
        int index = distance(fitness, worstIt);
        vpopulation.erase(vpopulation.begin() + index);
    }
}

// Функция скрещивания
void скрещивание(string parent1, string parent2, string& newchild1, string& newchild2)
{
    vector<bool> taken1(cityamount, false), taken2(cityamount, false);
    int from = rand() % (cityamount - 1) + 1;
    int to = rand() % (cityamount - 1) + 1;
    if (from > to) swap(from, to);

    newchild1 = newchild2 = string(cityamount + 1, '0');
    for (int i = from; i <= to; i++)
    {
        newchild1[i] = parent1[i];
        newchild2[i] = parent2[i];
        taken1[parent1[i] - '0'] = true;
        taken2[parent2[i] - '0'] = true;
    }

    int idx1 = 1, idx2 = 1;
    for (int i = 1; i < cityamount; i++)
    {
        if (!taken1[parent2[i] - '0'])
        {
            while (newchild1[idx1] != '0') idx1++;
            newchild1[idx1] = parent2[i];
        }
        if (!taken2[parent1[i] - '0'])
        {
            while (newchild2[idx2] != '0') idx2++;
            newchild2[idx2] = parent1[i];
        }
    }
}

// Функция мутации
void mutation(string& route, double chance) {
    if ((rand() % 100) < (chance * 100))
    {
        int i = rand() % (route.length() - 2) + 1;
        int j = rand() % (route.length() - 2) + 1;
        swap(route[i], route[j]);
    }
}

int main() {
    srand(time(0));
    setlocale(LC_ALL, "russian");
    addCityNoLog();
    addCityNoLog();
    addCityNoLog();
    addCityNoLog();
    addCityNoLog();

    addRoad(0,1,25);
    addRoad(0, 2, 40);
    addRoad(0, 3, 31);
    addRoad(0, 4, 27);

    addRoad(1, 0, 19);
    addRoad(1, 2, 17);
    addRoad(1, 3, 30);
    addRoad(1, 4, 25);

    addRoad(2, 0, 19);
    addRoad(2, 1, 15);
    addRoad(2, 3, 21);
    addRoad(2, 4, 14);

    addRoad(3, 0, 41);
    addRoad(3, 1, 50);
    addRoad(3, 2, 24);
    addRoad(3, 4, 23);

    addRoad(4, 0, 22);
    addRoad(4, 1, 24);
    addRoad(4, 2, 11);
    addRoad(4, 3, 18);
    int question;
    do {
        cout << "Добавить город? 0 - да, -1 - нет: ";
        cin >> question;
        if (question == 0) {
            addCity();
        }
    } while (question != -1);

    int que;
    do {
        cout << "Удалить город? 0 - да, -1 - нет: ";
        cin >> que;
        if (que == 0) {
            cout << "Введите номер города: ";
            cin >> que;
            deleteCity(que);
        }
    } while (que != -1);

    int population, скрещивания, evolves;
    double mutationchance;
    cout << "Введите начальный размер популяции: ";
    cin >> population;
    cout << "\nКоличество скрещиваний: ";
    cin >> скрещивания;
    cout << "\nШанс мутации (от 0 до 1): ";
    cin >> mutationchance;
    cout << "\nКоличество эволюций: ";
    cin >> evolves;

    vector<string> startpopulation;
    genPopulation(startpopulation, population);

    for (int evolve = 0; evolve < evolves; evolve++)
    {
        vector<int> fitness(startpopulation.size());
        for (int i = 0; i < startpopulation.size(); i++)
        {
            fitness[i] = routeLength(startpopulation[i]);
        }

        int bestIndex = selection(startpopulation, fitness.data());
        cout << "Эволюция " << evolve + 1 << "\n";
        for (int i = 0; i < startpopulation.size(); i++)
        {
            cout << startpopulation[i] << endl;
        }
        cout << "Лучший маршрут: " << startpopulation[bestIndex] << "\n";
        cout << "Длина маршрута: " << fitness[bestIndex] << "\n";

        for (int j = 0; j < скрещивания; j++)
        {
            int parent1Index = rand() % startpopulation.size();
            int parent2Index = rand() % startpopulation.size();
            while (parent1Index == parent2Index)
            {
                parent2Index = rand() % startpopulation.size();
            }

            string child1, child2;
            скрещивание(startpopulation[parent1Index], startpopulation[parent2Index], child1, child2);
            mutation(child1, mutationchance);
            mutation(child2, mutationchance);
            startpopulation.push_back(child1);
            startpopulation.push_back(child2);
        }

        deleteWorstOnes(startpopulation, fitness.data(), скрещивания*2);
    }

    return 0;
}