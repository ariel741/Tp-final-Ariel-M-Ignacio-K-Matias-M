﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;


namespace TPFinal.Models
{
    public static class BD
    {
        public static string strdb = "Server=.;Database=BDD-Lunfar2;Trusted_Connection=true;";

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
                string Nombre = Lector["Campo"].ToString();
                string Contraseña = Lector["campo"].ToString();
                string Mail = Lector["campo"].ToString();

                Usuarios Ayuda = new Usuarios(Nombre,Contraseña,Mail);
                Login.Add(Ayuda);
            }

            Desconectar(Conexion);
            return Login;
        }
    }
}