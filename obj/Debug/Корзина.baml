   M S B A M L   `   `   `  ����d  `Индивидуальный Проект, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulle7clr-namespace:Индивидуальный_Проект)Индивидуальный_Проект  5   	   >    8Индивидуальный_Проект.Корзина   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Ilocal7clr-namespace:Индивидуальный_Проект     5   	     � Title$  Корзина��5   	   $	��600��6   $	��800��6&    � 	Resources 5	      O   IИндивидуальный_Проект.ByteArrayToBitmapImageConverter #  ByteArrayToBitmapImageConverterG   AИндивидуальный_Проект.NullVisibilityConverter  NullVisibilityConverterK   EИндивидуальный_Проект.ShowTypeVisibilityConverter  ShowTypeVisibilityConverterN   HИндивидуальный_Проект.ShowTypeButtonEnabledConverter " ShowTypeButtonEnabledConverter  CartItemTemplate � ColumnDefinitions �� 
TargetType �� Triggers �� Binding �� Value �� Property �� Value	 �� 	Converter
 �� StringFormat �� Orientation �� ConverterParameter��%  &	        &	      &	 &     &	 9     &	 L     7   7  7  7  7    5
   
   60     5   
   6(     5   
   6,     5   
   6/   �� 5   
   .R�5      �  5      �� 5      $
��Auto �6'   �� 5      $��* �6'   �� 5      $
��Auto �6'   �� 5      $
��Auto �6'   �� 5      $
��Auto �6'   ��5      �� 5      " �6    5      �� 5       6*   �� *
ShowType+ 26G   .a�5   "   ��  � ��
 �����6?   5      5      .+�5!      �� $��0��6   $	��100��6�   $��5q�6�   ��6(   �� *Izobrazhenie+8	   y�6�   �� *Izobrazhenie+8	  �� 5"      $��1��6   $��5q�6-   .+�5#      �� $
��Bold"�6@   ��6    �� *NazvanieTovara+6@   �� 5$      ��6    �� *	Stoimostt+$
 Цена: {0} руб.���� 5%      
���  ��$��Center=�6�   $
��Bold"�6�   ��6    �� *
ShowType+8	  6�   5&      �� 5'      $��2��6   $��Количество:��6,   $��Center=�6?   $��5q�6Z   �� 5(      $��3��6   $ 
Horizontal=�6-   $��Center=�6F   $��5q�6a   .+�5)      �� -   5        $��-��5)      {�6H   �� *
ShowType+8	  $ 1���� 5*      $	��5,0q�6=   ��6    �� *Kolichestvo+6=   �� 5+      -   5        $��+��5+      {�6H   �� *
ShowType+8	  $ 1��5,      �� 5-      $��4��6   $ 
Horizontal=�6-   $��Center=�6F   $��5q�6a   .+�5.      �� $
��Bold"�6d   ��6    �� *ObshchayaStoimostt+$
 Итого: {0} руб.��6d   �� 5/      -   5        $��Удалить��5/      ��50      �� 51      " ��6$    52   "   �� 53   &    62   �� *
ShowType+ 26O   .a�54   *   ��  � ��
 �  ��6G   �� 55   *    � ��
 �����6G   56   '   58      5:      5;      5<      5=      5>      .��5@      � .+�5A   
   �� -   5        $��CartItemsControl��5A      #��[ 6/   5B      5C      