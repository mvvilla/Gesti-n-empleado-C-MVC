using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace ISPF
{
    public class conexion
    {
        private MySqlConnection _conexion = null;
       
        private readonly string _cadenaConexion;

        public string Mensaje { get; private set; } = "vacío";

        public conexion(){
            string cadenaConexion = ConfigurationManager.ConnectionStrings["ConexionMySQL"].ConnectionString;
            _conexion = new MySqlConnection(cadenaConexion);
        }

        public MySqlConnection Conectar()
        {
            try
            {
                if (_conexion.State != System.Data.ConnectionState.Open)
                    _conexion.Open();

                     Mensaje = "Conexión exitosa";
            }
            catch (MySqlException ex)
            {
                Mensaje = "Error al conectar: " + ex.Message;
            }

            return _conexion;
        }


        public void Desconectar()
        {
            try
            {
                if (_conexion.State != System.Data.ConnectionState.Closed)
                    _conexion.Close();

                   Mensaje = "Conexión cerrada";
            }
            catch (MySqlException ex)
            {
                Mensaje = "Error al desconectar: " + ex.Message;
            }
        }

    }
}