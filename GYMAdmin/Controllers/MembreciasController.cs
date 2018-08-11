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
    public class MembreciasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Membrecias
        public ActionResult Index()
        {
            return View(db.Membrecias.ToList());
        }

        // GET: Membrecias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Membrecia membrecia = db.Membrecias.Find(id);
            if (membrecia == null)
            {
                return HttpNotFound();
            }
            return View(membrecia);
        }

        // GET: Membrecias/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Membrecias/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Codigo,Nombre_Membrecia,Costo")] Membrecia membrecia)
        {
            if (ModelState.IsValid)
            {
                db.Membrecias.Add(membrecia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(membrecia);
        }

        // GET: Membrecias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Membrecia membrecia = db.Membrecias.Find(id);
            if (membrecia == null)
            {
                return HttpNotFound();
            }
            return View(membrecia);
        }

        // POST: Membrecias/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Codigo,Nombre_Membrecia,Costo")] Membrecia membrecia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(membrecia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(membrecia);
        }

        // GET: Membrecias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Membrecia membrecia = db.Membrecias.Find(id);
            if (membrecia == null)
            {
                return HttpNotFound();
            }
            return View(membrecia);
        }

        // POST: Membrecias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Membrecia membrecia = db.Membrecias.Find(id);
            db.Membrecias.Remove(membrecia);
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
