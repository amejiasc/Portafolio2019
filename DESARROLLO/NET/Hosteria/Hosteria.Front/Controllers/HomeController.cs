using Hosteria.Clases.Entrada;
using Hosteria.Front.Integracion;
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
            //EntradaUsuarioTraer entradaUsuarioTraer = new EntradaUsuarioTraer()  { IdUsuario=1, RutUsuario="15538372-0" };
            //ServicioUsuario.ServicioUsuarioClient servicioUsuario = new ServicioUsuario.ServicioUsuarioClient();
            //ServicioUsuario.Entrada entrada = new ServicioUsuario.Entrada() { Datos = Newtonsoft.Json.JsonConvert.SerializeObject(entradaUsuarioTraer) };
            //Respuesta Respuesta = new Respuesta();
            //var RespuestaServicio = await servicioUsuario.TraerAsync(entradaUsuarioTraer);
            //servicioUsuario.Close();
            //Respuesta.Exito = RespuestaServicio.Exito;
            //Respuesta.MotivoNoExito = RespuestaServicio.MotivoNoExito;
            //Respuesta.Datos = RespuestaServicio.Datos;


            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Services()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}