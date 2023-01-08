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
    public class ManejadorInventario
    {
        Conexion conexion = Conexion.GetInstanceConexion();

        public List<InventarioModel> Consultar()
        {

            /* List<Parametro> lista = new List<Parametro>() {
                 new Parametro("ID","1"),
             };*/

            List<InventarioModel> list = new List<InventarioModel>();

            DataTable datos = conexion.EjecutarConsulta("CONSULTARINVENTARIO");
            foreach (DataRow dr in datos.AsEnumerable())
            {
                list.Add(
                     new InventarioModel()
                     {
                         IDINVENTARIO = int.Parse(dr["IDINVENTARIO"].ToString()),
                         TIPO = dr["TIPOINVENTARIO"].ToString(),
                         CANTIDAD = int.Parse(dr["CANTIDAD"].ToString())
                     }
                    );
            }
            return list;
        }



    }
}
