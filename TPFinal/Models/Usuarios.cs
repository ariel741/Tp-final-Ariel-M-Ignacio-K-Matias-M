using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TPFinal.Models
{
    public class Usuarios
    {

        private string _NombreU;
        private string _Mail;
        private string _Contraseña;
        private int _IdUsuario;

        [Required(ErrorMessage = "Ingrese nombre de usuario")]
        public string NombreU { get => _NombreU; set => _NombreU = value; }
        public string Mail { get => _Mail; set => _Mail = value; }
        [Required(ErrorMessage = "Ingresar contraseña")]
        public string Contraseña { get => _Contraseña; set => _Contraseña = value; }
        public int IdUsuario { get => _IdUsuario; set => _IdUsuario = value; }

        public Usuarios(string NombreU, string Contraseña, string Mail, int IdUsuario)
        {
            _NombreU = NombreU;
            _Mail = Mail;
            _Contraseña = Contraseña;
            _IdUsuario = IdUsuario;
        }

        public static void Usu()
        {

        }
    }
        
    
}