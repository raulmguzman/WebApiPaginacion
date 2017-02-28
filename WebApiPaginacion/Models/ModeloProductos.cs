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

        [ResponseType(typeof(ProductosPaginaResult<PRODUCTOS>))]
        public ProductosPaginaResult<PRODUCTOS> GetProductos(int page, int rows)
        {
            var elementostotales = entidad.PRODUCTOS.Count();
            var paginastotales = (int)Math.Ceiling((double)elementostotales / rows);
            var productos = entidad.PRODUCTOS
                .OrderBy(c => c.PROD_ID)
                .Skip((page) * rows)
                .Take(rows)
                .ToList();

            var result = new ProductosPaginaResult<PRODUCTOS>()
            {
                ElementosPagina = rows,
                ElementosTotales = elementostotales,
                PaginasTotales = paginastotales,
                PaginaActual = page,
                Productos = productos
            };

            return result;
        }
    }
}
