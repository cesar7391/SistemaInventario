using Newtonsoft.Json;
using SistemaInventario.CLIENTS;
using SistemaInventario.ENTITY.Parametros;
using SistemaInventario.ENTITY.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaInventario.BUSINESS
{
    public class BUEmpleados
    {
        private Client clients;
        public BUEmpleados()
        {
            clients = new Client();
        }

        public ResponseEmpleados validarCantUsers(ENEmpleados paramss, string token)
        {
            try
            {
                return JsonConvert.DeserializeObject<ResponseEmpleados>(clients.Post<ENEmpleados>("Empleados/validarCantUsers", paramss, token));
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public ResponseEmpleados registrarUsuario(ENEmpleados paramss, string token)
        {
            try
            {
                return JsonConvert.DeserializeObject<ResponseEmpleados>(clients.Post<ENEmpleados>("Empleados/registarUsuario", paramss, token));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<ResponseEmpleados> listaEmpleados(ENEmpleados paramss, string token)
        {
            try
            {
                return JsonConvert.DeserializeObject<List<ResponseEmpleados>>(clients.Post<ENEmpleados>("Empleados/listaEmpleados", paramss, token));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public ResponseEmpleados activarEmpleado(ENEmpleados paramss, string token)
        {
            try
            {
                return JsonConvert.DeserializeObject<ResponseEmpleados>(clients.Post<ENEmpleados>("Empleados/activarEmpleado", paramss, token));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        //SE VA PARA LA API 
        public ResponseEmpleados desactivarEmpleado(ENEmpleados paramss, string token)
        {
            try
            {
                return JsonConvert.DeserializeObject<ResponseEmpleados>(clients.Post<ENEmpleados>("Empleados/desactivarEmpleado", paramss, token));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public ResponseEmpleados eliminarEmpleado(ENEmpleados paramss, string token)
        {
            try
            {
                return JsonConvert.DeserializeObject<ResponseEmpleados>(clients.Post<ENEmpleados>("Empleados/eliminarEmpleado", paramss, token));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        
        public List<ResponseEmpleados> listaCargos(ENEmpleados paramss, string token)
        {
            try
            {
                return JsonConvert.DeserializeObject<List<ResponseEmpleados>>(clients.Post<ENEmpleados>("Empleados/listaCargos", paramss, token));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        
        public ResponseEmpleados obteditarEmpleado(ENEmpleados paramss, string token)
        {
            try
            {
                return JsonConvert.DeserializeObject<ResponseEmpleados>(clients.Post<ENEmpleados>("Empleados/obteditarEmpleado", paramss, token));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public ResponseEmpleados editarEmpleado(ENEmpleados paramss, string token)
        {
            try
            {
                return JsonConvert.DeserializeObject<ResponseEmpleados>(clients.Post<ENEmpleados>("Empleados/editarEmpleado", paramss, token));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
