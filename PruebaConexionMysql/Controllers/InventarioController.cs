using LogicaNegocio;
using LogicaNegocio.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PruebaConexionMysql.Controllers
{
    public class InventarioController : Controller
    {
        ManejadorInventario admin = new ManejadorInventario();
        // GET: InventarioController
        public ActionResult Index()
        {
            List<InventarioModel> lista = admin.Consultar();

            return View(lista);
        }

    }
}
