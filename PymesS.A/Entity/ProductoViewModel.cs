using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class ProductoViewModel
    {
        public int IdProducto { get; set; }
        public string NombreProducto { get; set; }
        public decimal PrecioXUnidad { get; set; }
        public string Descripcion { get; set; }
        public bool activo { get; set; }
        public string NombresTipoProducto { get; set; }

        public TipoProducto TipoProducto { get; set; }
        public Producto Producto { get; set; }
    }
}
