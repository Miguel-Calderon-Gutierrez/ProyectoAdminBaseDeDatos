using LogicaNegocio;
using LogicaNegocio.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PruebaConexionMysql.Controllers
{
    public class RecoleccionController : Controller
    {
        // GET: RecoleccionController
        ManejadorHuevosDiarios admin = new ManejadorHuevosDiarios();

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RegistrarRecolecion(HuevosDiariosModel model) {
            model.CORREO = LoginController.usuario;

            admin.Guardar(model);
            return RedirectToAction("Index");
        }

    }
}
