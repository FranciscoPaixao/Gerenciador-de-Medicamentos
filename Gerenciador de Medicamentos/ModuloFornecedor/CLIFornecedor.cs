using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gerenciador_de_Medicamentos.ModuloFornecedor
{
    public class CLIFornecedor
    {
        RepositorioFornecedor repositorioFornecedor;
        public CLIFornecedor(RepositorioFornecedor repositorioFornecedor)
        {
            this.repositorioFornecedor = repositorioFornecedor;
        }
        public void MenuFornecedor()
        {
            Console.WriteLine("1 - Cadastrar Fornecedor");
            Console.WriteLine("2 - Listar Fornecedor");
            Console.WriteLine("3 - Atualizar Fornecedor");
            Console.WriteLine("4 - Deletar Fornecedor");
            Console.WriteLine("5 - Buscar Fornecedor");
            Console.WriteLine("6 - Voltar ao menu principal");
            Console.Write("7 - Sair do sistema");
            Console.Write("Opção: ");
            int opcao = int.Parse(Console.ReadLine());
            switch (opcao)
            {
                case 1:
                    CadastrarFornecedor();
                    break;
                case 2:
                    ListaFornecedores("Lista de fornecedores cadastrados no sistema:");
                    break;
                case 3:
                    EditarFornecedor();
                    break;
                case 4:
                    ExcluirFornecedor();
                    break;
                case 5:
                    BuscarFornecedor();
                    break;
                case 6:
                    return;
                    break;
                case 7:
                    Environment.Exit(0);
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Opção inválida");
                    break;
            }
            MenuFornecedor();
        }
        public void CadastrarFornecedor()
        {
            Console.Clear();
            Fornecedor fornecedor = new Fornecedor();
            Console.WriteLine("Digite o nome do fornecedor: ");
            fornecedor.nome = Console.ReadLine();
            Console.WriteLine("Digite o CNPJ do fornecedor: ");
            fornecedor.cnpj = Console.ReadLine();
            Console.WriteLine("Digite o telefone do fornecedor: ");
            fornecedor.telefone = Console.ReadLine();
            Console.WriteLine("Digite o email do fornecedor: ");
            fornecedor.email = Console.ReadLine();
            if (repositorioFornecedor.Inserir(fornecedor))
            {
                Console.WriteLine("Fornecedor cadastrado com sucesso!");
            }
            else
            {
                Console.WriteLine("Fornecedor já cadastrado!");
            }
            MenuFornecedor();
        }
        public void ExcluirFornecedor()
        {
            Console.Clear();
            ListaFornecedores("Fornecedores disponíveis para exclusão: ");
            Console.WriteLine("Digite o ID do fornecedor que deseja excluir: ");
            int id = int.Parse(Console.ReadLine());
            if (repositorioFornecedor.Excluir(id))
            {
                Console.WriteLine("Fornecedor excluído com sucesso!");
            }
            else
            {
                Console.WriteLine("Fornecedor não encontrado!");
            }
            MenuFornecedor();
        }
        public void EditarFornecedor()
        {
            Console.Clear();
            ListaFornecedores("Fornecedores disponíveis para edição: ");
            Console.WriteLine("Digite o ID do fornecedor que deseja editar: ");
            int id = int.Parse(Console.ReadLine());
            Fornecedor fornecedor = repositorioFornecedor.Obter(id);
            if (fornecedor != null)
            {
                Console.WriteLine("Digite o nome do fornecedor: ");
                fornecedor.nome = Console.ReadLine();
                Console.WriteLine("Digite o CNPJ do fornecedor: ");
                fornecedor.cnpj = Console.ReadLine();
                Console.WriteLine("Digite o telefone do fornecedor: ");
                fornecedor.telefone = Console.ReadLine();
                Console.WriteLine("Digite o email do fornecedor: ");
                fornecedor.email = Console.ReadLine();
                if (repositorioFornecedor.Editar(fornecedor))
                {
                    Console.WriteLine("Fornecedor editado com sucesso!");
                }
                else
                {
                    Console.WriteLine("Fornecedor não encontrado!");
                }
            }
            else
            {
                Console.WriteLine("Fornecedor não encontrado!");
            }
            MenuFornecedor();
        }
        public void BuscarFornecedor()
        {
            Console.Clear();
            Console.WriteLine("Digite o CNPJ do fornecedor que deseja buscar: ");
            string cnpj = Console.ReadLine();
            Fornecedor fornecedor = repositorioFornecedor.Obter(cnpj);
            if (fornecedor != null)
            {
                Console.WriteLine("ID: " + fornecedor.id);
                Console.WriteLine("Nome: " + fornecedor.nome);
                Console.WriteLine("CNPJ: " + fornecedor.cnpj);
                Console.WriteLine("Telefone: " + fornecedor.telefone);
                Console.WriteLine("Email: " + fornecedor.email);
                Console.WriteLine("==================================");
            }
            else
            {
                Console.WriteLine("Fornecedor não encontrado!");
            }
            MenuFornecedor();
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