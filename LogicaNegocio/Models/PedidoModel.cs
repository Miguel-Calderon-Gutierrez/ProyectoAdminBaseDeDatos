using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Models
{
    public class PedidoModel
    {
        public int NumeroPedido { get; set; }
        public string DocumentoCliente { get; set; }
        public string nombre  { get; set; }
        public int cantidad { get; set; }
        public int precio { get; set; }
        public string fechaPedido { get; set; }
        public string fechaEntrega { get; set; }
        public string Estado { get; set; }

    }
}
