   M S B A M L   `   `   `  ����?  ;lab4, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:lab4lab4  5   	   1clr-namespace:lab4.ViewModelslab4.ViewModels  5   	   5clr-namespace:lab4.userControlslab4.userControls  5   	   O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5   	       lab4.ItemsList   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   $localclr-namespace:lab4     5   	   ,vmclr-namespace:lab4.ViewModels     5   	   3controlclr-namespace:lab4.userControls     5   	   b ^MaterialDesignThemes.Wpf, Version=3.2.0.1979, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	   	   0sys&clr-namespace:System;assembly=mscorlib  5   	   _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  5      ���	#FFF5F5F7  � Title$%  Главная страница��5   	   $	��800��5   	   $
��1050��6    � WindowStartupLocation$ CenterScreen=�5   	   $��Segoe UI)�5   	    � DataContext 5      (   "lab4.ViewModels.ItemsListViewModel  5   
    � 	Resources 5       �� 
TargetType   ModernButton �� Property �� Value3  -System.Windows.Media.Effects.DropShadowEffect   
BlurRadius   ShadowDepth	   Opacity  MaterialFilterComboBox  MaterialDesignComboBox
 �� BasedOn)  #MaterialDesignThemes.Wpf.HintAssist.  (MaterialDesignThemes.Wpf.TextFieldAssist  MaterialComboBoxItem # MaterialDesignComboBoxItemStyle �� Triggers P� Property P� Value  ModernTextBox  SectionHeader$   lab4.BoolToVisibilityConverter  BoolToVisibilityConverter  ShipCardTemplate �� CornerRadius J� InputBindings d� MouseAction �� Command �� RelativeSource �� AncestorType �� CommandParameter � RowDefinitions �� Padding � ColumnDefinitions �� Orientation'  !MaterialDesignThemes.Wpf.PackIcon   Kind �� StringFormat 	 PerDaySuffix 
 
CardShadow��%�  &	        &	 y    7  &	 -    7  &	     &	 �    &	 �    &	 �    &	
 !    �� 5   
   " ��6   .�5      ��  � �� �#4285F46+   �� 5       � ��
 �����6+   �� 5       � ��$ 16(�6)   �� 5       � ��$
 15,8q�6(   �� 5       � ��$ 0q�60   �� 5       �@�Cursor$
 Hand��6'   �� 5       �@J�Effect 5         5!      $ 10Q�6'   $ 2Q�67   $		 0.2Q�6G   5#      5$      �� 5%   
   " ��6/   8
   .�5&      ��  � �� �#4285F46+   �� 5'       � ��
 �����6+   �� 5(       � �� �#3367D66,   �� 5)       � ��$ 0,0,0,15q�6'   �� 5*       � ��$	 200��6&   �� 5+       � ��$ 16(�6)   �� 5,       �@ Hint$ Тип судна��6?   �� 5-       �@ 
Foreground
 �����6E   �� 5.       �@ UnderlineBrush
 �����6N   5/      �� 50   
   " ��6-   8
   .�51      ��  � �� �#4285F46+   �� 52       � ��
 �����6+    53      P� 54       �@��IsHighlighted$
 True��63   . �55      ��  � �� �#3367D663   56      58      �� 59   
   " ��6   .�5:      ��  � ��
 �����6+   �� 5;       � �� �#DDDDDD6,   �� 5<       � ��$ 1q�60   �� 5=       � ��$ 10q�6(   �� 5>       � ��$ 16(�6)   5@      �� 5B   
   " ��6   .�5C      ��  � ��$ 18(�6)   �� 5D       � ��$ SemiBold"�6+   �� 5E       � �� �#3333336+   �� 5F       � ��$ 0,0,0,10q�6'   5G        5I   
   6*   �� 5K   
   .R�5L      �� ���#E0E0E0$��1q�6+   $ 12��6?   $��15q�5M      
������� 5N      d� 5O      $ 	LeftClicke�6#    5P      �� * DataContext.ShipDetailsCommand+ �� 
 Window 5R      �� ._�5T      � $	��300��6   $	��350��6#    5U      �� 5V      $	��200 �6(   �� 5W      $��* �6(   �� 5X      $
��Auto �6(   .+�5[      �� $��0��6   $ 	12,12,0,0��6*   $
}�True��6C   ._�5\      �� $��UniformToFill=�6=   ��6    �� *	ImagePath+6=   5]      �� 5_      $��1��6!   .+�5`      �� $��20(�6:   $
��Bold"�6H   $
��Wrap=�5a      $��0,0,0,5q�60   ��5`   $   �� *Name+5a   0   �� 5b      $��14(�6F   ���#666666$
��Wrap=�5c   1   ��5b   $   �� *ShortDescription+5c   1   5d      �� 5f      $��2��6   ���#F8F9FA$ 	0,0,12,12��6?   $ 15q�5g      $��0,1,0,0q�6"   ���#EEEEEE._�5h      �  5i      �� 5j   "   $��* �63   �� 5k   "   $
��Auto �63   .+�5n      �� $ 
Horizontal=�6)   $��Center=�6B   .+�5o   "     $
 Star=�6:   $��16��6F   $��16��6Q   ���#FFC107$��0,0,5,0q�5p   E   �� 5q   "   $��18(�6[   ��6,   �� *Rating+$ {0:F2}��6[   �� 5r   "   $��/5��6,   $��18(�66   ���#666666$��2,0,0,0q�6Y   5s      �� 5u      $��1��6)   $ 
Horizontal=�69   $��Center=�6R   .+�5v   "   �� $��18(�5w      $��SemiBold"�5x      ��5v   ,   �� *PriceString+5x      �� 5y   "   #��� 	 6,   $��18(�5z      $��SemiBold"�5{      5|      5~      5      5�      5�      5�        5�   
   $ 15Q�6.   $ 3Q�6>   $		 0.1Q�6N   5�      .��5�      �  5�   
   �� 5�      $	��300 �6   �� 5�      $��* �6   .+�5�   
   �� $��0��6   ���#FFFFFF���#EEEEEE$��0,0,1,0q�6L   ._�5�      �  5�      �� 5�      $��* �6$   �� 5�      $
��Auto �6$   .+�5�      �� $��0��6   $
��Auto=�6,   .��5�      �� $��20q�6!   .+�5�      ��   FiltersTitle#���  6$   $��22(�6J   $
��Bold"�6X   $��0,0,0,20q�6j   �� 5�        SearchByName#���  6$   #��[ 6J   �� 5�      #��[ 6"   $��0,0,0,20q�5�      ��5�      �� *
FilterName+ �� UpdateSourceTrigger$ PropertyChanged=�5�      �� 5�        
PriceRange#���  6$   #��[ 6H   �� 5�      $ 
Horizontal=�6%   $��0,0,0,20q�6>   .+�5�      �� #��[ 6&   $	��100��6M     	PriceFrom   Hint# �  5�      ��5�      �� *
MinPrice+$ PropertyChanged=�.��5�   O   *  $Microsoft.Xaml.Behaviors.Interaction   	Behaviors 5�   "      lab4.NumericInputBehavior  5�   &   .��5�   ;   5�      �� 5�      $	��—��6(   $
��10,0q�61   $��Center=�6?   �� 5�      #��[ 6&   $	��100��6M     PriceTo# �  5�      ��5�      �� *
MaxPrice+$ PropertyChanged=�.��5�   M    5�   "     5�   &   .��5�   ;   5�      5�      �� 5�        	SydnoType#���  6$   #��[ 6G   6p   �� 5�      #��[ 5�      #��[ 5�      $��10q�5�      $	��259��6(   ��5�   #   �� *FilterTypes+ �� SelectedItem 5�      �� *SelectedFilterType+5�   (   �� 5�      $��0,30,0,0q�5�      y�5�   %   �� *	IsAdmin+ �� 	Converter# [ .+�5�      ��   AdminSection#���  6(   #��[ 6N   �� 5�        AddBoat#���  6%   #��[  6I   $��0,0,0,10q�5�   4   ��6   �� *AddShipCommand+64   �� 5�        
AdminPanel#���  6%   #��[  6L   ��5�      �� *AdminPanelCommand+5�      5�      5�      �� 5�      $��20q�6   $��Bottom=�6)   .+�5�      ��   UserProfile#���  6   #��[  6E   $��0,30,0,0q�5�      ��6   �� *UserProfileCommand+�� 5�      $��Bottom=�6     
ExitButton#���  6Z   #��[  6�   $��0,30,0,0q�6�   ��68   �� *LogoutCommand+6�   5�      5�      5�      � 5�   
   $��1��6    5�      �� 5�      $
��Auto �6    �� 5�      $��* �6    .+�5�      �� $��0��6   ���#4285F4$ 20q�67   ._�5�      ��   AvailableBoats#���  6   $��24(�6D   
�������$
��Bold"�5�      $��Center=�6&   5�      �� 5�      $��1��6   $
��Auto=�6(   $��20q�6K   .��5�      �� #��[ 5�      ��5�      �� *Ships+��5�      �� 5�      .R�5�      �   � Orientation$  
Horizontal=�6(   5�      5�      5�      5�      5�      5�      