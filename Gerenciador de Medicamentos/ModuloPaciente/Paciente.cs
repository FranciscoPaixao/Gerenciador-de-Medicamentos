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

        public string sexo { get; set; }
        public string tipoSanguineo { get; set; }
        public double altura { get; set; }
        public double peso { get; set; }
        
        public Paciente(int id = -1, string nome = "", string nomeMae = "", string cpf = "", string telefone = "", string email = "", string endereco = "", string cidade = "", string estado = "", string cep = "", DateTime dataNascimento = default(DateTime), string cartaoSUS = "") : base(id, nome, nomeMae, cpf, telefone, email, endereco, cidade, estado, cep, dataNascimento)
        {
            this.cartaoSUS = cartaoSUS;
        }
    }
}