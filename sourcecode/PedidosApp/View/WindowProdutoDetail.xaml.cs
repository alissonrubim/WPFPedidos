using PedidosDominio.DAO;
using PedidosDominio.Models;
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
using System.Windows.Shapes;

namespace PedidosApp.View
{
    /// <summary>
    /// Lógica interna para WindowProdutoDetail.xaml
    /// </summary>
    public partial class WindowProdutoDetail : Window
    {
        private Produto currentData;

        public WindowProdutoDetail(Produto c)
        {
            InitializeComponent();
            currentData = c;
            if (currentData != null)
                load(c);
        }

        private void buttonConfirm_Click(object sender, RoutedEventArgs e)
        {
            confirm(new Produto()
            {
                Codigo = Convert.ToInt32(textBoxCode.Text),
                Descricao = textBoxDescription.Text,
                Preco = Convert.ToDouble(textBoxPrice.Text)
            });
        }

        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            cancel();
        }

        private void load(Produto c)
        {
            textBoxCode.Text = c.Codigo.ToString();
            textBoxDescription.Text = c.Descricao;
            textBoxPrice.Text = c.Preco.ToString();
        }

        private void confirm(Produto c)
        {
            if (currentData == null)
                (new ProdutoDAO()).Inserir(c);
            else
            {
                currentData.Codigo = c.Codigo;
                currentData.Descricao = c.Descricao;
                currentData.Preco = c.Preco;
                (new ProdutoDAO()).Alterar(currentData);
            }
            this.DialogResult = true;
            this.Close();
        }

        private void cancel()
        {
            this.DialogResult = false;
            this.Close();
        }
    }
}
