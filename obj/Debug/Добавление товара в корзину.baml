   M S B A M L   `   `   `  ����d  `Индивидуальный Проект, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulle7clr-namespace:Индивидуальный_Проект)Индивидуальный_Проект  5   	   c    ]Индивидуальный_Проект.Добавление_товара_в_корзину   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Ilocal7clr-namespace:Индивидуальный_Проект     5   	     � Title$9  3Добавление товара в корзину��5	   	   .��5      �  � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��2* �6   .+�5   
   �� -   5         ��Name$ ProductImage��5      $��0��6&   $��20q�66   $��Center=�6B   �� 5   
   $��1��6   $��20q�6%   $��Center=�61   .+�5      �� -   5         ��Name$ ProductName��5      $��24(�6-   $
��Bold"�6;   $
��Wrap=�6M   �� 5      -   5        $ ProductDescription��5      $��0,10,0,0q�64   $
��Wrap=�6F   �� 5       �� Orientation$ 
Horizontal=�6   $��0,20,0,0q�62   .+�5      �� $��Количество:��6   $��Center=�6/   �� 5      -   5         ��Name$ DecreaseQuantityButton��5      $��-��69   $
��10,0q�6E   $	��5,2q�6S   6a   �� 5      -   5        $ QuantityTextBlock��5      $��1��67   $��Center=�6@   $
��10,0q�6[   �� 5      -   5        $ IncreaseQuantityButton��5      $��+��69   $
��10,0q�6E   $	��5,2q�6S   6a   5      �� 5      -   5        $ ExistingCartItemMessage��5      
���  ��$��0,10,0,0q�6J   $
��Wrap=�6\   �� 5       -   5        $ AddToCartButton��5       $(��"Добавить в корзину��6.   $��0,20,0,0q�6K   $
��10,5q�6]   6l   5!      5"      5#      