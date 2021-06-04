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
    public class DAPromociones
    {
        public ResponsePromociones guardarPromocion(ENPromociones paramss)
        {
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
                var lista = new List<ResponsePromociones>();

                using (SqlConnection conn = new SqlConnection(cs))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("usp_guardarPromocion", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@idproducto", paramss.idproducto));
                    cmd.Parameters.Add(new SqlParameter("@promocion", paramss.nompromo));
                    cmd.Parameters.Add(new SqlParameter("@finicio", paramss.finicio));
                    cmd.Parameters.Add(new SqlParameter("@ffin", paramss.ffin));
                    cmd.Parameters.Add(new SqlParameter("@rucempresa", paramss.rucempresa));

                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            var resul = new ResponsePromociones();
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

        public List<ResponsePromociones> listarPromociones(ENPromociones paramss)
        {
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
                var lista = new List<ResponsePromociones>();

                using (SqlConnection conn = new SqlConnection(cs))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("usp_listaPromociones", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@rucempresa", paramss.rucempresa));

                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            var resul = new ResponsePromociones();
                            resul.row = Convert.ToInt32(rdr["Row"]);
                            resul.idpromocion = Convert.ToInt32(rdr["idpromocion"]);
                            resul.nombrePromocion = Convert.ToString(rdr["nombrePromocion"]);
                            resul.descProducto = Convert.ToString(rdr["descProducto"]);
                            resul.codbarra = Convert.ToString(rdr["codbarra"]);
                            resul.pventa = Convert.ToDecimal(rdr["pventa"]);
                            resul.finicio = Convert.ToString(rdr["finicio"]);
                            resul.ffin = Convert.ToString(rdr["ffin"]);
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

        public ResponsePromociones eliminarPromociones(ENPromociones paramss)
        {
            try
            {
                string idpromocion = paramss.datos;
                String[] strlist = idpromocion.Split('|');
                var count = strlist.Count() - 1;

                string cs = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
                var lista = new List<ResponsePromociones>();

                using (SqlConnection conn = new SqlConnection(cs))
                {
                    conn.Open();

                    for (int i = 0; i < count; i++)
                    {
                        SqlCommand cmd = new SqlCommand("usp_eliminarPromociones", conn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@idpromocion", strlist[i]));

                        using (SqlDataReader rdr = cmd.ExecuteReader())
                        {
                            while (rdr.Read())
                            {
                                var resul = new ResponsePromociones();
                                resul.response = Convert.ToString(rdr["response"]);
                                lista.Add(resul);
                            }
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



        public ResponsePromociones obtEditarPromo(ENPromociones paramss)
        {
            try
            {
                string idpromocion = paramss.datos;
                String[] strlist = idpromocion.Split('|');
                var count = strlist.Count() - 1;

                string cs = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
                var lista = new List<ResponsePromociones>();

                using (SqlConnection conn = new SqlConnection(cs))
                {
                    conn.Open();

                    for (int i = 0; i < count; i++)
                    {
                        SqlCommand cmd = new SqlCommand("usp_obtPromociones", conn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@rucempresa", paramss.rucempresa));
                        cmd.Parameters.Add(new SqlParameter("@idpromo", strlist[i]));

                        using (SqlDataReader rdr = cmd.ExecuteReader())
                        {
                            while (rdr.Read())
                            {
                                var resul = new ResponsePromociones();
                                resul.idpromocion = Convert.ToInt32(rdr["idpromocion"]);
                                resul.nombrePromocion = Convert.ToString(rdr["nombrePromocion"]);
                                resul.idproducto = Convert.ToInt32(rdr["idproducto"]);
                                resul.descProducto = Convert.ToString(rdr["descProducto"]);

                                resul.pventa1 = Convert.ToString(rdr["pventa"]);
                                resul.finicio = Convert.ToString(rdr["finicio"]);
                                resul.ffin = Convert.ToString(rdr["ffin"]);
                                resul.response = Convert.ToString(rdr["response"]);
                                lista.Add(resul);
                            }
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

        public ResponsePromociones editarPromocion(ENPromociones paramss)
        {
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
                var lista = new List<ResponsePromociones>();

                using (SqlConnection conn = new SqlConnection(cs))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("usp_editarPromocion", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@idpromo", paramss.idpromo));
                    cmd.Parameters.Add(new SqlParameter("@promocion", paramss.nompromo));
                    cmd.Parameters.Add(new SqlParameter("@finicio", paramss.finicio));
                    cmd.Parameters.Add(new SqlParameter("@ffin", paramss.ffin));
                    cmd.Parameters.Add(new SqlParameter("@rucempresa", paramss.rucempresa));

                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            var resul = new ResponsePromociones();
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
    }
}
