using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiPaginacion.Models
{
    public class ProductosPaginaResult<T> where T : class
    {
        public int CurrentPage { get; set; }

        public int PageSize { get; set; }

        public int TotalRows { get; set; }

        public int TotalPages { get; set; }

        public List<T> Results { get; set; }
    }

}