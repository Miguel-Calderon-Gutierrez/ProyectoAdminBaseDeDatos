using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Models
{
    public class PersonaModel
    {
        [DisplayName("ID")]
        public int IdPersonas { get; set; }
        [DisplayName("DOCUMENTO")]
        public string documento { get; set; }
        [DisplayName("NOMBRES")]
        public string nombres { get; set; }
        public string apellidos { get; set; }

        [DisplayName("CELULAR")]
        public string telfono { get; set; }
        public string estado { get; set; }


    }
}
