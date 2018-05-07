using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Entity;

namespace PymesS.A.Controllers
{
    public class TipoInventarioController : Controller
    {
        private DB_PymesEntities db = new DB_PymesEntities();

        // GET: TipoInventario
        public ActionResult Index()
        {
            return View(db.TipoInventario.ToList());
        }

        // GET: TipoInventario/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoInventario tipoInventario = db.TipoInventario.Find(id);
            if (tipoInventario == null)
            {
                return HttpNotFound();
            }
            return View(tipoInventario);
        }

        // GET: TipoInventario/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoInventario/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdTipoInventario,NombresTipoInventario,activo")] TipoInventario tipoInventario)
        {
            if (ModelState.IsValid)
            {
                db.TipoInventario.Add(tipoInventario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoInventario);
        }

        // GET: TipoInventario/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoInventario tipoInventario = db.TipoInventario.Find(id);
            if (tipoInventario == null)
            {
                return HttpNotFound();
            }
            return View(tipoInventario);
        }

        // POST: TipoInventario/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdTipoInventario,NombresTipoInventario,activo")] TipoInventario tipoInventario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoInventario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoInventario);
        }

        // GET: TipoInventario/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoInventario tipoInventario = db.TipoInventario.Find(id);
            if (tipoInventario == null)
            {
                return HttpNotFound();
            }
            return View(tipoInventario);
        }

        // POST: TipoInventario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoInventario tipoInventario = db.TipoInventario.Find(id);
            db.TipoInventario.Remove(tipoInventario);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult TipoInventarioActi()
        {
            var producto = (from t in db.TipoInventario
                            where t.activo == true
                            select t);
            return View(producto.ToList());
        }
    }
}
