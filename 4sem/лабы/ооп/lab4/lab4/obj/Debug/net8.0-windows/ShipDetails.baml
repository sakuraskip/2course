   M S B A M L   `   `   `  ����?  ;lab4, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:lab4lab4  5   	       lab4.ShipDetails   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   $localclr-namespace:lab4     5   	   $	��600��5	   	   $	��800��6     � Title$  ShipDetails��5
   	    � 	Resources 5         ShipTemplate ��Name��%�  &	        �� 5   
   .R�5      �� .+�5      �� $
��Auto��6   $	��400��6&   $��Uniform=�6S   $��Stretch=�5      $	��Top=�66   $��20q�6N   ��5   6   �� *	Photopath+5   N   �� 5      $
 fart��6   $
��Wrap=�6G   $��24(�6[   $
��auto��6i   $	��750��6v   $��10q�6�   $��Stretch=�5      ��5   *   �� *Description+5      5      5      5      .��5      � 
������� � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $
��0.3* �6   �� 5      $��0.25* �6   .+�5   
   �� $
��Auto=�6   $
��Auto=�6<   $��0��6_   $��2��6l   .��5       �� #��[  61   ��6   �� 61   5!      � 5#   
   $��2��6   
������� � ColumnDefinitions 5$      �� 5%      $��* �6#   �� 5&      $
��0.9* �6#    5(      �� 5)      �� 5*      .+�5,      �� -   5        $ price_textblock��5,      $��0��61    	 Price#���  6>   $��24(�6]   �� 5-      -   5        $ avaliable_textblock��5-      $��1��65     Availability#���  6B   $��24(�6h   �� 5.      -   5        $��1��5.      $��2��6%   $	��200��66   $��50��6E     SubmitRequest#���  6Q   $��24(�6{   $��Stretch=�6�   6�   5/      50      51      