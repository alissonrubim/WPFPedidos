using MeuFramework.DAO;
using PedidosDominio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidosDominio.DAO
{
    public class PedidoDAO : BaseDAO<Pedido>
    {
        private PedidoItemDAO itemDAO = new PedidoItemDAO();

        protected override string Tabela => "pedido";

        protected override string[] Campos => new string[] { "Id", "AssinaturaAlteracao",
            "Numero", "Data", "IdCliente" };
        
        public override void Inserir(Pedido obj)
        {
            string sql = $"insert into {Tabela} ({RetornarCamposInsert()}) values" + 
                $" ({RetornarParametrosInsert()})";

            var comandos = new List<DbDapperCommand>();

            comandos.Add(baseDados.GetCommand(sql, obj));

            foreach (var item in obj.Itens)
            {
                item.Pedido = obj;
                comandos.Add(itemDAO.RetornarComandoInserirItem(item));
            }

            baseDados.Execute(comandos);
        }

        public override void Alterar(Pedido obj)
        {
            string sql = $"update {Tabela} set {RetornarCamposEParametrosUpdate()} where id=@Id and assinaturaAlteracao = @AssinaturaAlteracao";

            var comandos = new List<DbDapperCommand>();

            var cmd = baseDados.GetCommand(sql, obj);
            cmd.ControlarAlteracaoConcomitante = true;

            comandos.Add(cmd);

            comandos.Add(itemDAO.RetornarComandoExcluirItens(obj));

            foreach (var item in obj.Itens)
            {
                item.Pedido = obj;
                comandos.Add(itemDAO.RetornarComandoInserirItem(item));
            }

            baseDados.Execute(comandos);
        }

        public override void Excluir(Pedido obj)
        {
            string sql = $"delete from {Tabela} where id = @Id and assinaturaAlteracao = @AssinaturaAlteracao";

            var comandos = new List<DbDapperCommand>();

            var cmd = baseDados.GetCommand(sql, obj);
            cmd.ControlarAlteracaoConcomitante = true;

            comandos.Add(itemDAO.RetornarComandoExcluirItens(obj));

            comandos.Add(cmd);
            
            baseDados.Execute(comandos);
        }

        public void CarregarItens(Pedido obj)
        {
            itemDAO.PreencherItens(obj);
        }
    }
}
