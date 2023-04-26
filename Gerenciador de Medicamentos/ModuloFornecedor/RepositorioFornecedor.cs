using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gerenciador_de_Medicamentos.Compartilhado;

namespace Gerenciador_de_Medicamentos.ModuloFornecedor
{
    public class RepositorioFornecedor : RepositorioBase
    {
        public bool Excluir(string cnpj)
        {
            int indice = listaRegistros.FindIndex(f => (f as Fornecedor)?.cnpj == cnpj);
            if (indice == -1)
            {
                return false;
            }
            listaRegistros.RemoveAt(indice);
            return true;
        }
        public Fornecedor ObterPorCNPJ(string cnpj)
        {
            return listaRegistros.Find(f => (f as Fornecedor).cnpj == cnpj) as Fornecedor;
        }
    }
}