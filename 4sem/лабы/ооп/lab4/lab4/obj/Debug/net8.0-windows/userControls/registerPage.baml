   M S B A M L   `   `   `  ����?  ;lab4, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:lab4lab4  5   	   1clr-namespace:lab4.ViewModelslab4.ViewModels  5   	   $    lab4.userControls.registerPage   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   $localclr-namespace:lab4     5   	   ,vmclr-namespace:lab4.ViewModels     5   	   b ^MaterialDesignThemes.Wpf, Version=3.2.0.1979, Culture=neutral, PublicKeyToken=df2a72020bd7962a:md1http://materialdesigninxaml.net/winfx/xaml/themes  5   	      Title_RegisterPage  � Title#  �   5
   	   $	��700��66   $	��900��6C    � WindowStartupLocation$ CenterScreen=�5   	    � DataContext 5      '   !lab4.ViewModels.RegisterViewModel  5   
    � 	Resources 5        	OceanBlue �� Color  	LightWave �� 
TargetType % !MaterialDesignFloatingHintTextBox �� BasedOn �� Property �� Value)  #MaterialDesignThemes.Wpf.HintAssist  MaterialDesignRaisedButton��%X  &	       &	 !     '�� B     7  7  '�� >    7  7  �� 5   
   $ #1E88E5��6,   �� 5   
   $ #E3F2FD��6,   �� 5   
   " ��6   8   .�5      ��  � ��$ 	0,10,0,10q�6'   �� 5       � ��$ 18(�6)   �� 5       �@ FloatingScale$	 0.8Q�6<   �� 5       � ��
 �����6+   �� 5       �@ 
Foreground8  69   5      �� 5   
   " ��6   8   .�5      ��  � ��8  6+   �� 5       � ��
 �����6+   �� 5        � ��$ 50��6'   �� 5!       � ��$ 18(�6)   �� 5"       � ��$ 	0,20,0,10q�6'   5#      5$      .��5&      � #��[ 6   	 � RowDefinitions	 5'   
   �� 5(      $
��Auto �6   �� 5)      $��* �6   �� 5*      $
��Auto �6   .+�5-   
   #  MaterialDesignThemes.Wpf.Card  $��1��6   $��50q�6   
   UniformCornerRadius$
 6Q�6+   $��40q�6C   
�������#��[ 5/      $��0 0 0 3q�6;   .��50      �� $
��Auto=�6   .��51      �� .+�52      �� #���   6     $  MaterialDesignHeadline4TextBlock#��[ 53       #��[ 54       $��Center=�55       $��0,0,0,30q�6=   �� 57        
Hint_Login   Hint# �  58      ��57      �� *Login+ �� UpdateSourceTrigger$ PropertyChanged=�58      �� 5:        Hint_Username# �  5;      $��	0,10,0,10q�5<      ��5:      �� *
Username+$ PropertyChanged=�5<      G� 5>      -   5          Hint_Password# �  5@      $��	0,10,0,10q�5A      G� 5C      -   5         	 Hint_ConfirmPassword# � 	 5E      $��	0,10,0,20q�5F      �� 5H       
 Button_Register#��� 
 5I      ��5H      �� *RegisterCommand+5I      �� 5K       �� Orientation$ 
Horizontal=�6!   $��Center=�6:   $��0,20,0,0q�6W   .+�5L      ��    TextBlock_AlreadyHaveAccount#���  6$   $��Center=�5M   $   $��0,0,5,0q�5N   $   �� 5O      �� 5P      #��[ 5Q   (    �� TextDecorations$
 None{�5R   (    �� Command 5P   (   �� *NavigateToLoginCommand+.�5R   ?   .�5S   "   ��   Hyperlink_LoginText#���  6,   5T      5U      5V      5W      5X      5Y      5Z      5[      