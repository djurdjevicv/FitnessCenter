   M S B A M L   `   `   `  ����L  HProjekatPlatforme, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:ProjekatPlatformeProjekatPlatforme  5   	       ProjekatPlatforme.LogIn   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:ProjekatPlatforme     5   	     � WindowStartupLocation$  CenterScreen=�5   	    � Title$ Login��5	   	    � WindowStyle$
 None=�6    � 
ResizeMode$ NoResize=�6+   $	��500��6A   $	��500��6N   .��5
      �  � ColumnDefinitions 5   
   �� 5      $	��100 �6   �� 5      $	��100 �6   �� 5      $	��100 �6   �� 5      $	��100 �6   �� 5      $	��100 �6    � RowDefinitions 5   
   �� 5      $	��100 �6   �� 5      $��50 �6   �� 5      $	��100 �6   �� 5      $��50 �6   �� 5      $	��100 �6   �� 5      $	��100 �6   .+�5   
   �� $��0��6   $��0��6   $��5��6-   $
��Bold"�6A   $��40(�6S   $��Center=�6a   $��Center=�6~   .��6�   Login to your account6�   �� 5   
   $��30(�6   $��1��6   $��0��6+   $��5��6;   $��20,0,0,0q�6O   .��6a   JMBG:6h   �� 5   
   -   5        $��txtJMBG��5      $��2��6!   $��0��6.   $��5��6>   $��
20,5,20,40q�6R   $��32(�6f   6w   �� 5   
   $��30(�6   $��3��6   $��0��6+   $��5��6;   $��20,0,0,0q�6O   .��6a   	Password:6l   G� 5    
   -   5        $��txtPassword��5       $��4��6)   $��0��66   $��5��6F   $��
20,5,20,40q�6Z   $��32(�6n   6~   �� 5"   
   -   5        $��5��5"      $��0��6   $��2��6.   $��30(�6B   $
��Bold"�6P   $��10,20q�6b   .��6�   Submit6�   �� 5#   
   -   5        $��5��5#      $��3��6   $��2��6.   $��30(�6B   $
��Bold"�6P   $��10,20q�6b   .��6�   Back6�   5$      5%      