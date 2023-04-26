using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gerenciador_de_Medicamentos.Compartilhado
{
    public class RepositorioPessoa : RepositorioBase
    {
        public override bool Inserir(EntidadeBase pessoa)
        {
            if (checarCPFRepetido((Pessoa)pessoa))
            {
                return false;
            }
            pessoa.id = proximoId;
            listaRegistros.Add(pessoa);
            proximoId++;
            return true;
        }
        public virtual bool Editar(Pessoa pessoa)
        {
            int index = listaRegistros.FindIndex(p => p.id == pessoa.id);
            if (index >= 0 || listaRegistros[index].id == pessoa.id || checarCPFRepetido(pessoa))
            {
                return false;
            }
            listaRegistros[index] = pessoa;
            return true;
        }
        public bool ExcluirPorCPF(string cpf)
        {
            int index = listaRegistros.FindIndex(p => (p as Pessoa).cpf == cpf);
            if (index >= 0)
            {
                listaRegistros.RemoveAt(index);
                return true;
            }
            return false;
        }
        public Pessoa ObterPorCPF(string cpf)
        {
            return listaRegistros.Cast<Pessoa>().ToList().Find(p => p.cpf == cpf);
        }
        public bool checarCPFRepetido(Pessoa pessoa)
        {
            int index = listaRegistros.FindIndex(p => (p as Pessoa).cpf == pessoa.cpf);
            if (index >= 0)
            {
                return true;
            }
            return false;
        }
    }
}