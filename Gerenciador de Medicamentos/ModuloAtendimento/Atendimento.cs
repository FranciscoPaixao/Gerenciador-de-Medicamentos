using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gerenciador_de_Medicamentos.ModuloAtendimento
{
    public class Atendimento
    {
        public int id { get; set; }
        public int idPaciente { get; set; }
        public int idFuncionario { get; set; }
        public int idRemedio { get; set; }
        public int quantidade { get; set; }
        public DateTime data { get; set; }
        public Atendimento(int id = -1, int idPaciente = -1, int idFuncionario = -1, int idRemedio = -1, int quantidade = 0, DateTime data = default(DateTime))
        {
            this.id = id;
            this.idPaciente = idPaciente;
            this.idFuncionario = idFuncionario;
            this.idRemedio = idRemedio;
            this.quantidade = quantidade;
            this.data = data;
        }
    }
}