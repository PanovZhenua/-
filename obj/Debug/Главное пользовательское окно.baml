   M S B A M L   `   `   `  ����d  `Индивидуальный Проект, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulle7clr-namespace:Индивидуальный_Проект)Индивидуальный_Проект  5   	   h    bИндивидуальный_Проект.Главное_пользовательское_окно   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Ilocal7clr-namespace:Индивидуальный_Проект     5   	     � Title$  Главное окно��5   	   $	��600��6   $
��1000��6+    � 	Resources 5
      O   IИндивидуальный_Проект.ByteArrayToBitmapImageConverter #  ByteArrayToBitmapImageConverter  ProductTemplate �� Padding �� 
TargetType �� Triggers P� Property P� Value N� EnterActions �� TargetProperty		 W� To
 g� Duration N� ExitActions � RowDefinitions �� 	Converter �� TextAlignment �� StringFormat��%7  &	        &	      7     5   
   60   �� 5   
   .R�5      (� .��5      �� 
���   �$��1q�6-   $ 10q�6A   $��5q�6N   $	��180��6Y   z�5      �� 5      ��5      �� 5      " ��6     5      P� 5   "    �@J�IsMouseOver .  5   &   �� 5   *   .��5   .   �� .��5   2   W� $- 'RenderTransform.(ScaleTransform.ScaleX)�6B   $		 1.1X�6�   $
 0:0:0.2D�6�   W� 5   2   $- 'RenderTransform.(ScaleTransform.ScaleY)�6B   $		 1.1X�6�   $
 0:0:0.2D�6�   5   /   5   +    5   &   �� 5   *   .��5    .   �� .��5!   2   W� $- 'RenderTransform.(ScaleTransform.ScaleX)�6B   $	 1X�6�   $
 0:0:0.2D�6�   W� 5"   2   $- 'RenderTransform.(ScaleTransform.ScaleY)�6B   $	 1X�6�   $
 0:0:0.2D�6�   5#   /   5$   +   5&   #   5(      ._�5*      �  5+      �� 5,      $
��Auto �6,   �� 5-      $
��Auto �6,   �� 5.      $
��Auto �6,   .+�50      �� $��0��6    $
��Auto��6�   $	��150��6�   $��Uniform=�6�   ��6-   �� *Izobrazhenie+8   6�   �� 51      $��1��6$   $
��Bold"�6Q   $��0,5,0,0q�6c   $ Center=�6t   ��61   �� *NazvanieTovara+6t   �� 52      $��2��6$   $��0,5,0,0q�6k   $ Center=�6|   ��61   �� *	Stoimostt+$ Цена: {0} руб.��6|   53      54      55      57      58      .��5:      �  5;   
   �� 5<      $
��Auto �6   �� 5=      $
��Auto �6   �� 5>      $��* �6   .+�5A   
   �� $��0��6    �� Orientation$ 
Horizontal=�6"   
�������.+�5B      �� $=��7Интернет-магазин для животных��6   $��22(�6=   $
��Bold"�6K   $��10q�6]   $��Center=�6i   �� 5C      -   5         ��Name$ PersonalAccountButton��5C      $!��Личный кабинет��64   $��16(�6M   $
��10,5q�6[   $
��10,2q�6i   6x   �� 5D      -   5        $ AddProductButton��5D      $!��Добавить товар��6/   $��16(�6H   $
��10,5q�6V   $
��10,2q�6d   y�6�   �� *AddProductButtonVisibility+�� 5E      -   5        $ AdminPanelButton��5E      $��Панель админа��6/   $��16(�6G   $
��10,5q�6U   $
��10,2q�6c   y�6�   �� *AdminPanelButtonVisibility+�� 5F      -   5        $ 
CartButton��5F      $��Корзина��6)   $��16(�6;   $
��10,5q�6I   $
��10,2q�6W   $��Right=�6f   6�   5G      �� 5I   
   $��Disabled=�6   $
��Auto=�6>   $��1��6c   .��5J      �� $��1��6   $ 
Horizontal=�6&   
�������.+�5K      �� $&�� Поиск по названию��6   $��15(�65   $��10q�6C   $��Center=�6O   �� 5L      -   5         ��Name$ SearchTextBox��5L      $	��200��61   $��10q�6=   $��Center=�6I   6d   �� 5M      $!��Фильтр по цене:��6   $��15(�63   $��10q�6A   $��Center=�6M   �� 5N      $
��от��6   $	��5,0q�6&   $��Center=�63   �� 5O      -   5         ��Name$ MinPriceSlider��5O       � Minimum$ 0Q�61    � Maximum$
 1000Q�6=    �� TickPlacement$ BottomRight=�6L    �� TickFrequency$	 100Q�6h    �� IsSnapToTickEnabled .  � Value$ 0Q�6�   $	��150��6�   $��10q�6�   6�   �� 5P      -   5        $ MinPriceTextBox��5P      $��50��63   $	��5,0q�6>   $��Center=�6K   ��6f   �� *Value+ �� ElementName$ MinPriceSlider��$ N0���� 5Q      $
��до��6   $	��5,0q�6&   $��Center=�63   �� 5R      -   5        $ MaxPriceSlider��5R      $ 0Q�61   $
 1000Q�6=   $ BottomRight=�6L   $	 100Q�6h    . $
 1000Q�6�   $	��150��6�   $��10q�6�   6�   �� 5S      -	   5        $ MaxPriceTextBox��5S      $��50��63   $	��5,0q�6>   $��Center=�6K   ��6f   �� *Value+$ MaxPriceSlider��$ N0���� 5T      -
   5        $ ApplyFilterButton��5T      $��Применить��64   $��15(�6H   $��10q�6V   $��5q�6b   6n   5U      5V      �� 5Y   
   $
��Auto=�6   $��2��6:   .��5Z      �� -   5        $��productItemsControl��5Z      #��[ 66   ��5[      �� 5\      .R�5]      A�  A� Columns$ 4��6&   5^      ��5`      �� 5a      " ��6   .�5b      -   5        5c      5e      5f      5g      5i      