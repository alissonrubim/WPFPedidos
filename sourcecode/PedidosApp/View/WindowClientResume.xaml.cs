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
using PedidosDominio.DAO;
using PedidosDominio.Models;

namespace PedidosApp.View
{
    /// <summary>
    /// Lógica interna para WindowClientResume.xaml
    /// </summary>
    public partial class WindowClientResume : Window
    {
        private ObservableCollection<Cliente> resumeList;

        public WindowClientResume()
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
            Cliente c = getSelectedObject();
            if (c == null)
                MessageBox.Show("Necessário selecionar um registro antes de editar!", "Atenção", MessageBoxButton.OK, MessageBoxImage.Warning);
            else
                openDetail(c);
        }

        private void buttoRemove_Click(object sender, RoutedEventArgs e)
        {
            Cliente c = getSelectedObject();
            if (c == null)
                MessageBox.Show("Necessário selecionar um registro antes de remover!", "Atenção", MessageBoxButton.OK, MessageBoxImage.Warning);
            else
            {
                (new ClienteDAO()).Excluir(c);
                loadGrid();
            }
                
        }

        private void openDetail(Cliente c = null)
        {
            WindowClientDetail detail = new WindowClientDetail(c);
            detail.ShowDialog();
            loadGrid();
        }

        private Cliente getSelectedObject()
        {
            if(gridResume.SelectedIndex > -1)
                return resumeList[gridResume.SelectedIndex];
            return null;
        }

        private void loadGrid()
        {
            resumeList = (new ClienteDAO()).RetornarTodos();
            gridResume.ItemsSource = resumeList;
        }
    }
}
