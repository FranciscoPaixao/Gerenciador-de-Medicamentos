using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gerenciador_de_Medicamentos.ModuloPedidoFornecedor
{
    public class RepositorioPedidoFornecedor
    {
        private List<PedidoFornecedor> listaPedidos;
        private int proximoId;
        public RepositorioPedidoFornecedor()
        {
            this.listaPedidos = new List<PedidoFornecedor>();
            this.proximoId = 0;
        }
        public bool Inserir(PedidoFornecedor pedido)
        {
            if(checarPedidoAnteriorIgual(pedido))
            {
                return false;
            }
            pedido.id = proximoId;
            listaPedidos.Add(pedido);
            proximoId++;
            return true;
        }
        public PedidoFornecedor Obter(int id)
        {
            return listaPedidos.Find(p => p.id == id);
        }
        public List<PedidoFornecedor> ObterTodos()
        {
            return listaPedidos;
        }
        public bool checarPedidoAnteriorIgual(PedidoFornecedor pedido)
        {
            PedidoFornecedor pedidoAnterior = listaPedidos.Find(p => p.id == proximoId);
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