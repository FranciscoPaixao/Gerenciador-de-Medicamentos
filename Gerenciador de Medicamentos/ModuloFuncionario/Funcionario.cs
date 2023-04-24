using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gerenciador_de_Medicamentos.Compartilhado;

namespace Gerenciador_de_Medicamentos.ModuloFuncionario
{
    public class Funcionario : Pessoa
    {
        public string Cargo { get; set; }
        public Funcionario(int id = -1, string nome = "", string nomeMae = "", string cpf = "", string telefone = "", string email = "", string endereco = "", string cidade = "", string estado = "", string cep = "", DateTime dataNascimento = default(DateTime), string cargo = "") : base(id, nome, nomeMae, cpf, telefone, email, endereco, cidade, estado, cep, dataNascimento)
        {
            this.Cargo = cargo;
        }
    }
}