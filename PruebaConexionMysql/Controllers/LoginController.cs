using Microsoft.AspNetCore.Http;
using LogicaNegocio;
using LogicaNegocio.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using PruebaConexionMysql.Models;
using System.Web;

namespace PruebaConexionMysql.Controllers
{
  
    public class LoginController : Controller
    {
        // GET: HomeController1

        ManejadorLogin admin = new ManejadorLogin();
        public static string usuario = "";
        public static string rol = "SinRol";

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult validar(LoginModel Usuario_)
        {
            var UsuarioIngreso = admin.validarUsuario(Usuario_.correo,Usuario_.contraseña);
            if (UsuarioIngreso != null)
            {
                usuario = UsuarioIngreso.correo;
                rol = UsuarioIngreso.rol;


                System.Web.HttpContext.Current.Session.Set("nombre", "Juan");               


                MongoClient cliente = new MongoClient("mongodb://localhost:27017");
                var basededatos = cliente.GetDatabase("IngresosAlSistema");
                var coleccion = basededatos.GetCollection<MongoModel>("Movimientos");

                MongoModel mongoModel = new MongoModel()
                {
                    nombreUsuario = usuario,
                    horayfechaingreso = DateTime.Now.ToString("h:mm:ss tt")
                };

                coleccion.InsertOne(mongoModel);

                return RedirectToAction("Index","Home");
            }
            else
            {
                return RedirectToAction("Index");
            }
            
        }

        public IActionResult cerrarSesion()
        {
            usuario = "";
            rol = "SinRol";                      
           return RedirectToAction("Index", "Home");         
     
        }

        public IActionResult AuditoriaLogin()
        {
            MongoClient cliente = new MongoClient("mongodb://localhost:27017");
            var basededatos = cliente.GetDatabase("IngresosAlSistema");
            var coleccion = basededatos.GetCollection<MongoModel>("Movimientos");

            List<MongoModel> lista = coleccion.Find(d => true).ToList();

            return View(lista);
        }



    }
}
