import numpy as np

A = np.array([[10.9, 1.2, 2.1, 0.9],
              [1.2, 11.2, 1.5, 2.5],
              [2.1, 1.5, -9.8, 1.3],
              [-0.9, -2.5, -1.3, -12.1]])

norm_A = np.linalg.norm(A, 2)
print("1", norm_A)
A_inv = np.linalg.inv(A)

norm_A_inv = np.linalg.norm(A_inv, 2)
print("2",norm_A_inv)
condition_number = norm_A * norm_A_inv

print("3:", condition_number)