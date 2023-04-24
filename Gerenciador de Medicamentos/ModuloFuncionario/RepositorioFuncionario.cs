using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gerenciador_de_Medicamentos.ModuloFuncionario
{
    public class RepositorioFuncionario
    {
        private List<Funcionario> funcionarios;
        private int proximoId;
        public RepositorioFuncionario()
        {
            funcionarios = new List<Funcionario>();
            proximoId = 0;
        }
        public bool Inserir(Funcionario funcionario)
        {
            if (checarFuncionarioRepetido(funcionario))
            {
                return false;
            }
            funcionario.id = proximoId;
            funcionarios.Add(funcionario);
            proximoId++;
            return true;
        }
        public bool Editar(Funcionario funcionario)
        {
            int index = funcionarios.FindIndex(p => p.id == funcionario.id);
            if (index >= 0 || funcionarios[index].id == funcionario.id || checarFuncionarioRepetido(funcionario))
            {
                return false;
            }
            funcionarios[index] = funcionario;
            return true;
        }
        public bool Excluir(string cpf)
        {
            int index = funcionarios.FindIndex(p => p.cpf == cpf);
            if (index >= 0)
            {
                funcionarios.RemoveAt(index);
                return true;
            }
            return false;
        }
        public bool Excluir(int id)
        {
            int index = funcionarios.FindIndex(p => p.id == id);
            if (index >= 0)
            {
                funcionarios.RemoveAt(index);
                return true;
            }
            return false;
        }
        public Funcionario Obter(string cpf)
        {
            return funcionarios.Find(p => p.cpf == cpf);
        }
        public Funcionario Obter(int id)
        {
            return funcionarios.Find(p => p.id == id);
        }
        public List<Funcionario> ObterTodos()
        {
            return funcionarios;
        }
        public bool checarFuncionarioRepetido(Funcionario funcionario)
        {
            foreach (Funcionario f in funcionarios)
            {
                if (f.nome == funcionario.nome)
                {
                    return true;
                }
            }
            return false;
        }
    }
}