   M S B A M L   `   `   `  ����D  @BudgetApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:BudgetApp	BudgetApp  5      %    BudgetApp.BudgetOverviewControl   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      )localclr-namespace:BudgetApp     5      .��5	      �   � RowDefinitions  5
   
   �� 5      $
��Auto �6   �� 5      $��40 �6   .+�5   
   �� 
������ $	��600��5      $	��Top=�5      $��Disabled=�5      $
��Auto=�6I   
������ ��5      �� *BTList+ �� SelectedItem 5      �� *CurrentSelection+5      �� 5   
   $��1��6    �� Orientation$ 
Horizontal=�6"   $��Center=�6;   .+�5      �� $��Add Company��6   ��6+   �� *AddCompanyCommand+�� 5      $��Remove Company��6   ��6.   �� *RemoveCompanyCommand+5      5      5      