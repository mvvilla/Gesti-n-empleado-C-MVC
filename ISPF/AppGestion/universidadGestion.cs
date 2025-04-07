using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ISPF.Models;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Collections;

namespace ISPF.AppGestion
{
    public class universidadGestion
    {
        public String insertar(UniversidadModelo u)
        {
            conexion conne = new conexion();
            MySqlConnection mys = conne.Conectar();
            string msjR = "";
            if (mys!=null)
            {
                MySqlCommand cmd = new MySqlCommand("insertUniversidad", mys);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@cod", u.codigo);
                cmd.Parameters.AddWithValue("@nombre", u.nombre);
                cmd.Parameters.AddWithValue("@pais", u.pais);
                MySqlParameter valorRetorno = new MySqlParameter("@msj", MySqlDbType.VarChar, 45);
                valorRetorno.Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add(valorRetorno);

                try
                {
                    cmd.ExecuteNonQuery();
                    msjR = Convert.ToString(valorRetorno.Value);
                    mys = null;
                    conne.Desconectar();
                }
                catch (Exception ex)
                {
                    msjR = "No se pudo realizar la operacion "+ex.ToString();
                    mys = null;
                    conne.Desconectar();
                }
                finally
                {
                    mys = null;
                    conne.Desconectar();
                }


            }
            return msjR;
        }

        public UniversidadModelo obtenerUniversidad(string cod) {
            conexion conne = new conexion();
            MySqlConnection mys = conne.Conectar();
            UniversidadModelo uM = new UniversidadModelo();
            if (mys != null)
            {
                MySqlCommand cmd = new MySqlCommand("verUniversidad", mys);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@cod", cod);
                MySqlDataReader da;
                da = cmd.ExecuteReader();
                if (da.Read())
                {
                    uM.codigo = da.GetString(0);
                    uM.nombre = da.GetString(1);
                    uM.pais = da.GetString(2);
                }
                conne.Desconectar();
                mys.Close();
            }
            return uM;
        }

        public ArrayList mostrarUniversidad(string cod)
        {
            conexion conne = new conexion();
            MySqlConnection mys = conne.Conectar();
            ArrayList arrayUniversidad = new ArrayList();
            if (mys != null)
            {
                MySqlCommand cmd = new MySqlCommand("verUniversidad", mys);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@cod", cod);
                MySqlDataReader da;
                da = cmd.ExecuteReader();
                while (da.Read())
                {
                    UniversidadModelo uM = new UniversidadModelo();
                    uM.codigo = da.GetString(0);
                    uM.nombre = da.GetString(1);
                    uM.pais = da.GetString(2);
                    arrayUniversidad.Add(uM);
                }
                conne.Desconectar();
                mys.Close();
            }
            return arrayUniversidad;
        }
    }
}