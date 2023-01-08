using LogicaNegocio;
using LogicaNegocio.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PruebaConexionMysql.Controllers
{
    public class PersonasController : Controller
    {
        ManejadorPersonas admin = new ManejadorPersonas();
        

        // GET: PersonasController
        public ActionResult Index()
        {
            List<PersonaModel> lista = admin.Consultar();
            return View(lista);
        }

        // GET: PersonasController/Create
        public ActionResult CrearPersona()
        {
            return View();
        }

        // POST: PersonasController/Create
        [HttpPost]
        public ActionResult CrearPersona(PersonaModel persona)
        {
            if(admin.Guardar(persona))
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }


        public ActionResult CrearCliente()
        {
            return View();
        }

        public ActionResult GuardarCliente(ClienteModel cliente)
        {
            bool repuesta = admin.GuardarCliente(cliente);
            return RedirectToAction("CrearCliente");
        }

        public ActionResult CrearEmpleado()
        {
            return View();
        }

        // POST: PersonasController/Create
        [HttpPost]
        public ActionResult CrearEmpleado(FuncionarioModel persona)
        {

            if (admin.GuardarEmpleado(persona))
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }



        public ActionResult Eliminar(int id)
        {
            return RedirectToAction("Index");
        }


        [HttpPost]
        public JsonResult ConsultarPersona(string documento)
        {
            PersonaModel persona = admin.Consultar(documento);
            if (persona == null) {
                return Json("nueva");
            }
            return Json(persona);
        }

    }
}
