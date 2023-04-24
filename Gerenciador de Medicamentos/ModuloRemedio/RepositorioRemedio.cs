using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gerenciador_de_Medicamentos.ModuloRemedio
{
    public class RepositorioRemedio
    {
        private List<Remedio> listaRemedios;
        private int proximoId;
        public RepositorioRemedio()
        {
            this.proximoId = 0;
            this.listaRemedios = new List<Remedio>();
        }
        public bool Inserir(Remedio remedio)
        {
            if (checarRemedioRepetido(remedio))
            {
                if (remedio.quantidade > 0)
                {
                    listaRemedios.Find(p => p.nome == remedio.nome).quantidade += remedio.quantidade;
                    return true;
                }
                return false;
            }
            remedio.id = proximoId;
            listaRemedios.Add(remedio);
            proximoId++;
            return true;
        }
        public bool Editar(Remedio remedio)
        {
            int index = listaRemedios.FindIndex(p => p.id == remedio.id);
            if (index >= 0 || listaRemedios[index].id == remedio.id || checarRemedioRepetido(remedio))
            {
                return false;
            }
            listaRemedios[index] = remedio;
            return true;
        }
        public bool Excluir(string nome)
        {
            int index = listaRemedios.FindIndex(p => p.nome == nome);
            if (index >= 0)
            {
                listaRemedios.RemoveAt(index);
                return true;
            }
            return false;
        }
        public bool Excluir(int id)
        {
            int index = listaRemedios.FindIndex(p => p.id == id);
            if (index >= 0)
            {
                listaRemedios.RemoveAt(index);
                return true;
            }
            return false;
        }
        public Remedio Obter(string nome)
        {
            return listaRemedios.Find(p => p.nome == nome);
        }
        public Remedio Obter(int id)
        {
            return listaRemedios.Find(p => p.id == id);
        }
        public List<Remedio> ObterTodos()
        {
            return listaRemedios;
        }
        public List<Remedio> ObterRemediosComBaixaQuantidade()
        {
            //retornar os remedios com quantidade menor que 10
            return listaRemedios.FindAll(p => p.quantidade < 10);
        }
        public bool checarRemedioRepetido(Remedio remedio)
        {
            int index = listaRemedios.FindIndex(p => p.nome == remedio.nome);
            if (index >= 0)
            {
                return true;
            }
            return false;
        }
    }
}