using Hosteria.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hosteria.Front.Controllers
{
    [Authorize]
    public class SistemaController : Controller
    {
        // GET: Sistema

        [HttpPost]
        public ActionResult Modificar(Models.Cliente cliente)
        {
            ViewBag.Modifica = true;
            ViewBag.Mensaje = "Se ha modificado correctamente su información";
            return View("Index", cliente);
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(string rut, string clave)
        {

            ViewBag.Error = false;
            Negocio.Login login = new Negocio.Login();
            var respuesta = login.LoginCliente(rut.Replace(".", ""), clave);
            if (respuesta.Exito)
            {
                Negocio.Helper.Autenticacion.Login(respuesta);
                return RedirectToAction("Index");
                
            }
            ViewBag.Error = true;
            ViewBag.Mensaje = respuesta.Mensaje;
            return View();



        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult CerrarSesion()
        {
            ViewBag.Error = true;
            ViewBag.Mensaje = "Se cerró su sesión";
            return View("Login");
        }
        [HttpGet]
        [AllowAnonymous]
        public ActionResult SinAcceso()
        {
            ViewBag.Error = true;
            ViewBag.Mensaje = "No tiene acceso";
            return View("Login");
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login()
        {
            ViewBag.Error = false;
            ViewBag.Mensaje = "";
            return View();
        }
        [AllowAnonymous]
        public ActionResult Clave()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Registro()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Registro(Models.Cliente cliente)
        {
            Empresa empresa = new Empresa()
            {
                Celular = cliente.Celular,
                Clave = cliente.Clave,
                Comuna = cliente.Comuna,
                Direccion = cliente.Direccion,
                Email = cliente.Email,
                Giro = cliente.Giro,
                Nombrecliente = cliente.Nombrecliente,
                Region = cliente.Region,
                RutCliente = cliente.RutCliente.Replace(".", ""),
                Telefono = cliente.Telefono
            };

            Negocio.Empresa registro = new Negocio.Empresa();
            registro.Registrar(empresa);
            
            return View("Login");
        }
        
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.Modifica = false;
            ViewBag.Mensaje = "";
            return View();
        }

    }
}