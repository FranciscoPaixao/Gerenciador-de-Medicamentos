using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gerenciador_de_Medicamentos.ModuloRemedio;
using Gerenciador_de_Medicamentos.ModuloPaciente;
using Gerenciador_de_Medicamentos.ModuloFuncionario;
using Gerenciador_de_Medicamentos.ModuloFornecedor;
using Gerenciador_de_Medicamentos.ModuloAtendimento;
using Gerenciador_de_Medicamentos.ModuloPedidoFornecedor;

namespace Gerenciador_de_Medicamentos
{
    public class Gerenciador_de_Medicamentos
    {
        private RepositorioFornecedor repositorioFornecedor;
        private CLIFornecedor cliFornecedor;

        private RepositorioRemedio repositorioRemedio;
        private CLIRemedio cliRemedio;

        private RepositorioPedidoFornecedor repositorioPedidoFornecedor;
        private CLIPedidoFornecedor cliPedidoFornecedor;

        private RepositorioFuncionario repositorioFuncionario;
        private CLIFuncionario cliFuncionario;

        private RepositorioPaciente repositorioPaciente;
        private CLIPaciente cliPaciente;

        private RepositorioAtendimento repositorioAtendimento;
        private CLIAtendimento cliAtendimento;

        public Gerenciador_de_Medicamentos()
        {
            repositorioFornecedor = new RepositorioFornecedor();
            repositorioPedidoFornecedor = new RepositorioPedidoFornecedor();
            repositorioRemedio = new RepositorioRemedio();
            repositorioFuncionario = new RepositorioFuncionario();
            repositorioPaciente = new RepositorioPaciente();
            repositorioAtendimento = new RepositorioAtendimento();

            cliFornecedor = new CLIFornecedor(repositorioFornecedor);

            cliPedidoFornecedor = new CLIPedidoFornecedor(repositorioPedidoFornecedor, repositorioFornecedor, repositorioRemedio);

            cliRemedio = new CLIRemedio(repositorioRemedio, repositorioFornecedor, repositorioPedidoFornecedor);

            cliFuncionario = new CLIFuncionario(repositorioFuncionario);

            cliPaciente = new CLIPaciente(repositorioPaciente);

            cliAtendimento = new CLIAtendimento(repositorioAtendimento, repositorioPaciente, repositorioFuncionario, repositorioRemedio);
        }
        public void MenuPrincipal(){
            Console.WriteLine("Menu Principal");
            Console.WriteLine("1 - Menu Fornecedor");
            Console.WriteLine("2 - Menu Remédio");
            Console.WriteLine("3 - Menu Pedido Fornecedor");
            Console.WriteLine("4 - Menu Funcionário");
            Console.WriteLine("5 - Menu Paciente");
            Console.WriteLine("6 - Menu Atendimento");
            Console.WriteLine("7 - Sair do sistema");
            int opcao = int.Parse(Console.ReadLine());
            switch (opcao)
            {
                case 1:
                    cliFornecedor.MenuFornecedor();
                    break;
                case 2:
                    cliRemedio.MenuRemedio();
                    break;
                case 3:
                    cliPedidoFornecedor.MenuPedidoFornecedor();
                    break;
                case 4:
                    cliFuncionario.MenuFuncionario();
                    break;
                case 5:
                    cliPaciente.MenuPaciente();
                    break;
                case 6:
                    cliAtendimento.MenuAtendimento();
                    break;
                case 7:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Opção inválida");
                    break;
            }
            MenuPrincipal();
        }
    }
}