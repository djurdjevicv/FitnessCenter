   M S B A M L   `   `   `  ����L  HProjekatPlatforme, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullQ-clr-namespace:ProjekatPlatforme.AdministratorProjekatPlatforme.Administrator  5   	   4    .ProjekatPlatforme.Administrator.TrainingReview   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ?local-clr-namespace:ProjekatPlatforme.Administrator     5   	     � Title$  TrainingReview��5   	   $	��500��6    $	��800��6-    � WindowStyle$
 None=�6:    � 
ResizeMode$ NoResize=�6M    � WindowStartupLocation$ CenterScreen=�6c   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $	��100 �6   �� 5      $	��100 �6   �� 5      $	��100 �6   �� 5      $	��100 �6   �� 5      $	��100 �6   �� 5      $	��100 �6   �� 5      $	��100 �6   �� 5      $	��100 �6    � RowDefinitions 5   
   �� 5      $	��100 �6   �� 5      $	��100 �6   �� 5      $	��100 �6   �� 5      $	��100 �6   �� 5      $	��100 �6   �� 5      $��50 �6   .+�5   
   �� $��8��6   $��Center=�6$   $��Center=�6F   $��35(�6j   $
��Bold"�6x   .��6�   Training review5      &   System.Windows.Controls.DataGrid  5   
   -   5        $��dataGrid��5   &      
IsReadOnly . $��1��66   $��0��6C   $��8��6S   $��2��6g   $	��700��6x   �� 5    
   -   5        $��	createBtn��5       $��4��6#   $��0��60   $��2��6@   $��15, 23q�6T   $��18(�6d   $
��Bold"�6r   .��6�   ADD TRAINING6�   �� 5!   
   -   5        $��	deleteBtn��5!      $��4��6#   $��2��60   $��2��6@   $��15, 23q�6T   $��18(�6d   $
��Bold"�6r   .��6�   DELETE TRAINING6�   �� 5"   
   -   5        $��	updateBtn��5"      $��4��6#   $��4��60   $��2��6@   $��15, 23q�6T   $��18(�6d   $
��Bold"�6r   .��6�   EDIT TRAINING6�   �� 5#   
   -   5        $��4��5#      $��6��6   $��2��6.   $��15, 23q�6B   $��18(�6R   $
��Bold"�6`   .��6�   BACK6�   5$      5%      