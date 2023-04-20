using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gerenciador_de_Medicamentos.Compartilhado
{
    public class Pessoa
    {
        protected int id { get; set;}
        protected string nome { get; set; }
        protected string nomeMae { get; set; }
        protected string cpf { get; set; }
        protected string telefone { get; set; }
        protected string email { get; set; }
        protected string endereco { get; set; }
        protected string cidade { get; set; }
        protected string estado { get; set; }
        protected string cep { get; set; }
        protected string dataNascimento { get; set; }
    }
}