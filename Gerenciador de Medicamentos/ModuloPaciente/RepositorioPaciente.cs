using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gerenciador_de_Medicamentos.Compartilhado;

namespace Gerenciador_de_Medicamentos.ModuloPaciente
{
    public class RepositorioPaciente : RepositorioPessoa
    {
        public void RepositorioPessoa()
        {
            proximoId = 0;
            listaPessoas = new List<Pessoa>();
        }
        public override bool Editar(Pessoa paciente)
        {
            int index = listaPessoas.FindIndex(p => p.id == paciente.id);
            // O paciente pode ter seu cartão SUS alterado, pois antigamente era possível obter mais de um cartão SUS.
            if (index >= 0 || listaPessoas[index].id == paciente.id || checarCPFRepetido(paciente)  || checarCartaoSUSRepetido((Paciente)paciente))
            {
                return false;
            }
            listaPessoas[index] = paciente;
            return true;
        }
        public bool checarCartaoSUSRepetido(Paciente paciente)
        {
            int index = listaPessoas.FindIndex(p => ((Paciente)p).cartaoSUS == paciente.cartaoSUS);
            if (index >= 0)
            {
                return true;
            }
            return false;
        }
    }

}