using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gerenciador_de_Medicamentos.ModuloFornecedor
{
    public class RepositorioFornecedor
    {
        private List<Fornecedor> listaFornecedores;
        private int proximoId;
        public RepositorioFornecedor()
        {
            listaFornecedores = new List<Fornecedor>();
            proximoId = 0;
        }
        public bool Inserir(Fornecedor fornecedor)
        {
            if (checarFornecedorRepetido(fornecedor))
            {
                return false;
            }
            fornecedor.id = proximoId;
            listaFornecedores.Add(fornecedor);
            proximoId++;
            return true;
        }
        public bool Editar(Fornecedor fornecedor)
        {
            int indice = listaFornecedores.FindIndex(f => f.id == fornecedor.id);
            if (indice == -1 || checarFornecedorRepetido(fornecedor))
            {
                return false;
            }
            listaFornecedores[indice] = fornecedor;
            return true;
        }
        public bool Excluir(int id)
        {
            int indice = listaFornecedores.FindIndex(f => f.id == id);
            if (indice == -1)
            {
                return false;
            }
            listaFornecedores.RemoveAt(indice);
            return true;
        }
        public bool Excluir(string cnpj)
        {
            int indice = listaFornecedores.FindIndex(f => f.cnpj == cnpj);
            if (indice == -1)
            {
                return false;
            }
            listaFornecedores.RemoveAt(indice);
            return true;
        }
        public Fornecedor Obter(int id)
        {
            return listaFornecedores.Find(f => f.id == id);
        }
        public Fornecedor Obter(string cnpj)
        {
            return listaFornecedores.Find(f => f.cnpj == cnpj);
        }
        public List<Fornecedor> ObterTodos()
        {
            return listaFornecedores;
        }
        public bool checarFornecedorRepetido(Fornecedor fornecedor)
        {
            int indice = listaFornecedores.FindIndex(f => f.cnpj == fornecedor.cnpj);
            if (indice == -1)
            {
                return false;
            }
            return true;
        }
    }
}