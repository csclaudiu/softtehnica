   M S B A M L   `   `   `  ����E  ARestaurant, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:Restaurant
Restaurant  5   	   ;"clr-namespace:Restaurant.ConverterRestaurant.Converter  5   	       Restaurant.Dashboard   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:Restaurant     5   	   0c"clr-namespace:Restaurant.Converter     5   	     � Title$  	Dashboard��5	   	   $	��500��6   $	��800��6(    � 	Resources 5
      $   Restaurant.Converter.convPrice 	  price��%   &	          5   
   6   5      .��5      � $��10q�6    � ColumnDefinitions 5   
   �� 5      $	��100 �6   �� 5      $��* �6   .+�5   
   �� $��	0,50,0,10q�6   .+�5      �� -   5         ��Name$ 
btnClients��5      $��Clients��6)   $	��100��6;   $
��Left=�6G   6b   �� 5      -   5        $ 	btnOrders��5      $��Orders��6(   $	��100��69   $
��Left=�6E   6`   5      � 5   
   $��1��6   $��10, 0, 10, 0q�6    5      �� 5      $��2* �6#   �� 5      $��2* �6#    � RowDefinitions 5      �� 5      $��4* �6    �� 5      $��2* �6    �� 5      $��* �6    �� 5      $
��Auto �6    .+�5!      �� -   5         ��Name$ avaibleProducts��5!      $��Stretch=�6Q   $��Stretch=�6o   ��60   �� *
products+��5"      �� 5#      .R�5$      �� $��2q�5&      
����ح���5$   !   ��  �� RelativeSource �� *FindAncestor+ �� AncestorType" � �� Path$ DataContext.cmdAddToMenu���5%      �� *.+.��5(      � $	��150��6#   $��5q�6/    5)   "   �� 5*   &   $��4* �67   �� 5+   &   $��* �67   .+�5-   "   �� $��0��6B   $
��Left=�6R   	 �� TextAlignment$
	 Left=�6m   ��6,   �� *name+6m   �� 5.   "   $	 Right=�6e   $��Right=�6{   $��1��6�   ��6,   �� *price+
 �� 	Converter#
 [  6�   5/      50      52      ��54      �� 55      .R�56      ��  �� Orientation$ Vertical=�6%   $��Stretch=�6<   57      59      �� 5:      -   5        $ orderedProducts��5:      $��1��60   $��Stretch=�6h   $��Stretch=�6�   ��6@   �� *orderedProducts+��5;      �� 5<      .R�5=      �� $��2q�5?      
���������5=   !   ��  �� *FindAncestor+" �$# DataContext.cmdRemoveFromMenu���5>      �� *.+.��5A      � $	��150��6#   $��5q�6/    5B   "   �� 5C   &   $��4* �67   �� 5D   &   $��* �67   .+�5F   "   �� $��0��6B   $
��Left=�6R   $
	 Left=�6m   ��6,   �� *name+6m   �� 5G   "   $	 Right=�6e   $��Right=�6{   $��1��6�   ��6,   �� *price+#
 [  6�   5H      5I      5J      5L      �� 5N      $ 
Horizontal=�6   $��1��62   .+�5O      �� $��25(�6   $��Client: ��6*   $��4q�6:   �� 5P      $��25(�6   $
��Bold"�6*   $��4q�6f   ��6<   �� *selectedClient.firstname+6f   �� 5Q      $��25(�6   $
��Bold"�6*   $��4q�6e   ��6<   �� *selectedClient.lastname+6e   5R      �� 5S      -   5         ��Name$ Total��5S   Q   $��1��6`   $��1��6p   $��28(�6}   ��6   �� *Total+#
 [  6}   �� 5U      -   5        $ btnSend��5U      $��2��6s   $��1��6�   $
��Send��6�   ��6&   �� *cmdSaveOrder+��6G   �� *selectedClient+6�   �� 5V      $��3��6   $��2��6%   $��5q�69   $��20(�6D   $��Black"�6R   $��Right=�6e   ��6�   �� *currentLocation.location_name+5W      5X      5Z      