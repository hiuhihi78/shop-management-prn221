   M S B A M L   `   `   `  ????F  BSalesWPFApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:SalesWPFApp.ViewsSalesWPFApp.Views  5   	   ?$clr-namespace:SalesWPFApp.ValidationSalesWPFApp.Validation  5   	   0    *SalesWPFApp.Views.PopupCreateUpdateProduct   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:SalesWPFApp.Views     5   	   _ [MaterialDesignThemes.Wpf, Version=4.7.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5
   
   9ValidationRule$clr-namespace:SalesWPFApp.Validation  5   	   -   5        $??	MyWindown??5   	   $	??567??5   	   $	??585??6   
???????  ? WindowStartupLocation$  CenterScreen=?5   
   .??5      ?? $??
0,10,10,-6q?6   .+?5   
   ?? $??Product's Info??6   $
??Bold"?5      $??25(?5       ?? Left$	 214??5      
 ?? Top$ 10??6%   $
??Left=?65   $??Center=?6P   ?? 5   
   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Product Name??5         MaterialDesignFilledTextBox#??[  5      $??Center=?6B   $	??Top=?6_   $	??368??6w   $	 117??6?   $ 88??6?    ?? 	MaxLength$ 40??5      .??5      ??5      ?? 5       ?? Path$ ProductName?5       ?? UpdateSourceTrigger$ PropertyChanged=?5       ?? Mode$ TwoWay=?5       ?? ValidationRules 5      3   -SalesWPFApp.Validation.NotEmptyValidationRule  5       ,  &System.Windows.Controls.ValidationRule	   ValidatesOnTargetUpdated$
	 True??6@   5"      .??5#      5$      ?? 5&   
   $ Weight??5'      #??[  5(      $??Center=?6B   $	??Top=?6_   $	??368??6w   $	 117??6?   $	 167??6?   $ 40??5)      .??5*      ??5+      ?? 5,      $ Weight?5-      $ PropertyChanged=?5.      $ TwoWay=?5/       50        51      $
	 True??6@   53      .??54      55      ?? 57   
   $ 	UnitPrice??58      #??[  59      $??Center=?6B   $	??Top=?6_   $	??368??6w   $	 117??6?   $	 237??6?   $ 40??5:      .??5;      ??5<      ?? 5=      $ 	UnitPrice?5>      $ PropertyChanged=?5?      $ TwoWay=?5@       5A        5B      $
	 True??6@   5D      .??5E      5F      ?? 5H   
   $ UnitsInStock??5I      #??[  5J      $??Center=?6B   $	??Top=?6_   $	??368??6w   $	 117??6?   $	 304??6?   $ 40??5K      .??5L      ??5M      ?? 5N      $ UnitsInStock?5O      $ PropertyChanged=?5P      $ TwoWay=?5Q       5R        5S      $
	 True??6@   5U      .??5V      5W      ?? 5Z   
   $??Submit??5[       # MaterialDesignFlatLightBgButton#??[ 5\      
 ? ToolTip$#
 MaterialDesignFlatLightButton??5]      $	 243??65   $	 463??6G   $??Center=?6X   $	??Top=?6u   $	??116??6?   $??42??6?   {?5^      ?? *EnableButton+??5_      ?? *SubmitCommand+??5`      ??  ?? ElementName$ 	MyWindown??5b      5c      