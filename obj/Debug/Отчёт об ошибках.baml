   M S B A M L   `   `   `  ����d  `Индивидуальный Проект, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulle7clr-namespace:Индивидуальный_Проект)Индивидуальный_Проект  5   	   N    HИндивидуальный_Проект.Отчёт_об_ошибках   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Ilocal7clr-namespace:Индивидуальный_Проект     5   	     N� Title$$  Отчёт об ошибках��5   	   $	��450��6"   $	��800��6/   .��5	      �  � RowDefinitions 5
   
   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ BugReportDataGrid��5         AutoGenerateColumns .     
IsReadOnly . $��0��6   ��6.   �� *
BugReports+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      -   5        Column1��,  &System.Windows.Controls.DataGridColumn   Header$ BugID��5   6      Width5  /System.Windows.Controls.DataGridLengthConverter$
 0.8* 6E   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6R   �� *BugID+	   HeaderStyle	 5      �� 5      
 �� 
TargetType=  7System.Windows.Controls.Primitives.DataGridColumnHeader"
  6    .�5      ��  �� Property � �� �� Value$ Center=�6K   �� 5       � ��$
 Wrap=�6G   5      5        5      -   5        Column2��$ UserID��5   6   $
 0.8* 6F    6S   �� *UserID+	 5      �� 5      "
  6    .�5      ��  � ��$ Center=�6K   �� 5       � ��$
 Wrap=�6G   5      5         5!      -   5        Column3��$ Тема��5!   6   $
 1.5* 6D    6Q   �� *Tema+	 5"      �� 5#      "
  6    .�5$      ��  � ��$ Center=�6K   �� 5%       � ��$
 Wrap=�6G   5&      5(        5)      -   5        Column4��$ Описание��5)   6   $ 3* 6H    6S   �� *
Opisanie+	 5*      �� 5+      "
  6    .�5,      ��  � ��$ Center=�6K   �� 5-       � ��$
 Wrap=�6G   5.      50        51      -   5        Column5��$ Дата и время��51   6   $ 2* 6L    6W   �� *Time+	 52      �� 53      "
  6    .�54      ��  � ��$ Center=�6K   �� 55       � ��$
 Wrap=�6G   56      58      4  .System.Windows.Controls.DataGridCheckBoxColumn  59      -   5        Column6��$ Исправлено��59   :   $ * 6N    6X   �� *	IsFixed+5;      �� 5=   
   $��1��6    �� Orientation$ 
Horizontal=�6"   $��Right=�6;   $��10q�6W   .+�5>      �� -   5        $��Удалить��5>      $��5q�6B   �� 5?      -	   5        $��Пометить��5?      $��5q�6@   5@      5A      5B      