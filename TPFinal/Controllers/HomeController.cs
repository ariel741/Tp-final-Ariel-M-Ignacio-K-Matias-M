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

        public ActionResult BuscarxLetraM(int Letra)
        {
            ViewBag.Palabras = BD.NOficialesxLetra(Convert.ToChar(Letra));
            ViewBag.Letra = Letra;
            return View("Moderacion");
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

        public ActionResult BuscarDefinicionM(int IdPalabra, int Letra)
        {
            ViewBag.Definicion = BD.BuscarDef(IdPalabra);
            ViewBag.Letra = Letra;
            if (Letra != -1)
            {
                ViewBag.Palabras = BD.NOficialesxLetra(Convert.ToChar(Letra));
            }
            else
            {
                ViewBag.Palabras = BD.Moderacion();
            }

            return View("Moderacion");
        }

        public ActionResult Escribir()
        {
            ViewBag.Message = "Your application description page.";
            
            return View();
        }

        public ActionResult AlAzar()
        {
            return View();
        }
        public ActionResult Azar()
        {
            Definiciones Hola = BD.PalRandom();
            ViewBag.Nom = Hola.Nombre;
            ViewBag.Desc = Hola.Descripcion;
            
            return View("AlAzar");
        }

        public ActionResult Moderacion()
        {
            ViewBag.Palabras = BD.Moderacion();
            ViewBag.Letra = -1;
            return View();
        }
        public ActionResult Login()
        {
            
            return View();
        }

        public ActionResult Moderaciones()
        {
            return View("Moderacion");
        }

        public ActionResult Like()
        {
            return View("Moderacion");
        }

        public ActionResult DisLike()
        {
            return View("Moderacion");
        }
    }
}