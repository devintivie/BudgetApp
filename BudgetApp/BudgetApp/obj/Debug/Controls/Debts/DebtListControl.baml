   M S B A M L   `   `   `  ����I  EIvieConverters, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG4clr-namespace:IvieConverters;assembly=IvieConvertersIvieConverters  5      M IIvieCustomControls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS<clr-namespace:IvieCustomControls;assembly=IvieCustomControlsIvieCustomControls 5      D @BudgetApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:BudgetApp.ViewModelsBudgetApp.ViewModels 5      %clr-namespace:BudgetApp	BudgetApp 5	         BudgetApp.DebtListControl   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Dcvt4clr-namespace:IvieConverters;assembly=IvieConverters     5      Pcustoms<clr-namespace:IvieCustomControls;assembly=IvieCustomControls     5      2vms"clr-namespace:BudgetApp.ViewModels     5      )localclr-namespace:BudgetApp     5	      .��5      �    BackgroundMainBrush#��[  5        � RowDefinitions  5   
   �� 5      $��* �6   �� 5      $��50 �6    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   �� -   5         ��Name$ 
BudgetList��5      
������ $y�Visible=�5      $	��Top=�5      $��Disabled=�5      $
��Auto=�5      
������ ��5   '   �� *BTList+ �� SelectedItem 5      �� *CurrentSelection+5      �� 5    
   $,��&Add a company to start tracking debts.��6   $	��300��5"      $��0��5#      $��0��5$      $
��Wrap=�5%      $��	0 10 20 0q�5&      $��20(�5'      $	��Top=�5(      $��Center=�5)      y�5!      �� *IsEmptyBudget+ �� 	Converter 1   +IvieConverters.BooleanToVisibilityConverter  5)      �� 5,   
   $��0��5-      $��1��6&   $	��Top=�5.      ��5,      �� *	CurrentBT+y�5/      �� *ShowCurrentBT+   �� 51   
    �� Orientation$ 
Horizontal=�6   $��1��6.   $��2��6;   .+�52      �� -   5         ��Name$ 	addButton��52      $��Add Company��6(   |�.  ��6>   �� *OpenPopupCommand+��53      ��  �� ElementName$ 	AppWindow��54      �� 55      $��Remove Company��6   ��6.   �� *RemoveCompanyCommand+�� 56      $��Edit Company Name��6   ��61   �� *OpenEditPopupCommand+57      � 59   
    � 	StaysOpen .  |�.  	 � HorizontalOffset$	 0��5;      
 � VerticalOffset$	
 -49��6)   ��59      �� *IsPopupOpen+.��5=      ]� $��48��5>      
���������5=      �� $ 
BudgetList�� �� Path$ ActualWidth�.+�5@      �� -   5         ��Name$ newCompanyText��5A       $��Company Name  ��5@      $��Center=�5B       $
��Left=�5C         FontSizeAverage#��[ 5D       �� 5E        FontAwesomeAddIcon#��[ 6     
IconButton#��[ 5F      $��5q�5G        FontAwesome#��[ 5J      $��Right=�5L      ��5H      �� $ newCompanyText��$ ActualHeight���5I      �� $ newCompanyText��$ ActualHeight���5K      �� *AddCompanyCommand+5L      �� 5N      -   5         ��Name$ newCompanyTextbox��5N      |�. {�. #��[ 5Q      $��Center=�5R      ��5N   5   �� *
NewCompany+5R      5T      5U      � 5V   
    .  |�.  $	 0��5X      $	
 -49��6)   ��5V      �� *IsEditPopupOpen+.��5Z      ]� $��48��5[      
���������5Z      �� $ 
BudgetList��$ ActualWidth�.+�5]      �� -   5        $ editCompanyText��5^       $��Edit Name  ��5]      $��Center=�5_       $
��Left=�5`       #��[ 5a       �� 5b      #��[ 6   #��[ 5c      $��5q�5d      #��[ 5g      $��Right=�5i      ��5e      �� $ editCompanyText��$ ActualHeight���5f      �� $ editCompanyText��$ ActualHeight���5h      �� *EditCompanyCommand+5i      �� 5k      -   5        $ editCompanyTextbox��5k      |�. {�. #��[ 5n      $��Center=�5o      ��5k   6   �� *
NewCompany+5o      5q      5r      5v      5w      