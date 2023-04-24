using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gerenciador_de_Medicamentos.Compartilhado
{
    public class RepositorioPessoa
    {
        protected List<Pessoa> listaPessoas;
        protected int proximoId;
        public RepositorioPessoa()
        {
            proximoId = 0;
            listaPessoas = new List<Pessoa>();
        }
        public bool Inserir(Pessoa paciente)
        {
            if (checarCPFRepetido(paciente))
            {
                return false;
            }
            paciente.id = proximoId;
            listaPessoas.Add(paciente);
            proximoId++;
            return true;
        }
        public virtual bool Editar(Pessoa paciente)
        {
            int index = listaPessoas.FindIndex(p => p.id == paciente.id);
            if (index >= 0 || listaPessoas[index].id == paciente.id || checarCPFRepetido(paciente))
            {
                return false;
            }
            listaPessoas[index] = paciente;
            return true;
        }
        public bool Excluir(string cpf)
        {
            int index = listaPessoas.FindIndex(p => p.cpf == cpf);
            if (index >= 0)
            {
                listaPessoas.RemoveAt(index);
                return true;
            }
            return false;
        }
        public Pessoa Obter(string cpf)
        {
            return listaPessoas.Find(p => p.cpf == cpf);
        }
        public Pessoa Obter(int id)
        {
            return listaPessoas.Find(p => p.id == id);
        }
        public List<Pessoa> ObterTodos()
        {
            return listaPessoas;
        }
        public bool checarCPFRepetido(Pessoa paciente)
        {
            int index = listaPessoas.FindIndex(p => p.cpf == paciente.cpf);
            if (index >= 0)
            {
                return true;
            }
            return false;
        }
    }
}