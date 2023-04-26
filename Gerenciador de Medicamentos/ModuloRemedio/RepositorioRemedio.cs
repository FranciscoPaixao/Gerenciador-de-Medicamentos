using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gerenciador_de_Medicamentos.Compartilhado;

namespace Gerenciador_de_Medicamentos.ModuloRemedio
{
    public class RepositorioRemedio : RepositorioBase
    {
        public override bool Inserir(EntidadeBase remedio)
        {
            if (checarRepetidoPorNome((Remedio)remedio))
            {
                if (AtualizarQuantidade(remedio.id, (remedio as Remedio).quantidade))
                {
                    return true;
                }
                return false;
            }
            remedio.id = proximoId;
            listaRegistros.Add(remedio);
            proximoId++;
            return true;
        }
        public override bool Editar(EntidadeBase remedio)
        {
            int indice = listaRegistros.FindIndex(p => p.id == remedio.id);
            if (indice >= 0 || listaRegistros[indice].id == remedio.id || checarRepetidoPorNome((Remedio)remedio))
            {
                return false;
            }
            listaRegistros[indice] = (Remedio)remedio;
            return true;
        }
        public bool AtualizarQuantidade(int id, int quantidade)
        {
            int indice = listaRegistros.FindIndex(p => p.id == id);
            if (indice >= 0)
            {
                Remedio remedio = (Remedio)listaRegistros[indice];
                remedio.quantidade += quantidade;
                return true;
            }
            return false;
        }
        public bool RetirarRemedio(int id, int quantidade)
        {
            int indice = listaRegistros.FindIndex(p => p.id == id);
            if (indice >= 0)
            {
                Remedio remedio = (Remedio)listaRegistros[indice];
                if (remedio.quantidade >= quantidade)
                {
                    remedio.quantidade += quantidade;
                    return true;
                }
            }
            return false;
        }
        public bool ExcluirPorNome(string nome)
        {
            int indice = listaRegistros.FindIndex(p => p.nome == nome);
            if (indice >= 0)
            {
                listaRegistros.RemoveAt(indice);
                return true;
            }
            return false;
        }
        public Remedio ObterPorNome(string nome)
        {
            return listaRegistros.Cast<Remedio>().ToList().Find(p => p.nome == nome);
        }
        public List<Remedio> ObterRemediosComBaixaQuantidade()
        {
            return listaRegistros.Cast<Remedio>().ToList().FindAll(p => p.quantidade < 10);
        }
    }
}