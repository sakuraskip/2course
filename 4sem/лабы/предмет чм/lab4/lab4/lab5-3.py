# -*- coding: utf-8 -*-

import numpy as np
import matplotlib.pyplot as plt

# Данные
x = np.array([-3	,-2.4,	-1.7,	-0.96	,-0.55,	0.65,	1.4	,1.9	,3.1	,3.5])
y = np.array([2.5,	1.7,	1.1,	0.7,	0.45,	0.39	,0.5,	0.79,	1.3	,1.9
])

# Вычисление коэффициентов линейной регрессии
N = len(x)
a = (N * np.sum(x * y) - np.sum(x) * np.sum(y)) / (N * np.sum(x**2) - np.sum(x)**2)
b = (np.sum(y) - a * np.sum(x)) / N

# Значения аппроксимированной функции
y_fit = a * x + b

# Вывод результата
print(f"coef: a = {a}, b = {b}")

# Построение графика
plt.scatter(x, y, label='data')
plt.plot(x, y_fit, color='red', label='approxy')
plt.legend()
plt.xlabel('x')
plt.ylabel('y')
plt.title('approxy2')
plt.show()