   M S B A M L   `   `   `  ����?  ;lab4, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:lab4.admin_panellab4.admin_panel  5   	   ;"clr-namespace:lab4.adminViewModelslab4.adminViewModels  5   	   '    !lab4.admin_panel.EditRentalWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:lab4.admin_panel     5   	   1vm"clr-namespace:lab4.adminViewModels     5   	   b ^MaterialDesignThemes.Wpf, Version=3.2.0.1979, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	      Title_EditRentalWindow  � Title#  �   5
   	   $	��500��6:   $	��600��6G    � WindowStartupLocation$ CenterScreen=�5   	    � DataContext 5      .   (lab4.adminViewModels.EditRentalViewModel  5   
    � 	Resources 5       �� 
TargetType �� Property �� Value)  #MaterialDesignThemes.Wpf.HintAssist(  "System.Windows.Controls.DatePicker��%�  '��       '  �     '�� >    �� 5   
   " ��6   .�5      ��  � ��$ 0,5,0,15q�6'   �� 5       � ��$ 14(�6)   �� 5       �@ Hint 6?   �� �� 5       �@ 
IsFloating$
 True��6E   5      �� 5   
   "  6   .�5      ��  � ��$ 0,5,0,15q�6'   �� 5       � ��$ 14(�6)   5      �� 5   
   " ��6   .�5      ��  � ��$ 0,15,0,5q�6'   �� 5        � ��$ 14(�6)   �� 5!       � ��$ SemiBold"�6+   5"      5#      .��5%      � $��15q�6   .+�5&   
   #  MaterialDesignThemes.Wpf.Card     UniformCornerRadius$ 5Q�6   $��15q�66   .��5'      �� $
��Auto=�6   .��5(      �� .+�5)      �� 
�������$��Italic$�5*   2   ��5)       �� *	Rental.Id+ �� StringFormat$ ID : {0}��5*   2   �� 5,      	 �� 
IsReadOnly$
	 True��5-        TextBlock_ShipName
   Hint#
 �  5.      ��5,      �� *Rental.shipName+ �� UpdateSourceTrigger$ PropertyChanged=� �� ValidatesOnDataErrors$
 True��5.      �� 50        TextBlock_ShipId#
 �  51      ��50      �� *Rental.ShipId+$ PropertyChanged=�$
 True��51      �� 53        TextBlock_UserId#
 �  54      ��53      �� *Rental.UserId+$ PropertyChanged=�$
 True��54        56        TextBlock_Date#
 �  57   !      SelectedDate 56   !   �� *Rental.Date+$ PropertyChanged=�57   !   �� 59       �� SelectedValuePath$	 Tag��5:        TextBlock_Status#
 �  5;      $��0,5,0,15q�5<       �� SelectedValue 59      �� *Rental.Status+$ PropertyChanged=�.@�5=      ��   ComboBox_Status_Active#���  6'   
 � Tag$ Активно��6Z   �� 5>        ComboBox_Status_Completed#���  6'   $ Завершено��6]   �� 5?        ComboBox_Status_Canceled#���  6'   $ Отменено��6\   �� 5@       !	 ComboBox_Status_PendingCancel#��� 	 6'   $# Ожидание отмены��6a   �� 5A       
 ComboBox_Status_Confirmed#��� 
 6'   $ Подтверждено��6]   5B      �� 5D        TextBlock_Price#
 �  5E      ��5D      �� *Rental.Cost+$ PropertyChanged=�$
 True��5E      �� 5G       �� Orientation$ 
Horizontal=�6!   $��Right=�6:   $��0,20,0,0q�6V   .+�5H      ��   Button_Cancel#���  5I   !   $	��130��5J   !   ��5H   !   �� *CloseCommand+5J   !   �� 5L        Button_Save#���  5M   !   $	��130��5N   !   ��5L   !   �� *SaveCommand+5N   !   5O      �� 5Q      
���  ��$
��Wrap=�5S       $��0,10,0,0q�5T       ��5Q       �� *ErrorMessage+5T       5U      5V      5W      5X      5Y      