using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using MySql.Data.MySqlClient;
using ISPF.Models;

namespace ISPF.AppGestion
{
    public class PuestoGestion
    {
        public String insertar(PuestoModelo pu)
        {
            conexion conne = new conexion();
            MySqlConnection mys = conne.Conectar();
            string msjR = "";
            if (mys != null)
            {
                MySqlCommand cmd = new MySqlCommand("insertarPuesto", mys);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@cod", pu.codigo);
                cmd.Parameters.AddWithValue("@nom", pu.codigo);
                cmd.Parameters.AddWithValue("@des", pu.des);
                cmd.Parameters.AddWithValue("@depa", pu.codDep);
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

        public PuestoModelo obtenerPuesto(string cod)
        {
            conexion conne = new conexion();
            MySqlConnection mys = conne.Conectar();
            PuestoModelo pu = new PuestoModelo();
            if (mys != null)
            {
                MySqlCommand cmd = new MySqlCommand("verPuesto", mys);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@cod", cod);
                MySqlDataReader da;
                da = cmd.ExecuteReader();
                if (da.Read())
                {
                    pu.codigo = da.GetString(0);
                    pu.des = da.GetString(1);
                    pu.codDep = da.GetString(2);
                }

            }
            return pu;
        }

        public ArrayList mostrarPuestosD(string cod)
        {
            conexion conne = new conexion();
            MySqlConnection mys = conne.Conectar();
            ArrayList arrayPuesto = new ArrayList();
            if (mys != null)
            {
                MySqlCommand cmd = new MySqlCommand("verPuestoD", mys);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@cod", cod);
                MySqlDataReader da;
                da = cmd.ExecuteReader();
                while (da.Read())
                {
                    PuestoModelo pu = new PuestoModelo();
                    pu.codigo = da.GetString(0);
                    pu.des = da.GetString(1);
                    pu.codDep = da.GetString(2);
                    arrayPuesto.Add(pu);
                }
                conne.Desconectar();
                mys.Close();
            }
            return arrayPuesto;
        }
        public ArrayList mostrarPuestos(string cod)
        {
            conexion conne = new conexion();
            MySqlConnection mys = conne.Conectar();
            ArrayList arrayPuesto = new ArrayList();
            if (mys != null)
            {
                MySqlCommand cmd = new MySqlCommand("verPuesto", mys);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@cod", cod);
                MySqlDataReader da;
                da = cmd.ExecuteReader();
                while (da.Read())
                {
                    PuestoModelo pu = new PuestoModelo();
                    pu.codigo = da.GetString(0);
                    pu.des = da.GetString(1);
                    pu.codDep = da.GetString(2);
                    arrayPuesto.Add(pu);
                }
                conne.Desconectar();
                mys.Close();
            }
            return arrayPuesto;
        }
    }
}