   M S B A M L   `   `   `  ����?  ;lab4, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:lab4lab4  5   	   1clr-namespace:lab4.ViewModelslab4.ViewModels  5   	       lab4.loginpage   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   $localclr-namespace:lab4     5   	   ,vmclr-namespace:lab4.ViewModels     5   	   b ^MaterialDesignThemes.Wpf, Version=3.2.0.1979, Culture=neutral, PublicKeyToken=df2a72020bd7962a:md1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � Title$  Вход��5
   	   $	��700��6   $	��900��6#    � WindowStartupLocation$ CenterScreen=�5   	    � DataContext 5      $   lab4.ViewModels.LoginViewModel  5   
    � 	Resources 5         	OceanBlue �� Color  	LightWave �� 
TargetType % !MaterialDesignFloatingHintTextBox �� BasedOn �� Property �� Value)  #MaterialDesignThemes.Wpf.HintAssist��%d  &	        &	 !     '�� B     7  7   �� 5   
   $ #1E88E5��6,   �� 5   
   $ #E3F2FD��6,   �� 5   
   " ��6   8   .�5      ��  � ��$ 	0,10,0,20q�6'   �� 5       � ��$ 18(�6)   �� 5       �@ FloatingScale$	 0.8Q�6<   �� 5       � ��
 �����6+   �� 5       �@ 
Foreground8  69   5      5      .��5!      � #��[ 6   	 � RowDefinitions	 5"   
   �� 5#      $
��Auto �6   �� 5$      $��* �6   �� 5%      $
��Auto �6   �� 5&      $��* �6   �� 5'      $
��Auto �6   .+�5,   
   � $��1��6   $��3��6   
 � ColumnDefinitions
 5-      �� 5.      $��* �6#   �� 5/      $	��400 �6#   �� 50      $��* �6#   .+�53      (� $��80��6   $��1��6"   $	��Top=�62   $��	0,90,0,30q�6J   .��54      ��  �� Orientation$ 
Horizontal=�6   .+�55      ��   LoginPageText#���  6    #��[  56       $��36(�57       59      5:      #  MaterialDesignThemes.Wpf.Card  5<      $��1��6   $��1��6&      UniformCornerRadius$ 6Q�63   $��30q�6K   
�������#��[  5>      $��0 0 0 3q�6?   $��Center=�5?      .��5@      �� .+�5A      ��   
Hint_Login   Hint# �  5B      ��5A      �� *Login+ �� UpdateSourceTrigger$ PropertyChanged=�5B      G� 5D      -   5         G�Name$ PasswordBox��5D   "     Hint_Password# �  5E   "   $��	0,10,0,30q�5F   "   5G   "   �� 5I        Button_Login#���  5J      ��5I      �� *LoginCommand+5J      �� 5M      $ 
Horizontal=�6!   $��Center=�6:   .+�5N      ��   TextBlock_NoAccount#���  6$   $��Center=�5O   $   $��0,0,5,0q�5P   $   �� 5Q      �� 5R      #��[  5S   (    �� TextDecorations$
 None{�5T   (    �� Command 5R   (   �� *RegisterCommand+.�5T   ?   .�5U      ��   Hyperlink_RegisterText#���  6)   5W      5X      5Y      5Z      5[      5\      5_      5`      