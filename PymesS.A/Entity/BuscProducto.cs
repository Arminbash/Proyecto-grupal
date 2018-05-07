using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class BuscProducto
    {
        public List<Producto> Buscar(string nombre)
        {
            using (var context = new DB_PymesEntities())
            {
                context.Configuration.LazyLoadingEnabled = false;
                context.Configuration.ProxyCreationEnabled = false;

                var productos = context.Producto.OrderBy(x => x.NombreProducto)
                                        .Where(x => x.NombreProducto.Contains(nombre))
                                        .Take(10)
                                        .ToList();

                return productos;
            }
        }
    }
}
