using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Collections;
using ISPF.Models;

namespace ISPF.AppGestion
{
    public class datosproGestion
    {
        public String insertar(ProfesionalEmModelo pro)
        {
            conexion conne = new conexion();
            MySqlConnection mys = conne.Conectar();
            string msjR = "";
            if (mys != null)
            {
                MySqlCommand cmd = new MySqlCommand("insertarDatosPro", mys);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@universidad", pro.universidad);
                cmd.Parameters.AddWithValue("@codE", pro.codigoEmpleado);
                cmd.Parameters.AddWithValue("@Ncolegiado", pro.colegiado);
                cmd.Parameters.AddWithValue("@fechaCole", pro.fechaCole);
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
                    msjR = "No se pudo realizar la operacion " + ex.ToString();
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

        public ArrayList obtenerProf(string cod)
        {
            conexion conne = new conexion();
            MySqlConnection mys = conne.Conectar();
            ProfesionalEmModelo pro = new ProfesionalEmModelo();
            ArrayList arrayProf = new ArrayList();
            if (mys != null)
            {
                MySqlCommand cmd = new MySqlCommand("verProf", mys);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@dato", cod);
                MySqlDataReader da;
                da = cmd.ExecuteReader();
                if (da.Read())
                {
                    pro.universidad = da.GetString(0);
                    pro.colegiado = da.GetString(1);
                    pro.fechaCole = Convert.ToString(da.GetDateTime(2)).Substring(0,9);
                    arrayProf.Add(pro);
                }
                conne.Desconectar();
                mys.Close();
            }
            return arrayProf;
        }

        public ArrayList mostrarProf(string cod)
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