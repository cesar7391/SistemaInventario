using SistemaInventario.BUSINESS;
using SistemaInventario.ENTITY.Parametros;
using SistemaInventario.ENTITY.Response;
using SistemaInventario.Helpers;
using SistemaInventario.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaInventario.Controllers
{
    public class PromocionesController : Controller
    {
        private BUPromociones buPromociones;
        private modelList model;

        public PromocionesController()
        {
            buPromociones = new BUPromociones();
            model = new modelList();
        }

        // GET: Promociones
        public ActionResult Promociones()
        {
            var session = Session.GetCurrentUser();

            if (session != null)
            {
                /* Si tienes acceso a productos tambien lo tienes a departamentos */
                if (session.productos == 1 | session.cargo == "superadmin")
                {
                    ENPromociones paramss = new ENPromociones();
                    paramss.rucempresa = session.ruc;
                    var token = session.responsetoken;

                    model.listaPromociones = buPromociones.listaPromociones(paramss, token);


                    return View(model);
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
        public ActionResult guardarPromocion(ENPromociones paramss)
        {
            var session = Session.GetCurrentUser();
            var token = session.responsetoken;
            paramss.rucempresa = session.ruc;


            var rpt = buPromociones.guardarPromocion(paramss, token);
            return Json(new { dt = rpt });
        }

        [HttpPost]
        public ActionResult eliminarPromociones(ENPromociones paramss)
        {
            var session = Session.GetCurrentUser();
            var token = session.responsetoken;
            paramss.rucempresa = session.ruc;


            var rpt = buPromociones.eliminarPromociones(paramss, token);
            return Json(new { dt = rpt });
        }

        [HttpPost]
        public ActionResult obtEditarPromo(ENPromociones paramss)
        {
            var session = Session.GetCurrentUser();
            var token = session.responsetoken;
            paramss.rucempresa = session.ruc;

            ResponsePromociones rpt = new ResponsePromociones();

            string idpromo = paramss.datos;
            String[] strlist = idpromo.Split('|');
            var count = strlist.Count() - 1;

            if (count == 1)
            {
                rpt = buPromociones.obtEditarPromo(paramss, token);
                return Json(new { dt = rpt });
            }
            else
            {
                rpt.response = "Error";
                return Json(new { dt = rpt });
            }
        }


        [HttpPost]
        public ActionResult editarPromocion(ENPromociones paramss)
        {
            var session = Session.GetCurrentUser();
            var token = session.responsetoken;
            paramss.rucempresa = session.ruc;


            var rpt = buPromociones.editarPromocion(paramss, token);
            return Json(new { dt = rpt });
        }
    }
}