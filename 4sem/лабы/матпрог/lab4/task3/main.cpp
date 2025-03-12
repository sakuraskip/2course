#include <iostream>
#include "LCS.h"
int main()
{
    setlocale(LC_ALL, "rus");
    char X[] = "ALDC", Y[] = "LADCM";
    std::cout << std::endl << "-- ���������� ����� LCS ��� X � Y(��������)";
    std::cout << std::endl << "-- ������������������ X: " << X;
    std::cout << std::endl << "-- ������������������ Y: " << Y;
    int s = lcs(
        sizeof(X) - 1,  // �����   ������������������  X   
        "ALDC",       // ������������������ X
        sizeof(Y) - 1,  // �����   ������������������  Y
        "LADCM"       // ������������������ Y
    );
    std::cout << std::endl << "-- ����� LCS: " << s << std::endl;

    char z[100] = "";
    char x[] = "ABCBDAB",
        y[] = "BDCABA";

    int l = lcsd(x, y, z);
    std::cout << std::endl
        << "-- ���������� ����� �������������������� - LCS(������������ "
        << "����������������)" << std::endl;
    std::cout << std::endl << "����������������� X: " << x;
    std::cout << std::endl << "����������������� Y: " << x;
    std::cout << std::endl << "                LCS: " << z;
    std::cout << std::endl << "          ����� LCS: " << l;
    std::cout << std::endl;

    system("pause");
    return 0;

}
