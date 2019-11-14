using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TPFinal.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Escribir()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult AlAzar()
        {
            ViewBag.Message = "Tu pagina de contacto.";

            return View();
        }
        public ActionResult Moderacion()
        {
            ViewBag.Message = "Tu pagina de contacto.";

            return View();
        }
        public ActionResult Login()
        {
            

            return View();
        }

    }
}