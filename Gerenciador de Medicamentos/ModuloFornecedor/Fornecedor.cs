using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gerenciador_de_Medicamentos.ModuloFornecedor
{
    public class Fornecedor
    {
        public int id {get; set;}
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