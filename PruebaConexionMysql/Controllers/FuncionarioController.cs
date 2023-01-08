using LogicaNegocio;
using LogicaNegocio.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PruebaConexionMysql.Controllers
{
    public class FuncionarioController : Controller
    {
        // GET: FuncionarioController

        ManejadorPersonas admin = new ManejadorPersonas();
        public ActionResult Index()
        {
            ViewBag.roles = admin.ConsultarRoles();
            ViewBag.PerDisponibles = admin.ConsultarPersonasNoFuncionarios();
            return View();
        }

        [HttpPost]
        public ActionResult CrearEmpleado(FuncionarioModel persona)
        {

            admin.GuardarEmpleado(persona);

            return RedirectToAction("Index");
      
        }

    }
}
