# -*- coding: utf-8 -*-

import numpy as np

# Определяем матрицу V и вектор y
A = np.array([[1, 0.04, 0.0016],
              [1, 0.66, 0.43],
              [1, 1.8, 3.24]])
y = np.array([1,0.65,0.02])


coefficients = np.linalg.solve(A, y)

A_transpose = A.T

# Вычисляем обратную матрицу
A_inv = np.linalg.inv(A)
det_A = np.linalg.det(A)
# Вычисляем 2-норму матрицы A
norm_A = np.linalg.norm(A, 2)
print(norm_A)
# Вычисляем 2-норму обратной матрицы A_inv
norm_A_inv = np.linalg.norm(A_inv, 2)
print(norm_A_inv)
# Вычисляем число обусловленности
condition_number = norm_A * norm_A_inv
print("coefs", coefficients)
# Выводим результаты
print("matrix A:")
print(A)
print(det_A)
print("\ntranspose matrix A:")
print(A_transpose)
print("\nreverse matrix A:")
print(A_inv)
print("\ncondition_number matrix A:", condition_number)