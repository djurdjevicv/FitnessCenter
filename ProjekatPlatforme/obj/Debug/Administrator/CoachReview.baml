   M S B A M L   `   `   `  ����L  HProjekatPlatforme, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullQ-clr-namespace:ProjekatPlatforme.AdministratorProjekatPlatforme.Administrator  5   	   1    +ProjekatPlatforme.Administrator.CoachReview   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ?local-clr-namespace:ProjekatPlatforme.Administrator     5   	     � Title$  CoachReview��5   	   $	��550��6   $	��820��6*    � WindowStyle$
 None=�67    � 
ResizeMode$ NoResize=�6J    � WindowStartupLocation$ CenterScreen=�6`   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $	��100 �6   �� 5      $	��100 �6   �� 5      $	��100 �6   �� 5      $	��100 �6   �� 5      $	��100 �6   �� 5      $	��100 �6   �� 5      $	��100 �6   �� 5      $	��100 �6    � RowDefinitions 5   
   �� 5      $	��100 �6   �� 5      $	��100 �6   �� 5      $	��100 �6   �� 5      $	��100 �6   �� 5      $	��100 �6   �� 5      $��50 �6   .+�5   
   �� $��8��6   $��Center=�6$   $��Center=�6F   $��35(�6j   $
��Bold"�6x   .��6�   Coach review5      &   System.Windows.Controls.DataGrid  5   
   -   5        $��dataGrid��5   u      AutoGenerateColumns .    
IsReadOnly . $��1��6�   $��0��6�   $��8��6�   $��2��6�   $	��700��6�   �� 5    
   -   5        $��	createBtn��5       $��4��6#   $��0��60   $��2��6@   $��15, 23q�6T   $��18(�6d   $
��Bold"�6r   .��6�   CREATE A COACH6�   �� 5!   
   -   5        $��	deleteBtn��5!      $��4��6#   $��2��60   $��2��6@   $��15, 23q�6T   $��18(�6d   $
��Bold"�6r   .��6�   DELETE COACH6�   �� 5"   
   -   5        $��	updateBtn��5"      $��4��6#   $��4��60   $��2��6@   $��15, 23q�6T   $��18(�6d   $
��Bold"�6r   .��6�   
EDIT COACH6�   �� 5#   
   -   5        $��4��5#      $��6��6   $��2��6.   $��15, 23q�6B   $��18(�6R   $
��Bold"�6`   .��6�   BACK6�   5$      5%      