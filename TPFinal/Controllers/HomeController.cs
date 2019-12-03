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
            ViewBag.Palabras = BD.Oficiales();
            ViewBag.Letra = -1;
            return View();
        }

        public ActionResult BuscarxLetra(int Letra)
        {
            ViewBag.Palabras = BD.OficialesxLetra(Convert.ToChar(Letra));
            ViewBag.Letra = Letra;
            return View("Index");
        }

        public ActionResult BuscarDefinicion(int IdPalabra, int Letra)
        {
            ViewBag.Definicion = BD.BuscarDef(IdPalabra);
            ViewBag.Letra = Letra;
            if (Letra!=-1)
            {
                ViewBag.Palabras = BD.OficialesxLetra(Convert.ToChar(Letra));
            }
            else
            {
                ViewBag.Palabras = BD.Oficiales();
            }
           
            return View("Index");
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
       
        

        public ActionResult Logueo(Usuarios user)
        {
            bool Existe = BD.ValidarUsuarios(user);
            if (ModelState.IsValid)
            {
                if (Existe)
                {
                    return View("Index");
                }
                else
                {
                    return View("Login");

                }
            }
            else
            {
                return View("Login");
            }


        }

        public ActionResult CrearUsuarios(Usuarios user)
        {
            if (ModelState.IsValid)
            {
                BD.CrearUsuarios(user);
                return View("Login");
            }
            else
            {
                return View("Registro", user);
            }

        }
        public ActionResult Registro()
        {
            return View("Registro");
        }
    }   
}