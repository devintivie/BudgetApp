   M S B A M L   `   `   `  ����D  @BudgetApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:BudgetApp	BudgetApp  5      I EIvieConverters, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG4clr-namespace:IvieConverters;assembly=IvieConvertersIvieConverters 5      ;"clr-namespace:BudgetApp.ViewModelsBudgetApp.ViewModels  5      M IIvieCustomControls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS<clr-namespace:IvieCustomControls;assembly=IvieCustomControlsIvieCustomControls 5	      O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5
      %    BudgetApp.BudgetCalendarControl   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      )localclr-namespace:BudgetApp     5      Dcvt4clr-namespace:IvieConverters;assembly=IvieConverters     5      2vms"clr-namespace:BudgetApp.ViewModels     5      Pcustoms<clr-namespace:IvieCustomControls;assembly=IvieCustomControls     5	      6sys&clr-namespace:System;assembly=mscorlib     5
      $	��844��5      .��5      � $��Stretch=�6   
�������  � RowDefinitions  5!   
   �� 5"      $��40 �6   �� 5#      $
��Auto �6   �� 5$      $��* �6   �� 5%      $
��Auto �6   �� 5&      $��40 �6   �� 5'      $	��120 �6    � ColumnDefinitions 5)   
   �� 5*      $
��Auto �6   �� 5+      $��80 �6   �� 5,      $��* �6   �� 5-      $
��Auto �6   .+�50   
   ��  �� Orientation$ 
Horizontal=�6   
�������$��0��51      $��0��6   $��3��6.   .+�52      ��    FontAwesome#��[  6     FontAwesomeArrowLeftIcon#��[ 6?   ��53      �� *PrevTimeCommand+�� 54      #��[  6     FontAwesomeArrowRightIcon#��[ 6?   ��55      �� *NextTimeCommand+�� 56      $��14(�6W   $��Arial)�6e   $��Center=�6x   ��6   �� *	MonthYear+ �� 	Converter '  !IvieConverters.MonthYearConverter  6x   �� 5;      $��Center=�6   $��	10 0 10 0q�64   .+�5<      	�  d� 	IsChecked 6   ��  �� Path$ SelectedOption� (  "IvieConverters.EnumToBoolConverter   �� ConverterParameter$ TwoWeek��.��6�   Bi-Weekly View6�   	� 5=       6   �� $ SelectedOption�   $ FiveWeek��.��6�   
Month View6�   5>      �� 5@      $��Center=�5B      ��5@      ��  �� Source *   $BudgetApp.EnumBindingSourceExtension  *M� *local:PayDateFrequencies++ �� SelectedItem 5A      �� *PayDateFrequency+5B      �� 5C      $��Center=�5D      $��22��60   
����  �$��1q�6O   ��5C      �� *CurrPaydate+ &   IvieConverters.DateOnlyConverter  5D   O   5E      � 5F   
   $��1��6   
�������$��Stretch=�63   $��0��5G      $��3��6     5H      �� 5I      $��* �6    �� 5J      $��* �6    �� 5K      $
��Auto �6    �� 5L      $
��Auto �6     5P      �� 5Q      $��* �6#   �� 5R      $��* �6#   �� 5S      $��* �6#   �� 5T      $��* �6#   �� 5U      $��* �6#   �� 5V      $��* �6#   �� 5W      $��* �6#   .+�5Z      �� $��0��6   $��Sunday��6(     CalendarDays#��[ 66   �� 5[      $��1��6   $��Monday��6(   #��[ 66   �� 5\      $��2��6   $��Tuesday��6(   #��[ 67   �� 5]      $��3��6   $��	Wednesday��6(   #��[ 69   �� 5^      $��4��6   $��Thursday��6(   #��[ 68   �� 5_      $��5��6   $��Friday��6(   #��[ 66   �� 5`      $��6��6   $��Saturday��6(   #��[ 68   �� 5c      $��2��6   $��7��6#   $��0q�5d   5   $��Disabled=�5e      $��Disabled=�5f      2   ,BudgetApp.SelectorDoubleClickCommandBehavior	   HandleDoubleClick	 . ��5d      �� *	DayList+ 5g      �� *SelectedDBVM+
   DoubleClickCommand
 5i      �� *DoubleClickCommand+��5n      �� 5o       �� 
TargetType" ��6   .�5p      ��  �� Property � �� �� Value$ 0q�64   �� 5q       � ��$ 0q�6<   �� 5r       �@��
IsSelected 67   �� *
Selected+�� 5s       � �� 5t      �� 5u   "    �� 
TargetType" ��62   .R�5v   &   ��  ��Name$ Bd��6-   #��z��69     ForegroundVeryDarkBrush#��[ 6c   ._�5w   *   �� #��z��6;   #��z��6~    J� SnapsToDevicePixels# z 6�   5x   '    �� Triggers 5y   &   P� 5z   *    P� Property �@��
IsSelected P� Value . . �5{   .   ��   BackgroundVeryLightBrush# [ 6K    � ��5|   +   5   #   5�      5�      ��5�      �� 5�      .R�5�      �  � Orientation$ 
Horizontal=�6$   5�      5�      5�      �� 5�   
   $��3��6   $��7��6   $	��120��5�      ��5�   3   �� *
Accounts+��5�      �� 5�      .R�5�      �� $ 
Horizontal=�6!   5�      5�      �� 5�   
   $��	Total Due��6   $��4��6%   $��5q�62   $��Center=�6=   �� 5�   
   $��Center=�6^   $��4��5�      $��1��6   ��5�      �� *
TotalDue+ &   IvieConverters.CurrencyConverter   �� Mode$ OneWay=�5�      �� 5�   
   $��Center=�6f   $��4��5�      $��2��6   ��5�      �� *RemainingBalance+   $ OneWay=�5�      5�      5�      