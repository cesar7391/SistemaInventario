using SistemaInventario.ENTITY.Parametros;
using SistemaInventario.ENTITY.Response;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaInventario.DATOS
{
    public class DAPaises
    {
        public List<ResponsePais> listarPaises(ENRegistroEmpresa paramss)
        {
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
                var lista = new List<ResponsePais>();

                using (SqlConnection conn = new SqlConnection(cs))
                {
                    conn.Open();
                    //Se llama al store procedure
                    SqlCommand cmd = new SqlCommand("usp_listarPaises", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    //Ejecuta el SP
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            var result = new ResponsePais();
                            result.idPais = Convert.ToInt32(rdr["idpais"]);
                            result.pais = Convert.ToString(rdr["pais"]);
                            lista.Add(result);
                        }
                    }
                }
                return lista;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public List<ResponseMoneda> listarMoneda(ENRegistroEmpresa paramss)
        {
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
                var lista = new List<ResponseMoneda>();

                using (SqlConnection conn = new SqlConnection(cs))
                {
                    conn.Open();
                    //Se llama al store procedure
                    SqlCommand cmd = new SqlCommand("usp_listarMoneda", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    //Ejecuta el SP
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            var result = new ResponseMoneda();
                            result.idMoneda = Convert.ToInt32(rdr["idmoneda"]);
                            result.moneda = Convert.ToString(rdr["moneda"]);
                            lista.Add(result);
                        }
                    }
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ResponseTImpuesto> listarTImpuesto(ENRegistroEmpresa paramss)
        {
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
                var lista = new List<ResponseTImpuesto>();

                using (SqlConnection conn = new SqlConnection(cs))
                {
                    conn.Open();
                    //Se llama al store procedure
                    SqlCommand cmd = new SqlCommand("usp_listarTImpuesto", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    //Ejecuta el SP
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            var result = new ResponseTImpuesto();
                            result.idTImpuesto = Convert.ToInt32(rdr["idtimpuesto"]);
                            result.tImpuesto = Convert.ToString(rdr["timpuesto"]);
                            lista.Add(result);
                        }
                    }
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ResponsePImpuesto> listarPImpuesto(ENRegistroEmpresa paramss)
        {
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
                var lista = new List<ResponsePImpuesto>();

                using (SqlConnection conn = new SqlConnection(cs))
                {
                    conn.Open();
                    //Se llama al store procedure
                    SqlCommand cmd = new SqlCommand("usp_listarPImpuesto", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    //Ejecuta el SP
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            var result = new ResponsePImpuesto();
                            result.idPImpuesto = Convert.ToInt32(rdr["idpimpuesto"]);
                            result.pImpuesto = Convert.ToInt32(rdr["pimpuesto"]);
                            lista.Add(result);
                        }
                    }
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
