using LogicaNegocio;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using PruebaConexionMysql.Models;
using System.Diagnostics;

namespace PruebaConexionMysql.Controllers
{
    public class HomeController : Controller
    {

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewBag.rol = LoginController.rol;
            ViewBag.user = LoginController.usuario;
            

            return View();
        }


        public IActionResult Privacy()
        {

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}