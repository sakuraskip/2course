   M S B A M L   `   `   `  ����?  ;lab4, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:lab4lab4  5   	   1clr-namespace:lab4.ViewModelslab4.ViewModels  5   	       lab4.editShipWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   $localclr-namespace:lab4     5   	   ,vmclr-namespace:lab4.ViewModels     5   	   b ^MaterialDesignThemes.Wpf, Version=3.2.0.1979, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	      Title_EditShipWindow  � Title#  �   5
   	   $	��820��5   	   $	��800��5   	    � WindowStartupLocation$ CenterScreen=�5   	    � DataContext 5      '   !lab4.ViewModels.EditShipViewModel  5   
    � 	Resources 5       �� 
TargetType �� Property �� Value)  #MaterialDesignThemes.Wpf.HintAssist��%!  '��       '�� �     �� 5   
   " ��6   .�5      ��  � ��$ 0,5,0,15q�6'   �� 5       � ��$ 14(�6)   �� 5       �@ Hint 6?   �� 5      �� 5   
   " ��6   .�5      ��  � ��$ 0,5,0,15q�6'   �� 5       � ��$ 14(�6)   5      5      .��5       � $��15q�6   .+�5!   
   #  MaterialDesignThemes.Wpf.Card     UniformCornerRadius$ 5Q�6   $��15q�66   .��5"      �� $
��Auto=�6   .��5#      �� .+�5$      ��  �� CornerRadius$ 5��6   $	��200��6.   $��0,0,0,15q�6;   $	��400��6M     MaterialDesignDivider#���  5%      $��1q�5&      ._�5'      �� $��Uniform=�6=   $��Center=�5(       $��Center=�6=   ��5'       �� *	ShipImage+5(   =   5)      �� 5+        Button_ChangeImage#���  5,      $	��220��5-      $
��Left=�5.      $��0,0,0,20q�5/      ��5+      �� *ChangeImageCommand+5/      �� 50        TextBlock_Name#���  6    �� 51        Hint_ShipName	   Hint#	 �  52      ��51      �� *Name+
 �� UpdateSourceTrigger$
 PropertyChanged=�52      �� 53        TextBlock_ShortDescription#���  6    �� 55        Hint_ShortDescription#	 �  56       �� 	MaxLength$	 200��57      $��60��58       �� TextWrapping$
 Wrap=�59       �� AcceptsReturn$
 True��5:      ��55      �� *ShortDescription+$
 PropertyChanged=�5:      �� 5;        TextBlock_Description#���  6    �� 5=        Hint_Description#	 �  5>      $	��120��5?      $
 Wrap=�5@      $
 True��5A      " �� VerticalScrollBarVisibility$
 Auto=�5B      ��5=      �� *Description+$
 PropertyChanged=�5B      �� 5C       	 TextBlock_ShipType#��� 	 6    �� 5E       
 Hint_ShipType#	 � 
 5F      ��5E      �� *
ShipType+$
 PropertyChanged=�5F      �� 5G        TextBlock_Price#���  6    �� 5I        
Hint_Price#	 �  5J      .  (MaterialDesignThemes.Wpf.TextFieldAssist   
PrefixText$	 BYN��5K      ��5I      �� *Price+$
 PropertyChanged=�5K      �� 5L        TextBlock_Availability#���  6    �� 5N        Hint_Availability#	 �  5O      ��5N      �� *Availability+5O      �� 5P       �� Orientation$ 
Horizontal=�6!   $��Right=�6:   $��0,20,0,0q�6V   .+�5Q      �� 
�������
���   �  Button_Cancel#���  5T   !   $	��120��5U   !   ��5Q   !   �� *CancelCommand+5U   !   �� 5W        Button_Save#���  5X   !   $	��120��5Y   !   ��5W   !   �� *SaveCommand+5Y   !   5Z      �� 5\      
���  ��$
��Wrap=�5^       $��0,10,0,0q�5_       ��5\       �� *ErrorMessage+5_       5`      5a      5b      5c      5d      