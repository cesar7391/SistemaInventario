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
    public class BULogin
    {
        private Client clients;

        public BULogin()
        {
            clients = new Client();
        }

        public ResponseLogin Acceder(ENLogin paramss)
        {
            try
            {
                return JsonConvert.DeserializeObject<ResponseLogin>(clients.Post<ENLogin>("Login/Acceder", paramss));
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
