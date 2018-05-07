using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entity;
using System.Data.SqlClient;

namespace PymesS.A.Controllers
{
    public class HomeController : Controller
    {
        private DB_PymesEntities db = new DB_PymesEntities();

        public ActionResult Index()
        {
            // LISTA EL PROCEDIENTO ALAMACENADP sp_persona_por_cedula
            
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Producto()
        {
            
            
            return Json(db.Producto.ToList(), JsonRequestBehavior.AllowGet);
        }
    }
}