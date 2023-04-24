using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gerenciador_de_Medicamentos.ModuloRemedio;
using Gerenciador_de_Medicamentos.ModuloFornecedor;

namespace Gerenciador_de_Medicamentos.ModuloPedidoFornecedor
{
    public class CLIPedidoFornecedor
    {
        RepositorioPedidoFornecedor repositorioPedidoFornecedor;
        RepositorioFornecedor repositorioFornecedor;
        RepositorioRemedio repositorioRemedio;
        public CLIPedidoFornecedor(RepositorioPedidoFornecedor repositorioPedidoFornecedor, RepositorioFornecedor repositorioFornecedor, RepositorioRemedio repositorioRemedio)
        {
            this.repositorioPedidoFornecedor = repositorioPedidoFornecedor;
            this.repositorioFornecedor = repositorioFornecedor;
            this.repositorioRemedio = repositorioRemedio;
        }
        public void MenuPedidoFornecedor()
        {
            Console.WriteLine("Menu Pedido Fornecedor");
            Console.WriteLine("1 - Fazer novo pedido de remédios");
            Console.WriteLine("2 - Histórico de pedidos");
            Console.WriteLine("3 - Remédios com baixo estoque");
            Console.WriteLine("4 - Voltar ao menu principal");
            Console.WriteLine("5 - Sair do sistema");
            int opcao = int.Parse(Console.ReadLine());
            switch (opcao)
            {
                case 1:
                    FazerPedido();
                    break;
                case 2:
                    ListarPedidos("Pedidos realizados:");
                    break;
                case 3:
                    ListarRemediosComBaixoEstoque();
                    break;
                case 4:
                    return;
                    break;
                case 5:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Opção inválida");
                    break;
            }
            MenuPedidoFornecedor();
        }
        public void FazerPedido()
        {
            Console.Clear();
            PedidoFornecedor novoPedido = new PedidoFornecedor();
            ListaFornecedores("Selecione um do(s) fornecedore(s) cadastrado(s) no sistema:");
            Console.WriteLine("Digite o ID do fornecedor:");
            int idFornecedor = int.Parse(Console.ReadLine());
            ListarRemedios("Selecione um do(s) remédio(s) cadastrado(s) no sistema:");
            Console.WriteLine("Digite o ID do remédio:");
            int idRemedio = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite a quantidade do remédio:");
            int quantidade = int.Parse(Console.ReadLine());

            novoPedido.idFornecedor = idFornecedor;
            novoPedido.idRemedio = idRemedio;
            novoPedido.quantidade = quantidade;
            novoPedido.data = DateTime.Now;


            repositorioPedidoFornecedor.Inserir(novoPedido);
            repositorioRemedio.AtualizarQuantidade(idRemedio, quantidade);
            Console.WriteLine("Pedido realizado com sucesso!");
            MenuPedidoFornecedor();
        }
        public void ListarRemediosComBaixoEstoque()
        {
            Console.Clear();
            Console.WriteLine("Remédios com estoque abaixo de 5 unidades:");
            List<Remedio> remedios = repositorioRemedio.ObterTodos();
            foreach (Remedio remedio in remedios)
            {
                if (remedio.quantidade < 5)
                {
                    Fornecedor fornecedor = repositorioFornecedor.Obter(remedio.idFornecedor);
                    Console.WriteLine("Nome: " + remedio.nome);
                    Console.WriteLine("Descrição: " + remedio.descricao);
                    Console.WriteLine("Fornecedor: " + fornecedor.nome);
                    Console.WriteLine("Quantidade: " + remedio.quantidade);
                    Console.WriteLine("==================================");
                }
            }
        }
        public void ListarPedidos(string mensagem = "")
        {
            Console.WriteLine(mensagem);
            List<PedidoFornecedor> pedidos = repositorioPedidoFornecedor.ObterTodos();
            foreach (PedidoFornecedor pedido in pedidos)
            {
                Remedio remedio = repositorioRemedio.Obter(pedido.idRemedio);
                Fornecedor fornecedor = repositorioFornecedor.Obter(pedido.idFornecedor);
                Console.WriteLine("ID: " + pedido.id);
                Console.WriteLine("Nome do Remédio: " + remedio.nome);
                Console.WriteLine("Nome do Fornecedor: " + fornecedor.nome);
                Console.WriteLine("Quantidade: " + pedido.quantidade);
                Console.WriteLine("Data: " + pedido.data);
                Console.WriteLine("==================================");
            }
        }
        public void ListarRemedios(string mensagem = "")
        {
            Console.WriteLine(mensagem);
            List<Remedio> remedios = repositorioRemedio.ObterTodos();
            foreach (Remedio remedio in remedios)
            {
                Console.WriteLine("Nome: " + remedio.nome);
                Console.WriteLine("Descrição: " + remedio.descricao);
                Console.WriteLine("Quantidade: " + remedio.quantidade);
                Console.WriteLine();
            }
        }
        public void ListaFornecedores(string mensagem = "")
        {
            Console.WriteLine(mensagem);
            List<Fornecedor> listaFornecedores = repositorioFornecedor.ObterTodos();
            foreach (var fornecedor in listaFornecedores)
            {
                Console.WriteLine("ID: " + fornecedor.id);
                Console.WriteLine("Nome: " + fornecedor.nome);
                Console.WriteLine("CNPJ: " + fornecedor.cnpj);
                Console.WriteLine("Telefone: " + fornecedor.telefone);
                Console.WriteLine("Email: " + fornecedor.email);
                Console.WriteLine("==================================");
            }
        }
    }
}