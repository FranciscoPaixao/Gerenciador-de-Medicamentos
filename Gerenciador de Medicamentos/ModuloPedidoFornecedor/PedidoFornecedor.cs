using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gerenciador_de_Medicamentos.ModuloPedidoFornecedor
{
    public class PedidoFornecedor
    {
        public int id { get; set; }
        public int idRemedio { get; set; }
        public int quantidade { get; set; }
        public int idFornecedor { get; set; }
        public DateTime data { get; set; }
        public PedidoFornecedor(int id = -1, int idRemedio = -1, int quantidade = 0, int idFornecedor = -1, DateTime data = default(DateTime))  
        {
            this.id = id;
            this.idRemedio = idRemedio;
            this.quantidade = quantidade;
            this.idFornecedor = idFornecedor;
            this.data = data;
        }
    }
}