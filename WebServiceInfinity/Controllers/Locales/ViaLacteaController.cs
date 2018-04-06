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
    public class ViaLacteaController : Controller
    {
        private WebServiceInfinityContext db = new WebServiceInfinityContext();

        // GET: ViaLactea
        public ActionResult Index()
        {
            return View(db.ViaLacteas.ToList());
        }

        // GET: ViaLactea/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViaLactea viaLactea = db.ViaLacteas.Find(id);
            if (viaLactea == null)
            {
                return HttpNotFound();
            }
            return View(viaLactea);
        }

        // GET: ViaLactea/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ViaLactea/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id")] ViaLactea viaLactea)
        {
            if (ModelState.IsValid)
            {
                db.ViaLacteas.Add(viaLactea);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(viaLactea);
        }

        // GET: ViaLactea/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViaLactea viaLactea = db.ViaLacteas.Find(id);
            if (viaLactea == null)
            {
                return HttpNotFound();
            }
            return View(viaLactea);
        }

        // POST: ViaLactea/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id")] ViaLactea viaLactea)
        {
            if (ModelState.IsValid)
            {
                db.Entry(viaLactea).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(viaLactea);
        }

        // GET: ViaLactea/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViaLactea viaLactea = db.ViaLacteas.Find(id);
            if (viaLactea == null)
            {
                return HttpNotFound();
            }
            return View(viaLactea);
        }

        // POST: ViaLactea/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ViaLactea viaLactea = db.ViaLacteas.Find(id);
            db.ViaLacteas.Remove(viaLactea);
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
