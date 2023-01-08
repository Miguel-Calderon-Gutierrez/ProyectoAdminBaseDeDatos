using AccesoDatos;
using LogicaNegocio.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Web.Mvc;




namespace LogicaNegocio
{
    public class ManejadorPersonas
    {
        Conexion conexion = Conexion.GetInstanceConexion();


        public List<PersonaModel> Consultar()
        {

            /* List<Parametro> lista = new List<Parametro>() {
                 new Parametro("ID","1"),
             };*/

            List<PersonaModel> list = new List<PersonaModel>();

            DataTable datos = conexion.EjecutarConsulta("consultarPersonas");
            foreach (DataRow dr in datos.AsEnumerable())
            {
                list.Add(
                     new PersonaModel()
                     {
                         IdPersonas = int.Parse(dr["IDPERSONAS"].ToString()),
                         documento = dr["DOCUMENTO"].ToString(),
                         nombres = dr["NOMBRES"].ToString(),
                         apellidos = dr["APELLIDOS"].ToString(),
                         telfono = dr["TELEFONO"].ToString(),
                         estado = dr["ESTADO"].ToString()
                     }
                    );
            }
            return list;
        }

        public bool Guardar(PersonaModel persona)
        {
            List<Parametro> lista = new List<Parametro>() {
                new Parametro("indocumento",persona.documento),
                new Parametro("innombres",persona.nombres),
                new Parametro("inapellidos",persona.apellidos),
                new Parametro("intelefono",persona.telfono)
            };

            return conexion.EjecutarTransaccion("guardarPersona", lista);
        }

        public bool GuardarCliente(ClienteModel infoCliente)
        {
            List<Parametro> lista = new List<Parametro>() {
                new Parametro("indocumento",infoCliente.documento),
                new Parametro("innombres",infoCliente.nombres),
                new Parametro("inapellidos",infoCliente.apellidos),
                new Parametro("intelefono",infoCliente.telfono),
                new Parametro("indireccion",infoCliente.DIRECCION),
                new Parametro("inContrasena",infoCliente.contraseña)
            };

            return conexion.EjecutarTransaccion("guardarCliente", lista);
        }

        public PersonaModel Consultar(string documento)
        {

            List<Parametro> lista = new List<Parametro>() {
                 new Parametro("indocumento",documento),
             };

            PersonaModel data = null;

            DataTable datos = conexion.EjecutarConsulta("consultarPersonaDocumento", lista);
            foreach (DataRow dr in datos.AsEnumerable())
            {
                data = new PersonaModel()
                     {
                         IdPersonas = int.Parse(dr["IDPERSONAS"].ToString()),
                         documento = dr["DOCUMENTO"].ToString(),
                         nombres = dr["NOMBRES"].ToString(),
                         apellidos = dr["APELLIDOS"].ToString(),
                         telfono = dr["TELEFONO"].ToString(),
                         estado = dr["ESTADO"].ToString()
               };
            }

            return data;
        }


        public bool GuardarEmpleado(FuncionarioModel funcionario)
        {
            List<Parametro> lista = new List<Parametro>() {
                new Parametro("inCorreo",funcionario.CORREO),
                new Parametro("inContrasena",funcionario.CONTRASENA),
                new Parametro("inRol",funcionario.FK_IDROL),
                new Parametro("inDocumento",funcionario.ID_FUNCIONARIOS)
            };

            return conexion.EjecutarTransaccion("guardarFuncionario", lista);
        }


        public List<PersonaModel> ConsultarPersonasNoFuncionarios()
        {

            /* List<Parametro> lista = new List<Parametro>() {
                 new Parametro("ID","1"),
             };*/

            List<PersonaModel> list = new List<PersonaModel>();

            DataTable datos = conexion.EjecutarConsulta("consultarPersonasDisponibles");
            foreach (DataRow dr in datos.AsEnumerable())
            {
                list.Add(
                     new PersonaModel()
                     {
                         documento = dr["DOCUMENTO"].ToString(),
                         nombres = dr["Nombre"].ToString()
                     });
            }
            return list;
        }



        public List<RolModel> ConsultarRoles()
        {

            /* List<Parametro> lista = new List<Parametro>() {
                 new Parametro("ID","1"),
             };*/

            List<RolModel> list = new List<RolModel>();

            DataTable datos = conexion.EjecutarConsulta("consultarRoles");
            foreach (DataRow dr in datos.AsEnumerable())
            {
                list.Add(
                     new RolModel()
                     {
                         Id = int.Parse(dr["IDROL"].ToString()),
                         nombreRol = dr["NOMBREROL"].ToString()
                     });
            }
            return list;
        }


    }
}
