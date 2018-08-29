using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GYMAdmin.Models;

namespace GYMAdmin.Controllers
{
    public class RecargosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Recargos
        public ActionResult Index()
        {
            return View(db.Recargos.ToList());
        }

        // GET: Recargos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recargo recargo = db.Recargos.Find(id);
            if (recargo == null)
            {
                return HttpNotFound();
            }
            return View(recargo);
        }

        // GET: Recargos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Recargos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Codigo_Recargo,Nombre,Descripcion,Porcentaje")] Recargo recargo)
        {
            if (ModelState.IsValid)
            {
                db.Recargos.Add(recargo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(recargo);
        }

        // GET: Recargos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recargo recargo = db.Recargos.Find(id);
            if (recargo == null)
            {
                return HttpNotFound();
            }
            return View(recargo);
        }

        // POST: Recargos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Codigo_Recargo,Nombre,Descripcion,Porcentaje")] Recargo recargo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(recargo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(recargo);
        }

        // GET: Recargos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recargo recargo = db.Recargos.Find(id);
            if (recargo == null)
            {
                return HttpNotFound();
            }
            return View(recargo);
        }

        // POST: Recargos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Recargo recargo = db.Recargos.Find(id);
            db.Recargos.Remove(recargo);
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
