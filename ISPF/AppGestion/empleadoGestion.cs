using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using MySql.Data.MySqlClient;
using ISPF.Models;

namespace ISPF.AppGestion
{
    public class empleadoGestion
    {
        public String insertar(EmpleadoModelo emple)
        {
            conexion conne = new conexion();
            MySqlConnection mys = conne.Conectar();
            string msjR = "";
            if (mys != null)
            {
                MySqlCommand cmd = new MySqlCommand("insertarEmpleado", mys);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@dpi", emple.dpi);
                cmd.Parameters.AddWithValue("@nombre", emple.nombre);
                cmd.Parameters.AddWithValue("@apellido", emple.apellido);
                cmd.Parameters.AddWithValue("@fNaci", emple.fechaN);
                cmd.Parameters.AddWithValue("@genero", emple.genero);
                cmd.Parameters.AddWithValue("@direccion", emple.direccion);
                cmd.Parameters.AddWithValue("@codigoEmple", emple.dpi);
                cmd.Parameters.AddWithValue("@nit", emple.nit);
                cmd.Parameters.AddWithValue("@correo", emple.correo);
                cmd.Parameters.AddWithValue("@iggs", emple.igss);
                cmd.Parameters.AddWithValue("@cuentaB", emple.cuentaBancaria);
                cmd.Parameters.AddWithValue("@nombreMadre", emple.nomMadre);
                cmd.Parameters.AddWithValue("@nombrePadre", emple.nomPadre);
                cmd.Parameters.AddWithValue("@nombreCony", emple.nomConyugue);
                cmd.Parameters.AddWithValue("@nivelEdu", emple.nivelAca);
                cmd.Parameters.AddWithValue("@gradoAca", emple.gradoAca);
                cmd.Parameters.AddWithValue("@puesto", emple.puesto);
                cmd.Parameters.AddWithValue("@fechaGra", emple.fechaGra);
                MySqlParameter valorRetorno = new MySqlParameter("@msj", MySqlDbType.VarChar, 45);
                valorRetorno.Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add(valorRetorno);

                try
                {
                    cmd.ExecuteNonQuery();
                    msjR = Convert.ToString(valorRetorno.Value);
                    String cod = msjR;
                    String dd = cod;
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

        public EmpleadoModelo obtenerEmpleado(string cod)
        {
            conexion conne = new conexion();
            MySqlConnection mys = conne.Conectar();
            EmpleadoModelo emple = new EmpleadoModelo();
            if (mys != null)
            {
                MySqlCommand cmd = new MySqlCommand("verEmpleado", mys);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@dpi", cod);
                MySqlDataReader da;
                da = cmd.ExecuteReader();
                if (da.Read())
                {
                    emple.dpi = da.GetString(0);
                    emple.nombre = da.GetString(1);
                    emple.apellido = da.GetString(2);
                    emple.fechaN = Convert.ToString(da.GetDateTime(3));
                    emple.genero = da.GetString(4);
                    emple.direccion = da.GetString(5);
                    emple.nit = da.GetString(6);
                    emple.correo = da.GetString(7);
                    emple.igss = da.GetString(8);
                    emple.cuentaBancaria = da.GetString(9);
                    emple.puesto = da.GetString(10);
                }
                conne.Desconectar();
                mys.Close();
            }
            return emple;
        }

        public EmpleadoModelo obtenerEmpleadoDetalle(string cod)
        {
            conexion conne = new conexion();
            MySqlConnection mys = conne.Conectar();
            EmpleadoModelo emple = new EmpleadoModelo();
            if (mys != null)
            {
                MySqlCommand cmd = new MySqlCommand("verEmpleadoDetalle", mys);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@dpi", cod);
                MySqlDataReader da;
                da = cmd.ExecuteReader();
                if (da.Read())
                {
                    emple.dpi = da.GetString(0);
                    emple.nombre = da.GetString(1);
                    emple.apellido = da.GetString(2);
                    emple.fechaN = Convert.ToString(da.GetDateTime(3)).Substring(0, 9);
                    emple.genero = da.GetString(4);
                    emple.direccion = da.GetString(5);
                    emple.codigoEmple = da.GetString(6);
                    emple.nit = da.GetString(7);
                    emple.correo = da.GetString(8);
                    emple.igss = da.GetString(9);
                    emple.cuentaBancaria = da.GetString(10);
                    emple.nomMadre = da.GetString(11);
                    emple.nomPadre = da.GetString(12);
                    emple.nomConyugue = da.GetString(13);
                    emple.nivelAca = da.GetString(14);
                    emple.gradoAca = da.GetString(15);
                    emple.puesto = da.GetString(16);
                    emple.fechaGra = Convert.ToString(da.GetDateTime(17)).Substring(0,9);
                    emple.fechaIngreso = Convert.ToString(da.GetDateTime(18)).Substring(0, 9);
                }
                conne.Desconectar();
                mys.Close();
            }
            return emple;
        }

        public ArrayList mostrarEmpleados(string cod)
        {
            conexion conne = new conexion();
            MySqlConnection mys = conne.Conectar();
            ArrayList arrayempleado = new ArrayList();
            if (mys != null)
            {
                MySqlCommand cmd = new MySqlCommand("verEmpleado", mys);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@dpi", cod);
                MySqlDataReader da;
                da = cmd.ExecuteReader();
                while (da.Read())
                {
                    EmpleadoModelo emple = new EmpleadoModelo();
                    emple.dpi = da.GetString(0);
                    emple.nombre = da.GetString(1);
                    emple.apellido = da.GetString(2);
                    emple.fechaN = Convert.ToString(da.GetDateTime(3)).Substring(0, 9);
                    emple.genero = da.GetString(4);
                    emple.direccion = da.GetString(5);
                    emple.nit = da.GetString(6);
                    emple.correo = da.GetString(7);
                    emple.igss = da.GetString(8);
                    emple.cuentaBancaria = da.GetString(9);
                    emple.puesto = da.GetString(10);
                    arrayempleado.Add(emple);
                }
                conne.Desconectar();
                mys.Close();
            }
            return arrayempleado;
        }

        public MySqlDataAdapter reporte(string cod)
        {
            conexion conne = new conexion();
            MySqlConnection mys = conne.Conectar();
            if (mys != null)
            {
                MySqlCommand cmd = new MySqlCommand("fullEmpleado", mys);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@dato", cod);
                MySqlDataAdapter da=new MySqlDataAdapter(cmd);
                conne.Desconectar();
                mys = null;
                return da;
            }
            return null;
        }
    }
}