using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ISPF.Models;
using MySql.Data.MySqlClient;
using System.Collections;
namespace ISPF.AppGestion
{
    public class departamentoGestion
    {
        public String insertar(DepartamentoModelo dep) {
            conexion conne = new conexion();
            MySqlConnection mys = conne.Conectar();
            string msjR = "";
            if (mys != null)
            {
                MySqlCommand cmd = new MySqlCommand("insetarDepartamento", mys);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@codigo",dep.codigo);
                cmd.Parameters.AddWithValue("@des", dep.des);
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

        public DepartamentoModelo obtenerDepa(string cod) {
            conexion conne = new conexion();
            MySqlConnection mys = conne.Conectar();
            DepartamentoModelo dep = new DepartamentoModelo();
            if (mys != null)
            {
                MySqlCommand cmd = new MySqlCommand("verDepartamento", mys);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@codigo", cod);
                MySqlDataReader da;
                da = cmd.ExecuteReader();
                if (da.Read())
                {
                    dep.codigo = da.GetString(0);
                    dep.des = da.GetString(1);
                }
                conne.Desconectar();
                mys.Close();
            }
            return dep;
        }

        public ArrayList mostrarDepartamentos(string cod)
        {
            conexion conne = new conexion();
            MySqlConnection mys = conne.Conectar();
            ArrayList arrayDepa = new ArrayList();
            if (mys != null)
            {
                MySqlCommand cmd = new MySqlCommand("verDepartamento", mys);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@codigo", cod);
                MySqlDataReader da;
                da = cmd.ExecuteReader();
                while (da.Read())
                {
                    DepartamentoModelo dep = new DepartamentoModelo();
                    dep.codigo = da.GetString(0);
                    dep.des = da.GetString(1);
                    arrayDepa.Add(dep);
                }
                conne.Desconectar();
                mys.Close();
            }
            return arrayDepa;
        }
    }
}