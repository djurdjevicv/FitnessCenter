   M S B A M L   `   `   `  ����L  HProjekatPlatforme, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:ProjekatPlatforme.BeginnerProjekatPlatforme.Beginner  5   	   3    -ProjekatPlatforme.Beginner.BeginnerEditWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   :local(clr-namespace:ProjekatPlatforme.Beginner     5   	     � Title$  BeginnerEditWindow��5   	   $	��610��6$   $	��910��61    � WindowStyle$
 None=�6>    � 
ResizeMode$ NoResize=�6Q    � WindowStartupLocation$ CenterScreen=�6g   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $	��100 �6   �� 5      $	��100 �6   �� 5      $	��100 �6   �� 5      $	��100 �6   �� 5      $	��100 �6   �� 5      $	��100 �6   �� 5      $	��100 �6   �� 5      $	��100 �6   �� 5      $	��100 �6    � RowDefinitions 5   
   �� 5      $��80 �6   �� 5      $��50 �6   �� 5      $��60 �6   �� 5      $��50 �6   �� 5      $��60 �6   �� 5      $��50 �6   �� 5      $��60 �6   �� 5      $��50 �6   �� 5      $��60 �6   �� 5      $��60 �6   .+�5!   
   �� $��9��6   $��35(�6%   $��Center=�63   $��Center=�6P   $
��Bold"�6k   .��6~   Change beginner data6�   �� 5#   
   $��1��6   $��0��6   $��28(�6-   $��Bottom=�6;   $��2��6V   $��10,0,0,0q�6j   .��6|   First name:6�   �� 5$   
   -   5        $��firstName_txt��5$      $��2��6'   $��0��64   $��10,5,5,5q�6D   $��25(�6V   $��3��6d   6z   �� 5&   
   $��3��6   $��0��6   $��28(�6-   $��Center=�6;   $��2��6V   $��10,0,0,0q�6j   .��6|   
Last name:6�   �� 5'   
   -   5        $��lastName_txt��5'      $��4��6&   $��0��63   $��10,5,5,5q�6C   $��3��6U   $��25(�6i   6y   �� 5)   
   $��5��6   $��0��6   $��28(�6-   $��Center=�6;   $��2��6V   $��10,0,0,0q�6j   .��6|   	Password:6�   G� 5*   
   -   5        $��password_txt��5*      $��6��6+   $��0��68   $��10,5,5,5q�6H   $��3��6Z   $��25(�6n   6~   �� 5,   
   $��1��6   $��3��6   $��28(�6-   $��Center=�6;   $��2��6W   $��10,0,0,0q�6k   .��6}   Jmbg:6�   �� 5-   
   -   5        $��jmbg_txt��5-   $    �� 
IsReadOnly . $��2��64   $��3��6A   $��25(�6Q   $��10,5,5,5q�6_   $��3��6q   6�   �� 5/   
   $��3��6   $��3��6   $��28(�6-   $��Center=�6;   $��2��6V   $��10,0,0,0q�6j   .��6|   Email:6�   �� 50   
   -   5        $��	email_txt��50      $��4��6#   $��3��60   $��10,5,5,5q�6@   $��3��6R   $��25(�6f   6v   �� 52   
   $��5��6   $��3��6   $��28(�6-   $��Center=�6;   $��2��6V   $��10,0,0,0q�6j   .��6|   	Street:6�   �� 53   
   -   5        $��
street_txt��53      $��6��6$   $��3��61   $��10,5,5,5q�6A   $��3��6S   $��25(�6g   6w   �� 55   
   $��1��6   $��6��6   $��28(�6-   $��Center=�6;   $��2��6V   $��10,0,0,0q�6j   .��6|   	Number:6�   �� 56   
   -   5        $��
number_txt��56      $��2��6$   $��6��61   $��10,5,5,5q�6A   $��3��6S   $��25(�6g   6w   �� 58   
   $��3��6   $��6��6   $��28(�6-   $��Center=�6;   $��2��6V   $��10,0,0,0q�6j   .��6|   City:6�   �� 59   
   -   5        $��city_txt��59      $��4��6"   $��6��6/   $��10,5,5,5q�6?   $��3��6Q   $��25(�6e   6u   �� 5;   
   $��5��6   $��6��6   $��28(�6-   $��Center=�6;   $��2��6V   $��10,0,0,0q�6j   .��6|   State:6�   �� 5<   
   -	   5        $��	state_txt��5<      $��6��6#   $��6��60   $��10,5,5,5q�6@   $��3��6R   $��25(�6f   6v   �� 5>   
   $��7��6   $��0��6   $��28(�6-   $��Center=�6;   $��2��6V   $��10,0,0,0q�6j   .��6|   ID Address:6�   �� 5?   
   -
   5        $��idAddress_txt��5?   $    . $��8��69   $��0��6F   $��10,5,5,5q�6V   $��3��6h   $��25(�6|   6�   �� 5A   
   $��7��6   $��6��6   $��28(�6-   $��Center=�6;   $��2��6W   $��10,0,0,0q�6k   .��6}   	Gender:6�   �� 5B   
   -   5        $��	gender_cb��5B      $��8��6$   $��6��61   $��25(�6A   $��10,5,5,5q�6O   $��3��6a   .@�5C      �� -   5        $��GMale��5C      .��6(   Male6.   �� 5D      -   5        $��GFemale��5D      .��6*   Female62   5E      �� 5G   
   -   5        $��9��5G      $��2��6   $��2��6.   $��25(�6B   $��Center=�6P   $��Center=�6m   $	��200��6�   $��50��6�   .��6�   Submit6�   �� 5H   
   -   5        $��9��5H      $��5��6   $��2��6.   $��25(�6B   $��Center=�6P   $��Center=�6m   $	��200��6�   $��50��6�   .��6�   Back6�   5J      5K      