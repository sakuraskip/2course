   M S B A M L   `   `   `  ����?  ;lab4, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:lab4lab4  5          lab4.ShipDetails   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      $localclr-namespace:lab4     5      $	��600��5	      $	��800��6     N� Title$  ShipDetails��5
       � 	Resources 5         ShipTemplate��%  &	        �� 5   
   .R�5      �� .+�5      �� $	��390��6   $	��390��6%   $��UniformToFill=�6R   ��65   �� *	Photopath+6R   �� 5      $
��Wrap=�69   $��24(�6M   $	��750��6[   $��10q�6j   ��6   �� *Description+6j   5      5      5      .��5      � 
������� � ShowGridLines$
 True��6   $��Stretch=�63   $��Stretch=�6Q    � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $
��0.3* �6   �� 5      $��0.25* �6   .+�5   
   �� $
��Auto=�6   $
��Auto=�6<   $��0��6_   $��2��6l   .��5       �� #��[  61   ��6   �� 61   5!      � 5#   
   $��2��6    K� ZIndex$ 1��6    � ColumnDefinitions 5$      �� 5%      6%   �� 5&      6%    5(      �� 5)      6"   �� 5*      6"   .+�5,      �� $��0��6   $��
Цена: ��6%   $��24(�63   6C   �� 5-      $��1��6   $-��'Длительность аренды: ��6%   $��24(�6B   6R   �� 5.      $��1��6   $��2��6%   $	��200��66   $��50��6B   $��request to book��6N   $��24(�6h   $��Right=�6v   $��0,0,20,0q�6�   6�   �� 5/      $��1��6   $��2��6%   $	��100��66   $��50��6B   $
��Left=�6N   $��удалить��6i   $��20(�6{   6�   50      51      52      