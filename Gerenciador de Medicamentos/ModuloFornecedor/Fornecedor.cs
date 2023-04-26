using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gerenciador_de_Medicamentos.Compartilhado;
namespace Gerenciador_de_Medicamentos.ModuloFornecedor
{
    public class Fornecedor : EntidadeBase
    {
        public string nome {get; set;}
        public string cnpj {get; set;}
        public string telefone {get; set;}
        public string email {get; set;}
        public Fornecedor(int id = -1, string nome = "", string cnpj = "", string telefone = "", string email = "")
        {
            this.id = id;
            this.nome = nome;
            this.cnpj = cnpj;
            this.telefone = telefone;
            this.email = email;
        }
    }
}