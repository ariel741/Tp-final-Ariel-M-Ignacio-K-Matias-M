﻿using System;
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

        public static void CrearUsuarios(Usuarios user)
        {

            SqlConnection Conexion = BD.Conectar();
            SqlCommand Consulta = Conexion.CreateCommand();
            Consulta.CommandType = System.Data.CommandType.StoredProcedure;
            Consulta.CommandText = "sp_CrearUsuarios";
            Consulta.Parameters.AddWithValue("NombreUsuario", user.NombreU);
            Consulta.Parameters.AddWithValue("Mail", user.Mail);
            Consulta.Parameters.AddWithValue("Contraseña", user.Contraseña);

            Consulta.ExecuteNonQuery();

            Conexion.Close();
        }
        public static bool ValidarUsuarios(Usuarios user)
        {
            bool Existe;
            SqlConnection Conexion = BD.Conectar();
            SqlCommand Consulta = Conexion.CreateCommand();
            SqlCommand cmd = new SqlCommand("sp_VerificarUsuario", Conexion);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NombreUsuario", user.NombreU);
            cmd.Parameters.AddWithValue("@Contraseña", user.Contraseña);

            SqlDataReader Lector = cmd.ExecuteReader();
            if (Lector.Read())
            {
                Existe = true;
            }
            else
            {
                Existe = false;
            }
            Desconectar(Conexion);
            return Existe;
        }

    }

}