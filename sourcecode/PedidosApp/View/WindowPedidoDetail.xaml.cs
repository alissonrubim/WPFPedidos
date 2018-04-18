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
    /// Lógica interna para WindowPedidoDetail.xaml
    /// </summary>
    public partial class WindowPedidoDetail : Window
    {
        private ObservableCollection<Cliente> clientsList;
        private Pedido currentData;

        public WindowPedidoDetail(Pedido p)
        {
            InitializeComponent();
            loadClientList();
            currentData = p;
            if (currentData != null)
                load(p);
        }

        private void load(Pedido c)
        {
            textBoxNumero.Text = c.Numero.ToString();
            if (c.Cliente == null)
                c.Cliente = (new ClienteDAO()).ConsultarPorId(Guid.Parse(c.IdCliente));
            comboBoxClient.SelectedIndex = getClientIndex(c.Cliente);
        }

        private int getClientIndex(Cliente c)
        {
            int idx = -1;
            for (var i =0; i< clientsList.Count; i++)
            {
                Cliente cc = clientsList[i];
                if (cc.Id == c.Id)
                    idx = i;
            }
            return idx;
        }

        private void loadClientList()
        {
            clientsList = (new ClienteDAO()).RetornarTodos();
            comboBoxClient.ItemsSource = clientsList;
        }

        private Cliente selectedClient()
        {
            if(comboBoxClient.SelectedIndex > -1)
                return clientsList[comboBoxClient.SelectedIndex];
            return null;
        }

        private void buttonConfirm_Click(object sender, RoutedEventArgs e)
        {
            confirm(new Pedido()
            {
                Numero = Convert.ToInt32(textBoxNumero.Text),
                Data = DateTime.Now,
                Cliente = selectedClient()
            });
        }

        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            cancel();
        }

        private void confirm(Pedido c)
        {
            if (currentData == null) {
                (new PedidoDAO()).Inserir(c);
            }
            else
            {
                currentData.Numero = c.Numero;
                currentData.Data = c.Data;
                currentData.Cliente = c.Cliente;
                (new PedidoDAO()).Alterar(currentData);
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
