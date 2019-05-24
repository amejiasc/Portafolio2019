using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hosteria.Front.Controllers
{
    public class SistemaController : Controller
    {
        // GET: Sistema
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Clave()
        {
            return View();
        }
        public ActionResult Registro()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Registro(Models.Cliente cliente)
        {
            return View();
        }
        public ActionResult Index()
        {
            return View();
        }
    }
}