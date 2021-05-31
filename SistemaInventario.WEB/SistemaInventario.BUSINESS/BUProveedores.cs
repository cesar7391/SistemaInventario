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
    public class BUProveedores
    {
        private Client clients;

        public BUProveedores()
        {
            clients = new Client();
        }

        public ResponseProveedores registrarProveedor(ENProveedores paramss, string token)
        {
            try
            {
                return JsonConvert.DeserializeObject<ResponseProveedores>(clients.Post<ENProveedores>("Proveedores/registrarProveedor", paramss, token));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
