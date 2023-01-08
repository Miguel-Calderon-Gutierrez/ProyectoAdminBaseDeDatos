using AccesoDatos;
using LogicaNegocio.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio
{
    public class ManejadorLogin
    {
       Conexion conexion = Conexion.GetInstanceConexion();

        public List<LoginModel> Consultar(String correo, String contrseña)
        {
            List<Parametro> lista = new List<Parametro>() {
                new Parametro("incorre",correo),
                new Parametro("incontrasena",contrseña)
            };
            
            List<LoginModel> list = new List<LoginModel>();
            DataTable datos = conexion.EjecutarConsulta("consultaLogin",lista);
            foreach (DataRow dr in datos.AsEnumerable())
            {
                list.Add(
                     new LoginModel()
                     {
                         correo = dr["CORREO"].ToString(),
                         contraseña = dr["CONTRASENA"].ToString(),
                         rol = dr["ROL"].ToString()
                     }
                    );
            }
            return list;
        }

        public LoginModel validarUsuario(String correo, String contrseña)
        {
            IEnumerable<LoginModel> listaLogin = Consultar(correo,contrseña);

            return listaLogin.Where(item => item.correo == correo && item.contraseña == contrseña).FirstOrDefault();

        }



    }
}
