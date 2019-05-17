using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hosteria.Front.Controllers
{
    public class UtilsController : Controller
    {
        // GET: Utils
        public ActionResult Comuna(string _region)
        {               
            if (string.IsNullOrEmpty(_region)) {
                return PartialView(new List<Clases.Comuna>());
            }
            List<Clases.Comuna> comunas = UtilConfig.Comunas().Where(x=> x.IdRegion.Equals(int.Parse(_region))).ToList();
            return PartialView(comunas);
        }
    }
}