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
    public class DAProveedores
    {
        public ResponseProveedores registrarProveedor(ENProveedores paramss)
        {
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
                var lista = new List<ResponseProveedores>();

                using (SqlConnection conn = new SqlConnection(cs))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("usp_registrarProveedor", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@ruc", paramss.ruc));
                    cmd.Parameters.Add(new SqlParameter("@razonsocial", paramss.razonsocial));
                    cmd.Parameters.Add(new SqlParameter("@telefono", paramss.telefono));
                    cmd.Parameters.Add(new SqlParameter("@email", paramss.email));
                    cmd.Parameters.Add(new SqlParameter("@direccion", paramss.direccion));
                    cmd.Parameters.Add(new SqlParameter("@rucempresa", paramss.rucempresa));

                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            var resul = new ResponseProveedores();
                            resul.response = Convert.ToString(rdr["response"]);
                            lista.Add(resul);
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

        public List<ResponseProveedores> listarProveedores(ENProveedores paramss)
        {
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
                var lista = new List<ResponseProveedores>();

                using (SqlConnection conn = new SqlConnection(cs))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("usp_listarProveedores", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@rucempresa", paramss.rucempresa));

                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            var resul = new ResponseProveedores();
                            resul.idprov = Convert.ToInt32(rdr["idproveedor"]);
                            resul.ruc = Convert.ToString(rdr["ruc"]);
                            resul.razonsocial = Convert.ToString(rdr["razonsocial"]);
                            resul.telefono = Convert.ToString(rdr["telefono"]);
                            resul.email = Convert.ToString(rdr["email"]);
                            resul.direccion = Convert.ToString(rdr["direccion"]);
                            resul.status = Convert.ToInt32(rdr["status"]);
                            lista.Add(resul);
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

        public ResponseProveedores desactivarProveedor(ENProveedores paramss)
        {
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
                var lista = new List<ResponseProveedores>();

                using (SqlConnection conn = new SqlConnection(cs))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("usp_desactivarProveedor", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@idprov", paramss.idprov));
                    cmd.Parameters.Add(new SqlParameter("@rucempresa", paramss.rucempresa));

                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            var resul = new ResponseProveedores();
                            resul.response = Convert.ToString(rdr["response"]);
                            lista.Add(resul);
                        }
                    }
                }
                return lista.FirstOrDefault(); ;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        
        public ResponseProveedores activarProveedor(ENProveedores paramss)
        {
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
                var lista = new List<ResponseProveedores>();

                using (SqlConnection conn = new SqlConnection(cs))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("usp_activarProveedor", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@idprov", paramss.idprov));
                    cmd.Parameters.Add(new SqlParameter("@rucempresa", paramss.rucempresa));


                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            var resul = new ResponseProveedores();
                            resul.response = Convert.ToString(rdr["response"]);
                            lista.Add(resul);
                        }
                    }
                }
                return lista.FirstOrDefault(); ;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ResponseProveedores eliminarProveedor(ENProveedores paramss)
        {
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
                var lista = new List<ResponseProveedores>();

                using (SqlConnection conn = new SqlConnection(cs))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("usp_eliminarProveedor", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@idprov", paramss.idprov));
                    cmd.Parameters.Add(new SqlParameter("@rucempresa", paramss.rucempresa));


                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            var resul = new ResponseProveedores();
                            resul.response = Convert.ToString(rdr["response"]);
                            lista.Add(resul);
                        }
                    }
                }
                return lista.FirstOrDefault(); ;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public ResponseProveedores obteditarProveedor(ENProveedores paramss)
        {
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
                var lista = new List<ResponseProveedores>();

                using (SqlConnection conn = new SqlConnection(cs))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("usp_obteditarProveedor", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@idprov", paramss.idprov));

                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            var resul = new ResponseProveedores();

                            resul.response = Convert.ToString(rdr["response"]);

                            if (resul.response == "ok")
                            {
                                resul.idprov = Convert.ToInt32(rdr["idproveedor"]);
                                resul.response = Convert.ToString(rdr["response"]);
                                resul.ruc = Convert.ToString(rdr["ruc"]);
                                resul.razonsocial = Convert.ToString(rdr["razonsocial"]);
                                resul.telefono = Convert.ToString(rdr["telefono"]);
                                resul.email = Convert.ToString(rdr["email"]);
                                resul.direccion = Convert.ToString(rdr["direccion"]);
                            }
                            lista.Add(resul);
                        }
                    }
                }
                return lista.FirstOrDefault(); ;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ResponseProveedores editarProveedor(ENProveedores paramss)
        {
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
                var lista = new List<ResponseProveedores>();

                using (SqlConnection conn = new SqlConnection(cs))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("usp_editarProveedor", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@idprov", paramss.idprov));
                    cmd.Parameters.Add(new SqlParameter("@ruc", paramss.ruc));
                    cmd.Parameters.Add(new SqlParameter("@razonsocial", paramss.razonsocial));
                    cmd.Parameters.Add(new SqlParameter("@telefono", paramss.telefono));
                    cmd.Parameters.Add(new SqlParameter("@email", paramss.email));
                    cmd.Parameters.Add(new SqlParameter("@direccion", paramss.direccion));
                    cmd.Parameters.Add(new SqlParameter("@rucempresa", paramss.rucempresa));
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            var resul = new ResponseProveedores();

                            resul.response = Convert.ToString(rdr["response"]);

                            lista.Add(resul);
                        }
                    }
                }
                return lista.FirstOrDefault(); ;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }        
    }
}
