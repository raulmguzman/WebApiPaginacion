using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiPaginacion.Models;

namespace WebApiPaginacion.Controllers
{
    public class ProductosController : ApiController
    {
        ModeloProductos modelo;
        public ProductosController()
        {
            modelo = new ModeloProductos();
        }
        //GET api/productos
        //[HttpGet]
        //public List<PRODUCTOS> Get(int? id)
        //{
        //    return modelo.GetProductos(id);
        //}
        public List<PRODUCTOS> Get()
        {
            return modelo.GetProductos();
        }

        public ProductosPaginaResult<PRODUCTOS> GetProdPaginacion(int page, int rows)
        {
            return modelo.GetProductos(page, rows);
        }
    }
}
