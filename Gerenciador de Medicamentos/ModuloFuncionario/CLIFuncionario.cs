using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gerenciador_de_Medicamentos.Compartilhado;

namespace Gerenciador_de_Medicamentos.ModuloFuncionario
{
    public class CLIFuncionario : CLIBase
    {
        private RepositorioFuncionario repositorioFuncionario;
        public CLIFuncionario(RepositorioFuncionario repositorioFuncionario)
        {
            this.repositorioFuncionario = repositorioFuncionario;
        }
        public void MenuFuncionario(bool statusOpcao = false)
        {
            if (statusOpcao)
            {
                Console.Clear();
                Console.WriteLine("Opção inválida");
                statusOpcao = false;
                Console.ReadKey();
            }else{ 
                Console.ReadKey();
                Console.Clear();
            }
            Console.WriteLine("==== Menu de Funcionários ====");
            Console.WriteLine("Escolha uma opção:");
            Console.WriteLine(" 1 - Cadastrar Funcionário");
            Console.WriteLine(" 2 - Editar Funcionário");
            Console.WriteLine(" 3 - Excluir Funcionário");
            Console.WriteLine(" 4 - Listar Funcionários");
            Console.WriteLine(" 5 - Buscar Funcionário");
            Console.WriteLine(" 6 - Voltar ao menu principal");
            Console.WriteLine(" 7 - Sair do sistema");
            Console.Write("Opção: ");
            int opcao = int.Parse(Console.ReadLine());
            Console.Clear();
            switch (opcao)
            {
                case 1:
                    CadastrarFuncionario();
                    break;
                case 2:
                    EditarFuncionario();
                    break;
                case 3:
                    ExcluirFuncionario();
                    break;
                case 4:
                    ListarFuncionarios("Lista de funcionários cadastrados no sistema:");
                    break;
                case 5:
                    BuscarFuncionario();
                    break;
                case 6:
                    return;
                    break;
                case 7:
                    Environment.Exit(0);
                    break;
                default:
                    statusOpcao = true;
                    break;
            }
            MenuFuncionario(statusOpcao);
        }
        public void CadastrarFuncionario()
        {
            Funcionario funcionario = new Funcionario();
            Console.WriteLine("=== Cadastro de Funcionário ===");
            Console.WriteLine("Digite as informações do funcionário:");
            Console.Write(" Nome: ");
            funcionario.nome = Console.ReadLine();
            Console.Write(" CPF: ");
            funcionario.cpf = Console.ReadLine();
            Console.Write(" Nome da mãe: ");
            funcionario.nomeMae = Console.ReadLine();
            Console.Write(" cargo: ");
            funcionario.cargo = Console.ReadLine();
            Console.Write(" Data de nascimento: ");
            funcionario.dataNascimento = DateTime.Parse(Console.ReadLine());
            if (repositorioFuncionario.Inserir(funcionario))
            {
                Console.WriteLine("Funcionário cadastrado com sucesso!");
            }
            else
            {
                Console.WriteLine("Erro ao cadastrar funcionário");
            }
            MenuFuncionario();
        }
        public void EditarFuncionario()
        {
            ListarFuncionarios("Lista de funcionários cadastrados no sistema:");
            Console.Write("Digite o ID do funcionário que deseja editar: ");
            int id = int.Parse(Console.ReadLine());
            Funcionario funcionario = (Funcionario)repositorioFuncionario.ObterPorID(id);
            if (funcionario != null)
            {
                Console.Write(" Nome: ");
                funcionario.nome = Console.ReadLine();
                Console.Write(" CPF: ");
                funcionario.cpf = Console.ReadLine();
                Console.Write(" Nome da mãe: ");
                funcionario.nomeMae = Console.ReadLine();
                Console.Write(" cargo: ");
                funcionario.cargo = Console.ReadLine();
                Console.Write(" Data de nascimento: ");
                funcionario.dataNascimento = DateTime.Parse(Console.ReadLine());
                if (repositorioFuncionario.Editar(funcionario))
                {
                    Console.WriteLine("Funcionário editado com sucesso!");
                }
                else
                {
                    Console.WriteLine("Erro ao editar funcionário");
                }
            }
            else
            {
                Console.WriteLine("Funcionário não encontrado");
            }
            MenuFuncionario();
        }
        public void ExcluirFuncionario()
        {
            ListarFuncionarios("Lista de funcionários cadastrados no sistema:");
            Console.Write("Digite o ID do funcionário que deseja excluir: ");
            int id = int.Parse(Console.ReadLine());
            if (repositorioFuncionario.ExcluirPorID(id))
            {
                Console.WriteLine("Funcionário excluído com sucesso!");
            }
            else
            {
                Console.WriteLine("Erro ao excluir funcionário");
            }
            MenuFuncionario();
        }
        public void BuscarFuncionario()
        {
            Console.Write("Digite o CPF do funcionário que deseja buscar: ");
            string cpf = Console.ReadLine();
            Funcionario funcionario = (Funcionario)repositorioFuncionario.ObterPorCPF(cpf);
            if (funcionario != null)
            {
                Console.WriteLine(" ID: " + funcionario.id);
                Console.WriteLine(" Nome: " + funcionario.nome);
                Console.WriteLine(" CPF: " + funcionario.cpf);
                Console.WriteLine(" Nome da mãe: " + funcionario.nomeMae);
                Console.WriteLine(" Cargo: " + funcionario.cargo);
                Console.WriteLine(" Data de nascimento: " + funcionario.dataNascimento);
                Console.WriteLine("==================================");
            }
            else
            {
                Console.WriteLine("Funcionário não encontrado");
            }
            MenuFuncionario();
        }
    }
}