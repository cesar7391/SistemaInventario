using SistemaInventario.ENTITY.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaInventario.Models
{
    public class modelList
    {
        public List<ResponsePais> listPais { get; set; }
        public List<ResponseMoneda> listMoneda { get; set; }
        public List<ResponseTImpuesto> listTImpuesto { get; set; }
        public List<ResponsePImpuesto> listPImpuesto { get; set; }
        public ResponseRegistroEmpresa msjActivarCuenta { get; set; }

        //********************************* EMPLEADOS

        public List<ResponseEmpleados> listaEmpleados { get; set; }
        public List<ResponseEmpleados> listaCargos { get; set; }

        //********************************* PROVEEDORES

        public List<ResponseProveedores> listaProveedores { get; set; }
    }
}