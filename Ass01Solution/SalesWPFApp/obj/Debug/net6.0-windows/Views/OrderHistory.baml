   M S B A M L   `   `   `  ????F  BSalesWPFApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:SalesWPFApp.CommonSalesWPFApp.Common  5   	   $    SalesWPFApp.Views.OrderHistory   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:SalesWPFApp.Common     5   	   2converclr-namspace:SalesWPFApp.Common     5
   	   _ [MaterialDesignThemes.Wpf, Version=4.7.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     N? Title$  OrderHistory??5   	   $	??450??6   $	??800??6+    N? FontSize$ 15(?5   	    ? 	Resources 5      *   $SalesWPFApp.Common.DateTimeConverter   DateTimeConverter??%   &	          5   
   6"   5      .??5      ?? .+?5   
   ?? $??ORDER??5      $??30(?5      $
??Bold"?5      $??Center=?6    ?? Left$ 35??6<   $	??Top=?6M   
 ?? Top$ 10??6e   ?? 5   
   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Member's email??5       ?? 	MaxLength$ 40??5        MaterialDesignFilledTextBox#??[ 5       ?? TextWrapping$
 Wrap=?5       $ 35??6!   $ 67??62   $
??Left=?6B   $	??Top=?6]   $	??395??6u    J? RenderTransformOrigin$ 0.501,0.559&?6?   .  (MaterialDesignThemes.Wpf.TextFieldAssist!	   CharacterCounterVisibility	 5      ?? 
 ?? Path$
 	IsChecked? ?? ElementName$2 ,MaterialDesignFilledTextBoxTextCountComboBox??   BooleanToVisibilityConverter ?? 	Converter# [ ??5!      ?? *SearchEmail+ ?? Mode$ TwoWay=? ?? UpdateSourceTrigger$ PropertyChanged=?(  "System.Windows.Controls.DatePicker  5$   
   $	??140??5%      /  )MaterialDesignThemes.Wpf.DatePickerAssist&   OutlinedBorderInactiveThickness$ 2q?5&         FloatingOffset$ 0,-22&?5'      $ 
Start date??5(       $  MaterialDesignOutlinedDatePicker#??[ 5)      $ 35??5*      $	 129??6   $
??Left=?5,   0      SelectedDate 5+      ?? *	StartDate+   DisplayDateEnd 5,      ?? *	EndDate+60     5/   
   $	??140??50      $ 2q?51      $ 0,-22&?52      $ End date??53      #??[ 54      $	 200??55      $	 129??6   $
??Left=?60    56      ?? *	EndDate+ 57      ?? *CurrentDate+?? 5:   
   $??Search??5;       " MaterialDesignFlatDarkBgButton#??[ 5=       ? ToolTip$" MaterialDesignOutlinedButton??5>      $	 364??64   $	 129??6F   $
??Left=?6W   $??56??6r   $??Center=?6~   $	??102??6?   {?5<      ?? *DataContext.ControlsEnabled+ ?? RelativeSource ?? *FindAncestor+ ?? AncestorType
 Window??5?      ?? *SearchHistoryOrder+?? 5C   
   3  -MaterialDesignThemes.Wpf.ButtonProgressAssist   IsIndeterminate$
 True??5E         IsIndicatorVisible$
 True??5F         Value$ -1Q?5G      $??	Statistis??5H        MaterialDesignRaisedButton#??[ 5J      $	 675??6A   $	 186??6S   $??Center=?6d   $??Center=?6?   ??5D      ?? *OpenStatistics+{?5I      ?? *DataContext.ControlsEnabled+ ?? *FindAncestor+
 Window5J   ?   &   System.Windows.Controls.DataGrid  5M   
   -   5        $??gridProducts??5N         CanUserAddRows$ False??5O         SelectionMode$ Extended=?5Q         SelectionUnit$
 Cell=?5R         AutoGenerateColumns$ False??5S         
IsReadOnly$
 True??5T      $
??True??5U      $	??243??5V      $ 35??6   $	 223??6+   $
??Left=?6<   $	??Top=?6W   $	??721??6o   ??5P      ?? *ListOrderHistory+   Columns 5X      0  *System.Windows.Controls.DataGridTextColumn  5Y      ,	  &System.Windows.Controls.DataGridColumn 	  Header$ Email Member??6%     	  Width5
  /System.Windows.Controls.DataGridLengthConverter$	  180
 6\   1  +System.Windows.Controls.DataGridBoundColumn!   Binding! 6;   ?? *Member.Email+6\     5Z      $ 
Order Date??6%   $	  140
 6W   ! 69   ?? *	OrderDate+6W     5[      $ Shipped??6%   $	  140
 6V   ! 66   ?? *ShippedDate+6V     5\      $ Freight??6%   $	  140
 6R   ! 66   ?? *	Freight+6R   4  .System.Windows.Controls.DataGridTemplateColumn  5^      $ Actions??6)   $  80
 6:   "   CellTemplate" 5_      ?? 5`      .R?5a      ?? ???	#FF63BEE6??5b   !   ?? *DataContext.ViewOrderDetail+ ??  DataGrid??5c   !   ?? ??5f   "   '  !MaterialDesignThemes.Wpf.PackIcon  5g   &   #   Kind$	# Eye=?6>   5i      5j      5l      5n      ?? 5p   
   $	 800??5r      $	 408??6   $
??Left=?5s      $	??Top=?6(   $??92??5t      $??58??6   ???#0077d0$??40(?5v      ??5q      ?? *BackToPreviousScreen+??5x        5y      $??40??5z      $??40??5{      $# KeyboardReturn=?5|      5~      5?      5?      