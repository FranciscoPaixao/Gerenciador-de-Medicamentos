using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gerenciador_de_Medicamentos.ModuloRemedio
{
    public class Remedio
    {
        private string nome { get; set;}
        private string descricao{ get; set;}
        private string quantidade{ get; set;}

        public Remedio()
        {
            this.nome = "";
            this.descricao = "";
            this.quantidade = "";
        }
        public Remedio(string nome, string descricao, string quantidade)
        {
            this.nome = nome;
            this.descricao = descricao;
            this.quantidade = quantidade;
        }
    }
}