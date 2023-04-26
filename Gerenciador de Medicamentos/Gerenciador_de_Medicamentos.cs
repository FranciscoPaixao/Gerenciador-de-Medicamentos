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

            //Teste de inserção de funcionário
            repositorioFuncionario.Inserir(new Funcionario(nome: "Atendente 1",cpf: "000000000-00", nomeMae: "Mãe", cargo: "Atendente", dataNascimento: new DateTime(1990, 1, 1)));
            repositorioFuncionario.Inserir(new Funcionario(nome: "Atendente 2",cpf: "111111111-11", nomeMae: "Mãe", cargo: "Atendente", dataNascimento: new DateTime(1991, 2, 2)));
            
            //Teste de inserção de paciente
            repositorioPaciente.Inserir(new Paciente(nome: "Paciente 1", cpf: "222222222-22", nomeMae: "Mãe",cartaoSUS: "3490583409636", dataNascimento: new DateTime(1992, 3, 3)));
            repositorioPaciente.Inserir(new Paciente(nome: "Paciente 2", cpf: "333333333-33", nomeMae: "Mãe",cartaoSUS: "3490583409637", dataNascimento: new DateTime(1993, 4, 4)));

            //Teste de inserção fornecedor
            repositorioFornecedor.Inserir(new Fornecedor(nome: "Fornecedor 1", cnpj: "444444444-44", telefone: "444444444", email: "fornecedor@gmail.com"));
            repositorioFornecedor.Inserir(new Fornecedor(nome: "Fornecedor 2", cnpj: "555555555-55", telefone: "555555555", email: "fornecedor2@gmai.com"));

            //Teste de inserção de remédio
            repositorioRemedio.Inserir(new Remedio(nome: "Remédio 1", descricao: "Descrição 1",quantidade: 10, idFornecedor: 0));
            repositorioRemedio.Inserir(new Remedio(nome: "Remédio 2", descricao: "Descrição 2",quantidade: 20, idFornecedor: 1));

            //Teste de inserção de atendimento
            repositorioAtendimento.Inserir(new Atendimento(idPaciente: 0, idFuncionario: 0, idRemedio: 0, dataAtendimento: new DateTime(2021, 1, 1)));
            repositorioAtendimento.Inserir(new Atendimento(idPaciente: 1, idFuncionario: 1, idRemedio: 1, dataAtendimento: new DateTime(2021, 2, 2)));

            //Teste de inserção de pedido fornecedor
            repositorioPedidoFornecedor.Inserir(new PedidoFornecedor(idFornecedor: 0, idRemedio: 0, quantidade: 1, dataPedido: new DateTime(2021, 1, 1)));
            repositorioPedidoFornecedor.Inserir(new PedidoFornecedor(idFornecedor: 1, idRemedio: 1, quantidade: 1, dataPedido: new DateTime(2021, 2, 2)));
        }
        public void MenuPrincipal(bool statusOpcao = false){
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
            Console.WriteLine("Bem vindo ao sistema de gerenciamento de medicamentos!");
            Console.WriteLine("==== MENU PRINCIPAL ====");
            Console.WriteLine(" Selecione o módulo desejado:");
            Console.WriteLine(" 1 - Menu Fornecedor");
            Console.WriteLine(" 2 - Menu Remédio");
            Console.WriteLine(" 3 - Menu Pedido Fornecedor");
            Console.WriteLine(" 4 - Menu Funcionário");
            Console.WriteLine(" 5 - Menu Paciente");
            Console.WriteLine(" 6 - Menu Atendimento");
            Console.WriteLine(" 7 - Sair do sistema");
            Console.Write("Opção: ");
            int opcao = int.Parse(Console.ReadLine());
            Console.Clear();
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
                    statusOpcao = true;
                    break;
            }
            MenuPrincipal(statusOpcao);
        }
    }
}