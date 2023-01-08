using LogicaNegocio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PruebaConexionMysql.Controllers
{
    public class AlimentoController : Controller
    {
        ManejadorAlimento admin = new ManejadorAlimento();
        // GET: AlimentoController
        public ActionResult Index()
        {
            ViewBag.tipoAlimento = admin.consultarTipoAlimento();
            ViewBag.UnidadesMedida = admin.consultarUnidadMedida();

            return View();
        }


        [HttpPost]
        public JsonResult RegistrarCompra(string json)
        {
            bool resultado = admin.GuardarJson(json);

            return Json(resultado);
        }

    }
}
