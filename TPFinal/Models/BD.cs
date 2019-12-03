using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;


namespace TPFinal.Models
{
    public static class BD
    {
        public static string strdb = "Server=.;Database=BDD-Lunfar2;User Id=alumno; password=alumno;";

        private static SqlConnection Conectar()
        {
            SqlConnection db = new SqlConnection(strdb);
            db.Open();
            return db;
        }

        public static void Desconectar(SqlConnection Conexion)
        {
            Conexion.Close();
        }


        public static List<Usuarios> TraerUsuario()
        {
            List<Usuarios> Login = new List<Usuarios>();
            SqlConnection Conexion = Conectar();

            SqlCommand consulta = Conexion.CreateCommand();
            consulta.CommandType = System.Data.CommandType.Text;
            consulta.CommandText = "SELECT * from Usuarios";
            SqlDataReader Lector = consulta.ExecuteReader();

            while (Lector.Read())
            {
                int IdUsuario = Convert.ToInt32(Lector["IdUsuario"]);
                string Nombre = Lector["NombreUsuario"].ToString();
                string Contraseña = Lector["Contraseña"].ToString();
                string Mail = Lector["Mail"].ToString();

                Usuarios Ayuda = new Usuarios(Nombre, Contraseña, Mail, IdUsuario);
                Login.Add(Ayuda);
            }

            Desconectar(Conexion);
            return Login;
        }

        

        public static string BuscarDef(int IdPalabra)
        {
            string Definicion = "";
            SqlConnection Conexion = Conectar();

            SqlCommand consulta = Conexion.CreateCommand();
            consulta.CommandType = System.Data.CommandType.Text;
            consulta.CommandText = "SELECT Descripcion from Definicion WHERE IdDefinicion = " + IdPalabra + " ";
            SqlDataReader Lector = consulta.ExecuteReader();

            while (Lector.Read())
            {
                Definicion = Lector["Descripcion"].ToString();
            }

            return Definicion;
        }

        public static List<Definiciones> OficialesxLetra(char Letra)
        {
            List<Definiciones> Oficial = new List<Definiciones>();
            SqlConnection Conexion = Conectar();

            SqlCommand consulta = Conexion.CreateCommand();
            consulta.CommandType = System.Data.CommandType.Text;
            consulta.CommandText = "SELECT * from Definicion WHERE Palabra LIKE '" + Letra.ToString() + "%'";
            SqlDataReader Lector = consulta.ExecuteReader();

            while (Lector.Read())
            {
                string Palabra = Lector["Palabra"].ToString();
                string Desc = Lector["Descripcion"].ToString();
                int FkPais = Convert.ToInt32(Lector["FkPais"]);
                int Likes = Convert.ToInt32(Lector["Likes"]);
                int Dislikes = Convert.ToInt32(Lector["Dislikes"]);
                bool Ofi = Convert.ToBoolean(Lector["Oficial"]);
                int IdPalabra = Convert.ToInt32(Lector["IdDefinicion"]);

                if (Ofi == true)
                {
                    Definiciones Ayuda = new Definiciones(Palabra, Desc, FkPais, Ofi, Likes, Dislikes, IdPalabra);
                    Oficial.Add(Ayuda);
                }

            }
            Desconectar(Conexion);
            return Oficial;
        }

        public static List<Definiciones> NOficialesxLetra(char Letra)
        {
            List<Definiciones> NOficial = new List<Definiciones>();
            SqlConnection Conexion = Conectar();

            SqlCommand consulta = Conexion.CreateCommand();
            consulta.CommandType = System.Data.CommandType.Text;
            consulta.CommandText = "SELECT * from Definicion WHERE Palabra LIKE '" + Letra.ToString() + "%'";
            SqlDataReader Lector = consulta.ExecuteReader();

            while (Lector.Read())
            {
                string Palabra = Lector["Palabra"].ToString();
                string Desc = Lector["Descripcion"].ToString();
                int FkPais = Convert.ToInt32(Lector["FkPais"]);
                int Likes = Convert.ToInt32(Lector["Likes"]);
                int Dislikes = Convert.ToInt32(Lector["Dislikes"]);
                bool Ofi = Convert.ToBoolean(Lector["Oficial"]);
                int IdPalabra = Convert.ToInt32(Lector["IdDefinicion"]);

                if (Ofi == false)
                {
                    Definiciones Ayuda = new Definiciones(Palabra, Desc, FkPais, Ofi, Likes, Dislikes, IdPalabra);
                    NOficial.Add(Ayuda);
                }

            }
            Desconectar(Conexion);
            return NOficial;
        }

