   M S B A M L   `   `   `  ????F  BSalesWPFApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:SalesWPFApp.ViewsSalesWPFApp.Views  5   	   #    SalesWPFApp.Views.OrderDetail   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:SalesWPFApp.Views     5   	   _ [MaterialDesignThemes.Wpf, Version=4.7.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     ? Title$  OrderDetail??5   	   $	??567??6   $	??800??6*    ? WindowStartupLocation$ CenterScreen=?5	   	   .??5      #  MaterialDesignThemes.Wpf.Card  $	??600??5   	   .??5   
   ?? .+?5      ?? $??Order Detail??6   $
??Bold"?6*   $??25(?6<    ?? Left$ 37??6J   
 ?? Top$ 10??6[   $
??Left=?6k   $??Center=?6?   ?? 5      ${?False??5      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Email??5       ?? AcceptsReturn$
 True??5         MaterialDesignFilledTextBox#??[  5       ?? TextWrapping$
 Wrap=?5      $ 37??6%   $ 71??66   $
??Left=?6F   $	??Top=?6a   $	??270??6y   ??5      ?? *SelectedOrder.Member.Email+5   y   ?? 5      $ 
Order Date??5      $
 True??5      ${?False??5      #??[  5      $
 Wrap=?5      $ 37??6%   $	 121??66   $
??Left=?6G   $	??Top=?6b   $	??270??6z   ??5      ?? *SelectedOrder.OrderDate+5   z   ?? 5!      $ Shipped Date??5"      $
 True??5$      ${?False??5%      #??[  5&      $
 Wrap=?5'      $ 37??6%   $	 171??66   $
??Left=?6G   $	??Top=?6b   $	??270??6z   ??5#      ?? *SelectedOrder.ShippedDate+5'   z   &   System.Windows.Controls.DataGrid  5)      -   5        $??gridProducts??5*         CanUserAddRows$ False??5+         SelectionMode$ Extended=?5-      	   SelectionUnit$
	 Cell=?5.      
   AutoGenerateColumns$
 False??5/         
IsReadOnly$
 True??50      $
??True??51      $	??147??52      $ 20??6   $	 251??6+   $
??Left=?6<   $	??Top=?6W   $	??560??6o   ??5,      ?? *ListProductOrderHistory+   Columns 54      0  *System.Windows.Controls.DataGridTextColumn  55      ,  &System.Windows.Controls.DataGridColumn   Header$
 Name??6)      Width5  /System.Windows.Controls.DataGridLengthConverter$	 180 6W   1  +System.Windows.Controls.DataGridBoundColumn   Binding 67   ?? *ProductName+6W     56      $ Weight??6)   $	 100 6T    69   ?? *Weight+6T     57      $ 	UnitPrice??6)   $	 100 6Z    6<   ?? *	UnitPrice+6Z     58      $ UnitsInStock??6)   $	 140 6`    6?   ?? *UnitsInStock+6`   5;      ?? 5=      $??Total??6   $??20(?6$   $	 350??62   $	 411??6D   ?? 5?      $	??180??6@   $??20(?5@      $	 400??5A      $	 415??6*   $??Center=?6;   $??34??6X   $	??Top=?6d   ??5?      ?? *TotalPriceOrderHistory+5A   d   ?? 5D      $	 488??5F      $	 466??6   $
??Left=?5G      $	??Top=?6(   $??92??5H      $??58??6   ???#0077d0$??40(?5J      ??5E      ?? *BackToHsitoryOrderScreen+??5L      '  !MaterialDesignThemes.Wpf.PackIcon  5M      $??40??5N      $??40??5O         Kind$ KeyboardReturn=?5P      5R      5S      5T      5V      