   M S B A M L   `   `   `  ����L  HProjekatPlatforme, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:ProjekatPlatforme.CoachProjekatPlatforme.Coach  5   	   .    (ProjekatPlatforme.Coach.SearchCoachUnReg   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7local%clr-namespace:ProjekatPlatforme.Coach     5   	     � Title$  SearchCoachUnReg��5   	   $	��405��6#   $	��600��60    � WindowStyle$
 None=�6<    � 
ResizeMode$ NoResize=�6O    � WindowStartupLocation$ CenterScreen=�6e   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $	��100 �6   �� 5      $	��100 �6   �� 5      $	��100 �6   �� 5      $	��100 �6   �� 5      $	��100 �6   �� 5      $	��100 �6    � RowDefinitions 5   
   �� 5      $��60 �6   �� 5      $	��100 �6   �� 5      $	��100 �6   �� 5      $��70 �6   �� 5      $��70 �6   .+�5   
   �� $��1��6   $��4��6    $��Center=�64   $��Center=�6O   $��27(�6l   $
��Bold"�6z   .��6�   Search coach6�   &   System.Windows.Controls.DataGrid  5   
   -   5        $��dataGrid��5   c      AutoGenerateColumns . $��1��6s   $��6��6�   $��2��6�   $
��10,0q�6�   6�   �� 5   
   $��3��6   $��	10,5,10,0q�6   $��2��62   
�������$	��Top=�6]   $��Center=�6u   $��23(�6�    �� 
IsReadOnly . .��6�   
First name6�   �� 5   
   -   5        $��firstName_txt��5      $��3��6'   $��
10,39,10,0q�64   $��2��6H   $��Center=�6\   $��Center=�6w   $��20(�6�   6�   �� 5    
   $��3��6   $��	10,5,10,0q�6   $��2��62   $��2��6B   
�������$	��Top=�6m   $��Center=�6�   $��23(�6�    . .��6�   	Last name6�   �� 5!   
   -   5        $��lastName_txt��5!      $��3��6&   $��2��63   $��
10,39,10,0q�6C   $��2��6W   $��Center=�6k   $��Center=�6�   $��20(�6�   6�   �� 5#   
   $��3��6   $��	10,5,10,0q�6   $��2��62   $��4��6F   
�������$	��Top=�6m   $��Center=�6�   $��23(�6�    . .��6�   Email6�   �� 5$   
   -   5        $��	email_txt��5$      $��3��6#   $��
10,39,10,0q�60   $��4��6D   $��2��6T   $��Center=�6h   $��Center=�6�   $��20(�6�   6�   �� 5&   
   $��4��6   $��	10,5,10,0q�6   $��2��62   $��2��6F   
�������$	��Top=�6m   $��Center=�6�   $��23(�6�    . .��6�   	Address6�   �� 5'   
   -   5        $��address_txt��5'      $��4��6%   $��
10,39,10,0q�62   $��2��6F   $��2��6V   $��Center=�6j   $��Center=�6�   $��20(�6�   6�   �� 5)   
   -   5        $��2��5)      $��4��6%   $��10,15,10,15q�62   $��23(�6G   .��6h   Back6n   �� 5*   
   -   5        $��2��5*      $��4��6%   $��4��65   $��10,15,10,15q�6B   $��23(�6l   .��6z   Search6�   5,      5-      