   M S B A M L   `   `   `  ????F  BSalesWPFApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:SalesWPFApp.ViewsSalesWPFApp.Views  5          SalesWPFApp.Views.Order   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1localclr-namespace:SalesWPFApp.Views     5      _ [MaterialDesignThemes.Wpf, Version=4.7.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5
        N? Title$  Order??5       N? FontSize$ 15(?5      .??5      ?? .+?5   
   ?? $??ORDER??5      $??30(?5      $
??Bold"?5      $
??Left=?6    ?? Left$ 10??6:   $	??Top=?6K   
 ?? Top$ 12??6c   ?? 5   
   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Product's name??5       ?? 	MaxLength$ 40??5         MaterialDesignFilledTextBox#??[  5       ?? TextWrapping$
 Wrap=?5      $ 60??6!   $ 57??62   $
??Left=?6B   $	??Top=?6]   $	??395??6u    J? RenderTransformOrigin$ 0.501,0.559&?6?   .  (MaterialDesignThemes.Wpf.TextFieldAssist!   CharacterCounterVisibility 5      ?? 	 ?? Path$	 	IsChecked?
 ?? ElementName$2
 ,MaterialDesignFilledTextBoxTextCountComboBox??   BooleanToVisibilityConverter ?? 	Converter# [ ??5      ?? *SearchProduct+ ?? Mode$ TwoWay=? ?? UpdateSourceTrigger$ PropertyChanged=??? 5    
   $??Products??5!      $??17(?5"      $??DemiBold"?5#      $
??Left=?6#   $	 275??5$      $	??Top=?6   $	 129??67   ?? 5'   
   $??Order history??5(       # MaterialDesignFlatLightBgButton#??[ 5)       ? ToolTip$# MaterialDesignFlatLightButton??5*      $	 525??65   $	 136??5+      $??Center=?6   $??Center=?6;   ??5,      ?? *OpenOrderHistory+?? 5/   
   $
??Cart??50      $??17(?51      $??DemiBold"?52      $
??Left=?6#   $	 889??53      $	??Top=?6   $	 129??67   &   System.Windows.Controls.DataGrid  55   
   -   5        $??gridProducts??56         CanUserAddRows$ False??57         SelectionMode$ Extended=?59         SelectionUnit$
 Cell=?5:         AutoGenerateColumns$ False??5;         
IsReadOnly$
 True??5<      $
??True??5=      $	??301??5>      $ 10??6   $	 173??6+   $
??Left=?6<   $??Center=?6W   $	??632??6r   ??58      ?? *
Products+   Columns 5@      0  *System.Windows.Controls.DataGridTextColumn  5A      ,  &System.Windows.Controls.DataGridColumn   Header$
 Name??6%      Width5  /System.Windows.Controls.DataGridLengthConverter$	 180 6S   1  +System.Windows.Controls.DataGridBoundColumn   Binding 63   ?? *ProductName+6S     5B      $ Weight??6%   $	 100 6P    65   ?? *Weight+6P     5C      $ 	UnitPrice??6%   $	 100 6V    68   ?? *	UnitPrice+6V     5D      $ UnitsInStock??6%   $	 140 6\    6;   ?? *UnitsInStock+6\   4  .System.Windows.Controls.DataGridTemplateColumn  5F      $ Actions??6)   $ 80 6:      CellTemplate 5G      ?? 5H      .R?5I      ?? ??5J   !   ?? *DataContext.AddToCart+ ?? RelativeSource ??  ?? AncestorType DataGrid??5K   !   ?? ??5M   "   '	  !MaterialDesignThemes.Wpf.PackIcon	  5N   &    	  Kind$ 	PlusThick=?6>   5P      5Q      5S      5U        5V   
   $ False??5W      $ Extended=?5Y      $
 Cell=?5Z      $ False??5[      $
 True??5\      $
??Left=?5]      $	 706??5^      $	??Top=?5_      $
??True??5`      $	??244??5a      $	 185??6   $	??370??6+   ??5X      ?? *ListOrderProduct+$ TwoWay=? 5c        5d      $
 Name??6%   $	 160 6S    63   ?? *ProductName+6S     5e      $ Quantity??6)    5f      ?? 5g      .R?5h      ?? $??80??6F   ??6(   ?? *UnitsInStock+6F   5i      5k        5l      $ Actions??6)    5m      ?? 5n      .R?5o      ?? ??5p   !   ?? *!DataContext.RemoveProductInCart+ ??  DataGrid??5q   !   ?? ??5s   "   	  5t   &   $ 
CloseThick=?6>   5v      5w      5y      5{      ?? 5}   
   $??Total:??6   $??24(?5~      $	 707??5      $	 434??6"   $
??Left=?5?      $	??Top=?6+   ?? 5?   
   $	 829??5?      $	 482??6   $
??Left=?5?      $??Center=?6(   $??92??5?      $??58??6   ???#0077d0$??40(?5?      ??5?      ?? *BackToPreviousScreen+??5?      	  5?      $??40??5?      $??40??5?      $ KeyboardReturn=?5?      5?      ?? 5?   
   $	 965??5?      $	 485??6   $
??Left=?5?      $	??Top=?6(   $??95??5?      $??56??6   ???#49be25$??40(?5?      ??5?      ?? *CheckoutOrder+{?5?      ?? *EnableButtonCheckout+??5?      	  5?      $??40??5?      $??40??5?      $ CartArrowRight=?5?      5?      5?      5?      