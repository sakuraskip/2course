#include <iostream>
#include "LCS.h"
int main()
{
    setlocale(LC_ALL, "rus");
    char X[] = "ALDC", Y[] = "LADCM";
    std::cout << std::endl << "-- вычисление длины LCS для X и Y(рекурсия)";
    std::cout << std::endl << "-- последовательность X: " << X;
    std::cout << std::endl << "-- последовательность Y: " << Y;
    int s = lcs(
        sizeof(X) - 1,  // длина   последовательности  X   
        "ALDC",       // последовательность X
        sizeof(Y) - 1,  // длина   последовательности  Y
        "LADCM"       // последовательность Y
    );
    std::cout << std::endl << "-- длина LCS: " << s << std::endl;

    char z[100] = "";
    char x[] = "ABCBDAB",
        y[] = "BDCABA";

    int l = lcsd(x, y, z);
    std::cout << std::endl
        << "-- наибольшая общая подпоследовательость - LCS(динамическое "
        << "программирование)" << std::endl;
    std::cout << std::endl << "последовательость X: " << x;
    std::cout << std::endl << "последовательость Y: " << x;
    std::cout << std::endl << "                LCS: " << z;
    std::cout << std::endl << "          длина LCS: " << l;
    std::cout << std::endl;

    system("pause");
    return 0;

}
