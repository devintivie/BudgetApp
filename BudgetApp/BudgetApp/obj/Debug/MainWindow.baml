   M S B A M L   `   `   `  ����D  @BudgetApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:BudgetApp	BudgetApp  5   	   ;"clr-namespace:BudgetApp.ViewModelsBudgetApp.ViewModels  5   	   3clr-namespace:BudgetApp.ModelsBudgetApp.Models  5   	   I EIvieConverters, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG4clr-namespace:IvieConverters;assembly=IvieConvertersIvieConverters 5	   	       BudgetApp.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:BudgetApp     5   	   2vms"clr-namespace:BudgetApp.ViewModels     5   	   1modelsclr-namespace:BudgetApp.Models     5   	   Dcvt4clr-namespace:IvieConverters;assembly=IvieConverters     5	   	   -   5          �Name$  	AppWindow��5   	    � Title$ 
MainWindow��5   	   $
��1000��6   $
��1500��6*    � DataContext 5      .   (BudgetApp.ViewModels.MainWindowViewModel  5   
    J� InputBindings 5      �� 5   
    �� Gesture$ CTRL+S��65    �� Command 6   �� *SaveCommand+65   �� 5   
   $ CTRL+O��65    6   �� *OpenCommand+65   �� 5   
   $ Ctrl+N��64    6   �� *
NewCommand+64   �� 5   
   $ Enter��63    6   �� *	LoseFocus+63   .��5      ]�    ForegroundLightBrush#��[  6N   .+�5   
   o� $��Stretch=�6   $	��Top=�6-   .@�5      m� $
��File��6   .@�5      m� $��New Budget...��6    m� InputGestureText$ Ctrl+N��6Q    m� Command 62   �� *
NewCommand+6Q   m� 5      $��Save Budget��6   $ Ctrl+S��6P    60   �� *SaveCommand+6P   m� 5      $��Save Budget As...��6    66   �� *SaveAsCommand+m� 5      $��Open Budget...��6   $ Ctrl+O��6S    63   �� *OpenCommand+6S   m� 5      $
��Exit��6   5      m� 5       $��Bills��6   .@�5!      m� $��Add Company��6   m� 5"      $��Add Bill��6   5#      5$      �� 5%   
   $
��Left=�6   $	��200��6'   ._�52      �� $��0q�54        BackgroundLightBrush#��[ 55        NavigationListView#��[ 56        NavigationItems#��[ 57      ��52      ��  �� Source *   $BudgetApp.EnumBindingSourceExtension  *M� *local:Navigation++	 �� SelectedItem	 53      �� *PageDisplay+59      5;      �� 5<   
   $
��Left=�6;   ��6   �� *PageViewModel+6;   5�      5�      