   M S B A M L   `   `   `  ����?  ;lab4, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:lab4lab4  5   	   O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5   	   1clr-namespace:lab4.ViewModelslab4.ViewModels  5   	       lab4.AddShipWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   $localclr-namespace:lab4     5   	   6sys&clr-namespace:System;assembly=mscorlib     5   	   ,vmclr-namespace:lab4.ViewModels     5   	      BackgroundColor#���   5   D     � Title$  Add Ship��5   	   $	��550��6   $	��500��6'    � DataContext 5	      ,   &lab4.ViewModels.AddShipWindowViewModel  5
   
    � 	Resources 5       �� 
TargetType  ValidatingTextBox �� Property �� Value �� Triggers �� Binding �� Value  PriceTextBox	 �� BasedOn��%z  &	       &	 Z    7  �� 5   
   " ��6   .�5      ��  � ��$ 0,0,0,10q�6'   �� 5       � ��
 �����6,    5      �� 5       6   �� *IsNameValid+	 false6>   .a�5      ��  � ��
 �  ��64   �� 5       �@�ToolTip$H BЭто поле обязательно для заполнения��60   5      5      �� 5   
   " ��6   8	    5      �� 5       6   �� *IsPriceValid+	 false6?   .a�5      ��  � ��
 �  ��64   �� 5       �@�ToolTip$C =Введите корректную цену (число > 0)��60   5      5       52      .��53      �� $��Disabled=�6   $
��Auto=�6<   .��54      � $��20q�6   .+�55   
   �� .+�56      ��   TextBlock_ShipName#���  6   $��16(�6D   �� 57      -   5        
 ��Name$
 NameTextBox��57   {   #��[ 6   $��0,0,0,10q�6�   ��6A   �� *Name+ �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 59        TextBlock_Description#���  6   $��16(�6G   �� 5:      -   5        $
 DescriptionTextBox��5:   �   #��[ 6    �� TextWrapping$
 Wrap=�6�   $��0,0,0,10q�6�    �� AcceptsReturn$
 True��6�   $��90��6�   ��6A   �� *Description+$ PropertyChanged=�6�   �� 5<        TextBlock_ShortDescription#���  6   $��16(�6L   �� 5=      $��0,0,0,10q�6\   $
 true��6n   $��50��6�   ��6   �� *ShortDescription+$ PropertyChanged=�6�   �� 5?        TextBlock_Price#���  6   $��16(�6A   �� 5@      -   5        $
 PriceTextBox��5@   w   #��[ 6   $��0,0,0,10q�6�   ��6<   �� *Price+$ PropertyChanged=�6�   �� 5B        TextBlock_ShipType#���  6   $��16(�6D   �� 5C      ��6   �� *
ShipType+$ PropertyChanged=��� 5E        TextBlock_ImagePath#���  6   $��16(�6E   �� 5F      -   5        $
 PhotopathTextBox��5F   U   $��0,0,0,10q�6o    �� 
IsReadOnly$
 True��6�   ��6   �� *	ImagePath+$ PropertyChanged=�6�   �� 5G       	 Button_ChooseFile#��� 	 6   $	��150��6i   $
��Left=�6u   $��0,0,0,10q�6�   ��6C   �� *SelectFileCommand+6�   �� 5I      -   5         ��Name$ ImageBorder��5I      $��0q�6*   
�������._�5J      �� -   5         ��Name$ ImagePreview��5J   8   $	��100��6N   $��0,0,0,10q�6[   ��6   �� *ImagePreview+6[   5K      �� 5M       
 
Button_Add#��� 
 6   $	��110��6`   $��Right=�6l   ��6<   �� *AddShipCommand+6l   5N      5O      5P      5Q      