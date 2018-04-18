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
    /// Lógica interna para WindowClientDetail.xaml
    /// </summary>
    public partial class WindowClientDetail : Window
    {
        private Cliente currentData;

        public WindowClientDetail(Cliente c)
        {
            InitializeComponent();
            currentData = c;
            if(currentData != null)            
                load(c);
        }

        private void buttonConfirm_Click(object sender, RoutedEventArgs e)
        {
            confirm(new Cliente()
            {
                Nome = textBoxName.Text,
                Email = textBoxEmail.Text
            });
        }

        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            cancel();
        }

        private void load(Cliente c)
        {
            textBoxName.Text = c.Nome;
            textBoxEmail.Text = c.Email;
        }

        private void confirm(Cliente c)
        {
            if(currentData ==  null)
                (new ClienteDAO()).Inserir(c);
            else
            {
                currentData.Nome = c.Nome;
                currentData.Email = c.Email;
                (new ClienteDAO()).Alterar(currentData);
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
