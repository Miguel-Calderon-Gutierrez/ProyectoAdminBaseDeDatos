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
    public class ManejadorAlimento
    {
        Conexion conexion = Conexion.GetInstanceConexion();
        public List<TipoAlimentoModel> consultarTipoAlimento()
        {

            /* List<Parametro> lista = new List<Parametro>() {
                 new Parametro("ID","1"),
             };*/

            List<TipoAlimentoModel> list = new List<TipoAlimentoModel>();

            DataTable datos = conexion.EjecutarConsulta("consultarTipoAlimento");
            foreach (DataRow dr in datos.AsEnumerable())
            {
                list.Add(
                     new TipoAlimentoModel()
                     {
                         Id = int.Parse(dr["IDTIPO_ALIMENTO"].ToString()),
                         nombreTipoAlimento = dr["NOMBRE_TIPOALIMENTO"].ToString()                     
                     }
                    );
            }
            return list;
        }

        public List<UnidadMedidaModel> consultarUnidadMedida()
        {

            /* List<Parametro> lista = new List<Parametro>() {
                 new Parametro("ID","1"),
             };*/

            List<UnidadMedidaModel> list = new List<UnidadMedidaModel>();

            DataTable datos = conexion.EjecutarConsulta("consultarUnidadMedida");
            foreach (DataRow dr in datos.AsEnumerable())
            {
                list.Add(
                     new UnidadMedidaModel()
                     {
                         id = int.Parse(dr["IDUNIDADMEDIDA"].ToString()),
                         Unidad = dr["NOMBREUNIDADMEDIDA"].ToString()                         
                     }
                    );
            }
            return list;
        }


        public bool GuardarJson(string json)
        {
            List<Parametro> lista = new List<Parametro>() {
                new Parametro("inJSON",json),            };

            return conexion.EjecutarTransaccion("guardarFacturaAlimentoJson", lista);
        }

    }
}
