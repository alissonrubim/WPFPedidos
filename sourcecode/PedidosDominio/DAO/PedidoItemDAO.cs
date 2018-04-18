using MeuFramework.DAO;
using PedidosDominio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidosDominio.DAO
{
    public class PedidoItemDAO : BaseDAO<PedidoItem>
    {
        protected override string Tabela => "pedidoitem";

        protected override string[] Campos => new string[] { "Id", "IdPedido", "IdProduto",
            "Quantidade" };

        public void PreencherItens(Pedido obj)
        {
            obj.Itens.Clear();

            var itens = Consultar("select * from pedidoitem where idpedido = @Id", obj);

            foreach (var item in itens)
                obj.Itens.Add(item);
        }

        public DbDapperCommand RetornarComandoExcluirItens(Pedido obj)
        {
            var cmd = new DbDapperCommand();

            string sql = $"delete from {Tabela} where idpedido = @Id";
            
            cmd.Sql = sql;
            cmd.Objeto = obj;

            return cmd;
        }

        public DbDapperCommand RetornarComandoInserirItem(PedidoItem obj)
        {
            var cmd = new DbDapperCommand();

            string sql = $"insert into {Tabela} ({RetornarCamposInsert(Campos)}) values ({RetornarParametrosInsert(Campos)})";

            cmd.Sql = sql;
            cmd.Objeto = obj;

            return cmd;
        }
    }
}
