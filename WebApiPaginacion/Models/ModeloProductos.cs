using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Description;

namespace WebApiPaginacion.Models
{
    class ModeloProductos
    {
        EntityProductos entidad;
        public ModeloProductos()
        {
            entidad = new EntityProductos();
        }

        public List<PRODUCTOS> GetProductos()
        {
            var productos = (from datos in entidad.PRODUCTOS
                             select datos);

            return productos.ToList();
        }

        //public int GetNumeroProductos()
        //{
        //    return entidad.PRODUCTOS.Count();
        //}

        //public List<PRODUCTOS> GetProductos(int? id)
        //{
        //    var productos = (from datos in entidad.PRODUCTOS
        //                     select datos)
        //    .OrderBy(z => z.PROD_ID)
        //    .Skip(id.GetValueOrDefault())
        //    .Take(5)
        //    .ToList();
        //    return productos;
        //}


        [ResponseType(typeof(ProductosPaginaResult<PRODUCTOS>))]
        public ProductosPaginaResult<PRODUCTOS> GetProductos(int page, int rows)
        {
            var totalRows = entidad.PRODUCTOS.Count();
            var totalPages = (int)Math.Ceiling((double)totalRows / rows);
            var results = entidad.PRODUCTOS
                .OrderBy(c => c.PROD_ID)
                .Skip((page) * rows)
                .Take(rows)
                .ToList();

            var result = new ProductosPaginaResult<PRODUCTOS>()
            {
                PageSize = rows,
                TotalRows = totalRows,
                TotalPages = totalPages,
                CurrentPage = page,
                Results = results
            };

            return result;
        }
    }
}
