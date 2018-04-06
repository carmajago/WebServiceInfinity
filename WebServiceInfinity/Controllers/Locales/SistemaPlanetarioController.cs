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
    public class SistemaPlanetarioController : Controller
    {
        private WebServiceInfinityContext db = new WebServiceInfinityContext();

        // GET: SistemaPlanetario
        public ActionResult Index()
        {
            var sistemaPlanetarios = db.SistemaPlanetarios.Include(s => s.nebulosa);
            return View(sistemaPlanetarios.ToList());
        }

        // GET: SistemaPlanetario/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SistemaPlanetario sistemaPlanetario = db.SistemaPlanetarios.Find(id);
            if (sistemaPlanetario == null)
            {
                return HttpNotFound();
            }
            return View(sistemaPlanetario);
        }

        // GET: SistemaPlanetario/Create
        public ActionResult Create()
        {
            ViewBag.nebulosaFK = new SelectList(db.Nebulosas, "id", "nombre");
            return View();
        }

        // POST: SistemaPlanetario/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nombre,x,y,z,nebulosaFK")] SistemaPlanetario sistemaPlanetario)
        {
            if (ModelState.IsValid)
            {
                db.SistemaPlanetarios.Add(sistemaPlanetario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.nebulosaFK = new SelectList(db.Nebulosas, "id", "nombre", sistemaPlanetario.nebulosaFK);
            return View(sistemaPlanetario);
        }

        // GET: SistemaPlanetario/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SistemaPlanetario sistemaPlanetario = db.SistemaPlanetarios.Find(id);
            if (sistemaPlanetario == null)
            {
                return HttpNotFound();
            }
            ViewBag.nebulosaFK = new SelectList(db.Nebulosas, "id", "nombre", sistemaPlanetario.nebulosaFK);
            return View(sistemaPlanetario);
        }

        // POST: SistemaPlanetario/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nombre,x,y,z,nebulosaFK")] SistemaPlanetario sistemaPlanetario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sistemaPlanetario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.nebulosaFK = new SelectList(db.Nebulosas, "id", "nombre", sistemaPlanetario.nebulosaFK);
            return View(sistemaPlanetario);
        }

        // GET: SistemaPlanetario/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SistemaPlanetario sistemaPlanetario = db.SistemaPlanetarios.Find(id);
            if (sistemaPlanetario == null)
            {
                return HttpNotFound();
            }
            return View(sistemaPlanetario);
        }

        // POST: SistemaPlanetario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SistemaPlanetario sistemaPlanetario = db.SistemaPlanetarios.Find(id);
            db.SistemaPlanetarios.Remove(sistemaPlanetario);
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
