using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TPFinal.Models;

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

        public ActionResult Logueo(Usuarios NombreU)
        {
            bool existe;
            
                if(ModelState.IsValid)
            {
                existe = BD.ExisteUsuario(NombreU);
                    if(existe)
                {
                    return View("Index");
                }
                else
                {
                    ViewBag.Error = "Nombre o contraseña incorrecto";
                    return View("Login", NombreU);
                }
            }
            else
            {
                return View("Login", NombreU);
            }
            return View();
        }
    }
}