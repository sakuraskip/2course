# -*- coding: utf-8 -*-

import numpy as np
import sympy as sp

# ������������ �������
def f(x):
    return -np.sin(4 - x**2) # ��������

# ���������� �������� ���������
def divided_differences(x, y):
    n = len(x)
    table = np.zeros((n, n), dtype=object)
    table[:, 0] = y
    
    for j in range(1, n):
        print("line", j)
        for i in range(n - j):
            table[i][j] = (table[i+1][j-1] - table[i][j-1])/(x[i+j]-x[i])
            print(table[i][j])
    print("\n\n\n\n\n")
    return table

# ������������ �� ������� �������
def newton_interpolation(x_data, y_data, x):
    n = len(x_data)
    table = divided_differences(x_data, y_data)
    poly = table[0, 0]
    product = 1

    for j in range(1, n):
        product *= (x - x_data[j - 1])
        poly += table[0, j] * product
    return poly

# ������� ��� ������ ����������� �����
def remainder_term(x_data, x, n):
    # ���������� ������������� ����������
    xi = sp.symbols('xi')
    # ���������� �����������
    f_prime = sp.diff(-sp.sin(4 - xi**2), xi, n + 1)
    prod = np.prod([x - xi_val for xi_val in x_data])
    return f_prime.subs(xi, np.mean(x_data)) / sp.factorial(n + 1) * prod

# ������ ������
x_data = np.linspace(-1, 3, 11)  # ��������
y_data = f(x_data)

# ����� ����� x ��� ������
x_value = -0.9  # ��������

# ������������
# ���������� �������� ������������ ������� � ����� x_value
original_value = f(x_value)
print("orig x:", original_value)

# ������������
P = newton_interpolation(x_data, y_data, x_value)
print("polinom  x:", P)

# �������� �� ����������
print("s:", np.isclose(original_value, P))

# ������ ����������� �����
R = remainder_term(x_data, x_value, 10) 
print("res", R)