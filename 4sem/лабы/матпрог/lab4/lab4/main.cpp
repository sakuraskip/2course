#include <algorithm>
#include <iostream>
#include <ctime>
#include <iomanip>
#include <string>

using namespace std;

string randString(int length) {
    string chars = "abcdefghijklmnopqrstuvwxyz";
    string res;
    for (size_t i = 0; i < length; i++) {
        int index = rand() % chars.size();
        res += chars[index];
    }
    return res;
}

int main() {
    srand(static_cast<unsigned int>(time(0)));
    setlocale(LC_ALL, "rus");
    clock_t t1 = 0, t2 = 0, t3, t4;

    string s1 = randString(300);
    string s2 = randString(200);

    int lx = s1.size(), ly = s2.size();
    std::cout << std::endl;
    cout << "строка 1: " << s1 << endl;
    cout << "строка 2: " << s2 << endl;
   

    system("pause");
    return 0;
}