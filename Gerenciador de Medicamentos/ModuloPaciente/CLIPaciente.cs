using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gerenciador_de_Medicamentos.Compartilhado;

namespace Gerenciador_de_Medicamentos.ModuloPaciente
{
    public class CLIPaciente : CLIBase
    {
        private RepositorioPaciente repositorioPaciente;

        public CLIPaciente(RepositorioPaciente repositorioPaciente)
        {
            this.repositorioPaciente = repositorioPaciente;
        }

        public void MenuPaciente(bool statusOpcao = false)
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
            Console.WriteLine("==== Menu de Pacientes ====");
            Console.WriteLine("Escolha uma opção:");
            Console.WriteLine(" 1 - Cadastrar Paciente");
            Console.WriteLine(" 2 - Editar Paciente");
            Console.WriteLine(" 3 - Excluir Paciente");
            Console.WriteLine(" 4 - Listar Pacientes");
            Console.WriteLine(" 5 - Buscar Paciente");
            Console.WriteLine(" 6 - Voltar ao menu principal");
            Console.WriteLine(" 7 - Sair do sistema");
            Console.Write("Opção: ");
            int opcao = int.Parse(Console.ReadLine());
            Console.Clear();
            switch (opcao)
            {
                case 1:
                    CadastrarPaciente();
                    break;
                case 2:
                    EditarPaciente();
                    break;
                case 3:
                    ExcluirPaciente();
                    break;
                case 4:
                    ListarPacientes("Lista de listaPacientes cadastrados no sistema:");
                    break;
                case 5:
                    BuscarPaciente();
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
            MenuPaciente(statusOpcao);
        }
        public void CadastrarPaciente()
        {
            Paciente paciente = new Paciente();
            Console.Write("Nome: ");
            paciente.nome = Console.ReadLine();
            Console.Write("CPF: ");
            paciente.cpf = Console.ReadLine();
            Console.WriteLine("Nome da mãe: ");
            paciente.nomeMae = Console.ReadLine();
            Console.Write("Cartão SUS: ");
            paciente.cartaoSUS = Console.ReadLine();
            Console.Write("Data de Nascimento: ");
            paciente.dataNascimento = DateTime.Parse(Console.ReadLine());
            /*
            Console.Write("Endereço: ");
            paciente.endereco = Console.ReadLine();
            Console.Write("Telefone: ");
            paciente.telefone = Console.ReadLine();
            Console.Write("Email: ");
            paciente.email = Console.ReadLine();
            Console.Write("Sexo: ");
            paciente.sexo = Console.ReadLine();
            Console.Write("Peso: ");
            paciente.peso = double.Parse(Console.ReadLine());
            Console.Write("Altura: ");
            paciente.altura = double.Parse(Console.ReadLine());
            Console.Write("Tipo Sanguíneo: ");
            paciente.tipoSanguineo = Console.ReadLine();
            */

            if (repositorioPaciente.Inserir(paciente))
            {
                Console.WriteLine("Paciente cadastrado com sucesso");
            }
            else
            {
                Console.WriteLine("ERRO: Paciente já cadastrado anteriormente!");
            }
            MenuPaciente();
        }
        public void EditarPaciente()
        {
            ListarPacientes("Pacientes disponíveis para edição:");
            Console.Write("Digite o CPF do paciente que deseja editar: ");
            string cpf;
            do
            {
                cpf = Console.ReadLine();
                if (cpf.Length == 11)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("CPF inválido, digite novamente: ");
                }
            } while (true);
            Paciente paciente = (Paciente)repositorioPaciente.ObterPorCPF(cpf);
            if (paciente != null)
            {
                Console.Write("Nome: ");
                paciente.nome = Console.ReadLine();
                Console.Write("CPF: ");
                paciente.cpf = Console.ReadLine();
                Console.Write("Cartão SUS: ");
                paciente.cartaoSUS = Console.ReadLine();
                Console.Write("Data de Nascimento: ");
                paciente.dataNascimento = DateTime.Parse(Console.ReadLine());
                Console.Write("Endereço: ");
                paciente.endereco = Console.ReadLine();
                Console.Write("Telefone: ");
                paciente.telefone = Console.ReadLine();
                Console.Write("Email: ");
                paciente.email = Console.ReadLine();
                Console.Write("Sexo: ");
                paciente.sexo = Console.ReadLine();
                Console.Write("Peso: ");
                paciente.peso = double.Parse(Console.ReadLine());
                Console.Write("Altura: ");
                paciente.altura = double.Parse(Console.ReadLine());
                Console.Write("Tipo Sanguíneo: ");
                paciente.tipoSanguineo = Console.ReadLine();

                if (repositorioPaciente.Editar(paciente))
                {
                    Console.WriteLine("Paciente editado com sucesso");
                }
                else
                {
                    Console.WriteLine("ERRO: Paciente não encontrado!");
                }
            }
            else
            {
                Console.WriteLine("ERRO: Paciente não encontrado!");
            }
            MenuPaciente();
        }
        public void ExcluirPaciente()
        {
            ListarPacientes("Pacientes disponíveis para exclusão: ");
            Console.Write("Digite o CPF do paciente que deseja excluir: ");
            string cpf;
            do
            {
                cpf = Console.ReadLine();
                if (cpf.Length == 11)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("CPF inválido, digite novamente: ");
                }
            } while (true);
            if (repositorioPaciente.ExcluirPorCPF(cpf))
            {
                Console.WriteLine("Paciente excluído com sucesso");
            }
            else
            {
                Console.WriteLine("ERRO: Paciente não encontrado!");
            }
            MenuPaciente();
        }
        public void BuscarPaciente()
        {
            Console.Write("Digite o CPF do paciente que deseja buscar: ");
            string cpf;
            do
            {
                cpf = Console.ReadLine();
                if (cpf.Length == 11)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("CPF inválido, digite novamente: ");
                }
            } while (true);
            Paciente paciente = (Paciente)repositorioPaciente.ObterPorCPF(cpf);
            if (paciente != null)
            {
                Console.WriteLine("Nome: " + paciente.nome);
                Console.WriteLine("CPF: " + paciente.cpf);
                Console.WriteLine("Cartão SUS: " + paciente.cartaoSUS);
                Console.WriteLine("Data de Nascimento: " + paciente.dataNascimento);
                Console.WriteLine("Endereço: " + paciente.endereco);
                Console.WriteLine("Telefone: " + paciente.telefone);
                Console.WriteLine("Email: " + paciente.email);
                Console.WriteLine("Sexo: " + paciente.sexo);
                Console.WriteLine("Peso: " + paciente.peso);
                Console.WriteLine("Altura: " + paciente.altura);
                Console.WriteLine("Tipo Sanguíneo: " + paciente.tipoSanguineo);
            }
            else
            {
                Console.WriteLine("ERRO: Paciente não encontrado!");
            }
            MenuPaciente();
        }
    }
}