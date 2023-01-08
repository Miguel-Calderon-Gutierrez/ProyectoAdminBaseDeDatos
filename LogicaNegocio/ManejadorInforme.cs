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
    public class ManejadorInforme
    {
        Conexion conexion = Conexion.GetInstanceConexion();

        public List<InformeModel> ConsultarDiario(String fecha)
        {
            List<Parametro> lista = new List<Parametro>() {
               new Parametro("inFecha",fecha)
            };

            List<InformeModel> list = new List<InformeModel>();
            DataTable datos = conexion.EjecutarConsulta("generarInformeDiario", lista);
            foreach (DataRow dr in datos.AsEnumerable())
            {
                list.Add(
                     new InformeModel()
                     {
                         fechaInicio = dr["FECHA"].ToString(),
                         FUNCIONARIO = dr["FUNCIONARIO"].ToString(),
                         CANTIDADRECOLECTADA = int.Parse(dr["CANTIDADRECOLECTADA"].ToString())                 
                     });
            }
            return list;
        }


        public List<InformeModel> ConsultarSemana(String fecha)
        {
            List<Parametro> lista = new List<Parametro>() {
               new Parametro("fechaFinal",fecha)
            };

            List<InformeModel> list = new List<InformeModel>();
            DataTable datos = conexion.EjecutarConsulta("generarInformeSemanal", lista);
            foreach (DataRow dr in datos.AsEnumerable())
            {
                list.Add(
                     new InformeModel()
                     {
                         fechaInicio = dr["fechaInicio"].ToString(),
                         fechaFinal = dr["fechaFinal"].ToString(),
                         FUNCIONARIO = dr["FUNCIONARIO"].ToString(),
                         CANTIDADRECOLECTADA = int.Parse(dr["CANTIDADRECOLECTADA"].ToString())
                     });
            }
            return list;
        }


        public List<InformeModel> Consultarmes(String fecha)
        {
            List<Parametro> lista = new List<Parametro>() {
               new Parametro("fechaFinal",fecha)
            };

            List<InformeModel> list = new List<InformeModel>();
            DataTable datos = conexion.EjecutarConsulta("generarInformeMensual", lista);
            foreach (DataRow dr in datos.AsEnumerable())
            {
                list.Add(
                     new InformeModel()
                     {
                         fechaInicio = dr["fechaInicio"].ToString(),
                         fechaFinal = dr["fechaFinal"].ToString(),
                         FUNCIONARIO = dr["FUNCIONARIO"].ToString(),
                         CANTIDADRECOLECTADA = int.Parse(dr["CANTIDADRECOLECTADA"].ToString())
                     });
            }
            return list;
        }


    }
}
