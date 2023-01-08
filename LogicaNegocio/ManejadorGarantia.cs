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
    public class ManejadorGarantia
    {
        Conexion conexion = Conexion.GetInstanceConexion();
        public bool GuardarGarantia(GarantiaModel model)
        {
            List<Parametro> lista = new List<Parametro>() {
                new Parametro("inPedido",model.IdPedido),
                new Parametro("inDano",model.daño),
                new Parametro("inDescripcion",model.descripcion),
                new Parametro("inCantidad",model.cantidad),
            };

            return conexion.EjecutarTransaccion("guardarSolicitudGarantia", lista);
        }

        public List<GarantiaModel> Consultar()
        {

            /* List<Parametro> lista = new List<Parametro>() {
                 new Parametro("ID","1"),
             };*/

            List<GarantiaModel> list = new List<GarantiaModel>();

            DataTable datos = conexion.EjecutarConsulta("consultarSolicitudesGarantia");
            foreach (DataRow dr in datos.AsEnumerable())
            {
                list.Add(
                     new GarantiaModel()
                     {
                         id_soliicitud = int.Parse(dr["IDSOLICITUD_GARANTIA"].ToString()),
                         documentoCliente = dr["DOCUMENTO"].ToString(),
                         IdPedido = int.Parse(dr["IDPEDIDOS"].ToString()),
                         cantidad = int.Parse(dr["CANTHUEVOSGARANTIA"].ToString()),
                         daño = dr["TIPO_DANO"].ToString(),
                         descripcion = dr["DESCRIPCION_GARANTIA"].ToString(),
                         fechaCambio = dr["FECHA_CAMBIO"].ToString(),
                         Estado = dr["NOMBRE_ESTADO"].ToString()
                     }
                    );
            }
            return list;
        }

        public bool actualizarEstadoSolicitudGarantia(int idSolicitud,int idEstado)
        {
            List<Parametro> lista = new List<Parametro>() {
                new Parametro("idSolicitud",idSolicitud),
                new Parametro("idEstado",idEstado),
            };

            return conexion.EjecutarTransaccion("actualizarEstadoSolicitudGarantia", lista);
        }



    }
}
