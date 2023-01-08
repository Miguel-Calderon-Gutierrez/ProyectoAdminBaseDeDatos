using LogicaNegocio;
using LogicaNegocio.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PruebaConexionMysql.Controllers
{
    public class GarantiaController : Controller
    {
        // GET: GarantiaController

        ManejadorGarantia admin = new ManejadorGarantia();

        public ActionResult Index()
        {
            List<GarantiaModel> lista = admin.Consultar();
            return View(lista);
        }

        [HttpPost]
        public ActionResult SolicitudGarantia(int numeroPedido)
        {
            ViewBag.NumeroPedido = numeroPedido;
            return View();
        }

        [HttpPost]
        public ActionResult GuardarGarantia(GarantiaModel model)
        {
            admin.GuardarGarantia(model);        

            return RedirectToAction("Index","Home");
            
        }

        public IActionResult ActualizarEstadoGarantia(int id_soliicitud, int estado) {

            admin.actualizarEstadoSolicitudGarantia(id_soliicitud,estado);

            return RedirectToAction("Index");
        }
    }
}
