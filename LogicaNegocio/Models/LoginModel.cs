using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LogicaNegocio.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Las credenciales para iniciar son necesarias")]
        public String correo { get; set; }
        public String contraseña { get; set; }
        public String rol { get; set; }

    }
}
