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
    public class BUPais
    {
        private Client client;

        public BUPais()
        {
            client = new Client();
        }

        public List<ResponsePais> listarPaises(ENRegistroEmpresa paramss, string token)
        {
            try
            {
                return JsonConvert.DeserializeObject<List<ResponsePais>>(client.Post<ENRegistroEmpresa>("RegistroEmpresa/listarPaises",paramss,token));
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public List<ResponseMoneda> listarMoneda(ENRegistroEmpresa paramss, string token)
        {
            try
            {
                return JsonConvert.DeserializeObject<List<ResponseMoneda>>(client.Post<ENRegistroEmpresa>("RegistroEmpresa/listarMoneda", paramss, token));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ResponseTImpuesto> listarTImpuesto(ENRegistroEmpresa paramss, string token)
        {
            try
            {
                return JsonConvert.DeserializeObject<List<ResponseTImpuesto>>(client.Post<ENRegistroEmpresa>("RegistroEmpresa/listarTImpuesto", paramss, token));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ResponsePImpuesto> listarPImpuesto(ENRegistroEmpresa paramss, string token)
        {
            try
            {
                return JsonConvert.DeserializeObject<List<ResponsePImpuesto>>(client.Post<ENRegistroEmpresa>("RegistroEmpresa/listarPImpuesto", paramss, token));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
