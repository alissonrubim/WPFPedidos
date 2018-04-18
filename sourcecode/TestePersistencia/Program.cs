using PedidosDominio.DAO;
using PedidosDominio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestePersistencia
{
    class Program
    {
        static void Main(string[] args)
        {
            TestarConflitoPersistenciaProduto();

            InserirUmProduto();

            InserirUmCliente();

            InserirUmPedido();

            AlterarUmPedido();

            Console.WriteLine("Persistência concluída. Pressione Enter para apagar tudo: ");

            Console.ReadKey();

            ApagarTudo();

            Console.WriteLine("Tudo apagado. FIM");

            Console.ReadKey();
        }

        private static void ApagarTudo()
        {
            var pedDAO = new PedidoDAO();
            var clieDAO = new ClienteDAO();
            var prodDAO = new ProdutoDAO();

            var pedidos = pedDAO.RetornarTodos();
            var clientes = clieDAO.RetornarTodos();
            var produtos = prodDAO.RetornarTodos();

            foreach (var ped in pedidos)
                pedDAO.Excluir(ped);

            foreach (var clie in clientes)
                clieDAO.Excluir(clie);

            foreach (var prod in produtos)
                prodDAO.Excluir(prod);
        }

        private static void InserirUmProduto()
        {
            try
            {
                (new ProdutoDAO()).Inserir(new Produto { Codigo = 2, Descricao = "Produto 2", Preco = 102.34 });
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao inserir um produto: " + ex.Message);
            }
        }

        private static void InserirUmCliente()
        {
            try
            {
                (new ClienteDAO()).Inserir(new Cliente { Nome = "José da Silva", Email = "jose@dasilva.com.br" });
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao inserir um cliente: " + ex.Message);
            }
        }

        private static void AlterarUmPedido()
        {
            try
            {
                var pedido = (new PedidoDAO()).RetornarTodos().FirstOrDefault();

                var produtos = (new ProdutoDAO()).RetornarTodos();

                (new PedidoDAO()).CarregarItens(pedido);

                pedido.Itens.RemoveAt(0);

                pedido.Itens.Add(new PedidoItem { Pedido = pedido, Produto = produtos[0], Quantidade = 20 });
                pedido.Itens.Add(new PedidoItem { Pedido = pedido, Produto = produtos[produtos.Count - 1], Quantidade = 30 });
                pedido.Itens.Add(new PedidoItem { Pedido = pedido, Produto = produtos[produtos.Count - 1], Quantidade = 40 });

                (new PedidoDAO()).Alterar(pedido);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao alterar um pedido: " + ex.Message);
            }
        }

        private static void InserirUmPedido()
        {
            try
            {
                var pedido = new Pedido();

                pedido.Numero = 1;
                pedido.Data = DateTime.Now;
                pedido.Cliente = (new ClienteDAO()).RetornarTodos().FirstOrDefault();

                var produtos = (new ProdutoDAO()).RetornarTodos();

                pedido.Itens.Add(new PedidoItem { Pedido = pedido, Produto = produtos[0], Quantidade = 10 });
                pedido.Itens.Add(new PedidoItem { Pedido = pedido, Produto = produtos[produtos.Count - 1], Quantidade = 20 });

                (new PedidoDAO()).Inserir(pedido);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao inserir um pedido: " + ex.Message);
            }
        }

        private static void TestarConflitoPersistenciaProduto()
        {
            var prodDAO = new ProdutoDAO();
            var clieDAO = new ClienteDAO();
            var pediDAO = new PedidoDAO();

            //Objetos da tela de busca do usuário 1
            var produtos1 = prodDAO.RetornarTodos();

            if (produtos1.Where(x => x.Codigo == 123).Count() == 0)
            {
                prodDAO.Inserir(new Produto { Codigo = 123, Descricao = "Produto 123", Preco = 101.23 });
                produtos1 = prodDAO.RetornarTodos();
            }

            //Usuário 1 escolheu alterar o produto 123
            var p1 = produtos1.Where(x => x.Codigo == 123).FirstOrDefault();

            //Objetos da tela de busca do usuário 2
            var produtos2 = prodDAO.RetornarTodos();

            //Usuário 2 escolheu alterar o produto 123
            var p2 = produtos2.Where(x => x.Codigo == 123).FirstOrDefault();

            p1.Preco = 100;
            p2.Preco = 200;

            try
            { 
                //Usuário 2 grava primeiro
                prodDAO.Alterar(p2);
                Console.WriteLine("Usuário 2 gravou o produto 123 com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro usuário 2 NÃO conseguiu gravar (não deveria acontecer): {ex.Message}");
            }


            //Usuário 1 tenta gravar depois, mas é impedido devido a não estar com o objeto atualizado.
            try
            { 
                prodDAO.Alterar(p1);
                Console.WriteLine("Usuário 1 gravou o produto 123 com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Tudo certo -> Erro usuário 1 NÃO conseguiu gravar: {ex.Message}");
            }
        }
    }
}
