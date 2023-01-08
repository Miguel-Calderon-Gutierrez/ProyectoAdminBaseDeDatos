using System;
using System.ComponentModel;

namespace LogicaNegocio.Models
{
    public class ClienteModel
    {
        public int IDCLIENTEs { get; set; }

        public string contraseña { get; set; }

        public string DIRECCION { get; set; }

        public string FKROL { get; set; }

        [DisplayName("ID")]
        public int IdPersonas { get; set; }
        [DisplayName("DOCUMENTO")]
        public string documento { get; set; }
        [DisplayName("NOMBRES")]
        public string nombres { get; set; }
        public string apellidos { get; set; }

        [DisplayName("CELULAR")]
        public string telfono { get; set; }



    }
}
