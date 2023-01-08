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
    public class ManejadorPedido
    {
        Conexion conexion = Conexion.GetInstanceConexion();
        public List<PedidoModel> Consultar()
        {

            /* List<Parametro> lista = new List<Parametro>() {
                 new Parametro("ID","1"),
             };*/

            List<PedidoModel> list = new List<PedidoModel>();

            DataTable datos = conexion.EjecutarConsulta("consultarClientesDeben");
            foreach (DataRow dr in datos.AsEnumerable())
            {
                list.Add(
                     new PedidoModel()
                     {
                         NumeroPedido = int.Parse(dr["NumeroPedido"].ToString()),
                         DocumentoCliente = dr["DocumentoCliente"].ToString(),
                         nombre = dr["nombre"].ToString(),
                         cantidad = int.Parse(dr["cantidad"].ToString()),
                         precio = int.Parse(dr["precio"].ToString()),
                         fechaPedido = dr["fechaPedido"].ToString(),
                         fechaEntrega = dr["fechaEntrega"].ToString(),
                         Estado = dr["Estado"].ToString()
                     }
                    );
            }
            return list;
        }

        public List<PedidoModel> ConsultarPedidosPendientes()
        {

            /* List<Parametro> lista = new List<Parametro>() {
                 new Parametro("ID","1"),
             };*/

            List<PedidoModel> list = new List<PedidoModel>();

            DataTable datos = conexion.EjecutarConsulta("ConsultarPedidosPendientes");
            foreach (DataRow dr in datos.AsEnumerable())
            {
                list.Add(
                     new PedidoModel()
                     {
                         NumeroPedido = int.Parse(dr["IDPEDIDOS"].ToString()),
                         nombre = dr["infoCliente"].ToString(),
                         cantidad = int.Parse(dr["CANTPANALES"].ToString()),
                         precio = int.Parse(dr["PRECIO_PEDIDO"].ToString()),
                         fechaPedido = dr["FECHAPEDIDO"].ToString(),
                         fechaEntrega = dr["FECHAENTREGA"].ToString(),
                         Estado = dr["NOMBRE_ESTADO_PEDIDO"].ToString()
                     }
                    );
            }
            return list;
        }

        public List<PedidoModel> ConsultarPedidosDocumento(string documento)
        {

             List<Parametro> lista = new List<Parametro>() {
                 new Parametro("inDocumento",documento),
             };

            List<PedidoModel> list = new List<PedidoModel>();

            DataTable datos = conexion.EjecutarConsulta("consultarPedidoscliente",lista);
            foreach (DataRow dr in datos.AsEnumerable())
            {
                list.Add(
                     new PedidoModel()
                     {
                         NumeroPedido = int.Parse(dr["IDPEDIDOS"].ToString()),
                         cantidad = int.Parse(dr["CANTPANALES"].ToString()),
                         precio = int.Parse(dr["PRECIO_PEDIDO"].ToString()),
                         fechaPedido = dr["FECHAPEDIDO"].ToString(),
                         fechaEntrega = dr["FECHAENTREGA"].ToString(),
                         Estado = dr["NOMBRE_ESTADO_PEDIDO"].ToString()
                     }
                    ); 
            }
            return list;
        }



        public bool CambiarEstadoPago(int idPedido)
        {
            List<Parametro> lista = new List<Parametro>() {
                new Parametro("idPedido",idPedido),
            };

            return conexion.EjecutarTransaccion("actualizarClienteDebe", lista);
        }

        public bool GuardarPedido(PedidoModel pedido)
        {
            List<Parametro> lista = new List<Parametro>() {
                new Parametro("inCantidad",pedido.cantidad),
                new Parametro("inFecha",pedido.fechaPedido),
                new Parametro("inDocumentoCliente",pedido.nombre)
            };

            return conexion.EjecutarTransaccion("guardarPedido", lista);
        }


        public bool ActualizarPedidoPendiente(PedidoModel pedido)
        {
            List<Parametro> lista = new List<Parametro>() {
                new Parametro("idPedido",pedido.NumeroPedido),
                new Parametro("inCorreoFuncionario",pedido.DocumentoCliente)
            };

            return conexion.EjecutarTransaccion("actualizarPedidoPendiente", lista);
        }



    }
}
