   M S B A M L   `   `   `  ????P  LPayCalculatorTemplate, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:PayCalculatorTemplatePayCalculatorTemplate  5   	   &     PayCalculatorTemplate.MainWindow   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:PayCalculatorTemplate     5   	     ? Title$  
MainWindow??5   	   $	??550??6   $
??1000??6)   .??5	      ?  ? ColumnDefinitions 5
   
   ?? 5      $	??17* ?6   ?? 5      $	??33* ?6    ? RowDefinitions 5   
   ?? 5      $
??113* ?6   ?? 5      $
??154* ?6   .+?5   
   ?? ???#e5f2ff$??2??6&   $??2??67   ?? 5   
   $	??457??6   $??350,39,10,0q?6!   ???#e5f2ff???#e5f2ff$	??Top=?6V   $??2??6n   $??1??6   ?? 5   
   $
??Left=?6   $??
10,39,0,38q?6/   ???#e5f2ff???#e5f2ff$	??658??6c   $??2??6o   $??2??6?   ?? 5   
   $??Employee Details??6   $
??Left=?6+   $??
258,10,0,0q?6F   $	??Top=?6Z   $??16(?6r   $??2??6?   ?? 5   
   $??Payment Summary??6   $
??Left=?6*   $??
429,10,0,0q?6E   $	??Top=?6Y   $??16(?6q   $??1??6   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ empDataGrid??5      $??0,54,345,133q?6)      AutoGenerateColumns$ False??6?   $??2??5   W   $??Right=?6h   $	??623??6?   $??2??6?   ??6   ??    Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ id??6D      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6P   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   ?? *
employeeID+6P     5      $ * 6C   $ fName??6M    6%   ?? *	firstName+6M     5      $ * 6B   $ lName??6L    6%   ?? *
lastName+6L     5      $ * 6F   $	 Job??6P    6%   ?? *typeEmployee+6P     5       $ 
HourlyRate??6D   $ * 6X    6%   ?? *
hourlyRate+6X     5!      $ 
Threshhold??6F   $ * 6Z    6%   ?? *taxthreshold+6Z   5$      ?? 5%   
   $??Hours Worked (hr)??6   $
??Left=?6,   $??285,213,0,0q?6G   $	??Top=?6\   $??1??6t   $??2??6?   ?? 5&   
   -   5        	 ??Name$	 inputHr??5&      $
??Left=?6$   $??
70,217,0,0q?6?   
 ?? TextWrapping$

 Wrap=?6S   $??0??6g   $	??Top=?6p   $??60??6?   $??1??6?   $??1??6?   ?? 5'   
   -   5        $??	Calculate??5'      $
??Left=?6%   $??176,211,0,0q?6@   $	??Top=?6U   $??28??6m   $	??103??6y   $??1??6?   $??1??6?   ?? 5(   
   -   5         ??Name$ PaymentSummaryDisplay??5(      $??
392,54,0,0q?63   $
??Wrap=?6G   ???#f2f2f4$	??347??6p   $	??Top=?6}   $??2??6?   $??1??6?   $
??Left=?6?   $	??216??6?   ?? 5)   
   -   5        $??Save Payslip??5)      $
??Left=?6(   $??448,207,0,0q?6C   $	??Top=?6X   $??28??6p   $	??104??6|   $??1??6?   $??1??6?   5,      5-      