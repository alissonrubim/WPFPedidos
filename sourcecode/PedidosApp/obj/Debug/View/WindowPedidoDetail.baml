   M S B A M L   `   `   `  ����E  APedidosApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:PedidosApp.ViewPedidosApp.View  5   	   (    "PedidosApp.View.WindowPedidoDetail   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:PedidosApp.View     5   	     � Title$  Detalhe do Pedido��5   	   $	��450��6#   $	��800��60   .��5	      ]� .+�5
   
   �� $	��Top=�6   $	��360��6*    �� Orientation$ Vertical=�67   $��	5, 0 ,5,0q�6N   .+�5      �� .��6   
Número:6   �� 5      -   5         ��Name$ textBoxNumero��5      6/   �� 5      .��6   
Cliente:6   �� 5      -   5         ��Name$ comboBoxClient��5      ��6/   ��  �� Source$ clientsList����5      �� 5      .R�5      �� $ 
Horizontal=�6%   .+�5      �� ��6(   �� *Nome+5      5      5      1   +PedidosApp.View.UserControlPedidoItemResume  5      -   5          Name$! userControlPedidoItemResume��5   0   $	��258��6V   $��10q�6c   5      ]� 5   
   $��Bottom=�6   $��40��6,   .+�5      ]� $��230px��6   $
��Left=�6&   $��Right=�6<   .+�5      �� -   5         ��Name$ buttonConfirm��5      $	��100��60   $��25��6<   $��
5, 0, 5, 0q�6H   
����������	#FFECECEC$��Right=�6�   .��6�   	Confirmar6�   �� 5      -   5        $ buttonCancel��5      $	��100��6/   $��25��6;   $��
5, 0, 5, 0q�6G   
����������	#FFECECEC$��Right=�6�   .��6�   
Cancelar6�   5      5      5      5       