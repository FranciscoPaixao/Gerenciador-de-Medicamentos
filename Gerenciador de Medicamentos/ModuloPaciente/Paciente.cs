using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gerenciador_de_Medicamentos.Compartilhado;

namespace Gerenciador_de_Medicamentos.ModuloPaciente
{
    public class Paciente : Pessoa
    {
        public string cartaoSUS { get; set; }
        public string nomeResponsavel { get; set; }
        public string cpfResponsavel { get; set; }
        public string telefoneResponsavel { get; set; }

        public Paciente(){
            this.id = 0;
            this.nome = "";
            this.nomeMae = "";
            this.cpf = "";
            this.telefone = "";
            this.email = "";
            this.endereco = "";
            this.cidade = "";
            this.estado = "";
            this.cep = "";
            this.dataNascimento = "";
            this.cartaoSUS = "";
            this.nomeResponsavel = "";
            this.cpfResponsavel = "";
            this.telefoneResponsavel = "";
        }

        public Paciente(int id, string nome, string nomeMae, string cpf, string telefone, string email, string endereco, string cidade, string estado, string cep, string dataNascimento, string cartaoSUS, string nomeResponsavel, string cpfResponsavel, string telefoneResponsavel) : base(id, nome, nomeMae, cpf, telefone, email, endereco, cidade, estado, cep, dataNascimento)
        {
            this.cartaoSUS = cartaoSUS;
            this.nomeResponsavel = nomeResponsavel;
            this.cpfResponsavel = cpfResponsavel;
            this.telefoneResponsavel = telefoneResponsavel;
        }
    }
}