using LogicaNegocio;
using LogicaNegocio.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PruebaConexionMysql.Controllers
{
    public class ReportesController : Controller
    {
        ManejadorInforme admin = new ManejadorInforme();

        // GET: ReportesController
        [HttpGet]
        public ActionResult Index()
        {
      
           //List <InformeModel> lista= admin.ConsultarDiario(fecha);
           //ViewBag.Fecha = fecha;
           
            return View();
        }


        public ActionResult Diario(InformeModel fecha)
        {

            List<InformeModel> lista = admin.ConsultarDiario(fecha.fechaInicio);
            ViewBag.Fecha = fecha.fechaInicio;

            return View(lista);
        }

        public ActionResult Semanal()
        {
            return View();
        }

        public ActionResult Semana(InformeModel fecha)
        {

            List<InformeModel> lista = admin.ConsultarSemana(fecha.fechaInicio);
            ViewBag.fechaFin = fecha.fechaInicio;
            if (lista.Count>0)
            {
                ViewBag.fecha = lista[0].fechaInicio;
            }
            else {
                ViewBag.fecha = "Sin resultados";
            }
            return View(lista);
        }


        public ActionResult Mensual()
        {
            return View();
        }


        public ActionResult mes(InformeModel fecha)
        {

            List<InformeModel> lista = admin.Consultarmes(fecha.fechaInicio);
            ViewBag.Fecha = fecha.fechaInicio;
            if (lista.Count > 0)
            {
                ViewBag.fechaFin = lista[0].fechaInicio;
            }
            else
            {
                ViewBag.fechaFin = "Sin resultados";
            }

            return View(lista);
        }

    }
}
