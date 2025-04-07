using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Collections;
using ISPF.Models;

namespace ISPF.AppGestion
{
    public class beneficiarioGestion
    {
        public String insertar(BeneficiarioModelo bn)
        {
            conexion conne = new conexion();
            MySqlConnection mys = conne.Conectar();
            string msjR = "";
            if (mys != null)
            {
                MySqlCommand cmd = new MySqlCommand("insertarBeneficiario", mys);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@dpi", bn.dpi);
                cmd.Parameters.AddWithValue("@nombre", bn.nombre);
                cmd.Parameters.AddWithValue("@apellido", bn.apellido);
                cmd.Parameters.AddWithValue("@fNaci", bn.fechaN);
                cmd.Parameters.AddWithValue("@genero", bn.genero);
                cmd.Parameters.AddWithValue("@direccion", bn.direccion);
                cmd.Parameters.AddWithValue("@parentesco", bn.parentesco);
                cmd.Parameters.AddWithValue("@empleado", bn.codigoEmpleP);
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

        public ArrayList obtenerBeneficiario(string cod)
        {
            conexion conne = new conexion();
            MySqlConnection mys = conne.Conectar();
            BeneficiarioModelo be = new BeneficiarioModelo();
            ArrayList arrayBene = new ArrayList();
            if (mys != null)
            {
                MySqlCommand cmd = new MySqlCommand("verBeneficiario", mys);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@cod", cod);
                MySqlDataReader da;
                da = cmd.ExecuteReader();
                if (da.Read())
                {
                    be.dpi = da.GetString(0);
                    be.nombre = da.GetString(1);
                    be.apellido = da.GetString(2);
                    be.fechaN = Convert.ToString(da.GetDateTime(3)).Substring(0,9);
                    be.genero = da.GetString(4);
                    be.direccion = da.GetString(5);
                    be.parentesco = da.GetString(6);
                    be.fechaIgreso = Convert.ToString(da.GetDateTime(7)).Substring(0,9);
                    arrayBene.Add(be);
                }
                conne.Desconectar();
                mys.Close();
            }
            return arrayBene;
        }

        public ArrayList mostrarBeneficiario(string cod)
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