using SistemaInventario.BUSINESS;
using SistemaInventario.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaInventario.Controllers
{
    public class ActivarCuentaController : Controller
    {
        private modelList model;
        private BURegistroEmpresa buRegistroEmpresa;

        public ActivarCuentaController()
        {
            model = new modelList();
            buRegistroEmpresa = new BURegistroEmpresa();
        }

        public ActionResult ActivarCuenta(string ruc)
        {
            string token = "";
            model.msjActivarCuenta = buRegistroEmpresa.activarCuenta(ruc, token);
            return View(model);
        }

    }
}
