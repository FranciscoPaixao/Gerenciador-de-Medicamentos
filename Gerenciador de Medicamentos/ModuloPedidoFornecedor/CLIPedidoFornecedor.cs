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
        public MenuPedidoFornecedor MenuPedidoFornecedor()
        {
            Console.WriteLine("Menu Pedido Fornecedor");
            Console.WriteLine("1 - Fazer novo pedido ao fornecedor");
            Console.WriteLine("2 - Histórico de pedidos");
            Console.WriteLine("3 - Voltar ao menu principal");
            Console.WriteLine("4 - Sair do sistema");
            Console.WriteLine("Digite a opção desejada:");
            int opcao = int.Parse(Console.ReadLine());
            switch(opcao){
                case 1:
                    FazerPedido();
                    break;
                case 2:
                    ListarPedidos("Pedidos realizados:");
                    break;
                case 3:
                    return MenuPedidoFornecedor.MenuPrincipal;
                case 4:
                    return MenuPedidoFornecedor.Sair;
                default:
                    Console.WriteLine("Opção inválida");
                    break;
            }
        }
    }
}