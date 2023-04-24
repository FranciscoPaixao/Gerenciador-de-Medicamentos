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

    }
}