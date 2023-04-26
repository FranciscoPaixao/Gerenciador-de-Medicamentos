using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gerenciador_de_Medicamentos.Compartilhado;

namespace Gerenciador_de_Medicamentos.ModuloPedidoFornecedor
{
    public class PedidoFornecedor : EntidadeBase
    {
        public int idRemedio { get; set; }
        public int quantidade { get; set; }
        public int idFornecedor { get; set; }
        public DateTime dataPedido { get; set; }
        public PedidoFornecedor(int id = -1, int idRemedio = -1, int quantidade = 0, int idFornecedor = -1, DateTime dataPedido = default(DateTime))  
        {
            this.id = id;
            this.idRemedio = idRemedio;
            this.quantidade = quantidade;
            this.idFornecedor = idFornecedor;
            this.dataPedido = dataPedido;
        }
    }
}