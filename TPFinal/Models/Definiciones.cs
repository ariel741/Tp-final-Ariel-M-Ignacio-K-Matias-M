using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TPFinal.Models
{
    public class Definiciones
    {
        private string _Nombre;
        private string _Descripcion;
        private string _Pais;
        private bool _Oficial;
        private int _Likes;
        private int _Dislikes;

        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public string Descripcion { get => _Descripcion; set => _Descripcion = value; }
        public string Pais { get => _Pais; set => _Pais = value; }
        public bool Oficial { get => _Oficial; set => _Oficial = value; }
        public int Likes { get => _Likes; set => _Likes = value; }
        public int Dislikes { get => _Dislikes; set => _Dislikes = value; }
    }
}