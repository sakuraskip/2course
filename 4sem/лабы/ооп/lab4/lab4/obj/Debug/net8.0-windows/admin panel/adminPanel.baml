   M S B A M L   `   `   `  ����?  ;lab4, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:lab4lab4  5   	   1clr-namespace:lab4.ViewModelslab4.ViewModels  5   	   U QLiveCharts.Wpf, Version=0.9.7.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf 5	   	       lab4.adminPanel   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   $localclr-namespace:lab4     5   	   ,vmclr-namespace:lab4.ViewModels     5   	   b ^MaterialDesignThemes.Wpf, Version=3.2.0.1979, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   >lvc4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf  5	   	      BackgroundColor#���   5
        Title_AdminPanel  � Title#  �  5   	   $	��450��64   $	��800��6A    � DataContext 5      )   #lab4.ViewModels.AdminPanelViewModel  5   
   .��5      � .+�5   
   �� .@�5      ��   	Tab_Ships#���  6   .��5      �� $
��Auto=�6   .��5      �� -   5         ��Name$ ShipList��5   A   ��6#   �� *Ships+��5      �� 5      .R�5   "   � 5      ��5      �� 5      .R�5   "   �� 
�������$��1q�6<   $��5q�6P    �� Padding$ 10q�6[   ._�5   &   �� $	��220��61    �� Orientation$ Vertical=�6=   .+�5   *   �� $	��150��6M   $��UniformToFill=�6]   ��60   �� *	ImagePath+6]   �� 5    *   $��18(�6J   ��64   �� *Name+6J   �� 5!   *   $��18(�6K   ��64   �� *Price+6K   �� 5#   *   $ 
Horizontal=�65   $��Center=�6N   .+�5$   .   ��   Button_Edit#���  65   $	��110��6]   $��5q�6i   $��11(�6�   ��6t   �� *DataContext.EditCommand+ �� RelativeSource ��  �� AncestorType
 Window��6�   �� 6�   �� 5&   .     Button_Delete#���  65   $	��105��6_   $��5q�6k   $��12(�6�   ��6v   �� *DataContext.DeleteCommand+ �� 
 Window��6�   �� 6�   5(   +   5)   '   5*   #   5+      5-      5.      5/      �� 51        	Tab_Users#���  6   .��52      �� $
��Auto=�6   .��53      �� -   5        $ UserList��53   A   ��6#   �� *Users+��54      �� 55      .R�56   "   � 57      ��59      �� 5:      .R�5;   "   �� 
�������$��1q�6<   $��5q�6P   $ 10q�6[   ._�5<   &   �� $	��220��61   $ Vertical=�6=   .+�5=   *   �� $��18(�6K   ��64   �� *Login+6K   �� 5>   *   $��18(�6N   ��64   �� *
Username+6N   �� 5?   *   $��18(�6J   ��64   �� *Role+6J   �� 5@   *   $ 
Horizontal=�65   $��Center=�6N   .+�5A   .   �� #���  65   $	��110��6]   $��5q�6i   $��11(�6�   ��6t   �� *DataContext.EditUserCommand+ �� 
 Window��6�   �� 6�   5E   +   5F   '   5G   #   5H      5J      5K      5L      �� 5N        Tab_Rentals#���  6   .��5O      �� $
��Auto=�6   .��5P      �� -   5        $ 
RentalList��5P   D   ��6#   �� *
Requests+��5Q      �� 5R      .R�5S   "   � 5T      ��5V      �� 5W      .R�5X   "   �� 
�������$��1q�6<   $��5q�6P   $ 10q�6[   ._�5Y   &   �� $	��220��61   $ Vertical=�6=   .+�5Z   *   �� $��18(�6N   ��64   �� *
shipName+6N   �� 5[   *   $��18(�6L   ��64   �� *UserId+6L   �� 5\   *   $��18(�6J   ��64   �� *Date+6J   �� 5]   *   $ 
Horizontal=�65   $��Center=�6N   .+�5^   .   �� #���  65   $	��110��6]   $��5q�6i   $��11(�6�   ��6t   �� *DataContext.EditRentalCommand+ �� 
 Window��6�   �� 6�   5b   +   5c   '   5d   #   5e      5g      5h      5i      �� 5k        Tab_CancelRequests#���  6   .��5l      �� $
��Auto=�6   .��5m      �� $��10q�6L   ��6#   �� *CancelledRentals+��5n      �� 5o      .R�5p   "   �� 
�������$��1q�6<   $��5q�6P   $ 10q�6[   ._�5q   &   �� $ Vertical=�61   .+�5r   *   �� $��16(�6N   $
��Bold"�6\   ��64   �� *
ShipName+6\   �� 5s   *   $��14(�6N   ��64   �� *
UserName+6N   �� 5t   *   $��14(�6L   
���  ����64   �� *Status+6Z   �� 5v   *   $ 
Horizontal=�65   $��Center=�6N   $��0,10,0,0q�6k   .+�5w   .   ��   Button_ConfirmCancel#���  65   $	��200��6f   $��5q�6r   ��5x   5   �� *&$DataContext.ConfirmCancelRentCommand+ �� 
 Window��5z   5   �� �� 5|   .    	 Button_RejectCancel#��� 	 65   $	��200��6e   $��5q�6q   ��5}   5   �� *%#DataContext.CancelCancelRentCommand+ �� 
 Window��5   5   �� 5�   +   5�   '   5�   #   5�      5�      5�      5�      �� 5�       
 Tab_Statistics#��� 
 6   .��5�      �� $
��Auto=�6   .��5�      � $��10q�6    � RowDefinitions 5�      �� 5�      $
��Auto �6,   �� 5�      $��* �6,   .+�5�      #  MaterialDesignThemes.Wpf.Card  $��0��6.      UniformCornerRadius$ 6Q�6;   $��0,0,0,10q�6S   .��5�      �� $��10q�6)   .+�5�   "   ��   TextBlock_OverallStatistics#���  6,    $  MaterialDesignHeadline6TextBlock#��[ 5�       $��0,0,0,10q�5�       � 5�   "   	 � ColumnDefinitions	 5�   &   �� 5�   *   $
��Auto �6;   �� 5�   *   $��* �6;    5�   &   �� 5�   *   $
��Auto �68   �� 5�   *   $
��Auto �68   �� 5�   *   $
��Auto �68   .+�5�   &   ��   TextBlock_TotalRevenue#���  60   $��0��6`   $��0��6m    $  MaterialDesignSubtitle1TextBlock#��[ 5�   $   $��5q�6^   �� 5�   &   $��0��5�   $   $��1��61   $��5q�6A      MaterialDesignBody1TextBlock#��[ 5�   $   ��5�   0   �� *TotalRevenueString+5�   $   �� 5�   &     TextBlock_TotalRentals#���  60   $��1��6`   $��0��6m   #��[ 5�   $   $��5q�6^   �� 5�   &   $��1��5�   $   $��1��61   $��5q�6A   #��[ 5�   $   ��5�   0   �� *TotalRentals+5�   $   �� 5�   &     TextBlock_MostPopularShip#���  60   $��2��6c   $��0��6p   #��[ 5�   $   $��5q�6^   �� 5�   &   $��2��5�   $   $��1��61   $��5q�6A   #��[ 5�   $   ��5�   0   �� *MostPopularShip+5�   $   5�   #   5�      5�        5�      $��1��6.   $ 6Q�6;   .��5�      �� $��10q�6)   .+�5�   "   ��   TextBlock_PopularShips#���  6,   #��[ 5�       $��0,0,0,10q�5�         LiveCharts.Wpf.PieChart  5�   "   &   LiveCharts.Wpf.Charts.Base.Chart
   LegendLocation$
 Bottom=�5�   "      InnerRadius$ 70Q�5�   "      	Hoverable$
 True��5�   "   $	��300��5�   "      Series 5�   /   �� *RentDistributionSeries+   DataTooltip 5�   &   #  LiveCharts.Wpf.DefaultTooltip  5�   *      SelectionMode 
OnlySender6=   5�   #   5�      5�      5�      5�      5�      5�      5�      5�      