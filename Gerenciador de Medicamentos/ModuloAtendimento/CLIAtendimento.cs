using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gerenciador_de_Medicamentos.ModuloRemedio;
using Gerenciador_de_Medicamentos.ModuloPaciente;
using Gerenciador_de_Medicamentos.ModuloFuncionario;
using Gerenciador_de_Medicamentos.Compartilhado;

namespace Gerenciador_de_Medicamentos.ModuloAtendimento
{
    public class CLIAtendimento : CLIBase
    {
        RepositorioAtendimento repositorioAtendimento;
        RepositorioPaciente repositorioPaciente;
        RepositorioFuncionario repositorioFuncionario;
        RepositorioRemedio repositorioRemedio;

        public CLIAtendimento(RepositorioAtendimento repositorioAtendimento, RepositorioPaciente repositorioPaciente, RepositorioFuncionario repositorioFuncionario, RepositorioRemedio repositorioRemedio)
        {
            this.repositorioAtendimento = repositorioAtendimento;
            this.repositorioPaciente = repositorioPaciente;
            this.repositorioFuncionario = repositorioFuncionario;
            this.repositorioRemedio = repositorioRemedio;
        }
        public void MenuAtendimento(bool statusOpcao = false)
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
            Console.WriteLine("==== Menu de Atendimentos ====");
            Console.WriteLine("Escolha uma opção:");
            Console.WriteLine("1 - Fazer novo atendimento");
            Console.WriteLine("2 - Histórico de listaAtendimentos");
            Console.WriteLine("3 - Voltar ao menu principal");
            Console.WriteLine("4 - Sair do sistema");
            int opcao = int.Parse(Console.ReadLine());
            Console.Clear();
            switch (opcao)
            {
                case 1:
                    FazerAtendimento();
                    break;
                case 2:
                    ListarAtendimentos("Atendimentos realizados:");
                    break;
                case 3:
                    return;
                    break;
                case 4:
                    Environment.Exit(0);
                    break;
                default:
                    statusOpcao = true;
                    break;
            }
            MenuAtendimento(statusOpcao);
        }
        public void FazerAtendimento()
        {
            Console.WriteLine("Fazer novo atendimento");
            ListarFuncionarios("Selecione o funcionário que irá realizar o atendimento:");
            Console.Write("ID do funcionário: ", repositorioFuncionario.ObterTodos().Cast<Funcionario>().ToList());
            int idFuncionario = int.Parse(Console.ReadLine());
            ListarPacientes("Selecione o paciente que irá receber o remedio:", repositorioPaciente.ObterTodos().Cast<Paciente>().ToList());
            Console.Write("ID do paciente: ");
            int idPaciente = int.Parse(Console.ReadLine());
            ListarRemedios("Selecione o remedio que será retirado:", repositorioRemedio.ObterTodos().Cast<Remedio>().ToList());
            Console.Write("ID do remedio: ");
            int idRemedio = int.Parse(Console.ReadLine());
            Console.Write("Quantidade a ser retirada: ");
            int quantidade = int.Parse(Console.ReadLine());
            Remedio auxRemedio = (Remedio)repositorioRemedio.ObterPorID(idRemedio);
            if (quantidade > auxRemedio.quantidade)
            {
                Console.WriteLine("Quantidade indisponível");
                Console.ReadKey();
                return;
            }
            if (repositorioAtendimento.Inserir(new Atendimento(idFuncionario, idPaciente, idRemedio, quantidade)))
            {
                repositorioRemedio.RetirarRemedio(idRemedio, quantidade);
                Console.WriteLine("Atendimento realizado com sucesso");
            }
            else
            {
                Console.WriteLine("Erro ao realizar atendimento");
            }
            MenuAtendimento();
        }
    }
}