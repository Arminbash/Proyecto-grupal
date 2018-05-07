using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Entity;
using PagedList;

namespace PymesS.A.Controllers
{
    public class PersonasController : Controller
    {
        private DB_PymesEntities db = new DB_PymesEntities();

        // GET: Personas
        public ActionResult Index(string sortOrder, string CurrentSort, int? page)
        {
            
            var persona = db.Persona.Include(p => p.TipoPersona).Include(p => p.Usuario);
            return View(persona.ToList());
        }

        // GET: Personas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Persona persona = db.Persona.Find(id);
            if (persona == null)
            {
                return HttpNotFound();
            }
            return View(persona);
        }

        // GET: Personas/Create
        public ActionResult Create()
        {
            ViewBag.IdTipoPersona = new SelectList(db.TipoPersona, "IdTipoPersona", "NombresTipoPersona");
            ViewBag.IdUsuario = new SelectList(db.Usuario, "IdUsuario", "NombresUsuario");
            return View();
        }

        // POST: Personas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdPersona,Nombre,Apellido,Cedula,Direccion,IdTipoPersona,IdUsuario,activo")] Persona persona)
        {
            if (ModelState.IsValid)
            {
                db.Persona.Add(persona);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdTipoPersona = new SelectList(db.TipoPersona, "IdTipoPersona", "NombresTipoPersona", persona.IdTipoPersona);
            ViewBag.IdUsuario = new SelectList(db.Usuario, "IdUsuario", "NombresUsuario", persona.IdUsuario);
            return View(persona);
        }

        // GET: Personas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Persona persona = db.Persona.Find(id);
            if (persona == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdTipoPersona = new SelectList(db.TipoPersona, "IdTipoPersona", "NombresTipoPersona", persona.IdTipoPersona);
            ViewBag.IdUsuario = new SelectList(db.Usuario, "IdUsuario", "NombresUsuario", persona.IdUsuario);
            return View(persona);
        }

        // POST: Personas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdPersona,Nombre,Apellido,Cedula,Direccion,IdTipoPersona,IdUsuario,activo")] Persona persona)
        {
            if (ModelState.IsValid)
            {
                db.Entry(persona).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdTipoPersona = new SelectList(db.TipoPersona, "IdTipoPersona", "NombresTipoPersona", persona.IdTipoPersona);
            ViewBag.IdUsuario = new SelectList(db.Usuario, "IdUsuario", "NombresUsuario", persona.IdUsuario);
            return View(persona);
        }

        // GET: Personas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Persona persona = db.Persona.Find(id);
            if (persona == null)
            {
                return HttpNotFound();
            }
            return View(persona);
        }

        // POST: Personas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Persona persona = db.Persona.Find(id);
            db.Persona.Remove(persona);
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
    }
}
