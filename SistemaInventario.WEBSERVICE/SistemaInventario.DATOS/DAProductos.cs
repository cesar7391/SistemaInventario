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
    public class DAProductos
    {
        
        public ResponseProductos calcularPventaSinImpuestos(ENProductos paramss)
        {
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
                var lista = new List<ResponseProductos>();

                using (SqlConnection conn = new SqlConnection(cs))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("usp_calcularPventaSinImpuestos", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@pcosto", paramss.pcosto));
                    if (paramss.ganancia == null)
                        cmd.Parameters.Add(new SqlParameter("@ganancia", "0"));                    
                    else
                        cmd.Parameters.Add(new SqlParameter("@ganancia", paramss.ganancia));

                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            var resul = new ResponseProductos();
                            resul.pventa = Convert.ToDecimal(rdr["pventa"]);
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

        
        public List<ResponseDepartamentos> listarDepartamentos(ENDepartamentos paramss)
        {
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
                var lista = new List<ResponseDepartamentos>();

                using (SqlConnection conn = new SqlConnection(cs))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("usp_ListarDepartamentos", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            var resul = new ResponseDepartamentos();
                            resul.iddepart = Convert.ToInt32(rdr["iddepartamento"]);
                            resul.depart = Convert.ToString(rdr["departamento"]);
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
        
        public ResponseProductos guardarProducto(ENProductos paramss)
        {
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
                var lista = new List<ResponseProductos>();

                using (SqlConnection conn = new SqlConnection(cs))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("usp_guardarProducto", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    /******************* DATOS A ENVIAR **********************/
                    cmd.Parameters.Add(new SqlParameter("@rucempresa", paramss.rucempresa));
                    cmd.Parameters.Add(new SqlParameter("@tipo", paramss.tipo));

                    if (paramss.codbarra == null)                    
                        cmd.Parameters.Add(new SqlParameter("@codbarra", ""));
                    else                    
                        cmd.Parameters.Add(new SqlParameter("@codbarra", paramss.codbarra));

                    cmd.Parameters.Add(new SqlParameter("@desc", paramss.desc));
                    cmd.Parameters.Add(new SqlParameter("@tproduct", paramss.tproduct));

                    if (paramss.pcosto == null)                    
                        cmd.Parameters.Add(new SqlParameter("@pcosto", "0"));
                    else
                        cmd.Parameters.Add(new SqlParameter("@pcosto", paramss.pcosto));
                    
                    if (paramss.ganancia == null)
                        cmd.Parameters.Add(new SqlParameter("@ganancia", "0"));
                    else
                        cmd.Parameters.Add(new SqlParameter("@ganancia", paramss.ganancia));

                    cmd.Parameters.Add(new SqlParameter("@pventa", paramss.pventa));
                    cmd.Parameters.Add(new SqlParameter("@pmayoreo", paramss.pmayoreo));
                    cmd.Parameters.Add(new SqlParameter("@apartir", paramss.apartir));
                    cmd.Parameters.Add(new SqlParameter("@sldepart", paramss.sldepart));
                    cmd.Parameters.Add(new SqlParameter("@existen", paramss.existen));
                    cmd.Parameters.Add(new SqlParameter("@minexisten", paramss.minexisten));

                    if (paramss.fvenci == null)
                        cmd.Parameters.Add(new SqlParameter("@fvenci", ""));
                    else
                        cmd.Parameters.Add(new SqlParameter("@fvenci", paramss.fvenci));

                    cmd.Parameters.Add(new SqlParameter("@faplica", paramss.faplica));

                    /******************* FIN DATOS A ENVIAR **********************/

                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            var resul = new ResponseProductos();
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
        
        public List<ResponseProductos> listarProductos(ENProductos paramss)
        {
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
                var lista = new List<ResponseProductos>();

                using (SqlConnection conn = new SqlConnection(cs))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("usp_listarProductos", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@rucempresa", paramss.rucempresa));

                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            var resul = new ResponseProductos();
                            resul.row = Convert.ToInt32(rdr["Row"]);
                            resul.idproducto = Convert.ToInt32(rdr["idproducto"]);
                            resul.tipo = Convert.ToString(rdr["tipo"]);
                            resul.tproduct = Convert.ToString(rdr["tproduct"]);
                            resul.codbarra = Convert.ToString(rdr["codbarra"]);
                            resul.desc = Convert.ToString(rdr["descripcion"]);
                            resul.depart = Convert.ToString(rdr["departamento"]);
                            resul.pcosto = Convert.ToDecimal(rdr["pcosto"]);
                            resul.pventa = Convert.ToDecimal(rdr["pventa"]);
                            resul.pmayoreo = Convert.ToDecimal(rdr["pmayoreo"]);
                            resul.existen = Convert.ToInt32(rdr["existencia"]);
                            resul.minexisten = Convert.ToInt32(rdr["minexisten"]);
                            resul.fvenci = Convert.ToString(rdr["fvenci"]);
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

        
        public List<ResponseProductos> buscarProducto(ENProductos paramss)
        {
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
                var lista = new List<ResponseProductos>();

                using (SqlConnection conn = new SqlConnection(cs))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("usp_buscarProducto", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    if (paramss.buscarp == null)
                    {
                        cmd.Parameters.Add(new SqlParameter("@letra", ""));
                    }
                    else
                    {
                        cmd.Parameters.Add(new SqlParameter("@letra", paramss.buscarp));
                    }

                    cmd.Parameters.Add(new SqlParameter("@rucempresa", paramss.rucempresa));

                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            var resul = new ResponseProductos();
                            resul.row = Convert.ToInt32(rdr["Row"]);
                            resul.idproducto = Convert.ToInt32(rdr["idproducto"]);
                            resul.tipo = Convert.ToString(rdr["tipo"]);
                            resul.tproduct = Convert.ToString(rdr["tproduct"]);
                            resul.codbarra = Convert.ToString(rdr["codbarra"]);
                            resul.desc = Convert.ToString(rdr["descripcion"]);
                            resul.depart = Convert.ToString(rdr["departamento"]);
                            resul.pcosto = Convert.ToDecimal(rdr["pcosto"]);
                            resul.pventa = Convert.ToDecimal(rdr["pventa"]);
                            resul.pmayoreo = Convert.ToDecimal(rdr["pmayoreo"]);
                            resul.existen = Convert.ToInt32(rdr["existencia"]);
                            resul.minexisten = Convert.ToInt32(rdr["minexisten"]);
                            resul.fvenci = Convert.ToString(rdr["fvenci"]);
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

        /*
        public List<ResponseProductos> buscarProductodepart(ENProductos paramss)
        {
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
                var lista = new List<ResponseProductos>();

                using (SqlConnection conn = new SqlConnection(cs))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("usp_buscarProductodepart", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@iddepartamento", paramss.slbuscar));

                    cmd.Parameters.Add(new SqlParameter("@rucempresa", paramss.rucempresa));



                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            var resul = new ResponseProductos();
                            resul.row = Convert.ToInt32(rdr["Row"]);
                            resul.idproducto = Convert.ToInt32(rdr["idproducto"]);
                            resul.tipo = Convert.ToString(rdr["tipo"]);
                            resul.tproduct = Convert.ToString(rdr["tproduct"]);
                            resul.codbarra = Convert.ToString(rdr["codbarra"]);
                            resul.desc = Convert.ToString(rdr["descripcion"]);
                            resul.depart = Convert.ToString(rdr["departamento"]);
                            resul.pcosto = Convert.ToDecimal(rdr["pcosto"]);
                            resul.pventa = Convert.ToDecimal(rdr["pventa"]);
                            resul.pmayoreo = Convert.ToDecimal(rdr["pmayoreo"]);
                            resul.existen = Convert.ToInt32(rdr["existencia"]);
                            resul.minexisten = Convert.ToInt32(rdr["minexisten"]);
                            resul.fvenci = Convert.ToString(rdr["fvenci"]);
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

        public ResponseProductos eliminarProducto(ENProductos paramss)
        {
            try
            {
                string idproductos = paramss.datos;
                String[] strlist = idproductos.Split('|');
                var count = strlist.Count() - 1;

                string cs = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
                var lista = new List<ResponseProductos>();

                using (SqlConnection conn = new SqlConnection(cs))
                {
                    conn.Open();

                    for (int i = 0; i < count; i++)
                    {
                        SqlCommand cmd = new SqlCommand("usp_eliminarProducto", conn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@idproducto", strlist[i]));

                        using (SqlDataReader rdr = cmd.ExecuteReader())
                        {
                            while (rdr.Read())
                            {
                                var resul = new ResponseProductos();
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

        public ResponseProductos tmoneda(ENProductos paramss)
        {
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
                var lista = new List<ResponseProductos>();

                using (SqlConnection conn = new SqlConnection(cs))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("usp_obtTipoMoneda", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@rucempresa", paramss.rucempresa));


                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            var resul = new ResponseProductos();
                            resul.Moneda = Convert.ToString(rdr["Moneda"]);
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

        public ResponseProductos obtEditarProducto(ENProductos paramss)
        {
            try
            {
                string idproductos = paramss.datos;
                String[] strlist = idproductos.Split('|');
                var count = strlist.Count() - 1;

                string cs = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
                var lista = new List<ResponseProductos>();

                using (SqlConnection conn = new SqlConnection(cs))
                {
                    conn.Open();

                    for (int i = 0; i < count; i++)
                    {
                        SqlCommand cmd = new SqlCommand("usp_obtEditarProducto", conn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@idproducto", strlist[i]));

                        using (SqlDataReader rdr = cmd.ExecuteReader())
                        {
                            while (rdr.Read())
                            {
                                var resul = new ResponseProductos();
                                resul.idproducto = Convert.ToInt32(rdr["idproducto"]);
                                resul.tipo1 = Convert.ToInt32(rdr["tipo"]);
                                resul.codbarra = Convert.ToString(rdr["codbarra"]);
                                resul.desc = Convert.ToString(rdr["descripcion"]);
                                resul.sevende = Convert.ToInt32(rdr["sevende"]);
                                resul.pcosto = Convert.ToDecimal(rdr["pcosto"]);
                                resul.ganancia = Convert.ToDecimal(rdr["ganancia"]);
                                resul.pventa = Convert.ToDecimal(rdr["pventa"]);
                                resul.pmayoreo = Convert.ToDecimal(rdr["pmayoreo"]);
                                resul.apartir = Convert.ToInt32(rdr["apartir"]);
                                resul.iddepartamento = Convert.ToInt32(rdr["iddepartamento"]);
                                resul.departamento = Convert.ToString(rdr["departamento"]);
                                resul.existen = Convert.ToInt32(rdr["existencia"]);
                                resul.minexisten = Convert.ToInt32(rdr["minexisten"]);
                                resul.fvenci = Convert.ToString(rdr["fvenci"]);
                                resul.faplica = Convert.ToInt32(rdr["faplica"]);
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

        public ResponseProductos editarProduct(ENProductos paramss)
        {
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
                var lista = new List<ResponseProductos>();

                using (SqlConnection conn = new SqlConnection(cs))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("usp_editarProduct", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@idproducto", paramss.idproducto));
                    cmd.Parameters.Add(new SqlParameter("@rucempresa", paramss.rucempresa));
                    cmd.Parameters.Add(new SqlParameter("@tipo", paramss.tipo));
                    cmd.Parameters.Add(new SqlParameter("@codbarra", paramss.codbarra));
                    cmd.Parameters.Add(new SqlParameter("@desc", paramss.desc));
                    cmd.Parameters.Add(new SqlParameter("@tproduct", paramss.tproduct));
                    if (paramss.pcosto == null)
                    {
                        cmd.Parameters.Add(new SqlParameter("@pcosto", "0"));
                    }
                    else
                    {
                        cmd.Parameters.Add(new SqlParameter("@pcosto", paramss.pcosto));
                    }

                    if (paramss.ganancia == null)
                    {
                        cmd.Parameters.Add(new SqlParameter("@ganancia", "0"));
                    }
                    else
                    {
                        cmd.Parameters.Add(new SqlParameter("@ganancia", paramss.ganancia));
                    }


                    cmd.Parameters.Add(new SqlParameter("@pventa", paramss.pventa));
                    cmd.Parameters.Add(new SqlParameter("@pmayoreo", paramss.pmayoreo));
                    cmd.Parameters.Add(new SqlParameter("@apartir", paramss.apartir));
                    cmd.Parameters.Add(new SqlParameter("@sldepart", paramss.sldepart));
                    cmd.Parameters.Add(new SqlParameter("@existen", paramss.existen));
                    cmd.Parameters.Add(new SqlParameter("@minexisten", paramss.minexisten));
                    if (paramss.fvenci == null)
                    {
                        cmd.Parameters.Add(new SqlParameter("@fvenci", ""));
                    }
                    else
                    {
                        cmd.Parameters.Add(new SqlParameter("@fvenci", paramss.fvenci));
                    }

                    cmd.Parameters.Add(new SqlParameter("@faplica", paramss.faplica));


                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            var resul = new ResponseProductos();
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

        public List<ResponseProductos> obtlistaProducto(ENProductos paramss)
        {
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
                var lista = new List<ResponseProductos>();

                using (SqlConnection conn = new SqlConnection(cs))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("usp_obtlistaProducto", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@letra", paramss.letra));
                    cmd.Parameters.Add(new SqlParameter("@rucempresa", paramss.rucempresa));



                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            var resul = new ResponseProductos();

                            resul.idproducto = Convert.ToInt32(rdr["idproducto"]);
                            resul.desc = Convert.ToString(rdr["descripcion"]);
                            resul.precioventa = Convert.ToString(rdr["precioventa"]);
                            resul.existen = Convert.ToInt32(rdr["existencias"]);

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
        */
    }
}
