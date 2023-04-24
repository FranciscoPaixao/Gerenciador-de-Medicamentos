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
                if (AtualizarQuantidade(remedio.id, remedio.quantidade))
                {
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
            int indice = listaRemedios.FindIndex(p => p.id == remedio.id);
            if (indice >= 0 || listaRemedios[indice].id == remedio.id || checarRemedioRepetido(remedio))
            {
                return false;
            }
            listaRemedios[indice] = remedio;
            return true;
        }
        public bool AtualizarQuantidade(int id, int quantidade)
        {
            int indice = listaRemedios.FindIndex(p => p.id == id);
            if (indice >= 0)
            {
                listaRemedios[indice].quantidade = listaRemedios[indice].quantidade + quantidade;
                return true;
            }
            return false;
        }
        public bool RetirarRemedio(int id, int quantidade)
        {
            int indice = listaRemedios.FindIndex(p => p.id == id);
            if (indice >= 0)
            {
                if (listaRemedios[indice].quantidade >= quantidade)
                {
                    listaRemedios[indice].quantidade = listaRemedios[indice].quantidade - quantidade;
                    return true;
                }
            }
            return false;
        }
        public bool Excluir(string nome)
        {
            int indice = listaRemedios.FindIndex(p => p.nome == nome);
            if (indice >= 0)
            {
                listaRemedios.RemoveAt(indice);
                return true;
            }
            return false;
        }
        public bool Excluir(int id)
        {
            int indice = listaRemedios.FindIndex(p => p.id == id);
            if (indice >= 0)
            {
                listaRemedios.RemoveAt(indice);
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
            int indice = listaRemedios.FindIndex(p => p.nome == remedio.nome);
            if (indice >= 0)
            {
                return true;
            }
            return false;
        }
    }
}