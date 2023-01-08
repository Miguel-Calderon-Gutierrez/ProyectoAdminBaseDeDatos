using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Models
{
    public class FuncionarioModel
    {
        public int ID_FUNCIONARIOS { set; get; }
        public string CONTRASENA { set; get; }
        public string CORREO { set; get; }
        public int FK_IDPERSONA { set; get; }
        public int FK_IDROL { set; get; }
    }
}
