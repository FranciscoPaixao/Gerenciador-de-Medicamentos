using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gerenciador_de_Medicamentos.ModuloRemedio;
using Gerenciador_de_Medicamentos.ModuloPaciente;
using Gerenciador_de_Medicamentos.ModuloFuncionario;


namespace Gerenciador_de_Medicamentos.ModuloAtendimento
{
    public class CLIAtendimento
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
        public void MenuAtendimento()
        {
            Console.WriteLine("Menu Atendimento");
            Console.WriteLine("1 - Fazer novo atendimento");
            Console.WriteLine("2 - Histórico de atendimentos");
            Console.WriteLine("3 - Voltar ao menu principal");
            Console.WriteLine("4 - Sair do sistema");
            int opcao = int.Parse(Console.ReadLine());
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
                    Console.WriteLine("Opção inválida");
                    break;
            }
            MenuAtendimento();
        }
        public void FazerAtendimento()
        {
            Console.Clear();
            Console.WriteLine("Fazer novo atendimento");
            ListarFuncionarios("Selecione o funcionário que irá realizar o atendimento:");
            Console.Write("ID do funcionário: ");
            int idFuncionario = int.Parse(Console.ReadLine());
            ListarPacientes("Selecione o paciente que irá receber o remedio:");
            Console.Write("ID do paciente: ");
            int idPaciente = int.Parse(Console.ReadLine());
            ListarRemedios("Selecione o remedio que será retirado:");
            Console.Write("ID do remedio: ");
            int idRemedio = int.Parse(Console.ReadLine());
            Console.Write("Quantidade a ser retirada: ");
            int quantidade = int.Parse(Console.ReadLine());
            if(quantidade > repositorioRemedio.Obter(idRemedio).quantidade)
            {
                Console.WriteLine("Quantidade indisponível");
                Console.ReadKey();
                return;
            }
            if(repositorioAtendimento.Inserir(new Atendimento(idFuncionario, idPaciente, idRemedio, quantidade)))
            {
                repositorioRemedio.RetirarRemedio(idRemedio, quantidade);
                Console.WriteLine("Atendimento realizado com sucesso");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Erro ao realizar atendimento");
                Console.ReadKey();
            }
            MenuAtendimento();
        }
        public void ListarAtendimentos(string mensagem)
        {
            Console.WriteLine(mensagem);
            List<Atendimento> atendimentos = repositorioAtendimento.ObterTodos();
            foreach (Atendimento atendimento in atendimentos)
            {
                Remedio remedio = repositorioRemedio.Obter(atendimento.idRemedio);
                Funcionario funcionario = repositorioFuncionario.Obter(atendimento.idFuncionario);
                Paciente paciente = (Paciente)repositorioPaciente.Obter(atendimento.idPaciente);

                Console.WriteLine("ID: " + atendimento.id);
                Console.WriteLine("Data/Horário: " + atendimento.data);
                Console.WriteLine("Paciente: " + paciente.nome);
                Console.WriteLine("Funcionário: " + funcionario.nome);
                Console.WriteLine("Remédio retirado: " + remedio.nome);
                Console.WriteLine("Quantidade retirada: " + atendimento.quantidade);
                Console.WriteLine("====================================");
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
        public void ListarPacientes(string mensagem)
        {
            Console.WriteLine(mensagem);
            List<Paciente> pacientes = repositorioPaciente.ObterTodos().Cast<Paciente>().ToList();
            foreach (Paciente paciente in pacientes)
            {
                Console.WriteLine("Nome: " + paciente.nome);
                Console.WriteLine("CPF: " + paciente.cpf);
                Console.WriteLine("Nome da Mãe: " + paciente.nomeMae);
                Console.WriteLine("Cartão SUS: " + paciente.cartaoSUS);
                Console.WriteLine("Data de Nascimento: " + paciente.dataNascimento);
                Console.WriteLine("Endereço: " + paciente.endereco);
                Console.WriteLine("Telefone: " + paciente.telefone);
                Console.WriteLine("Email: " + paciente.email);
                Console.WriteLine("Sexo: " + paciente.sexo);
                Console.WriteLine("Peso: " + paciente.peso);
                Console.WriteLine("Altura: " + paciente.altura);
                Console.WriteLine("Tipo Sanguíneo: " + paciente.tipoSanguineo);
                Console.WriteLine("====================================");
            }
        }
        public void ListarFuncionarios(string mensagem)
        {
            List<Funcionario> funcionarios = repositorioFuncionario.ObterTodos();
            Console.WriteLine(mensagem);
            foreach (Funcionario funcionario in funcionarios)
            {
                Console.WriteLine("ID: " + funcionario.id);
                Console.WriteLine("Nome: " + funcionario.nome);
                Console.WriteLine("CPF: " + funcionario.cpf);
                Console.WriteLine("Nome da mãe: " + funcionario.nomeMae);
                Console.WriteLine("Cargo: " + funcionario.Cargo);
                Console.WriteLine("Data de nascimento: " + funcionario.dataNascimento);
                Console.WriteLine("==================================");
            }
        }
    }
}