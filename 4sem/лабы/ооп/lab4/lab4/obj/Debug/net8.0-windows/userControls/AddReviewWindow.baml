   M S B A M L   `   `   `  ����?  ;lab4, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:lab4lab4  5   	   1clr-namespace:lab4.ViewModelslab4.ViewModels  5   	   '    !lab4.userControls.AddReviewWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   $localclr-namespace:lab4     5   	   ,vmclr-namespace:lab4.ViewModels     5   	   b ^MaterialDesignThemes.Wpf, Version=3.2.0.1979, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	      Title_AddReviewWindow  � Title#  �   5
   	   $	��300��5   	   $	��400��6    � WindowStartupLocation$ CenterOwner=�5   	    � 
ResizeMode$ NoResize=�5   	    � DataContext 5      (   "lab4.ViewModels.AddReviewViewModel  5   
   6"   .��5      � $��15q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   ��   TextBlock_YourReview#���  6   $��18(�6B   $
��Bold"�6P   $��0,0,0,10q�6b   �� 5   
   $��1��6    �� AcceptsReturn$
 True��5       �� TextWrapping$
 Wrap=�6'   " �� VerticalScrollBarVisibility$
 Auto=�6;    �� 	MaxLength$	 500��5      $��14(�6"   $��5q�60   ��5      �� *	Comment+5   0   �� 5    
   $��2��6   	 �� Orientation$	 
Horizontal=�6"   $��0,15,0,0q�6;   .+�5!      ��   TextBlock_Rating#���  6   $��Center=�6B   $��0,0,10,0q�6]   �� 5"      
 �� SelectedValuePath$	
 Tag��5#      $	��100��5$      $
��Left=�6#    �� SelectedValue 5"      �� *Rating+.@�5%      ��   ComboBox_Rating_1#���  6   
 � Tag$ 1��6M   �� 5&        ComboBox_Rating_2#���  6   $ 2��6M   �� 5'        ComboBox_Rating_3#���  6   $ 3��6M   �� 5(        ComboBox_Rating_4#���  6   $ 4��6M   �� 5)        ComboBox_Rating_5#���  6   $ 5��6M   5*      5+      �� 5-   
   $��3��6   $	 
Horizontal=�6"   $��Right=�6;   $��0,20,0,0q�6W   .+�5.      ��   Button_Cancel#���  6   $	��120��5/      ��5.   ?   �� *CancelCommand+5/      �� 50       	 Button_Submit#��� 	 6   $	��120��51      ��50   ?   �� *SubmitCommand+51      52      53      54      