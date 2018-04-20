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
    /// Lógica interna para WindowPedidoItemDetail.xaml
    /// </summary>
    public partial class WindowPedidoItemDetail : Window
    {
        private ObservableCollection<Produto> produtosList;
        private PedidoItem currentData;
        public PedidoItem Data
        {
            get
            {
                return currentData;
            }
        }

        public WindowPedidoItemDetail(PedidoItem p)
        {
            InitializeComponent();
            loadProdutosList();
            currentData = p;
            if (currentData != null)
                load(p);
        }

        private void load(PedidoItem c)
        {
            textBoxQuantidade.Text = c.Quantidade.ToString();
            if (c.Produto == null)
                c.Produto = (new ProdutoDAO()).ConsultarPorId(Guid.Parse(c.IdProduto));
            comboBoxProduto.SelectedIndex = getProdutoIndex(c.Produto);
        }

        private int getProdutoIndex(Produto c)
        {
            int idx = -1;
            for (var i = 0; i < produtosList.Count; i++)
            {
                Produto cc = produtosList[i];
                if (cc.Id == c.Id)
                    idx = i;
            }
            return idx;
        }

        private void loadProdutosList()
        {
            produtosList = (new ProdutoDAO()).RetornarTodos();
            comboBoxProduto.ItemsSource = produtosList;
        }

        private Produto selectedProduto()
        {
            if (comboBoxProduto.SelectedIndex > -1)
                return produtosList[comboBoxProduto.SelectedIndex];
            return null;
        }

        private void buttonConfirm_Click(object sender, RoutedEventArgs e)
        {
            confirm(new PedidoItem()
            {
                Quantidade = Convert.ToInt32(textBoxQuantidade.Text),
                Produto = selectedProduto()
            });
        }

        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            cancel();
        }

        private void confirm(PedidoItem c)
        {
            if (currentData == null)
                currentData = new PedidoItem();
           
            currentData.Quantidade = c.Quantidade;
            currentData.Produto = c.Produto;
            
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
