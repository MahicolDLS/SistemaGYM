﻿using System;
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
    public class AlimentacionesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Alimentaciones
        public ActionResult Index()
        {
            return View(db.Alimentaciones.ToList());
        }

        // GET: Alimentaciones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Alimentacion alimentacion = db.Alimentaciones.Find(id);
            if (alimentacion == null)
            {
                return HttpNotFound();
            }
            return View(alimentacion);
        }

        // GET: Alimentaciones/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Alimentaciones/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Codigo_Alimentacion,Nombre,Descripcion")] Alimentacion alimentacion)
        {
            if (ModelState.IsValid)
            {
                db.Alimentaciones.Add(alimentacion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(alimentacion);
        }

        // GET: Alimentaciones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Alimentacion alimentacion = db.Alimentaciones.Find(id);
            if (alimentacion == null)
            {
                return HttpNotFound();
            }
            return View(alimentacion);
        }

        // POST: Alimentaciones/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Codigo_Alimentacion,Nombre,Descripcion")] Alimentacion alimentacion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(alimentacion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(alimentacion);
        }

        // GET: Alimentaciones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Alimentacion alimentacion = db.Alimentaciones.Find(id);
            if (alimentacion == null)
            {
                return HttpNotFound();
            }
            return View(alimentacion);
        }

        // POST: Alimentaciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Alimentacion alimentacion = db.Alimentaciones.Find(id);
            db.Alimentaciones.Remove(alimentacion);
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
