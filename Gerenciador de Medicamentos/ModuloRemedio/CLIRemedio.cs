using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gerenciador_de_Medicamentos.Compartilhado;
using Gerenciador_de_Medicamentos.ModuloFornecedor;
using Gerenciador_de_Medicamentos.ModuloPedidoFornecedor;

namespace Gerenciador_de_Medicamentos.ModuloRemedio
{
    public class CLIRemedio : CLIBase
    {
        RepositorioRemedio repositorioRemedio;
        RepositorioFornecedor repositorioFornecedor;
        RepositorioPedidoFornecedor repositorioPedidoFornecedor;
        public CLIRemedio(RepositorioRemedio repositorioRemedio, RepositorioFornecedor repositorioFornecedor, RepositorioPedidoFornecedor repositorioPedidoFornecedor)
        {
            this.repositorioRemedio = repositorioRemedio;
            this.repositorioFornecedor = repositorioFornecedor;
            this.repositorioPedidoFornecedor = repositorioPedidoFornecedor;
        }
        public void MenuRemedio(bool statusOpcao = false)
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
            Console.WriteLine("Menu de Remédios");
            Console.WriteLine("Escolha uma opção:");
            Console.WriteLine("1 - Cadastrar Remédio");
            Console.WriteLine("2 - Editar Remédio");
            Console.WriteLine("3 - Excluir Remédio");
            Console.WriteLine("4 - Listar Remédios");
            Console.WriteLine("5 - Sair");
            int opcao = int.Parse(Console.ReadLine());
            Console.Clear();
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
                    statusOpcao = true;
                    break;
            }
            MenuRemedio(statusOpcao);
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
            ListarFornecedores("Informe o fornecedor do remédio:", repositorioFornecedor.ObterTodos().Cast<Fornecedor>().ToList());
            Console.WriteLine("Digite o ID do fornecedor:");
            remedio.idFornecedor = repositorioFornecedor.ObterPorID(int.Parse(Console.ReadLine())).id;
            if (repositorioRemedio.Inserir(remedio))
            {
                Console.WriteLine("Remédio cadastrado com sucesso!");
                repositorioPedidoFornecedor.Inserir(new PedidoFornecedor(idRemedio: repositorioRemedio.ObterPorNome(remedio.nome).id, idFornecedor: remedio.idFornecedor, quantidade: remedio.quantidade, dataPedido: DateTime.Now));
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
            Remedio remedio = repositorioRemedio.ObterPorNome(nome);
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
            if (repositorioRemedio.ExcluirPorID(id))
            {
                Console.WriteLine("Remédio excluído com sucesso!");
            }
            else
            {
                Console.WriteLine("Remédio não encontrado!");
            }
            MenuRemedio();
        }
    }
}