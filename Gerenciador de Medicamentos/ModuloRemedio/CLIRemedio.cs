using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gerenciador_de_Medicamentos.ModuloFornecedor;

namespace Gerenciador_de_Medicamentos.ModuloRemedio
{
    public class CLIRemedio
    {
        RepositorioRemedio repositorioRemedio;
        RepositorioFornecedor repositorioFornecedor;
        public CLIRemedio(RepositorioRemedio repositorioRemedio, RepositorioFornecedor repositorioFornecedor)
        {
            this.repositorioRemedio = repositorioRemedio;
            this.repositorioFornecedor = repositorioFornecedor;
        }
        public void MenuRemedio()
        {
            Console.WriteLine("Menu de Remédios");
            Console.WriteLine("Escolha uma opção:");
            Console.WriteLine("1 - Cadastrar Remédio");
            Console.WriteLine("2 - Editar Remédio");
            Console.WriteLine("3 - Excluir Remédio");
            Console.WriteLine("4 - Listar Remédios");
            Console.WriteLine("5 - Sair");
            int opcao = int.Parse(Console.ReadLine());
            switch (opcao)
            {
                case 1:
                    CadastrarRemedio();
                    break;
                case 2:
                    EditarRemedio();
                    break;
                case 3:
                    ExcluirRemedio();
                    break;
                case 4:
                    ListarRemedios("Remédios cadastrados:");
                    break;
                case 5:
                    break;
                default:
                    Console.WriteLine("Opção inválida");
                    break;
            }
            MenuRemedio();
        }
        public void CadastrarRemedio()
        {
            Console.WriteLine("Cadastro de Remédio");
            Remedio remedio = new Remedio();
            Console.WriteLine("Digite o nome do remédio:");
            remedio.nome = Console.ReadLine();
            Console.WriteLine("Digite a descrição do remédio:");
            remedio.descricao = Console.ReadLine();
            Console.WriteLine("Digite a quantidade do remédio:");
            remedio.quantidade = int.Parse(Console.ReadLine());
            ListaFornecedores("Informe o fornecedor do remédio:");
            Console.WriteLine("Digite o ID do fornecedor:");
            remedio.idFornecedor = repositorioFornecedor.Obter(int.Parse(Console.ReadLine())).id;
            if (repositorioRemedio.Inserir(remedio))
            {
                Console.WriteLine("Remédio cadastrado com sucesso!");
            }
            else
            {
                Console.WriteLine("Remédio já cadastrado anteriormente!");
            }
            MenuRemedio();
        }
        public void EditarRemedio()
        {
            Console.WriteLine("Edição de Remédio");
            Console.WriteLine("Digite o nome do remédio:");
            string nome = Console.ReadLine();
            Remedio remedio = repositorioRemedio.Obter(nome);
            if (remedio == null)
            {
                Console.WriteLine("Remédio não encontrado!");
                return;
            }
            Console.WriteLine("Digite o novo nome do remédio:");
            remedio.nome = Console.ReadLine();
            Console.WriteLine("Digite a nova descrição do remédio:");
            remedio.descricao = Console.ReadLine();
            Console.WriteLine("Digite a nova quantidade do remédio:");
            remedio.quantidade = int.Parse(Console.ReadLine());
            if (repositorioRemedio.Editar(remedio))
            {
                Console.WriteLine("Remédio editado com sucesso!");
            }
            else
            {
                Console.WriteLine("Remédio não encontrado!");
            }
            MenuRemedio();
        }
        public void ExcluirRemedio()
        {
            ListarRemedios("Remédios disponíveis para exclusão:");
            Console.WriteLine("Digite o ID do remédio:");
            int id = int.Parse(Console.ReadLine());
            if (repositorioRemedio.Excluir(id))
            {
                Console.WriteLine("Remédio excluído com sucesso!");
            }
            else
            {
                Console.WriteLine("Remédio não encontrado!");
            }
            MenuRemedio();
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