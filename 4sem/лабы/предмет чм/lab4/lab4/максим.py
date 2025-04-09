# -*- coding: utf-8 -*-
import numpy as np
import sympy as sp
from sympy import symbols, expand

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

def newton_forward(x_data, y_data):
    x = sp.symbols('x')
    n = len(x_data)
    table = divided_differences(x_data, y_data)
    poly = table[0, 0]
    product = 1
    
    for j in range(1, n):
        product *= (x - x_data[j-1])
        poly += table[0, j] * product
    
    return expand(poly)

def newton_backward(x_data, y_data):
    x = sp.symbols('x')
    n = len(x_data)
    table = divided_differences(x_data, y_data)
    poly = table[-1, 0]
    product = 1
    
    for j in range(1, n):
        product *= (x - x_data[-j])
        poly += table[-j-1, j] * product
    
    return expand(poly)

# Пример данных
x_data = [-1,0,1,2,3,4]
y_data = [-0.14,0.756,-0.14,0,-0.958,-0.536]


# Первая формула Ньютона
P_forward = newton_forward(x_data, y_data)
sp.pprint(P_forward)

# Вторая формула Ньютона
P_backward = newton_backward(x_data, y_data)
sp.pprint(P_backward)