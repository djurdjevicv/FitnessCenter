   M S B A M L   `   `   `  ����L  HProjekatPlatforme, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:ProjekatPlatforme.ValidationsProjekatPlatforme.Validations  5   	   /    )ProjekatPlatforme.Administrator.AdminData   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   CValidations+clr-namespace:ProjekatPlatforme.Validations     5   	     � Title$  	AdminData��5   	   $	��500��6   $	��910��6(    � WindowStyle$
 None=�65    � 
ResizeMode$ NoResize=�6H    � WindowStartupLocation$ CenterScreen=�6^   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $	��100 �6   �� 5      $	��100 �6   �� 5      $	��100 �6   �� 5      $	��100 �6   �� 5      $	��100 �6   �� 5      $	��100 �6   �� 5      $	��100 �6   �� 5      $	��100 �6   �� 5      $	��100 �6    � RowDefinitions 5   
   �� 5      $��80 �6   �� 5      $��50 �6   �� 5      $��60 �6   �� 5      $��50 �6   �� 5      $��60 �6   �� 5      $��50 �6   �� 5      $��60 �6   �� 5      $��60 �6   .+�5   
   �� $��9��6   $��35(�6%   $��Center=�63   $��Center=�6P   $
��Bold"�6k   .��6~   Change data6�   �� 5!   
   $��1��6   $��0��6   $��28(�6-   $��Bottom=�6;   $��2��6V   $��10,0,0,0q�6j   .��6|   First name:6�   �� 5"   
   -   5        $��firstName_txt��5"      $��2��6'   $��0��64   $��10,5,5,5q�6D   $��25(�6V   $��3��6d   .��6y   5$      �� 5&   
   $��3��6   $��0��6   $��28(�6-   $��Center=�6;   $��2��6V   $��10,0,0,0q�6j   .��6|   
Last name:6�   �� 5'   
   -   5        $��lastName_txt��5'      $��4��6&   $��0��63   $��10,5,5,5q�6C   $��3��6U   $��25(�6i   .��6w   5)      �� 5+   
   $��5��6   $��0��6   $��28(�6-   $��Center=�6;   $��2��6V   $��10,0,0,0q�6j   .��6|   	Password:6�   G� 5,   
   -   5        $��password_txt��5,      $��6��6*   $��0��67   $��10,5,5,5q�6G   $��3��6Y   $��25(�6m   6}   �� 5.   
   $��1��6   $��3��6   $��28(�6-   $��Center=�6;   $��2��6W   $��10,0,0,0q�6k   .��6}   	Gender:6�   �� 5/   
   -   5        $��	gender_cb��5/   %    �� 
IsReadOnly . $��2��66   $��3��6C   $��25(�6S   $��10,5,5,5q�6a   $��3��6s   .@�50      �� -   5        $��GMale��50      .��6(   Male6.   �� 51      -   5        $��GFemale��51      .��6*   Female62   52      �� 54   
   $��3��6   $��3��6   $��28(�6-   $��Center=�6;   $��2��6V   $��10,0,0,0q�6j   .��6|   Email:6�   �� 55   
   -   5        $��	email_txt��55      $��4��6#   $��3��60   $��10,5,5,5q�6@   $��3��6R   $��25(�6f   .��6t   57      �� 59   
   $��5��6   $��3��6   $��28(�6-   $��Center=�6;   $��2��6V   $��10,0,0,0q�6j   .��6|   	Street:6�   �� 5:   
   -   5        $��
street_txt��5:      $��6��6$   $��3��61   $��10,5,5,5q�6A   $��3��6S   $��25(�6g   .��6u   5<      �� 5>   
   $��1��6   $��6��6   $��28(�6-   $��Center=�6;   $��2��6V   $��10,0,0,0q�6j   .��6|   	Number:6�   �� 5?   
   -	   5        $��
number_txt��5?      $��2��6$   $��6��61   $��10,5,5,5q�6A   $��3��6S   $��25(�6g   .��6u   5A      �� 5C   
   $��3��6   $��6��6   $��28(�6-   $��Center=�6;   $��2��6V   $��10,0,0,0q�6j   .��6|   City:6�   �� 5D   
   -
   5        $��city_txt��5D      $��4��6"   $��6��6/   $��10,5,5,5q�6?   $��3��6Q   $��25(�6e   .��6s   5F      �� 5H   
   $��5��6   $��6��6   $��28(�6-   $��Center=�6;   $��2��6V   $��10,0,0,0q�6j   .��6|   State:6�   �� 5I   
   -   5        $��	state_txt��5I      $��6��6#   $��6��60   $��10,5,5,5q�6@   $��3��6R   $��25(�6f   .��6t   5K      �� 5M   
   -   5        $��7��5M      $��2��6   $��2��6.   $��25(�6B   $��Center=�6P   $��Center=�6m   $	��200��6�   $��50��6�   .��6�   Submit6�   �� 5N   
   -   5        $��7��5N      $��5��6   $��2��6.   $��25(�6B   $��Center=�6P   $��Center=�6m   $	��200��6�   $��50��6�   .��6�   Back6�   5P      5Q      