using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Models
{
    public class AlimentoModel
    {
        [DisplayName("FECHA COMPRA")]
        public string fechaCompra { set; get; }
        [DisplayName("VALOR TOTAL")]
        public int valorUnidad { set; get; }
        [DisplayName("PESO")]
        public int peso { set; get; }
        [DisplayName("TIPO DE ALIMENTO")]
        public string tipoAlimento { set; get; }
        [DisplayName("UNIDAD DE MEDIDA")]
        public string unidadMedidad { set; get; }

    }
}
