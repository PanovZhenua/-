   M S B A M L   `   `   `  ����d  `Индивидуальный Проект, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulle7clr-namespace:Индивидуальный_Проект)Индивидуальный_Проект  5   	   ?    9Индивидуальный_Проект.БД_Админ   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Ilocal7clr-namespace:Индивидуальный_Проект     5   	     N� Title$:  4Управление таблицей товаров��5   	   $	��450��6-   $
��1000��6:   .��5
      �  � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��4* �6    � RowDefinitions 5   
   �� 5      $
��0.5* �6   �� 5      $��* �6   �� 5      $
��0.5* �6   �� 5      $
��0.5* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   �� $%��Название товара: ��6   $��0��6,   $��0��6<   $��Center=�6I   $��Center=�6m   $��16(�6�   �� 5   
   $��Описание: ��6   $��0��6%   $��1��65   $��Center=�6B   $��Center=�6f   $��16(�6�   �� 5   
   $��Стоимость: ��6   $��0��6&   $��2��66   $��Center=�6C   $��Center=�6g   $��16(�6�   �� 5   
   $%��Права просмотра: ��6   $��0��6,   $��3��6<   $��Center=�6I   $��Center=�6m   $��16(�6�   �� 5   
   $��Изображение: ��6   $��0��6(   $��4��68   $��Center=�6E   $��Center=�6i   $��16(�6�   $��Bottom=�6�   �� 5   
   -   5         ��Name$ 
Podskazka1��5      $)��#(выберите строку БД��6$   $��1��6B   $��2��6R   $��4��6f   $��Center=�6s   $��Bottom=�6�   $��14(�6�   $	��200��6�   �� 5    
   -   5        $ 
Podskazka2��5       $)��#или создайте новую)��6$   $��1��6B   $��2��6R   $��5��6f   $��Center=�6s   $	��Top=�6�   $��14(�6�   $	��200��6�   �� 5!   
   -   5        $ 
Podskazka3��5!      $��Нет картинки��6$   $��1��6;   $��2��6K   $��5��6_   $��Center=�6l   $	��Top=�6�   $��14(�6�   $	��200��6�   $y�	Collapsed=�6�   �� 5"   
   -   5         ��Name$ IzmenittIzobrazhenie��5"      $��5��6   $��Изменить��6<   $	��Top=�6r   $��40, 0, 40, 0q�6�   $��0��6�   �� 5#   
   -   5         ��Name$ 
imgDisplay��5#      $��Uniform=�6$   $��1��66   $��2��6F   $��4��6Z   $��2��6g   $��40 10 40 10q�6x   �� 5$   
   -   5         ��Name$ FirstBox��5$      $��0��6$   $��1��61   $��2��6A   $��10q�6U   
�������$��16(�6x    �� TextAlignment$
 Left=�6�   �� 5%   
   -   5        $ 	SecondBox��5%      $��1��6%   $��1��62   $��2��6B   $��10q�6V   
�������$��16(�6y   $
 Left=�6�    �� TextWrapping$
 Wrap=�6�   �� 5&   
   -   5        $ ThirdBox��5&      $��2��6$   $��1��61   $��2��6A   $��10q�6U   
�������$��16(�6x   $
 Left=�6�   �� 5'   
   -	   5        $ OdobrenieKnopka��5'      $��3��6   $��Одобрить��67   $��	30 7 30 7q�6b   $��1��6u   
��� � �6�   �� 5(   
   -
   5        $ DorabotkaKnopka��5(      $��3��6   $��Доработать��67   $��	30 7 30 7q�6d   $��2��6w   
���  ��6�   �� 5)   
   -   5        $ 
saveButton��5)      $��6��6   $��Сохранить��62   $��20q�6_   $��0��6k   �� 5*   
   -   5        $ deleteButton��5*      $��6��6   $��Удалить��64   $��20q�6a   $��1��6m   �� 5+   
   -   5        $ cancelButton��5+      $��6��6   $��Отмена��64   $��20q�6`   $��2��6l   &   System.Windows.Controls.DataGrid  5-   
   -   5        	  Name$		 dgv��5-   �   $��7��6   $��0��6j   $��3��6w   $��4��6�   $��10q�6�   
   AutoGenerateColumns
 .     
IsReadOnly . ��6$   �� *Users+   Columns 5.      0  *System.Windows.Controls.DataGridTextColumn  5/      -   5        Column1��,  &System.Windows.Controls.DataGridColumn   Header$ Tovar ID��5/   6      Width5  /System.Windows.Controls.DataGridLengthConverter$
 0.5* 6H   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6U   �� *	TovarID+   ElementStyle 50      �� 51       �� 
TargetType" ��6    .�52      ��  �� Property � �� �� Value$ Center=�6D    �� Triggers 53      �� 54   "    �� Binding 6.   �� *
ShowType+ �� Value 06K   .a�55   &   ��  � ��
 �����6C   56   #   �� 57   "    6.   �� *
ShowType+ 26K   .a�58   &   ��  � ��
 �  ��6C   59   #   �� 5:   "    6.   �� *
ShowType+ 16K   .a�5;   &   ��  � ��
 � � �6C   5<   #   5>      5@        5A      -   5        Column2��$ Название��5A   6   $ * 6H    6R   �� *NazvanieTovara+   HeaderStyle 5B      �� 5C      =  7System.Windows.Controls.Primitives.DataGridColumnHeader"  6    .�5D      ��  � ��$ Center=�6K   �� 5E       � ��$
 Wrap=�6G   5F      5H        5I      -   5        Column3��$ Описание��5I   6   $ 2* 6H    6S   �� *
Opisanie+ 5J      �� 5K      "  6    .�5L      ��  � ��$ Center=�6K   �� 5M       � ��$
 Wrap=�6G   5N      5P        5Q      -   5        Column4��$ Стоимость��5Q   6   $
 0.7* 6I    6V   �� *	Stoimostt+ 5R      �� 5S      "  6    .�5T      ��  � ��$ Center=�6K   �� 5U       � ��$
 Wrap=�6G   5V      5X        5Y      -   5        Column5��$ Создатель��5Y   6   $
 0.7* 6I    6V   �� *	Creator+ 5Z      �� 5[      "  6    .�5\      ��  � ��$ Center=�6K   �� 5]       � ��$
 Wrap=�6G   5^      5`      5b      5d      5e      