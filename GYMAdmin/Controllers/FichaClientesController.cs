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
    public class FichaClientesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: FichaClientes
        public ActionResult Index()
        {
            var fichaClientes = db.FichaClientes.Include(f => f.Alimentacion).Include(f => f.Cliente).Include(f => f.Membrecia);
            return View(fichaClientes.ToList());
        }

        // GET: FichaClientes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FichaCliente fichaCliente = db.FichaClientes.Find(id);
            if (fichaCliente == null)
            {
                return HttpNotFound();
            }
            return View(fichaCliente);
        }

        // GET: FichaClientes/Create
        public ActionResult Create()
        {
            ViewBag.Codigo_Alimentacion = new SelectList(db.Alimentaciones, "Codigo_Alimentacion", "Nombre");
            ViewBag.Codigo_Cliente = new SelectList(db.Clientes, "Codigo", "Nombre_Cliente");
            ViewBag.Codigo_Membrecia = new SelectList(db.Membrecias, "Codigo", "Nombre_Membrecia");
            return View();
        }

        // POST: FichaClientes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Codigo,Fecha_Pago,Vencimiento_Pago,Fecha_Ingreso,Codigo_Cliente,Enfermedades,Tipo_Asistencia,Objetivos,Codigo_Alimentacion,Codigo_Membrecia")] FichaCliente fichaCliente)
        {
            if (ModelState.IsValid)
            {
                db.FichaClientes.Add(fichaCliente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Codigo_Alimentacion = new SelectList(db.Alimentaciones, "Codigo_Alimentacion", "Nombre", fichaCliente.Codigo_Alimentacion);
            ViewBag.Codigo_Cliente = new SelectList(db.Clientes, "Codigo", "Nombre_Cliente", fichaCliente.Codigo_Cliente);
            ViewBag.Codigo_Membrecia = new SelectList(db.Membrecias, "Codigo", "Nombre_Membrecia", fichaCliente.Codigo_Membrecia);
            return View(fichaCliente);
        }

        // GET: FichaClientes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FichaCliente fichaCliente = db.FichaClientes.Find(id);
            if (fichaCliente == null)
            {
                return HttpNotFound();
            }
            ViewBag.Codigo_Alimentacion = new SelectList(db.Alimentaciones, "Codigo_Alimentacion", "Nombre", fichaCliente.Codigo_Alimentacion);
            ViewBag.Codigo_Cliente = new SelectList(db.Clientes, "Codigo", "Nombre_Cliente", fichaCliente.Codigo_Cliente);
            ViewBag.Codigo_Membrecia = new SelectList(db.Membrecias, "Codigo", "Nombre_Membrecia", fichaCliente.Codigo_Membrecia);
            return View(fichaCliente);
        }

        // POST: FichaClientes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Codigo,Fecha_Pago,Vencimiento_Pago,Fecha_Ingreso,Codigo_Cliente,Enfermedades,Tipo_Asistencia,Objetivos,Codigo_Alimentacion,Codigo_Membrecia")] FichaCliente fichaCliente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fichaCliente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Codigo_Alimentacion = new SelectList(db.Alimentaciones, "Codigo_Alimentacion", "Nombre", fichaCliente.Codigo_Alimentacion);
            ViewBag.Codigo_Cliente = new SelectList(db.Clientes, "Codigo", "Nombre_Cliente", fichaCliente.Codigo_Cliente);
            ViewBag.Codigo_Membrecia = new SelectList(db.Membrecias, "Codigo", "Nombre_Membrecia", fichaCliente.Codigo_Membrecia);
            return View(fichaCliente);
        }

        // GET: FichaClientes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FichaCliente fichaCliente = db.FichaClientes.Find(id);
            if (fichaCliente == null)
            {
                return HttpNotFound();
            }
            return View(fichaCliente);
        }

        // POST: FichaClientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FichaCliente fichaCliente = db.FichaClientes.Find(id);
            db.FichaClientes.Remove(fichaCliente);
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
