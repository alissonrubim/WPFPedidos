   M S B A M L   `   `   `  ����E  APedidosApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:PedidosApp.ViewPedidosApp.View  5   	   )    #PedidosApp.View.WindowProdutoResume   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:PedidosApp.View     5   	     � Title$  Produtos         ��5   	   $	��450��5	      $	��800��6   .��5
      ]� .+�5   
   ]� $	��Top=�6   $��5, 5, 5, 10q�6)   .+�5      �� -   5         ��Name$ 	buttonAdd��5      $	��100��6(   $��25��64   $��
5, 0, 5, 0q�6@   
����������	#FFECECEC.��6�   	Adicionar6�   �� 5      -   5        $ 
buttonEdit��5      $	��100��6)   $��25��65   $��
5, 0, 5, 0q�6A   
����������	#FFECECEC.��6�   Editar6�   �� 5      -   5        $ buttoRemove��5      $	��100��6*   $��25��66   $��
5, 0, 5, 0q�6B   
����������	#FFECECEC$
��Left=�6�   .��6�   	Remover6�   5      ]� 5   
   .+�5      &   System.Windows.Controls.DataGrid  -   5          Name$ 
gridResume��5   A      AutoGenerateColumns .     CanUserAddRows .  ��6   ��  �� Source$ 
resumeList��   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Código��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$ 80 69   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 6D   �� *Codigo+  5      $ Descrição��6)   $	 500 6<   	 6H   �� *	Descricao+  5      $ Preço��6)   $	 200 68   	 6D   �� *Preco+5      5      5      5      