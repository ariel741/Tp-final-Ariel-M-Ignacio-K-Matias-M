using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TPFinal.Models
{
    public class Usuario
    {
        [Required(ErrorMessage ="Ingrese Contraseña"]
        public string Contraseña { get; set; }

        [Required(ErrorMessage = "Ingrese nombre de usuario"]
        public string Username { get; set; }

        public string Nombre { get; set; }

        public Usuario(string nom, string con, string user)
        {
            Nombre = nom;
            Contraseña = con;
            Username = user;
        }
    }
}