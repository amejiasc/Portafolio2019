using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Hosteria.Front.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ActionResult> Index()
        {
            ServicioUsuario.ServicioUsuarioClient servicioUsuario = new ServicioUsuario.ServicioUsuarioClient();
            ServicioUsuario.RespuestaUsuarioTraer respuestaUsuarioTraer = await servicioUsuario.TraerUsuarioAsync(
                new ServicioUsuario.EntradaUsuarioTraer() { IdUsuario = 15555, RutUsuario = "15538372-0" });


            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}