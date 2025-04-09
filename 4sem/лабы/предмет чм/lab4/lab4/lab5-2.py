# -*- coding: utf-8 -*-

import numpy as np
import sympy as sp

# Оригинальная функция
def f(x):
    return -np.sin(4 - x**2) # ПОМЕНЯТЬ

# Вычисление конечных разностей
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

# Интерполяция по формуле Ньютона
def newton_interpolation(x_data, y_data, x):
    n = len(x_data)
    table = divided_differences(x_data, y_data)
    poly = table[0, 0]
    product = 1

    for j in range(1, n):
        product *= (x - x_data[j - 1])
        poly += table[0, j] * product
    return poly

# Функция для оценки остаточного члена
def remainder_term(x_data, x, n):
    # Определяем символические переменные
    xi = sp.symbols('xi')
    # Определяем производную
    f_prime = sp.diff(-sp.sin(4 - xi**2), xi, n + 1)
    prod = np.prod([x - xi_val for xi_val in x_data])
    return f_prime.subs(xi, np.mean(x_data)) / sp.factorial(n + 1) * prod

# Пример данных
x_data = np.linspace(-1, 3, 11)  # ПОМЕНЯТЬ
y_data = f(x_data)

# Выбор точки x для оценки
x_value = -0.9  # ПОМЕНЯТЬ

# Интерполяция
# Вычисление значения оригинальной функции в точке x_value
original_value = f(x_value)
print("orig x:", original_value)

# Интерполяция
P = newton_interpolation(x_data, y_data, x_value)
print("polinom  x:", P)

# Проверка на совпадение
print("s:", np.isclose(original_value, P))

# Оценка остаточного члена
R = remainder_term(x_data, x_value, 10) 
print("res", R)