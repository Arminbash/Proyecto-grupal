using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PymesS.A.Entity
{
   public  class BuscarProducto
    {
        public int IdProducto { get; set; }
        public int IdTipoProducto { get; set; }
        public string NombreProducto { get; set; }
        public decimal PrecioXUnidad { get; set; }
        public string Descripcion { get; set; }
        public bool activo { get; set; }
    }
}
