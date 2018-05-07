using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entity;
using System.Data.Entity;

namespace PymesS.A.Controllers
{
    public class ProducMateController : Controller
    {
        private DB_PymesEntities db = new DB_PymesEntities();
        // GET: ProducMate
        //public ActionResult Index()
        //{
        //    //var producto = (from p in db.Producto
        //    //                where p.IdTipoProducto.NombresTipoProducto.StartsWith("A")
        //    //                orderby p.NombreProducto
        //    //                select p);
        //    return View(producto.ToList());
        //}
        public ActionResult ProduMayor()
        {
            var producto = (from p in db.Producto
                            where p.PrecioXUnidad > 99
                            select p);
            return View(producto.ToList());

        }
        public ActionResult ProduCanti()
        {
            

            var producto = from p in db.Producto
                           where p.PrecioXUnidad > 99
                           select new MyProducto
                           {
                               Id = p.IdProducto,
                               Nombre = p.NombreProducto,
                               PrecioUnitario = p.PrecioXUnidad,
                               TotalIngreso = p.EntradaProducto.Sum(o => o.PrecioxUnidad * o.CantidadEntrante)


                           };
            return View(producto.ToList());

        }
        public ActionResult ProducActi()
        {
            var producto = (from p in db.Producto
                            where p.activo == true
                            select p);
            return View(producto.ToList());
        }

    }
}