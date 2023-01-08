using LogicaNegocio;
using LogicaNegocio.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PruebaConexionMysql.Controllers
{
    public class PedidoController : Controller
    {
        // GET: PedidoController
        ManejadorPedido admin = new ManejadorPedido();
        public ActionResult Index()
        {
            string documento = LoginController.usuario;
            List<PedidoModel> lista = admin.ConsultarPedidosDocumento(documento);
            return View(lista);
        }
        public ActionResult ClientesQueDeben()
        {
            List<PedidoModel> lista = admin.Consultar();

            return View(lista);
        }


        [HttpPost]
        public ActionResult ClientesQueDeben(int IdPedido)
        {
            admin.CambiarEstadoPago(IdPedido);

            List<PedidoModel> lista = admin.Consultar();

            return View(lista);
        }
        public ActionResult SolicitarPedido()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SolicitarPedido(PedidoModel model)
        {
            model.nombre = LoginController.usuario;
            admin.GuardarPedido(model);

         return  RedirectToAction("Index");
        }

        public ActionResult PedidosPendientes()
        {
            List<PedidoModel> lista = admin.ConsultarPedidosPendientes();
            return View(lista);
        }

        public IActionResult ActualizarPedidoPendiente(int idPdedio)
        {
            PedidoModel pedido = new PedidoModel() {
                NumeroPedido = idPdedio,
                DocumentoCliente = LoginController.usuario
            };

            admin.ActualizarPedidoPendiente(pedido);
            return RedirectToAction("PedidosPendientes");
        }

    }
}
