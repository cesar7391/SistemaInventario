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
    public class DALogin
    {
        public ResponseLogin Authenticate(ENLogin paramss)
        {
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["ConexionAcceso"].ConnectionString;
                var lista = new List<ResponseLogin>();

                using (SqlConnection conn = new SqlConnection(cs))
                {
                    conn.Open();
                    //Se llama al store procedure
                    SqlCommand cmd = new SqlCommand("usp_validarUserToken", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@usertoken", paramss.usertoken));
                    cmd.Parameters.Add(new SqlParameter("@passwordtoken", paramss.passwordtoken));
                    cmd.Parameters.Add(new SqlParameter("@proyecto", paramss.proyecto));

                    //Ejecuta el SP
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            var result = new ResponseLogin();
                            result.responsetoken = Convert.ToString(rdr["response"]);
                            lista.Add(result);
                        }
                    }
                }
                return lista.FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ResponseLogin Acceder(ENLogin paramss)
        {
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["ConexionAcceso"].ConnectionString;
                var lista = new List<ResponseLogin>();

                using (SqlConnection conn = new SqlConnection(cs))
                {
                    conn.Open();
                    //Se llama al store procedure
                    SqlCommand cmd = new SqlCommand("usp_validarAccesos", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@ruc", paramss.ruc));
                    cmd.Parameters.Add(new SqlParameter("@user", paramss.user));
                    cmd.Parameters.Add(new SqlParameter("@password", paramss.pass));
                    cmd.Parameters.Add(new SqlParameter("@proyecto", paramss.proyecto));

                    //Ejecuta el SP
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            var result = new ResponseLogin();
                            result.response = Convert.ToString(rdr["response"]);
                            result.username = Convert.ToString(rdr["username"]);
                            result.cargo = Convert.ToString(rdr["cargo"]);
                            result.cantaccesos = Convert.ToInt32(rdr["cantaccesos"]);
                            result.ruc = Convert.ToString(rdr["ruc"]);

                            //SE RECIBEN LOS VALORES DE ACCESO
                            result.ventas = Convert.ToInt32(rdr["ventas"]);
                            result.caja = Convert.ToInt32(rdr["caja"]);
                            result.clientes = Convert.ToInt32(rdr["compras"]);
                            result.productos = Convert.ToInt32(rdr["productos"]);
                            result.inventario = Convert.ToInt32(rdr["inventario"]);
                            result.proveedor = Convert.ToInt32(rdr["proveedor"]);
                            result.dashboard = Convert.ToInt32(rdr["dashboard"]);
                            result.usuarios = Convert.ToInt32(rdr["usuarios"]);
                            result.empresa = Convert.ToInt32(rdr["empresa"]);
                            result.configuraciones = Convert.ToInt32(rdr["configuraciones"]);

                            lista.Add(result);
                        }
                    }
                }
                return lista.FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
