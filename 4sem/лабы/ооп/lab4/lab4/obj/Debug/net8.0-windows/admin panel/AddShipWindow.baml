   M S B A M L   `   `   `  ����?  ;lab4, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:lab4lab4  5   	   O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5   	       lab4.AddShipWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   $localclr-namespace:lab4     5   	   6sys&clr-namespace:System;assembly=mscorlib     5   	     � Title$  Add Ship��5   	   $	��550��6   $	��500��6'    J� CommandBindings 5      )  #System.Windows.Input.CommandBinding  5	   
   -   5           lab4.AddShipWindow   AddShipCommand   Command# Z 5	      6Q     5
   
   -   5           SelectFileCommand# Z 5
      6T    � 	Resources 5       �� 
TargetType �� Triggers �� Binding	 �� RelativeSource
 �� Value �� Property �� Value :� RoutedEvent �� TargetProperty	 �� To g� Duration��%�  '��       '�� �     �� 5   
   " ��6    5      �� 5       6   �� *Text.Length+	 �� *Self+
 06d   .a�5      ��  � ��
 �����63   5      5      �� 5   
   " ��6    5      :� 5      $ Button.MouseEnter��6   .[�5      �� .��5      �� .��5      �� $1 +(Button.Background).(SolidColorBrush.Color)�6-    	LightBlue5   -   $ 0:0:0.3D�6<   5      5       5!      5#      5'      .��5)      � $��20q�6   .+�5*   
   �� .+�5+      �� #��� ��6   $��16(�66   �� 5,      -   5         ��Name$ NameTextBox��5,      $��0,0,0,10q�6+   �� 5.         Description#���   6   $��16(�6=   �� 5/      -   5        $ DescriptionTextBox��5/      $��0,0,0,10q�63    �� AcceptsReturn$
 True��6E   $��90��6Z   �� 51       	 Price#���  6   $��16(�67   �� 52      -   5        $ PriceTextBox��52      $��0,0,0,10q�6,   �� 54        	ImagePath#���  6   $��16(�6;   �� 55      -   5        $ PhotopathTextBox��55      $��0,0,0,10q�60    �� 
IsReadOnly$
 True��6B   �� 56        
ChooseFile#���  6   #��Z 6<   $	��100��6w   $
��Left=�6�   $��0,0,0,10q�6�   �� 58      -   5         ��Name$ ImageBorder��58      $��0q�6*   
�������._�59      �� -   5         ��Name$ ImagePreview��59      $	��100��6.   $��0,0,0,10q�6;   5:      �� 5<        Add#���  6   #��Z 65   $	��100��6m   $��Right=�6y   5=      5>      5?      