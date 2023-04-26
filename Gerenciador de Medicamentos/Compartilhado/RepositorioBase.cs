using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gerenciador_de_Medicamentos.Compartilhado
{
    public class RepositorioBase
    {
        protected List<EntidadeBase> listaRegistros;
        protected int proximoId;
        public RepositorioBase()
        {
            listaRegistros = new List<EntidadeBase>();
            proximoId = 0;
        }
        public virtual bool Inserir(EntidadeBase entidadeBase)
        {
            if (verificarDadosInvalidos(entidadeBase))
            {
                return false;
            }
            entidadeBase.id = proximoId;
            listaRegistros.Add(entidadeBase);
            proximoId++;
            return true;
        }
        public virtual bool Editar(EntidadeBase entidadeBase)
        {
            int indice = listaRegistros.FindIndex(f => f.id == entidadeBase.id);
            if (indice == -1 || checarRepetidoPorID(entidadeBase))
            {
                return false;
            }
            listaRegistros[indice] = entidadeBase;
            return true;
        }
        public virtual bool ExcluirPorID(int id)
        {
            int indice = listaRegistros.FindIndex(f => f.id == id);
            if (indice == -1)
            {
                return false;
            }
            listaRegistros.RemoveAt(indice);
            return true;
        }
        public virtual bool checarRepetidoPorID(EntidadeBase entidadeBase)
        {
            return listaRegistros.Exists(e => e.id != entidadeBase.id);
        }
        public virtual bool checarRepetidoPorNome(EntidadeBase entidadeBase)
        {
            int indice = listaRegistros.FindIndex(p => p.nome == entidadeBase.nome);
            if (indice >= 0)
            {
                return true;
            }
            return false;
        }
        public virtual List<EntidadeBase> ObterTodos()
        {
            return listaRegistros;
        }
        public virtual EntidadeBase ObterPorID(int id)
        {
            return listaRegistros.Find(f => f.id == id);
        }
        public virtual bool verificarDadosInvalidos(EntidadeBase entidadeBase)
        {
            return false;
        }
    }
}