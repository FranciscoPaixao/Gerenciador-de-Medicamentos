using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gerenciador_de_Medicamentos.Compartilhado;

namespace Gerenciador_de_Medicamentos.ModuloPedidoFornecedor
{
    public class RepositorioPedidoFornecedor : RepositorioBase
    {
        public override bool Inserir(EntidadeBase pedido)
        {
            if(checarPedidoAnteriorIgual((PedidoFornecedor) pedido))
            {
                return false;
            }
            pedido.id = proximoId;
            listaRegistros.Add(pedido);
            proximoId++;
            return true;
        }
        public bool checarPedidoAnteriorIgual(PedidoFornecedor pedido)
        {
            PedidoFornecedor pedidoAnterior = listaRegistros.Cast<PedidoFornecedor>().ToList().Find(p => p.id == proximoId);
            if(pedidoAnterior != null)
            {
                if(pedidoAnterior.idRemedio == pedido.idRemedio && pedidoAnterior.idFornecedor == pedido.idFornecedor && pedidoAnterior.quantidade == pedido.quantidade)
                {
                    return true;
                }
            }
            return false;
        }
    }
}