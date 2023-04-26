using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gerenciador_de_Medicamentos.ModuloAtendimento;
using Gerenciador_de_Medicamentos.ModuloFornecedor;
using Gerenciador_de_Medicamentos.ModuloFuncionario;
using Gerenciador_de_Medicamentos.ModuloPaciente;
using Gerenciador_de_Medicamentos.ModuloPedidoFornecedor;
using Gerenciador_de_Medicamentos.ModuloRemedio;

namespace Gerenciador_de_Medicamentos.Compartilhado
{
    public class CLIBase
    {
        private RepositorioFornecedor repositorioFornecedor;

        private RepositorioRemedio repositorioRemedio;

        private RepositorioPedidoFornecedor repositorioPedidoFornecedor;

        private RepositorioFuncionario repositorioFuncionario;

        private RepositorioPaciente repositorioPaciente;

        private RepositorioAtendimento repositorioAtendimento;

        public void ExibirFornecedor(Fornecedor fornecedor)
        {
            Console.WriteLine(" ID: " + fornecedor.id);
            Console.WriteLine(" Nome: " + fornecedor.nome);
            Console.WriteLine(" CNPJ: " + fornecedor.cnpj);
            Console.WriteLine(" Telefone: " + fornecedor.telefone);
            Console.WriteLine(" Email: " + fornecedor.email);
            Console.WriteLine("==================================");
        }
        public void ListarFornecedores(string mensagem = "", List<Fornecedor> listaFornecedores = null)
        {
            Console.WriteLine(mensagem);
            if (listaFornecedores == null)
            {
                listaFornecedores = this.repositorioFornecedor.ObterTodos().Cast<Fornecedor>().ToList();
            }
            if (listaFornecedores.Count == 0)
            {
                Console.WriteLine("Nenhum fornecedor cadastrado no sistema!");
                return;
            }
            foreach (var fornecedor in listaFornecedores)
            {
                ExibirFornecedor(fornecedor);
            }
        }
        public void ListarFuncionarios(string mensagem, List<Funcionario> listaFuncionarios = null)
        {
            Console.WriteLine(mensagem);
            if (listaFuncionarios == null)
            {
                listaFuncionarios = this.repositorioFuncionario.ObterTodos().Cast<Funcionario>().ToList();
            }

            if (listaFuncionarios.Count == 0)
            {
                Console.WriteLine("Nenhum funcionário cadastrado");
                return;
            }
            foreach (Funcionario funcionario in listaFuncionarios)
            {
                Console.WriteLine(" ID: " + funcionario.id);
                Console.WriteLine(" Nome: " + funcionario.nome);
                Console.WriteLine(" CPF: " + funcionario.cpf);
                Console.WriteLine(" Nome da mãe: " + funcionario.nomeMae);
                Console.WriteLine(" Cargo: " + funcionario.cargo);
                Console.WriteLine(" Data de nascimento: " + funcionario.dataNascimento);
                Console.WriteLine("==================================");
            }
        }
        public void ListarPacientes(string mensagem, List<Paciente> listaPacientes = null)
        {
            Console.WriteLine(mensagem);
            if (listaPacientes == null)
            {
                listaPacientes = repositorioPaciente.ObterTodos().Cast<Paciente>().ToList();
            }
            if (listaPacientes.Count == 0)
            {
                Console.WriteLine("Nenhum paciente cadastrado");
                return;
            }
            foreach (Paciente paciente in listaPacientes)
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
        public void ListarRemedios(string mensagem = "", List<Remedio> listaRemedios = null)
        {
            Console.WriteLine(mensagem);
            if (listaRemedios == null)
            {
                listaRemedios = this.repositorioRemedio.ObterTodos().Cast<Remedio>().ToList();
            }
            if (listaRemedios.Count == 0)
            {
                Console.WriteLine("Nenhum remédio cadastrado!");
                return;
            }
            foreach (Remedio remedio in listaRemedios)
            {
                Console.WriteLine("Nome: " + remedio.nome);
                Console.WriteLine("Descrição: " + remedio.descricao);
                Console.WriteLine("Quantidade: " + remedio.quantidade);
                Console.WriteLine();
            }
        }
        public void ListarRemediosComBaixoEstoque(List<Remedio> listaRemedios = null)
        {
            Console.WriteLine("Remédios com estoque abaixo de 5 unidades:");
            if (listaRemedios == null)
            {
                listaRemedios = repositorioRemedio.ObterTodos().Cast<Remedio>().ToList().FindAll(remedio => remedio.quantidade < 5);
            }
            else
            {
                listaRemedios = listaRemedios.FindAll(remedio => remedio.quantidade < 5);
            }
            if (listaRemedios.Count == 0)
            {
                Console.WriteLine("Não há remédios com estoque abaixo de 5 unidades");
                return;
            }
            foreach (Remedio remedio in listaRemedios)
            {
                Fornecedor fornecedor = (Fornecedor)repositorioFornecedor.ObterPorID(remedio.idFornecedor);
                Console.WriteLine(" Nome: " + remedio.nome);
                Console.WriteLine(" Descrição: " + remedio.descricao);
                Console.WriteLine(" Fornecedor: " + fornecedor.nome);
                Console.WriteLine(" Quantidade: " + remedio.quantidade);
                Console.WriteLine("==================================");
            }
        }
        public void ListarPedidosFornecedor(string mensagem = "", List<PedidoFornecedor> listaPedidosAoFornecedor = null)
        {
            Console.WriteLine(mensagem);
            if (listaPedidosAoFornecedor == null)
            {
                listaPedidosAoFornecedor = repositorioPedidoFornecedor.ObterTodos().Cast<PedidoFornecedor>().ToList();
            }
            if (listaPedidosAoFornecedor.Count == 0)
            {
                Console.WriteLine("Nenhum pedido realizado");
            }
            foreach (PedidoFornecedor pedido in listaPedidosAoFornecedor)
            {
                Remedio remedio = (Remedio)repositorioRemedio.ObterPorID(pedido.idRemedio);
                Fornecedor fornecedor = (Fornecedor)repositorioFornecedor.ObterPorID(pedido.idFornecedor);
                Console.WriteLine("ID: " + pedido.id);
                Console.WriteLine("Nome do Remédio: " + remedio.nome);
                Console.WriteLine("Nome do Fornecedor: " + fornecedor.nome);
                Console.WriteLine("Quantidade: " + pedido.quantidade);
                Console.WriteLine("Data do Pedido: " + pedido.dataPedido);
                Console.WriteLine("==================================");
            }
        }
        
        public void ListarAtendimentos(string mensagem, List<Atendimento> listaAtendimentos = null)
        {
            Console.WriteLine(mensagem);
            if(listaAtendimentos == null)
            {
                listaAtendimentos = repositorioAtendimento.ObterTodos().Cast<Atendimento>().ToList();
            }
            if(listaAtendimentos.Count == 0)
            {
                Console.WriteLine("Nenhum atendimento realizado");
                return;
            }
            foreach (Atendimento atendimento in listaAtendimentos)
            {
                Remedio remedio = (Remedio)repositorioRemedio.ObterPorID(atendimento.idRemedio);
                Funcionario funcionario = (Funcionario)repositorioFuncionario.ObterPorID(atendimento.idFuncionario);
                Paciente paciente = (Paciente)repositorioPaciente.ObterPorID(atendimento.idPaciente);

                Console.WriteLine("ID: " + atendimento.id);
                Console.WriteLine("Data/Horário: " + atendimento.dataAtendimento);
                Console.WriteLine("Paciente: " + paciente.nome);
                Console.WriteLine("Funcionário: " + funcionario.nome);
                Console.WriteLine("Remédio retirado: " + remedio.nome);
                Console.WriteLine("Quantidade retirada: " + atendimento.quantidade);
                Console.WriteLine("====================================");
            }
        }
    }
}