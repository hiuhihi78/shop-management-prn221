   M S B A M L   `   `   `  ????F  BSalesWPFApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:SalesWPFApp.ViewsSalesWPFApp.Views  5      )    #SalesWPFApp.Views.MemeberManagement   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      0viewclr-namespace:SalesWPFApp.Views     5      _ [MaterialDesignThemes.Wpf, Version=4.7.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5        N? Title$  MemeberManagement??5      .??5      ?? .+?5   
   ?? $??Member management??5      $??30(?5      $
??Bold"?5      $
??Left=?6    ?? Left$ 17??6:   $	??Top=?6K   
 ?? Top$ 27??6c   ?? 5   
   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Memeber's name??5   	    ?? AcceptsReturn$
 True??5   	      MaterialDesignFilledTextBox#??[  5   	    ?? TextWrapping$
 Wrap=?5   	   $ 58??6   $ 82??6.   $??Center=?6>   $	??Top=?6[   $	??241??6s   ??5   	   ?? *SearchMember+ ?? Mode$ TwoWay=? ?? UpdateSourceTrigger$ PropertyChanged=?5   s   ?? 5   
   
???P??$ 58??5       $	 145??61   $??Center=?5   +   $	??Top=?6H   ??5      ?? *CreateMember+{?5      ?? *	IsAdmin+$??Create new member??5"      5#      &   System.Windows.Controls.DataGrid  5%   
   -   5        $??gridProducts??5&         CanUserAddRows$ False??5'      	   SelectionMode$	 Extended=?5)      
   SelectionUnit$

 Cell=?5*         AutoGenerateColumns$ False??5+         
IsReadOnly$
 True??5,      $
??True??5-      $	??301??5.      $ 58??6   $	 194??6+   $
??Left=?6<   $??Center=?6W   $	??690??6r   ??5(      ?? *	Members+   Columns 50      0  *System.Windows.Controls.DataGridTextColumn  51      ,  &System.Windows.Controls.DataGridColumn   Header$ Id??6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 50 6N   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   ?? *
MemberId+6N     52      $ Email??6%   $	 180 6N    64   ?? *Email+6N     53      $ Company??6%   $	 150 6V    66   ?? *CompanyName+6V     54      $
 City??6%   $ 90 6L    63   ?? *City+6L     55      $ Country??6%   $	 100 6R    66   ?? *	Country+6R   4  .System.Windows.Controls.DataGridTemplateColumn  56      $  ??6)   $ 80 63      CellTemplate 57      ?? 58      .R?59      ?? 
????  ???5:   !   ?? *DataContext.UpdateMember+ ?? RelativeSource ??  ?? AncestorType DataGrid??5;   !   ?? ??5>   "   '  !MaterialDesignThemes.Wpf.PackIcon  5?   &      Kind$ Update=?6>   5A      5B      5D      5F      ?? 5H   
   $	 862??5J      $	 427??6   $
??Left=?5K      $	??Top=?6(   $	??133??5L      $??68??6   ???#0077d0$??40(?5N      ??5I      ?? *BackToPreviousScreen+??5P        5Q      $??40??5R      $??40??5S      $ KeyboardReturn=?5T      5V      5Z      5[      