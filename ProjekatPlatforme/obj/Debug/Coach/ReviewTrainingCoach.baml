   M S B A M L   `   `   `  ����L  HProjekatPlatforme, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:ProjekatPlatforme.CoachProjekatPlatforme.Coach  5   	   1    +ProjekatPlatforme.Coach.ReviewTrainingCoach   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7local%clr-namespace:ProjekatPlatforme.Coach     5   	     � Title$  ReviewTrainingCoach��5   	   $	��410��6%   $	��800��62    � WindowStartupLocation$ CenterScreen=�6>    � WindowStyle$
 None=�6c    � 
ResizeMode$ NoResize=�6v   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $	��100 �6   �� 5      $	��100 �6   �� 5      $	��100 �6   �� 5      $	��100 �6   �� 5      $	��100 �6   �� 5      $	��100 �6   �� 5      $	��100 �6   �� 5      $	��100 �6    � RowDefinitions 5   
   �� 5      $��60 �6   �� 5      $	��100 �6   �� 5      $	��100 �6   �� 5      $��50 �6   �� 5      $��50 �6   �� 5      $��50 �6   .+�5   
   �� $��30(�6   $
��Bold"�6   $��Center=�60   $��Center=�6K   $��8��6h   .��6|   Review your training6�   &   System.Windows.Controls.DataGrid  5   
   -   5        $��dataGrid��5         
IsReadOnly . $��1��65   $��2��6B   $��8��6S   $
��10,0q�6g   6w   (  "System.Windows.Controls.DatePicker  5!   
   -   5        $��selectedDate��5!      $��3��6)   $��2��66   $��2��6F   $��22(�6Z   $��Center=�6h   $	��5,0q�6�   6�   �� 5"   
   -   5        $��4��5"      $��2��6   $��2��62   $��22(�6B   $��Center=�6P   $	��5,0q�6k   .��6�   Search6�   �� 5#   
   -   5        $��5��5#      $��2��6   $��2��62   $��22(�6B   $��Center=�6P   $	��5,0q�6k   .��6�   
View all6�   �� 5%   
   -   5        $��3��5%      $��2��6   $��4��62   $��22(�6B   $��Center=�6P   $	��5,0q�6k   .��6�   Add training6�   �� 5&   
   -   5        $��4��5&      $��2��6   $��4��62   $��22(�6B   $��Center=�6P   $	��5,0q�6k   .��6�   Delete training6�   �� 5'   
   -   5        $��5��5'      $��2��6   $��4��62   $��22(�6B   $��Center=�6P   $	��5,0q�6k   .��6�   Back6�   5*      5+      