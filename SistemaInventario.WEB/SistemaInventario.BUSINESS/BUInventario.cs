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
    public class BUInventario
    {
        private Client clients;

        public BUInventario()
        {
            clients = new Client();
        }

        public ResponseInventario agregarInventario(ENInventario paramss, string token)
        {
            try
            {
                return JsonConvert.DeserializeObject<ResponseInventario>(clients.Post<ENInventario>("Inventarios/agregarInventario", paramss, token));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
