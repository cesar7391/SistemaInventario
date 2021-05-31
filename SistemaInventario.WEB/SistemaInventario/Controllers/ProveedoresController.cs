using SistemaInventario.BUSINESS;
using SistemaInventario.ENTITY.Parametros;
using SistemaInventario.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaInventario.Controllers
{
    public class ProveedoresController : Controller
    {
        private BUProveedores buProveedores;
        public ProveedoresController()
        {
            buProveedores = new BUProveedores();
        }

        // GET: Proveedores
        public ActionResult Proveedores()
        {
            var session = Session.GetCurrentUser();

            if (session != null)
            {
                //VERIFICA QUE TENGA ACCESO, SI NO ES SUPERADMIN REGRESA A PANEL
                if (session.proveedor == 1 | session.cargo == "superadmin")
                {
                    return View();
                }
                else
                {
                    return RedirectToAction("Panel", "Panel");
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public ActionResult validarAccesoModulo()
        {
            var session = Session.GetCurrentUser();

            if (session.cargo == "superadmin")
            {
                var respuesta = "ok";
                return Json(new { dt = respuesta });
            }
            else
            {
                if (session.proveedor == 1)
                {
                    var respuesta = "ok";
                    return Json(new { dt = respuesta });
                }
                else
                {
                    var respuesta = "error";
                    return Json(new { dt = respuesta });
                }
            }
        }

        [HttpPost]
        public ActionResult registrarProveedor(ENProveedores paramss)
        {
            var user = Session.GetCurrentUser();
            var token = user.responsetoken;
            paramss.rucempresa = user.ruc;

            var rpt = buProveedores.registrarProveedor(paramss,token);

            return Json(new { dt = rpt });

        }

    }
        
}