        public static List<Definiciones> Oficiales()
        {
            List<Definiciones> Oficial = new List<Definiciones>();
            SqlConnection Conexion = Conectar();

            SqlCommand consulta = Conexion.CreateCommand();
            consulta.CommandType = System.Data.CommandType.Text;
            consulta.CommandText = "SELECT * from Definicion";
            SqlDataReader Lector = consulta.ExecuteReader();
            while (Lector.Read())
            {
                string Palabra = Lector["Palabra"].ToString();
                string Desc = Lector["Descripcion"].ToString();
                int FkPais = Convert.ToInt32(Lector["FkPais"]);
                int Likes = Convert.ToInt32(Lector["Likes"]);
                int Dislikes = Convert.ToInt32(Lector["Dislikes"]);
                bool Ofi = Convert.ToBoolean(Lector["Oficial"]);
                int IdPalabra = Convert.ToInt32(Lector["IdDefinicion"]);

                if (Ofi == true)
                {
                    Definiciones Ayuda = new Definiciones(Palabra, Desc, FkPais, Ofi, Likes, Dislikes, IdPalabra);
                    Oficial.Add(Ayuda);
                }
            }
            Desconectar(Conexion);
            return Oficial;
        }

        public static Definiciones PalRandom()
        {
            SqlConnection Conexion = Conectar();
            int Menor=0;
            int Mayor=0;

            Definiciones Ran = new Definiciones("","",0,true,0,0,0);

            SqlCommand consulta = Conexion.CreateCommand();
            consulta.CommandType = System.Data.CommandType.Text;
            consulta.CommandText = "SELECT TOP 1 IdDefinicion from Definicion order by IdDefinicion asc;";
            SqlDataReader Lector = consulta.ExecuteReader();
            while (Lector.Read())
            {
                 Menor = Convert.ToInt32(Lector["IdDefinicion"]);
            }

            Lector.Close();

            SqlCommand consulta1 = Conexion.CreateCommand();
            consulta1.CommandType = System.Data.CommandType.Text;
            consulta1.CommandText = "SELECT TOP 1 IdDefinicion from Definicion order by IdDefinicion desc;";
            SqlDataReader Lector1 = consulta1.ExecuteReader();
            while (Lector1.Read())
            {
                 Mayor = Convert.ToInt32(Lector1["IdDefinicion"]);
            }

            Random r = new Random();
            int aleatorio = r.Next(Menor, Mayor + 1);//para sacar el ultimo que antes no sacaba + 1

            Lector1.Close();

            SqlCommand consulta2 = Conexion.CreateCommand();
            consulta2.CommandType = System.Data.CommandType.Text;
            consulta2.CommandText = "SELECT * from Definicion where IdDefinicion ="+aleatorio+";";
            SqlDataReader Lector2 = consulta2.ExecuteReader();
            while (Lector2.Read())
            {
                string Palabra = Lector2["Palabra"].ToString();
                string Desc = Lector2["Descripcion"].ToString();
                int FkPais = Convert.ToInt32(Lector2["FkPais"]);
                int Likes = Convert.ToInt32(Lector2["Likes"]);
                int Dislikes = Convert.ToInt32(Lector2["Dislikes"]);
                bool Ofi = Convert.ToBoolean(Lector2["Oficial"]);
                int IdPalabra = Convert.ToInt32(Lector2["IdDefinicion"]);

              Ran = new Definiciones(Palabra, Desc, FkPais, Ofi, Likes, Dislikes, IdPalabra);
            }
            Desconectar(Conexion);
            return Ran;
        }

        public static List<Definiciones> Moderacion()
        {
            List<Definiciones> NoOficial = new List<Definiciones>();
            SqlConnection Conexion = Conectar();

            SqlCommand consulta = Conexion.CreateCommand();
            consulta.CommandType = System.Data.CommandType.Text;
            consulta.CommandText = "SELECT * from Definicion";
            SqlDataReader Lector = consulta.ExecuteReader();
            while (Lector.Read())
            {
                string Palabra = Lector["Palabra"].ToString();
                string Desc = Lector["Descripcion"].ToString();
                int FkPais = Convert.ToInt32(Lector["FkPais"]);
                int Likes = Convert.ToInt32(Lector["Likes"]);
                int Dislikes = Convert.ToInt32(Lector["Dislikes"]);
                bool Ofi = Convert.ToBoolean(Lector["Oficial"]);
                int IdPalabra = Convert.ToInt32(Lector["IdDefinicion"]);

                if (Ofi == false)
                {
                    Definiciones Ayuda = new Definiciones(Palabra, Desc, FkPais, Ofi, Likes, Dislikes, IdPalabra);
                    NoOficial.Add(Ayuda);
                }
            }
            Desconectar(Conexion);
            return NoOficial;

            
        }
        public static void likes(Definiciones todo)
            {
            SqlConnection Conexion = Conectar();
            SqlCommand consulta = Conexion.CreateCommand();
            consulta.CommandType = System.Data.CommandType.Text;
            consulta.CommandText = "UPDATE Definicion SET Likes = " + todo.Likes + 1;
            SqlDataReader Lector = consulta.ExecuteReader();
        }
        public static void Dislikes(Definiciones todo)
        {
            SqlConnection Conexion = Conectar();
            SqlCommand consulta = Conexion.CreateCommand();
            consulta.CommandType = System.Data.CommandType.Text;
            consulta.CommandText = "UPDATE Definicion SET Dislikes = " + todo.Dislikes + 1;
            SqlDataReader Lector = consulta.ExecuteReader();
        }
    }

}