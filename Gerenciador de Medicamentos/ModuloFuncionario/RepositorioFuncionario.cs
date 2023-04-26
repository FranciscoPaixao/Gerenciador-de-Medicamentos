using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gerenciador_de_Medicamentos.Compartilhado;

namespace Gerenciador_de_Medicamentos.ModuloFuncionario
{
    public class RepositorioFuncionario : RepositorioPessoa
    {
        public override bool verificarDadosInvalidos(EntidadeBase funcioario){
            Funcionario auxFuncionario = (Funcionario)funcioario;
            if(auxFuncionario.cargo == null || auxFuncionario.cargo == ""){
                return true;
            }
            if(auxFuncionario.nome == null || auxFuncionario.nome == ""){
                return true;
            }
            if(auxFuncionario.nomeMae == null || auxFuncionario.nomeMae == ""){
                return true;
            }
            if(auxFuncionario.cpf == null || auxFuncionario.cpf == ""){
                return true;
            }
            if(auxFuncionario.dataNascimento == null || auxFuncionario.dataNascimento == default(DateTime)){
                return true;
            }
            return false;
        }
    }
}