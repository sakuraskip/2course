   M S B A M L   `   `   `  ����O  Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem  5      ? ;lab4, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:lab4lab4 5   	      lab4.ItemsList   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   9system&clr-namespace:System;assembly=mscorlib     5      $localclr-namespace:lab4     5   	     � Title$  	ItemsList��5	   	   $	��700��6   $
��1000��6(   .��5      � 
������� � ShowGridLines$ False��6    � ColumnDefinitions 5   
   �� 5      $��0.35* �6   6/   �� 5      6!    � RowDefinitions 5   
   �� 5      $
��Auto �6   6,   �� 5      $��* �6   6)   .+�5   
   �� $��1��6   $��0��6'   $��2��64   $
��Auto=�6E   $
��Auto=�6h   .��5      �� -   5         ��Name$ shipsControl��5      ��5      �� 5      .R�5      A�  A� Columns$ 2��6&   64   5      ��5      �� 5      .R�5      �� 
����  �$��1q�64    �� CornerRadius$ 5��6H   ._�5      � $	��330��6#   $
 True��6/    5    "   �� 5!   &   69    5#   "   �� 5$   &   $
��0.8* �64   6D   �� 5%   &   66   �� 5&   &   66   .+�5(   "   �� $��0��6E   $	��700��6R   $	��250��6a   $��UniformToFill=�6q   $��Stretch=�5)      $��Stretch=�62   ��5(   (   �� *	Photopath+5)   2   �� 5*   "   $��20(�6B   $��1��6P   $
��Left=�6]   ��6,   �� *Name+6]   �� 5+   "   $��20(�6C   $��2��6Q   $
��Left=�6^   ��6,   �� *Price+6^   5,      5-      5.      50      51      �� 52   
    �� Orientation$ Vertical=�6   $��Center=�6,   .+�53      �� $"��Перейти к яхтам��6   $��50��6/   $��	0 50 0 50q�6;   $��18(�6N   6^   �� 54      $&�� Поиск по названию��6   $��20(�61    �� Padding$ 0 0 0 10q�6?   �� 55      $��30��6   $	�� 20(�6"   $��	 0 0 0 20q�62   6H   �� 56      $��Диапазон цены��6   $��20(�6-   $ 	 0 0 0 10q�6;   6Q   �� 57      $ 
Horizontal=�6   .+�58      �� $��50��6   $��30��6&   $
��Left=�62   6O   �� 59      $��80��6   $��80��6*   $y�Hidden=�65   6K   �� 5:      $��50��6   $��30��6%   $��Right=�61   6O   5<      5=      �� 5>   
   $��1��6   $��Bottom=�6   $��0 0 0 30q�69   $,��&Добавить новое судно��6K   $	��200��6k   $��50��6w   $��15(�6�   6�   5@      5A      