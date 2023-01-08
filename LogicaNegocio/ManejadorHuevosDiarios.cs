using AccesoDatos;
using LogicaNegocio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio
{
    public class ManejadorHuevosDiarios
    {
        Conexion conexion = Conexion.GetInstanceConexion();
        public bool Guardar(HuevosDiariosModel huevos)
        {
            List<Parametro> lista = new List<Parametro>() {
                new Parametro("inHora",huevos.hora),
                new Parametro("inCantidad",huevos.cantidadRecolecctada),
                new Parametro("inFecha",huevos.fecha),
                new Parametro("inFuncionario",huevos.CORREO)
            };

            return conexion.EjecutarTransaccion("guardarHuevosDiarios", lista);
        }
    }
}
