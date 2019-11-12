using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TPFinal.Models
{
    public class Usuarios
    {
        private string _NombreU;
        private string _Mail;
        private string _Contraseña;

        public string NombreU { get => _NombreU; set => _NombreU = value; }
        public string Mail { get => _Mail; set => _Mail = value; }
        public string Contraseña { get => _Contraseña; set => _Contraseña = value; }

        public Usuarios(string NombreU, string Contraseña, string Mail)
        {
            _NombreU = NombreU;
            _Mail = Mail;
            _Contraseña = Contraseña;
        }
    }

}