#include <iostream>
using namespace std;

void move(int n, int start, int target, int buff)
{
	if (n == 1)
	{
		cout << "����������� ���� 1 � " << start << " �� " << target << " ��������" << endl;
		return;
	}
	buff = 6 - start - target;
	move(n - 1, start, buff, target);
	cout << "����������� ���� " << n << " � " << start << " �� " << target << " ��������" << endl;
	move(n - 1, buff, target, start);
}

int main()
{
	setlocale(LC_ALL, "russian");
	int n, k,i;
	int buff = 0;
	cout << "������� ���-�� ������: " << endl;
	cin >> n;
	if (n <= 0)
	{
		cout << "������� �������� ������ " << endl;
		return 0;
	}
	cout << "������� � ������ ������� ����� ���������� ������(1,2,3): " << endl;
	cin >> i;
	if (i < 1 or i>3)
	{
		cout << "������� �������� ������ " << endl;
		return 0;
	}
	cout << "������� �� ����� �������� ����� ��������� ������(1,2,3): " << endl;
	cin >> k;
	if (k < 1 or k>3)
	{
		cout << "������� �������� ������ " << endl;
		return 0;
	}
	if (i == k)
	{
		cout << "������ ��� ����������" << endl;
		return 0;
	}
	move(n, i, k,buff);


	
}
