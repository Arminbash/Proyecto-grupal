using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Entity;
using PymesS.A.VewModel;
using PymesS.A.ViewModel;

namespace PymesS.A.Controllers
{
    public class VentasController : Controller
    {
        private DB_PymesEntities db = new DB_PymesEntities();

        // GET: Ventas
        public async Task<ActionResult> Index()
        {
            var venta = db.Venta.Include(v => v.Persona).Include(v => v.Usuario);
            return View(await venta.ToListAsync());
        }

        // GET: Ventas/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Venta venta = await db.Venta.FindAsync(id);
            if (venta == null)
            {
                return HttpNotFound();
            }
            return View(venta);
        }

        // GET: Ventas/Create
        public ActionResult Create()
        {
            ViewBag.Inventario = new SelectList(db.Inventario, "IdInventario", "IdProducto");
            ViewBag.IdPersona = new SelectList(db.Persona, "IdPersona", "Nombre");
            ViewBag.IdUsuario = new SelectList(db.Usuario, "IdUsuario", "NombresUsuario");

            ViewBag.CantProductos = db.Inventario.Count();
            ModelVenta producto = new ModelVenta();
            producto.Inventario = GetInventarios();
            ViewBag.Min = 1;
            return View(producto);
        }
        public List<Inventario> GetInventarios()
        {
            List<Inventario> inventario = new List<Inventario>();
            inventario = db.Inventario.Include(x => x.Producto).Include(x => x.TipoInventario).ToList();
            return inventario;
        }
        // POST: Ventas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdVenta,IdPersona,IdUsuario,Fecha,Total,activo")] Venta venta)
        {
            venta.IdUsuario = 1;
            venta.IdPersona = 2;
            venta.activo = true;
            if (ModelState.IsValid)
            {
                db.Venta.Add(venta);
                db.SaveChanges();
                int detalleTotal = Convert.ToInt32(Request.Form["detalleTotal"]);
                if (detalleTotal > 1)
                {   // se le resta uno porque si es mayor que uno siempre tiene uno de mas
                    detalleTotal--;
                }
                int ultimo = db.Venta.Max(p => p.IdVenta);

                for (int i = 1; i <= detalleTotal; i++)
                {
                    DetalleVenta detalleVenta = new DetalleVenta();

                    detalleVenta.IdVenta = ultimo;


                    if (string.Compare(Request.Form["detalleTipo" + i], "Producto") == 0)
                    {
                        detalleVenta.IdInventario = Convert.ToInt32(Request.Form["detalleId" + i]);
                        detalleVenta.CantidaPedita = Convert.ToInt32(Request.Form["detalleCantidad" + i]); ;
                    }

                    db.DetalleVenta.Add(detalleVenta);
                    db.SaveChanges();
                    }
                return RedirectToAction("Index");
            }

            ViewBag.IdPersona = new SelectList(db.Persona, "IdPersona", "Nombre", venta.IdPersona);
            ViewBag.IdUsuario = new SelectList(db.Usuario, "IdUsuario", "NombresUsuario", venta.IdUsuario);
            return RedirectToAction("Create");
        }

        // GET: Ventas/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Venta venta = await db.Venta.FindAsync(id);
            if (venta == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdPersona = new SelectList(db.Persona, "IdPersona", "Nombre", venta.IdPersona);
            ViewBag.IdUsuario = new SelectList(db.Usuario, "IdUsuario", "NombresUsuario", venta.IdUsuario);
            return View(venta);
        }

        // POST: Ventas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IdVenta,IdPersona,IdUsuario,Fecha,Total,activo")] Venta venta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(venta).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.IdPersona = new SelectList(db.Persona, "IdPersona", "Nombre", venta.IdPersona);
            ViewBag.IdUsuario = new SelectList(db.Usuario, "IdUsuario", "NombresUsuario", venta.IdUsuario);
            return View(venta);
        }

        // GET: Ventas/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Venta venta = await db.Venta.FindAsync(id);
            if (venta == null)
            {
                return HttpNotFound();
            }
            return View(venta);
        }

        // POST: Ventas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Venta venta = await db.Venta.FindAsync(id);
            db.Venta.Remove(venta);
            await db.SaveChangesAsync();
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
