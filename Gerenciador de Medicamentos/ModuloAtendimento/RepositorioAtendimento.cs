using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gerenciador_de_Medicamentos.ModuloAtendimento
{
    public class RepositorioAtendimento
    {
        private List<Atendimento> listaAtendimentos;
        private int proximoId;
        public RepositorioAtendimento()
        {
            listaAtendimentos = new List<Atendimento>();
            proximoId = 0;
        }
        public bool Inserir(Atendimento atendimento)
        {
            if(atendimento.quantidade < 1 && atendimento.idRemedio < 0 && atendimento.idPaciente < 0 && atendimento.idFuncionario < 0)
            {
                return false;
            }
            atendimento.id = proximoId++;
            listaAtendimentos.Add(atendimento);
            return true;
        }
        public List<Atendimento> ObterTodos()
        {
            return listaAtendimentos;
        }
    }
}