#include <iostream>
using namespace std;

int main()
{
	setlocale(LC_ALL, "russian");
	int n;

	cout << "������� ����� ������������������ : " << endl;
	cin >> n;

	int* array = new int[n];
	int* lengths = new int[n];
	int* prev = new int[n];
	cout << "������� �������� ������������������ " << endl;

	for (int i = 0; i < n; i++)
	{
		cin >> array[i];
		prev[i] = -1;
		lengths[i] = 1;
	}

	for (int i = 1; i < n; i++)
	{
		for (int j = 0; j < i; j++)
		{
			if (array[j] < array[i] and lengths[j] + 1 > lengths[i])
			{
				lengths[i] = lengths[j] + 1;
				prev[i] = j;
			}
		}
	}
	int max = 0;
	int maxindex = 0;
	for (int i = 0; i < n; i++)
	{
		if (lengths[i] >= max)
		{
			max = lengths[i];
			maxindex = i;
		}
	}
	cout << "������ ���������� �������� " << endl;
	for (int i = 0; i < n; i++)
	{
		cout << prev[i] << " ";
	}
	/*cout << "\n ������ ���� ���������������������� : ";
	for (int i = 0; i < n; i++)
	{
		cout << lengths[i] << " ";
	}*/
	cout << "\n����� ����. ������������������: " << max << endl;
	int output[255];
	for (int i = max; i >= 0; i--)
	{
		output[i] = array[maxindex];
		maxindex = prev[maxindex];
	}
	cout << endl << "���� ���������������������: " << endl;
	for (int i = 1; i <= max; i++)
	{
		cout << output[i] << " ";
	}
}