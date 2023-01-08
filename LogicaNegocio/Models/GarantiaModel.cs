using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Models
{
    public class GarantiaModel
    {
        public int id_soliicitud { set; get; }
        public string documentoCliente { get; set; }
        public int IdPedido { get; set; }
        public int cantidad { get; set; }
        public string daño { get; set; }
        public string descripcion { get; set; }
        public string fechaCambio { get; set; }
        public string Estado { get; set; }

    }
}
