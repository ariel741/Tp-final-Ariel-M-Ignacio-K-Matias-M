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
        private int _Pais;
        private bool _Oficial;
        private int _Likes;
        private int _Dislikes;
        private int _IdPalabra;

        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public string Descripcion { get => _Descripcion; set => _Descripcion = value; }
        public int Pais { get => _Pais; set => _Pais = value; }
        public bool Oficial { get => _Oficial; set => _Oficial = value; }
        public int Likes { get => _Likes; set => _Likes = value; }
        public int Dislikes { get => _Dislikes; set => _Dislikes = value; }
        public int IdPalabra { get => _IdPalabra; set => _IdPalabra = value; }

        public Definiciones(string Nombre, string Descripcion, int Pais, bool Oficial, int Likes, int Dislikes, int IdPalabra)
        {
            _Nombre = Nombre;
            _Descripcion = Descripcion;
            _Pais = Pais;
            _Oficial = Oficial;
            _Likes = Likes;
            _Dislikes = Dislikes;
            _IdPalabra = IdPalabra;
        }

        
    }
}