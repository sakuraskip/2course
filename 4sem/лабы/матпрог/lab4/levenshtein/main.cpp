#include <algorithm>
#include <iostream>
#include <ctime>
#include <iomanip>
#include "Levenshtein.h"

#define len1 300
#define len2 250
using namespace std;
char* randString(int length) {
    string chars = "abcdefghijklmnopqrstuvwxyz";
    char* res = new char[length + 1]; 
    for (size_t i = 0; i < length; i++) {
        int index = rand() % chars.size(); 
        res[i] = chars[index];
    }
    res[length] = '\0';
    return res;
}

int main()
{
    srand(time(0));
    setlocale(LC_ALL, "rus");
    clock_t t1 = 0, t2 = 0, t3, t4;
    char* x = randString(len1);
        char* y = randString(len2);
    int  lx = sizeof(x)-1, ly = sizeof(y)-1;

    int xsize[]{ len1 / 25,len1 / 20,len1 / 15,len1 / 10,len1 / 5,len1 / 2,len1 };
    int ysize[]{ len2 / 25,len2 / 20,len2 / 15,len2 / 10,len2 / 5,len2 / 2,len2 };

    std::cout << std::endl;
    cout << "s1: " << x << endl;
    cout << "s2: " << y << endl;
    std::cout << std::endl << "-- расстояние Левенштейна -----" << std::endl;
    std::cout << std::endl << "--длина --- рекурсия -- дин.програм. ---"
        << std::endl;
    for (int i = 0; i < std::min(lx, ly); i++)
    {

        t1 = clock(); levenshtein_r(xsize[i], x, ysize[i], y); t2 = clock();

        t3 = clock(); levenshtein(xsize[i], x, ysize[i], y); t4 = clock();

        std::cout << std::right << std::setw(2) << xsize[i] << "/" << std::setw(2) << ysize[i]
            << "        " << std::left << std::setw(10) << (t2 - t1)
            << "   " << std::setw(10) << (t4 - t3) << std::endl;
    }
    system("pause");
    return 0;
}
