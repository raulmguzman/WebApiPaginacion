using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiPaginacion.Models
{
    public class ProductosPaginaResult<T> where T : class
    {
        public int PaginaActual { get; set; }

        public int ElementosPagina { get; set; }

        public int ElementosTotales { get; set; }

        public int PaginasTotales { get; set; }

        public List<T> Productos { get; set; }
    }

}