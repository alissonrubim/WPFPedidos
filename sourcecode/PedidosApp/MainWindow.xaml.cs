using PedidosApp.View;
using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PedidosApp
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void manuItemClientCRUD_Click(object sender, RoutedEventArgs e)
        {
            WindowClientResume resume = new WindowClientResume();
            resume.ShowDialog();
        }

        private void menuItemProdutoCRUD_Click(object sender, RoutedEventArgs e)
        {
            WindowProdutoResume resume = new WindowProdutoResume();
            resume.ShowDialog();
        }

        private void menuItemPedidoCRUD_Click(object sender, RoutedEventArgs e)
        {
            WindowPedidoResume resume = new WindowPedidoResume();
            resume.ShowDialog();
        }
    }
}
