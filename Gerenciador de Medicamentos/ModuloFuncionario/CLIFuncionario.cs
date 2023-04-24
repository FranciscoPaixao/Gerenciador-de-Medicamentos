using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gerenciador_de_Medicamentos.ModuloFuncionario
{
    public class CLIFuncionario
    {
        private RepositorioFuncionario repositorioFuncionario;
        public CLIFuncionario(RepositorioFuncionario repositorioFuncionario)
        {
            this.repositorioFuncionario = repositorioFuncionario;
        }
        public void MenuFuncionario()
        {
            Console.WriteLine("Menu de Funcionários");
            Console.WriteLine("1 - Cadastrar Funcionário");
            Console.WriteLine("2 - Editar Funcionário");
            Console.WriteLine("3 - Excluir Funcionário");
            Console.WriteLine("4 - Listar Funcionários");
            Console.WriteLine("5 - Buscar Funcionário");
            Console.WriteLine("6 - Voltar");
            Console.Write("Opção: ");
            int opcao = int.Parse(Console.ReadLine());
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
                    break;
                default:
                    Console.WriteLine("Opção inválida");
                    break;
            }
            MenuFuncionario();
        }
        public void CadastrarFuncionario()
        {
            Funcionario funcionario = new Funcionario();
            Console.Write("Nome: ");
            funcionario.nome = Console.ReadLine();
            Console.Write("CPF: ");
            funcionario.cpf = Console.ReadLine();
            Console.Write("Nome da mãe: ");
            funcionario.nomeMae = Console.ReadLine();
            Console.Write("Cargo: ");
            funcionario.Cargo = Console.ReadLine();
            Console.Write("Data de nascimento: ");
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
            Funcionario funcionario = repositorioFuncionario.Obter(id);
            if (funcionario != null)
            {
                Console.Write("Nome: ");
                funcionario.nome = Console.ReadLine();
                Console.Write("CPF: ");
                funcionario.cpf = Console.ReadLine();
                Console.Write("Nome da mãe: ");
                funcionario.nomeMae = Console.ReadLine();
                Console.Write("Cargo: ");
                funcionario.Cargo = Console.ReadLine();
                Console.Write("Data de nascimento: ");
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
            if(repositorioFuncionario.Excluir(id))
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
            Funcionario funcionario = repositorioFuncionario.Obter(cpf);
            if (funcionario != null)
            {
                Console.WriteLine("ID: " + funcionario.id);
                Console.WriteLine("Nome: " + funcionario.nome);
                Console.WriteLine("CPF: " + funcionario.cpf);
                Console.WriteLine("Nome da mãe: " + funcionario.nomeMae);
                Console.WriteLine("Cargo: " + funcionario.Cargo);
                Console.WriteLine("Data de nascimento: " + funcionario.dataNascimento);
                Console.WriteLine("==================================");
            }
            else
            {
                Console.WriteLine("Funcionário não encontrado");
            }
            MenuFuncionario();
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
            MenuFuncionario();
        }
    }
}