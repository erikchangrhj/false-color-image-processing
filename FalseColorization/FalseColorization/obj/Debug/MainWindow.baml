   M S B A M L   `   `   `  ����L  HFalseColorization, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:FalseColorizationFalseColorization  5   	   "    FalseColorization.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:FalseColorization     5   	   -   5          � Title$  False Colorization��5   	   $	��800��6$   $
��1200��61   $	��800��6_   $	��600��6n    � WindowStartupLocation$ CenterScreen=�6~   .��5	      � .+�5
   
   �� -   5         ��Name$ openImageButton��5
      $
��Open��6*   $
��Left=�69   $��30��6T   $��	12,10,0,0q�6`   $	��Top=�6s   $	��375��6�   6�   �� 5   
   -   5         ��Name$ convertedImageBorder��5      
���   �$��1q�6C   $
��Left=�6W   $	��749��6r   $��
392,10,0,0q�6   $	��Top=�6�   $	��790��6�   ._�5      �� -   5         ��Name$ convertedImage��5      5      �� 5   
   
���   �$��1q�6%   $
��Left=�69   $	��250��6T   $��
12,242,0,0q�6a   $	��Top=�6u   $	��375��6�   ._�5      �� -   5        $ originalImage��5      5      �� 5   
   -   5         ��Name$ degreeShiftSlider��5      $
��Left=�6,   $��
100,80,0,0q�6G   $	��Top=�6[   $	��245��6s   $��25��6    � Maximum$	 359Q�6�    � SmallChange$ 1Q�6�    � LargeChange$ 10Q�6�   	 � Minimum$
	 -359Q�6�   �� 5   
   -   5        
 ��Name$
 degreeShiftLabel��5      $�� ��6*   $
��Left=�65   $��25��6P   $��
350,80,0,0q�6\   $	��Top=�6p   $��37��6�   $��8(�6�   ���	#FFC8C8C86�   �� 5   
   -   5        $ redrawButton��5      $��Redraw��6'   $
��Left=�68   $��30��6S   $��	12,45,0,0q�6_   $	��Top=�6r   $	��375��6�   {�.  6�   �� 5   
   -	   5        $ grayDiagramImage��5      $
��Left=�6*   $��30��6E   $��
12,177,0,0q�6Q   $	��Top=�6e   $	��375��6}   $
��Fill=�6�   �� 5   
   -
   5        $ colorDiagramImage��5      $
��Left=�6+   $��30��6F   $��
12,207,0,0q�6R   $	��Top=�6f   $	��375��6~   $
��Fill=�6�   �� 5   
   -   5        $ contrastSlider��5      $
��Left=�6)   $��100,120,0,0q�6D   $	��Top=�6Y   $	��245��6q   $��25��6}   $	 100Q�6�   $ 1Q�6�   $ 10Q�6�    � Value$	 100Q�6�   �� 5   
   -   5        $
 contrastLabel��5      $
��Left=�6'   $��25��6B   $��350,120,0,0q�6N   $	��Top=�6c   $��37��6{   $��8(�6�   ���	#FFC8C8C8$	��100��6�   �� 5   
   $��Shift Degree��6   $
��Left=�6'   $��25��6B   $��	12,80,0,0q�6N   $	��Top=�6a   $��83��6y   �� 5   
   $��Contrast��6   $
��Left=�6#   $��25��6>   $��
12,120,0,0q�6J   $	��Top=�6^   $��83��6v   5      5      