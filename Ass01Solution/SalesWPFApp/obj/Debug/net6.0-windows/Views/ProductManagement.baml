   M S B A M L   `   `   `  ????F  BSalesWPFApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:SalesWPFApp.ViewsSalesWPFApp.Views  5      )    #SalesWPFApp.Views.ProductManagement   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1localclr-namespace:SalesWPFApp.Views     5      _ [MaterialDesignThemes.Wpf, Version=4.7.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5        N? Title$  ProductManagement??5      .??5      ?? .+?5   
   ?? $??Product management??5      $??30(?5      $
??Bold"?5      $
??Left=?6    ?? Left$ 17??6:   $	??Top=?6K   
 ?? Top$ 27??6c   ?? 5   
   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Product's id??5   	    ?? AcceptsReturn$
 True??5   	      MaterialDesignFilledTextBox#??[  5   	    ?? TextWrapping$
 Wrap=?5   	   $ 70??6   $ 72??6.   $
??Left=?6>   $??Center=?6Y   $	??100??6t   ??5   	   ?? *	ProductId+ ?? Mode$ TwoWay=? ?? UpdateSourceTrigger$ PropertyChanged=?5   t   ?? 5   
   $ Product's name??5   	   $
 True??5   	   #??[  5    	   $
 Wrap=?5!   	   $	 192??6   $ 72??6/   $
??Left=?6?   $??Center=?6Z   $	??242??6u   ??5   	   ?? *SearchProduct+$ TwoWay=?$ PropertyChanged=?5!   u   ?? 5#   
   $ Product's UnitPrice??5$   	   $
 True??5%   	   #??[  5'   	   $
 Wrap=?5(   	   $	 450??6   $ 72??6/   $
??Left=?5)      $??Center=?6(   $	??142??6C   ??5&   	   ?? *ProductPrice+$ TwoWay=?$ PropertyChanged=?5)   C   ?? 5,   
   $ Product's UnitInStock??5-   	   $
 True??5.   	   #??[  50   	   $
 Wrap=?51   	   $	 616??6   $ 72??6/   $
??Left=?52      $??Center=?6(   $	??142??6C   ??5/   	   ?? *ProductQuantity+$ TwoWay=?$ PropertyChanged=?52   C   ?? 55   
   
???????$	 785??57      $ 66??61   $??Center=?58      $	??Top=?6*   $??51??6B   $??70??6N   ??56      ?? *SearchCommand+??5:      '  !MaterialDesignThemes.Wpf.PackIcon  5;         Kind$ Magnify=?6*   $??30??69   $??30??6D   5=      ?? 5@   
   
???P??$ 58??5B       $	 145??61   $??Center=?5C   +   $	??Top=?6H   ??5A      ?? *CreateProduct+{?5C      ?? *	IsAdmin+$??Create new product??5G      5H      &   System.Windows.Controls.DataGrid  5J   
   	   CanUserAddRows$	 False??5K      
   SelectionMode$
 Extended=?5M         SelectionUnit$
 Cell=?5N         AutoGenerateColumns$ False??5O         
IsReadOnly$
 True??5P      $
??True??5Q      $	??301??5R      $ 58??6   $	 194??6+   $
??Left=?6<   $??Center=?6W   $	??751??6r   ??5L      ?? *
Products+   Columns 5T      0  *System.Windows.Controls.DataGridTextColumn  5U      ,  &System.Windows.Controls.DataGridColumn   Header$ Id??6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 50 6O   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   ?? *	ProductId+6O     5V      $
 Name??6%   $	 180 6S    63   ?? *ProductName+6S     5W      $ Weight??6%   $	 150 6P    65   ?? *Weight+6P     5X      $ 	UnitPrice??6%   $ 90 6V    68   ?? *	UnitPrice+6V     5Y      $ UnitsInStock??6%   $	 140 6\    6;   ?? *UnitsInStock+6\   4  .System.Windows.Controls.DataGridTemplateColumn  5Z      $  ??6)   $ 80 63      CellTemplate 5[      ?? 5\      .R?5]      ?? 
????  ???5^   !   ?? *DataContext.UpdateProduct+ ?? RelativeSource ??  ?? AncestorType DataGrid??5_   !   ?? {?5a   !   ?? *	IsAdmin+??5c   "     5d   &   $ Update=?6>   5f      5g      5i      5k      ?? 5m   
   $	 862??5o      $	 427??6   $
??Left=?5p      $	??Top=?6(   $	??133??5q      $??68??6   ???#0077d0$??40(?5s      ??5n      ?? *BackToPreviousScreen+??5u        5v      $??40??5w      $??40??5x      $ KeyboardReturn=?5y      5{      5}      5~      