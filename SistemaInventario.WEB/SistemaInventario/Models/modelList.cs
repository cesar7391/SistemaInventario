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

        //********************************* DEPARTAMENTOS
        public List<ResponseDepartamentos> listaDepartamentos { get; set; }

        //********************************* PRODUCTOS
        public List<ResponseProductos> listaProductos { get; set; }

        //********************************* BUSCAR PRODUCTOS
        public List<ResponseProductos> listaBuscarP { get; set; }

        //********************************* BUSCAR PRODUCTOS POR DEPARTAMENTO
        public List<ResponseProductos> listaBuscarPD { get; set; }

        public ResponseProductos tipomoneda { get; set; }

        //********************************* PROMOCIONES
        public List<ResponsePromociones> listaPromociones { get; set; }
    }
}