using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gerenciador_de_Medicamentos.Compartilhado;

namespace Gerenciador_de_Medicamentos.ModuloAtendimento
{
    public class RepositorioAtendimento : RepositorioBase
    {
        public override bool verificarDadosInvalidos(EntidadeBase atendimento)
        {
            Atendimento auxAtendimento = (Atendimento)atendimento;
            return auxAtendimento.quantidade < 1 && auxAtendimento.idRemedio < 0 && auxAtendimento.idPaciente < 0 && auxAtendimento.idFuncionario < 0;
        }
    }
}