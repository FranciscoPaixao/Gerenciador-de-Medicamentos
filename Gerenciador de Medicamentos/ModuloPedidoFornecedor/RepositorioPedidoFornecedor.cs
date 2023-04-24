using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gerenciador_de_Medicamentos.ModuloPedidoFornecedor
{
    public class RepositorioPedidoFornecedor
    {
        private List<Pedido> listaPedidos;
        private int proximoId;
        public RepositorioPedidoFornecedor()
        {
            this.listaPedidos = new List<Pedido>();
            this.proximoId = 0;
        }
        public bool Inserir(Pedido pedido)
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
        public Pedido Obter(int id)
        {
            return listaPedidos.Find(p => p.id == id);
        }
        public List<Pedido> ObterTodos()
        {
            return listaPedidos;
        }
        public bool checarPedidoAnteriorIgual(Pedido pedido)
        {
            Pedido pedidoAnterior = listaPedidos.Find(p => p.id == proximoId);
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