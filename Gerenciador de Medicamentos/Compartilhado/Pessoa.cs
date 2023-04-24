using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gerenciador_de_Medicamentos.Compartilhado
{
    public class Pessoa
    {
        public int id;
        public string nome;
        public string nomeMae;
        public string cpf;
        public string telefone;
        public string email;
        public string endereco;
        public string cidade;
        public string estado;
        public string cep;
        public DateTime dataNascimento;
        public Pessoa(int id = -1, string nome = "", string nomeMae = "", string cpf = "", string telefone = "", string email = "", string endereco = "", string cidade = "", string estado = "", string cep = "", DateTime dataNascimento = default(DateTime)){
            this.id = id;
            this.nome = nome;
            this.nomeMae = nomeMae;
            this.cpf = cpf;
            this.telefone = telefone;
            this.email = email;
            this.endereco = endereco;
            this.cidade = cidade;
            this.estado = estado;
            this.cep = cep;
            this.dataNascimento = dataNascimento;
        }
    }
}