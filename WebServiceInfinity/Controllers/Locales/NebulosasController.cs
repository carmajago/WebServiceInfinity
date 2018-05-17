using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebServiceInfinity.Models;

namespace WebServiceInfinity.Controllers.Locales
{
    public class NebulosasController : Controller
    {
        private WebServiceInfinityContext db = new WebServiceInfinityContext();

        // GET: Nebulosas
        public ActionResult Index()
        {
            var nebulosas = db.Nebulosas.Include(n => n.viaLactea);
            return View(nebulosas.ToList());
        }

        // GET: Nebulosas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nebulosa nebulosa = db.Nebulosas.Find(id);
            if (nebulosa == null)
            {
                return HttpNotFound();
            }
            return View(nebulosa);
        }

        // GET: Nebulosas/Create
        public ActionResult Create(int id)
        {

            ViewBag.ViaLacteaFK = id;
            return View();
        }

        // POST: Nebulosas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nombre,x,y,z,ViaLacteaFK")] Nebulosa nebulosa)
        {
            if (ModelState.IsValid)
            {
                db.Nebulosas.Add(nebulosa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            
            return View(nebulosa);
        }

        // GET: Nebulosas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nebulosa nebulosa = db.Nebulosas.Find(id);
            if (nebulosa == null)
            {
                return HttpNotFound();
            }
            ViewBag.ViaLacteaFK = new SelectList(db.ViaLacteas, "id", "nombre", nebulosa.ViaLacteaFK);
            return View(nebulosa);
        }

        // POST: Nebulosas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nombre,x,y,z,ViaLacteaFK")] Nebulosa nebulosa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nebulosa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ViaLacteaFK = new SelectList(db.ViaLacteas, "id", "nombre", nebulosa.ViaLacteaFK);
            return View(nebulosa);
        }

        // GET: Nebulosas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nebulosa nebulosa = db.Nebulosas.Find(id);
            if (nebulosa == null)
            {
                return HttpNotFound();
            }
            return View(nebulosa);
        }

        // POST: Nebulosas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Nebulosa nebulosa = db.Nebulosas.Find(id);
            db.Nebulosas.Remove(nebulosa);
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
