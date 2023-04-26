using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gerenciador_de_Medicamentos.Compartilhado;

namespace Gerenciador_de_Medicamentos.ModuloFornecedor
{
    public class CLIFornecedor : CLIBase
    {
        RepositorioFornecedor repositorioFornecedor;
        public CLIFornecedor(RepositorioFornecedor repositorioFornecedor)
        {
            this.repositorioFornecedor = repositorioFornecedor;
        }
        public void MenuFornecedor(bool statusOpcao = false)
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
            Console.Clear();
            Console.WriteLine("==== Menu Fornecedor ====");
            Console.WriteLine("Escolha uma opção:");
            Console.WriteLine(" 1 - Cadastrar Fornecedor");
            Console.WriteLine(" 2 - Lista de Fornecedores");
            Console.WriteLine(" 3 - Atualizar Fornecedor");
            Console.WriteLine(" 4 - Deletar Fornecedor");
            Console.WriteLine(" 5 - Buscar Fornecedor");
            Console.WriteLine(" 6 - Voltar ao menu principal");
            Console.WriteLine(" 7 - Sair do sistema");
            Console.Write("Opção: ");
            int opcao = int.Parse(Console.ReadLine());
            Console.Clear();
            switch (opcao)
            {
                case 1:
                    CadastrarFornecedor();
                    break;
                case 2:
                    ListarFornecedores("Lista de fornecedores cadastrados no sistema:");
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
                    statusOpcao = true;
                    break;
            }
            MenuFornecedor(statusOpcao);
        }
        public void CadastrarFornecedor()
        {
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
            ListarFornecedores("Fornecedores disponíveis para exclusão: ");
            Console.WriteLine("Digite o ID do fornecedor que deseja excluir: ");
            int id = int.Parse(Console.ReadLine());
            if (repositorioFornecedor.ExcluirPorID(id))
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
            ListarFornecedores("Fornecedores disponíveis para edição: ");
            Console.Write("Digite o ID do fornecedor que deseja editar: ");
            int id = int.Parse(Console.ReadLine());
            Fornecedor fornecedor = (Fornecedor)repositorioFornecedor.ObterPorID(id);
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
            Console.WriteLine("Digite o CNPJ do fornecedor que deseja buscar: ");
            string cnpj = Console.ReadLine();
            Fornecedor fornecedor = repositorioFornecedor.ObterPorCNPJ(cnpj);
            if (fornecedor != null)
            {
                ExibirFornecedor(fornecedor);
            }
            else
            {
                Console.WriteLine("Fornecedor não encontrado!");
            }
            MenuFornecedor();
        }
    }
}