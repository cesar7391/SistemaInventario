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
    public class DADepartamentos
    {
        public ResponseDepartamentos guardarDepartamento(ENDepartamentos paramss)
        {
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
                var lista = new List<ResponseDepartamentos>();

                using (SqlConnection conn = new SqlConnection(cs))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("usp_guardarDepartamento", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@departamento", paramss.departamento));
                    cmd.Parameters.Add(new SqlParameter("@rucempresa", paramss.rucempresa));

                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            var resul = new ResponseDepartamentos();
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

        public List<ResponseDepartamentos> listarDepartamentos(ENDepartamentos paramss)
        {
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
                var lista = new List<ResponseDepartamentos>();

                using (SqlConnection conn = new SqlConnection(cs))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("usp_listadepartamentos", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@rucempresa", paramss.rucempresa));

                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            var resul = new ResponseDepartamentos();
                            resul.row = Convert.ToInt32(rdr["Row"]);
                            resul.iddepart = Convert.ToInt32(rdr["iddepartamento"]);
                            resul.depart = Convert.ToString(rdr["departamento"]);
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

        public ResponseDepartamentos eliminarDepartamento(ENDepartamentos paramss)
        {
            try
            {
                string iddepartamento = paramss.datos;
                String[] strlist = iddepartamento.Split('|');
                var count = strlist.Count() - 1;

                string cs = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
                var lista = new List<ResponseDepartamentos>();

                using (SqlConnection conn = new SqlConnection(cs))
                {
                    conn.Open();

                    for (int i = 0; i < count; i++)
                    {
                        SqlCommand cmd = new SqlCommand("usp_bajaDepartamento", conn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@iddepartamento", strlist[i]));

                        using (SqlDataReader rdr = cmd.ExecuteReader())
                        {
                            while (rdr.Read())
                            {
                                var resul = new ResponseDepartamentos();
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

        public ResponseDepartamentos obtEditarDepartamento(ENDepartamentos paramss)
        {
            try
            {
                string iddepartamento = paramss.datos;
                String[] strlist = iddepartamento.Split('|');
                var count = strlist.Count() - 1;

                string cs = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
                var lista = new List<ResponseDepartamentos>();

                using (SqlConnection conn = new SqlConnection(cs))
                {
                    conn.Open();

                    for (int i = 0; i < count; i++)
                    {
                        SqlCommand cmd = new SqlCommand("usp_obtEditarDepartamento", conn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@iddepartamento", strlist[i]));

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
                }
                return lista.FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ResponseDepartamentos editarDepartamento(ENDepartamentos paramss)
        {
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
                var lista = new List<ResponseDepartamentos>();

                using (SqlConnection conn = new SqlConnection(cs))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("usp_editarDepartamento", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@iddepartamento", paramss.iddepartamento));
                    cmd.Parameters.Add(new SqlParameter("@departamento", paramss.departamento));
                    cmd.Parameters.Add(new SqlParameter("@rucempresa", paramss.rucempresa));

                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            var resul = new ResponseDepartamentos();
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
