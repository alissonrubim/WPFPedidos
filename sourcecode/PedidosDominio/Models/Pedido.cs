using MeuFramework.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidosDominio.Models
{
    public class Pedido : Modelo
    {
        public int Numero { get; set; }
        public DateTime Data { get; set; }
        public Cliente Cliente { get; set; }

        public string IdCliente { get => Cliente == null ? idCliente : Cliente.Id; set => idCliente = value; }
        
        public ObservableCollection<PedidoItem> Itens { get => itens; }

        private ObservableCollection<PedidoItem> itens = new ObservableCollection<PedidoItem>();
        private string idCliente = NovoGuid();

    }
}
