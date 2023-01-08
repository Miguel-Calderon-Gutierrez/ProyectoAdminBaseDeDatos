using MySql.Data.MySqlClient;
using System.Data;

namespace AccesoDatos
{
    public class Conexion:PrototypeObject
    {

        public MySqlConnection connection;
        private static Conexion SingletonConexion;


        private Conexion() { 
        }

        public static Conexion GetInstanceConexion() {

            if (SingletonConexion==null) { 
                SingletonConexion = new Conexion();               
            }

            return SingletonConexion;

        }

        public bool Conectar() {
           
            try
            {
                string cadenaConexion = "server=localhost; database=huevosDiana; user=ADMINHUEVOSDIANA; password=admin654321;port=3306;";
                connection = new MySqlConnection(cadenaConexion);
                connection.Open();
                return true;
            }
            catch{
                return false;
            }
           
        }

        public bool DesConectar()
        {
           
            try
            {
                connection.Close();
                return true;
            }
            catch
            {
                return false;
            }

        }

        public DataTable EjecutarConsulta(string procedimiento,List<Parametro> parametros = null) {
            Conectar();

            DataTable datos = new DataTable();
            try
            {
                MySqlCommand comando = new MySqlCommand(procedimiento, connection);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                if (parametros!= null) {
                    foreach (Parametro parametro in parametros)
                    {
                        comando.Parameters.AddWithValue(parametro.Nombre, parametro.Valor);
                    }
                }                
                MySqlDataReader lector = comando.ExecuteReader();               
                datos.Load(lector);
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro al traer datos de user" + e.Message);
            }
            finally
            {
                DesConectar();
            }

            return datos;

        }


        public bool EjecutarTransaccion(string procedimiento, List<Parametro> parametros = null)
        {
            Conectar();

            try
            {
                MySqlCommand comando = new MySqlCommand(procedimiento, connection);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                if (parametros != null)
                {
                    foreach (Parametro parametro in parametros)
                    {
                        comando.Parameters.AddWithValue(parametro.Nombre, parametro.Valor);
                    }
                }
                 comando.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro al insertar datos de user" + e.Message);
                return false;
            }
            finally
            {
                DesConectar();
            }
        }


        public override object CrearClon()
        {
            return (Conexion)this.MemberwiseClone();
        }

    }
}