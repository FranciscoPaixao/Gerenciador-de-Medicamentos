using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gerenciador_de_Medicamentos.ModuloRemedio;
using Gerenciador_de_Medicamentos.ModuloFornecedor;
using Gerenciador_de_Medicamentos.Compartilhado;

namespace Gerenciador_de_Medicamentos.ModuloPedidoFornecedor
{
    public class CLIPedidoFornecedor : CLIBase
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
        public void MenuPedidoFornecedor(bool statusOpcao = false)
        {
            if (statusOpcao)
            {
                Console.Clear();
                Console.WriteLine("Opção inválida");
                statusOpcao = false;
                Console.ReadKey();
            }
            else
            {
                Console.ReadKey();
                Console.Clear();
            }
            Console.WriteLine("==== Menu de Pedidos a Fornecedores ====");
            Console.WriteLine("Escolha uma opção:");
            Console.WriteLine(" 1 - Fazer novo pedido de remédios");
            Console.WriteLine(" 2 - Histórico de pedidos");
            Console.WriteLine(" 3 - Remédios com baixo estoque");
            Console.WriteLine(" 4 - Voltar ao menu principal");
            Console.WriteLine(" 5 - Sair do sistema");
            Console.Write("Opção: ");
            int opcao = int.Parse(Console.ReadLine());
            Console.Clear();
            switch (opcao)
            {
                case 1:
                    FazerPedido();
                    break;
                case 2:
                    ListarPedidosFornecedor("Pedidos realizados:");
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
                    statusOpcao = true;
                    break;
            }
            MenuPedidoFornecedor(statusOpcao);
        }
        public void FazerPedido()
        {
            PedidoFornecedor novoPedido = new PedidoFornecedor();
            ListarFornecedores("Selecione um do(s) fornecedore(s) cadastrado(s) no sistema:", repositorioFornecedor.ObterTodos().Cast<Fornecedor>().ToList());
            Console.WriteLine("Digite o ID do fornecedor:");
            int idFornecedor = int.Parse(Console.ReadLine());
            ListarRemedios("Selecione um do(s) remédio(s) cadastrado(s) no sistema:", repositorioRemedio.ObterTodos().Cast<Remedio>().ToList());
            Console.WriteLine("Digite o ID do remédio:");
            int idRemedio = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite a quantidade do remédio:");
            int quantidade = int.Parse(Console.ReadLine());

            novoPedido.idFornecedor = idFornecedor;
            novoPedido.idRemedio = idRemedio;
            novoPedido.quantidade = quantidade;
            novoPedido.dataPedido = DateTime.Now;

            repositorioPedidoFornecedor.Inserir(novoPedido);
            repositorioRemedio.AtualizarQuantidade(idRemedio, quantidade);
            Console.WriteLine("Pedido realizado com sucesso!");
            MenuPedidoFornecedor();
        }
    }
}