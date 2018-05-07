using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Entity;

namespace PymesS.A.ViewModel
{
    public class ModelVenta
    {
        public Venta Venta { get; set; }
        public IEnumerable<Inventario> Inventario { get; set; }
    }
}