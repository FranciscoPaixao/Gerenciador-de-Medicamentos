using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gerenciador_de_Medicamentos.ModuloRemedio
{
    public class Remedio
    {
        public int id { get; set;}
        public string nome { get; set;}
        public string descricao{ get; set;}
        public int quantidade{ get; set;}
        public int idFornecedor { get; set; }

        public Remedio(int id = -1, string nome = "", string descricao = "", int quantidade = -1, int idFornecedor = -1)
        {
            this.id = id;
            this.nome = nome;
            this.descricao = descricao;
            this.quantidade = quantidade;
            this.idFornecedor = idFornecedor;
        }
    }
}