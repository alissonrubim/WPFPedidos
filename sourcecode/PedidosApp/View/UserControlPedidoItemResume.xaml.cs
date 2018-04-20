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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PedidosApp.View
{
    /// <summary>
    /// Interação lógica para UserControlPedidoItemResume.xam
    /// </summary>
    public partial class UserControlPedidoItemResume : UserControl
    {
        private ObservableCollection<PedidoItem> resumeList;
        public ObservableCollection<PedidoItem> Data
        {
            get
            {
                return resumeList;
            }
        }

        public UserControlPedidoItemResume()
        {
            InitializeComponent();
            LoadGrid(new ObservableCollection<PedidoItem>());
        }

        public void LoadGrid(ObservableCollection<PedidoItem> resumeList)
        {
            this.resumeList = resumeList;
            foreach (PedidoItem p in resumeList)
            {
                if (p.Produto == null)
                    p.Produto = (new ProdutoDAO()).ConsultarPorId(Guid.Parse(p.IdProduto));
            }
            gridResume.ItemsSource = resumeList;
        }

        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            openDetail(null);
        }

        private void buttoRemove_Click(object sender, RoutedEventArgs e)
        {
            PedidoItem c = getSelectedObject();
            if (c == null)
                MessageBox.Show("Necessário selecionar um registro antes de remover!", "Atenção", MessageBoxButton.OK, MessageBoxImage.Warning);
            else
            {
                resumeList.Remove(c);
                LoadGrid(resumeList);
            }
        }

        private void openDetail(PedidoItem c = null)
        {
            WindowPedidoItemDetail detail = new WindowPedidoItemDetail(c);
            if (detail.ShowDialog() == true)
            {
                resumeList.Add(detail.Data);
            }
            LoadGrid(resumeList);
        }

        private PedidoItem getSelectedObject()
        {
            if (gridResume.SelectedIndex > -1)
                return resumeList[gridResume.SelectedIndex];
            return null;
        }
    }
}
