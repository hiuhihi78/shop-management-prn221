   M S B A M L   `   `   `  ????F  BSalesWPFApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:SalesWPFApp.ViewsSalesWPFApp.Views  5   	   '    !SalesWPFApp.Views.OrderStatistics   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:SalesWPFApp.Views     5   	   _ [MaterialDesignThemes.Wpf, Version=4.7.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5
   	   $??15(?5   	   $	??474??6   $	??617??6#     ? WindowStartupLocation$  CenterScreen=?5   	   .??5      ?? .+?5   
   ?? $??Statistics report??6   $
??Bold"?5      $??30(?5       ?? Left$	 125??6    
 ?? Top$ 10??62   &   System.Windows.Controls.DataGrid  5   
   -   5        $??gridProducts??5         CanUserAddRows$ False??5         SelectionMode$ Extended=?5         SelectionUnit$
 Cell=?5         AutoGenerateColumns$ False??5         
IsReadOnly$
 True??5      $
??True??5      $	??301??5      $ 34??6   $ 92??6/   $
??Left=?6?   $	??Top=?6Z   $	??406??6r   ??5      ?? *ListProductStatistics+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5       ,  &System.Windows.Controls.DataGridColumn	   Header$
	 Name??6%   
   Width5  /System.Windows.Controls.DataGridLengthConverter$	
 180 6S   1  +System.Windows.Controls.DataGridBoundColumn   Binding 63   ?? *ProductName+6S     5!      $	 UnitsInStock??6%   $	
 140 6\    6;   ?? *UnitsInStock+6\   5#      ?? 5&   
   $??Tota:l??6   $	 183??5'      $	 424??6"   $
??Left=?5(      $	??Top=?5)      $??20(?5*      ?? 5-   
   $	??198??5/      $	 242??6   $	 433??6+   $
??Left=?6<   $??26??6W   $??Center=?6c   ??5.      ?? *TotalPriceStatic+5/   c   ?? 52   
   $	 341??54      $	 502??6   $
??Left=?55      $	??Top=?6(   $??92??56      $??58??6   ???#0077d0$??40(?58      ??53      ?? *BackButonStatiscScreen+??5:      '  !MaterialDesignThemes.Wpf.PackIcon  5;      $??40??5<      $??40??5=         Kind$ KeyboardReturn=?5>      5@      5B      5C      