using PedidosDominio.DAO;
using PedidosDominio.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PedidosApp.View
{
    /// <summary>
    /// Lógica interna para WindowPedidoResume.xaml
    /// </summary>
    public partial class WindowPedidoResume : Window
    {
        private ObservableCollection<Pedido> resumeList;

        public WindowPedidoResume()
        {
            InitializeComponent();
            loadGrid();
        }

        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            openDetail(null);
        }

        private void buttonEdit_Click(object sender, RoutedEventArgs e)
        {
            Pedido c = getSelectedObject();
            if (c == null)
                MessageBox.Show("Necessário selecionar um registro antes de editar!", "Atenção", MessageBoxButton.OK, MessageBoxImage.Warning);
            else
                openDetail(c);
        }

        private void buttoRemove_Click(object sender, RoutedEventArgs e)
        {
            Pedido c = getSelectedObject();
            if (c == null)
                MessageBox.Show("Necessário selecionar um registro antes de remover!", "Atenção", MessageBoxButton.OK, MessageBoxImage.Warning);
            else
            {
                (new PedidoDAO()).Excluir(c);
                loadGrid();
            }

        }

        private void openDetail(Pedido c = null)
        {
            WindowPedidoDetail detail = new WindowPedidoDetail(c);
            detail.ShowDialog();
            loadGrid();
        }

        private Pedido getSelectedObject()
        {
            if (gridResume.SelectedIndex > -1)
                return resumeList[gridResume.SelectedIndex];
            return null;
        }

        private void loadGrid()
        {
            resumeList = (new PedidoDAO()).RetornarTodos();
            gridResume.ItemsSource = resumeList;
        }
    }
}
