using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PymesS.A.VewModel
{
    public class ModelProducto
    {
      
        public Producto producto { get; set; }
        public TipoProducto tipoproducto { get; set; }
    }
}