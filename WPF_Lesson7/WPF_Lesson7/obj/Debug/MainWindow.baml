   M S B A M L   `   `   `  ����F  BWPF_Lesson7, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:WPF_Lesson7WPF_Lesson7  5   	       WPF_Lesson7.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:WPF_Lesson7     5   	   -   5          � Title$  
MainWindow��5   	   $	��600��63   $	��800��6@   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   �� -   5        $��	btnAddEmp��5      $	��ADD��6"   $
��Left=�60   $��	25,55,0,0q�6K   $	��Top=�6^   $��74��6v   $��1��6�   6�   �� 5   
   -   5         ��Name$ btnRevomeEmp��5      $��Remove��6'   $
��Left=�68   $��	25,80,0,0q�6S   $	��Top=�6f   $��74��6~   $��1��6�   6�   �� 5   
   -   5        $ btnChengeEmp��5      $��Chenge��6'   $
��Left=�68   $��
25,105,0,0q�6S   $	��Top=�6g   $��74��6   $��1��6�   6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ EmployeeDataGrid��5      $��115.5,25,40,48q�5         
IsReadOnly . $��1��6U   ��6+   ��    Columns 5      5      5      5      