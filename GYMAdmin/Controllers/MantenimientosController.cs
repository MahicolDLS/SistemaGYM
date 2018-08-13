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
    public class MantenimientosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Mantenimientos
        public ActionResult Index()
        {
            var mantenimientoes = db.Mantenimientoes.Include(m => m.Maquina).Include(m => m.Usuario);
            return View(mantenimientoes.ToList());
        }

        // GET: Mantenimientos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mantenimiento mantenimiento = db.Mantenimientoes.Find(id);
            if (mantenimiento == null)
            {
                return HttpNotFound();
            }
            return View(mantenimiento);
        }

        // GET: Mantenimientos/Create
        public ActionResult Create()
        {
            ViewBag.Codigo_Maquina = new SelectList(db.Maquinas, "Codigo_Maquina", "Nombre_Maquina");
            ViewBag.Codigo_Usuario = new SelectList(db.Usuarios, "Codigo_Usuario", "Nombre_Usuario");
            return View();
        }

        // POST: Mantenimientos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Codigo_Mantenimiento,Codigo_Maquina,Descripcion,Costo,Fecha_Mantenimiento,Codigo_Usuario")] Mantenimiento mantenimiento)
        {
            if (ModelState.IsValid)
            {
                db.Mantenimientoes.Add(mantenimiento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Codigo_Maquina = new SelectList(db.Maquinas, "Codigo_Maquina", "Nombre_Maquina", mantenimiento.Codigo_Maquina);
            ViewBag.Codigo_Usuario = new SelectList(db.Usuarios, "Codigo_Usuario", "Nombre_Usuario", mantenimiento.Codigo_Usuario);
            return View(mantenimiento);
        }

        // GET: Mantenimientos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mantenimiento mantenimiento = db.Mantenimientoes.Find(id);
            if (mantenimiento == null)
            {
                return HttpNotFound();
            }
            ViewBag.Codigo_Maquina = new SelectList(db.Maquinas, "Codigo_Maquina", "Nombre_Maquina", mantenimiento.Codigo_Maquina);
            ViewBag.Codigo_Usuario = new SelectList(db.Usuarios, "Codigo_Usuario", "Nombre_Usuario", mantenimiento.Codigo_Usuario);
            return View(mantenimiento);
        }

        // POST: Mantenimientos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Codigo_Mantenimiento,Codigo_Maquina,Descripcion,Costo,Fecha_Mantenimiento,Codigo_Usuario")] Mantenimiento mantenimiento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mantenimiento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Codigo_Maquina = new SelectList(db.Maquinas, "Codigo_Maquina", "Nombre_Maquina", mantenimiento.Codigo_Maquina);
            ViewBag.Codigo_Usuario = new SelectList(db.Usuarios, "Codigo_Usuario", "Nombre_Usuario", mantenimiento.Codigo_Usuario);
            return View(mantenimiento);
        }

        // GET: Mantenimientos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mantenimiento mantenimiento = db.Mantenimientoes.Find(id);
            if (mantenimiento == null)
            {
                return HttpNotFound();
            }
            return View(mantenimiento);
        }

        // POST: Mantenimientos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Mantenimiento mantenimiento = db.Mantenimientoes.Find(id);
            db.Mantenimientoes.Remove(mantenimiento);
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
