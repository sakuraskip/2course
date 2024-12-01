#include <iostream>
using namespace std;

void move(int n, int start, int target, int buff)
{
	if (n == 1)
	{
		cout << "переместить диск 1 с " << start << " на " << target << " стержень" << endl;
		return;
	}
	buff = 6 - start - target;
	move(n - 1, start, buff, target);
	cout << "переместить диск " << n << " с " << start << " на " << target << " стержень" << endl;
	move(n - 1, buff, target, start);
}

int main()
{
	setlocale(LC_ALL, "russian");
	int n, k,i;
	int buff = 0;
	cout << "введите кол-во дисков: " << endl;
	cin >> n;
	if (n <= 0)
	{
		cout << "введены неверные данные " << endl;
		return 0;
	}
	cout << "введите с какого стержня будут перемещены кольца(1,2,3): " << endl;
	cin >> i;
	if (i < 1 or i>3)
	{
		cout << "введены неверные данные " << endl;
		return 0;
	}
	cout << "введите на какой стержегь будут перемещны кольца(1,2,3): " << endl;
	cin >> k;
	if (k < 1 or k>3)
	{
		cout << "введены неверные данные " << endl;
		return 0;
	}
	if (i == k)
	{
		cout << "кольца уже перемещены" << endl;
		return 0;
	}
	move(n, i, k,buff);


	
}
